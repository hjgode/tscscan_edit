using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    class tscscanmap
    {
        public class tscscanmapping
        {
            public byte _vkey { get; set; }
            public int _scancode { get; set; }
            public byte _char { get; set; }
            public string _comment { get; set; }
            public List<tscscanmapping> _mapfile = null;

            public tscscanmapping()
            {

            }
            public string getLine()
            {
                //0x00 0x00 //comment
                string sScancode = "0x00";
                string sChar = "0x00";
                string sComment = "//";
                if (this._comment.Length == 0)
                {
                    sComment = "// " + ((vkeys.VKEY)this._char).ToString();
                }
                else
                    sComment = this._comment;
                sScancode = String.Format("0x{0:x4}", this._scancode);
                sChar = String.Format("0x{0:x2}", this._char);

                return sScancode + " " + sChar + " " + sComment;
            }
            public override string ToString()
            {
                return ((vkeys.VKEY)_vkey).ToString();
            }
            public tscscanmapping(byte bVKey, int iScancode, byte bChar, string sComment)
            {
                _vkey = bVKey;
                _scancode = iScancode;
                _char = bChar;
                _comment = sComment;
            }

        }
        public class comment
        {
            public int _lineNumber { get; set; }
            public string _comment { get; set; }
            public comment(int iLine, string sComment)
            {
                _lineNumber = iLine;
                _comment = sComment;
            }
        }


    }
}
