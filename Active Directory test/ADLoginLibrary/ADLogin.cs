using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ADLoginLibrary
{
    public class AdLogin
    {
        const int SecurityImpersonation = 2;

        private readonly string _adUsername;
        private readonly string _adPassword;
        private readonly string _adDomainname;

        private IntPtr _token;
        private IntPtr _tokenDuplicate;
    
        public AdLogin(string adUsername, string adPassword)
        {
            _adUsername = adUsername;
            _adPassword = adPassword;
            _adDomainname = Environment.UserDomainName;

            _token = IntPtr.Zero;
            _tokenDuplicate = IntPtr.Zero;
        }

        /// <summary>
        /// Tries to login the user
        /// </summary>
        /// <returns>true if login was successfully</returns>
        public bool TryLogin()
        {
            return SafeNativeMethods.LogonUser(_adUsername, _adDomainname, _adPassword, 2, 0, ref _token);
        }

        /// <summary>
        /// Gets the windows user object
        /// </summary>
        /// <returns>The WindowsUser object</returns>
        public WindowsUser GetWindowsUser()
        {
            WindowsUser winUser = null;

            if (SafeNativeMethods.DuplicateToken(_token, SecurityImpersonation, ref _tokenDuplicate) != 0)
            {
                var mImpersonatedUser = new WindowsIdentity(_tokenDuplicate);

                using (mImpersonatedUser.Impersonate())
                {
                    var windowsIdentity = WindowsIdentity.GetCurrent(TokenAccessLevels.MaximumAllowed);

                    if (windowsIdentity != null)
                    {
                        if (windowsIdentity.User != null)
                        {
                            var name = windowsIdentity.Name;
                            var isAdmin = IsAdministratorByToken(mImpersonatedUser);
                            var groups = windowsIdentity.Groups.ToList();

                            winUser = new WindowsUser()
                            {
                                Name = name,
                                IsAdmin = isAdmin,
                                GroupsList = groups
                            };
                        }
                    }
                }
            }

            return winUser;
        }

        /// <summary>
        /// Closes the two tokens
        /// </summary>
        public void CloseHandle()
        {
            SafeNativeMethods.CloseHandle(_token);
            SafeNativeMethods.CloseHandle(_tokenDuplicate);
        }

        private bool IsAdministratorByToken(WindowsIdentity identity)
        {
            if (identity == null) throw new InvalidOperationException("Couldn't get the current user identity");
            var principal = new WindowsPrincipal(identity);

            // Check if this user has the Administrator role. If they do, return immediately.
            // If UAC is on, and the process is not elevated, then this will actually return false.
            if (principal.IsInRole(WindowsBuiltInRole.Administrator)) return true;

            // If we're not running in Vista onwards, we don't have to worry about checking for UAC.
            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 6)
            {
                // Operating system does not support UAC; skipping elevation check.
                return false;
            }

            int tokenInfLength = Marshal.SizeOf(typeof(int));
            IntPtr tokenInformation = Marshal.AllocHGlobal(tokenInfLength);

            try
            {
                var token = identity.Token;
                var result = SafeNativeMethods.GetTokenInformation(token, SafeNativeMethods.TokenInformationClass.TokenElevationType, tokenInformation, tokenInfLength, out tokenInfLength);

                if (!result)
                {
                    var exception = Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
                    throw new InvalidOperationException("Couldn't get token information", exception);
                }

                var elevationType = (SafeNativeMethods.TokenElevationType)Marshal.ReadInt32(tokenInformation);

                switch (elevationType)
                {
                    case SafeNativeMethods.TokenElevationType.TokenElevationTypeDefault:
                        // TokenElevationTypeDefault - User is not using a split token, so they cannot elevate.
                        return false;
                    case SafeNativeMethods.TokenElevationType.TokenElevationTypeFull:
                        // TokenElevationTypeFull - User has a split token, and the process is running elevated. Assuming they're an administrator.
                        return true;
                    case SafeNativeMethods.TokenElevationType.TokenElevationTypeLimited:
                        // TokenElevationTypeLimited - User has a split token, but the process is not running elevated. Assuming they're an administrator.
                        return true;
                    default:
                        // Unknown token elevation type.
                        return false;
                }
            }
            finally
            {
                if (tokenInformation != IntPtr.Zero) Marshal.FreeHGlobal(tokenInformation);
            }
        }
    }
}
