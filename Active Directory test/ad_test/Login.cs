using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using ADLoginLibrary;

namespace ad_test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var domainname = Environment.UserDomainName;

            var username = textBox1.Text;
            var password = textBox2.Text;

            var output = new StringBuilder();

            var login = new AdLogin(username, password);

            if (login.TryLogin())
            {
                var windowsUser = login.GetWindowsUser();
                output.AppendLine("Name: " + windowsUser.Name);
                output.AppendLine("IsAdmin: " + windowsUser.IsAdmin);
                output.AppendLine("Groups: ");
                foreach (var group in windowsUser.GroupsList)
                {
                    output.Append(group.Value + ", ");
                }
            }

            /*
            output.AppendLine("domain: " + domainname);
            var token = IntPtr.Zero;
            var tokenDuplicate = IntPtr.Zero;

            const int securityImpersonation = 2;

            var validLogin = SafeNativeMethods.LogonUser(username, domainname, password, 2, 0, ref token);

            if (validLogin)
            {
                output.AppendLine("Login successfully!");

                if (SafeNativeMethods.DuplicateToken(token, securityImpersonation, ref tokenDuplicate) != 0)
                {
                    var mImpersonatedUser = new WindowsIdentity(tokenDuplicate);

                    using (mImpersonatedUser.Impersonate())
                    {
                        var windowsIdentity = WindowsIdentity.GetCurrent(TokenAccessLevels.MaximumAllowed);
                        if (windowsIdentity != null)
                        {
                            var name = windowsIdentity.Name;

                            if (windowsIdentity.User != null)
                            {
                                var isAdmin = IsAdministratorByToken(mImpersonatedUser);
                                output.AppendLine("Is " + name + " admin : " + isAdmin.ToString());
                            }
                        }
                    }
                }

                SafeNativeMethods.CloseHandle(token);
                SafeNativeMethods.CloseHandle(tokenDuplicate);
            }
            else
            {
                output.AppendLine("Can not login the user");
            }
            */
            MessageBox.Show(output.ToString());
        
        }

        private static bool IsAdministratorByToken(WindowsIdentity identity)
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
