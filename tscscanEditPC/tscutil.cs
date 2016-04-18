using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using tscscan_edit;

namespace tscscanEditPC
{
    public class tscutil
    {
        public static string getChar(byte b)
        {
            if (Convert.ToByte(b.ToString(), 10) > 32)
                return Convert.ToChar(b).ToString();
            else
                return "0x" + Convert.ToByte(b.ToString(), 10).ToString("x02");
        }

        public static string getScanCodeStr(int s)
        {
            foreach (scancode c in scancode.scancodes)
            {
                if (c._scancode == s)
                    return c._keyUS;
            }
            return "n/a";
        }
    }
}
