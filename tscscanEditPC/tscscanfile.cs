using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    public class tscscanfile{

        public List<tscscan> tscscanList = new List<tscscan>();
        public tscscanfile(string sFile)
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
                        tscscanList.Add(new tscscan((byte)vkIdx, sLine));
                        iLine++;
                        continue;
                    }
                    string[] s = sLine.Split(new char[] { ' ' });
                    // 0x2a 0x00  // 0x10 - VK_SHIFT (LEFT SHIFT)
                    //vkIdx is VKEY, first is scancode, second is char and rest is comment
                    string sC = "";
                    int p=sLine.IndexOf("//");
                    if(p > 0){
                        sC = sLine.Substring(p);
                    }
                    if (sC.Length>0)
                        tscscanList.Add( new tscscan((byte)vkIdx, Convert.ToByte(s[0], 16), Convert.ToByte(s[1], 16), sC));
                    else
                        tscscanList.Add(new tscscan((byte)vkIdx, Convert.ToByte(s[0], 16), Convert.ToByte(s[1], 16)));
                    vkIdx++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
        }

    }

}
