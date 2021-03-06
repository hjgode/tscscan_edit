﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    class tscscnFile{

        public int parseFile(string sFile, ref List<tscscanmap.tscscanmapping> myList, ref List<tscscanmap.comment> myComments)
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
                        myComments.Add(new tscscanmap.comment(iLine, sLine));
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
                    tscscanmap.tscscanmapping map = new tscscanmap.tscscanmapping((byte)vkIdx, Convert.ToByte(s[0], 16), Convert.ToByte(s[1], 16), sC);
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

}
