using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RefreshAADRefreshTokenCore
{
    [StructLayout(LayoutKind.Sequential)]
    public class PopCookieInfo
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public uint Flags { get; set; }
        public string P3PHeader { get; set; }

        
    }
}
