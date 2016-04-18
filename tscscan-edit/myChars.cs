using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    class myChars
    {
        const int char_max = 255;
        public class charvalue
        {
            public byte bValue { get; set; }
            public string sValue { get; set; }
            public charvalue(byte b, string s)
            {
                bValue = b;
                sValue = s;
            }
            public override string ToString()
            {
                return sValue;
            }
        }
        public class charvalues
        {
            public charvalue[] charlist;
            public charvalues()
            {
                charlist = new charvalue[char_max];
                for (byte i = 0; i < 32; i++)
                    charlist[i] = new charvalue(i, "0x" + i.ToString("x2"));
                for (byte i = 32; i < char_max; i++)
                    charlist[i] = new charvalue(i, Convert.ToChar(i).ToString());
            }
        }
    }
}
