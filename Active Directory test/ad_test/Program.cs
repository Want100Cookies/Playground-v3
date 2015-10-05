using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ad_test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //GetListOfAdUsersByGroup();
            Application.Run(new Login());
            Application.EnableVisualStyles();
        }

        public static void GetListOfAdUsersByGroup()
        {
            using (var context = new PrincipalContext(ContextType.Domain, "CORPAD.DSM-GROUP.com"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    int count = 0;
                    foreach (var result in searcher.FindAll())
                    {
                        count++;

                        var de = result.GetUnderlyingObject() as DirectoryEntry;
                        var accountName = de.Properties["samAccountName"].Value.ToString();

                        UserPrincipal user = UserPrincipal.FindByIdentity(context, accountName);

                        if (user != null)
                        {
                            Console.WriteLine("Name: " + user.Name);
                            Console.Write("Groups: ");

                            var groups = user.GetGroups();
                            foreach (var group in groups)
                            {
                                Console.Write(group + ",");
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();
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
