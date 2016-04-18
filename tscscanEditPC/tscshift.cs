using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    class tscshift
    {
        public byte inChar { get; set; }
        public byte outIndex { get; set; }
        public byte flag { get; set; }

        public List<tscshift> tscshiftList = new List<tscshift>();

        public tscshift(byte input, byte output, byte flg)
        {
            inChar = input;
            outIndex = output;
            flag = flg;
        }

        public override string ToString()
        {
            return Convert.ToChar(inChar).ToString() + ", " + outIndex.ToString("02x") + ", " + flag.ToString();
        }
    }
}
