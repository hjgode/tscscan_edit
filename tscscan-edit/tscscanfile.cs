using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    public class tscscnFile{

        public int parseFile(string sFile, ref List<tscscanmapping> myList, ref List<comment> myComments)
        {
            int iRet = 0;
            try
            {
                System.IO.TextReader tr = new System.IO.StreamReader(sFile);
                string sLine = "";
                int iLine=0;
                int vkIdx = 0;
                while ((sLine = tr.ReadLine()) != null)
                {
                    //first test for comment line
                    if (sLine.StartsWith("//"))
                    {
                        myComments.Add(new comment(iLine, sLine));
                        iLine++;
                        continue;
                    }
                    string[] s = sLine.Split(new char[] { ' ' });
                    // 0x2a 0x00  // 0x10 - VK_SHIFT (LEFT SHIFT)
                    //vkIdx is VKEY, first is scancode, second is char and rest is comment
                    string sC = "";
                    if (s.Length > 2)
                    {
                        for (int i = 2; i < s.Length; i++)
                            sC += s[i] + " ";
                    }
                    tscscanmapping map = new tscscanmapping((byte)vkIdx, Convert.ToByte(s[0], 16), Convert.ToByte(s[1],16), sC);
                    myList.Add(map);
                    vkIdx++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
            return iRet;
        }

    }

    public class tscscanmapping
    {
        public byte _vkey{get; set;}
        public int _scancode { get; set; }
        public byte _char { get; set; }
        public string _comment { get; set; }
        public List<tscscanmapping> _mapfile=null;

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
                sComment = "// " + ((scancode.VKEY)this._char).ToString();
            }
            else
                sComment = this._comment;
            sScancode = String.Format("0x{0:x4}", this._scancode);
            sChar = String.Format("0x{0:x2}", this._char);

            return sScancode + " " + sChar + " " + sComment;
        }
        public override string ToString()
        {
            return ((scancode.VKEY)_vkey).ToString();
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
