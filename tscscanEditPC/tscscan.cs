using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tscscan_edit
{
    public class tscscan
    {
        public byte _idx { get; set; }
        public int _scancode { get; set; }
        public byte _char { get; set; }
        public string _comment { get; set; }

        public tscscan(byte idx, int scn, byte ch, string cmt)
        {
            _idx = idx;
            _scancode = scn;
            _char = ch;
            _comment = cmt;
        }
        public tscscan(byte idx, int scn, byte ch)
        {
            _idx = idx;
            _scancode = scn;
            _char = ch;
            _comment = "";
        }
        public tscscan(byte idx, string cmt)
        {
            _idx = idx;
            _scancode = 0;
            _char = 0;
            _comment = cmt;
        }

        public string getString()
        {
            string s = "";
            s += "0x" +_scancode.ToString("x02");
            if (_scancode==0 && _char==0)
                s = "//" + _comment;

            return s;
        }
    }
}
