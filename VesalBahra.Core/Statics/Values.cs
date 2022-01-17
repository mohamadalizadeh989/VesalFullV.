using Bz.ClassFinder.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VesalBahar.Statics
{   
    public class Values
    {
        public const int PageSize = 12;
        public static List<BzClassInfo> Permissions
        {
            get
            {
                var permission = Bz.ClassFinder.Helper
                    .GetClassAndMethods(Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "Shop.WebUI.dll"))
                    .ToList();
                //permission.Add(_otherBzClassInfo);

                return permission.Where(c => c.Methods.Any()).OrderBy(c => c.FullName).ToList();
            }
        }
        //private static readonly BzClassInfo _otherBzClassInfo = new BzClassInfo() { };
    }
}
