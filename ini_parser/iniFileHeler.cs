using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;

namespace ini_parser
{
    static class IniFileHelper
    {
        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
 
        public static void ParseFromIni<T>(this T self, string section, string filepath)
        {
            foreach(var prop in typeof(T).GetProperties())
            {
                if (prop.PropertyType == typeof(int))
                {
                    prop.SetValue(self, (int)GetPrivateProfileInt(section, prop.Name, 0, Path.GetFullPath(filepath)));
                }
                else if(prop.PropertyType == typeof(uint))
                {
                    prop.SetValue(self, GetPrivateProfileInt(section, prop.Name, 0, Path.GetFullPath(filepath)));
                }
                else
                {
                    var sb = new StringBuilder(1024);
                    GetPrivateProfileString(section, prop.Name, string.Empty, sb, (uint)sb.Capacity, Path.GetFullPath(filepath));
                    prop.SetValue(self, sb.ToString());
                }
            }
        }

        public static void ExportToIni<T>(this T self, string section, string filepath)
        {
            foreach(var prop in typeof(T).GetProperties())
            {
                WritePrivateProfileString(section, prop.Name, prop.GetValue(self).ToString(), Path.GetFullPath(filepath));
            }
        }
    }
}
