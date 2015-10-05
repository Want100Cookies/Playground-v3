using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ADLoginLibrary
{
    public class WindowsUser
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<IdentityReference> GroupsList { get; set; }

        public WindowsUser()
        {
            GroupsList = new List<IdentityReference>();
        }
    }
}
