using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    class tscshiftfile
    {
        public List<tscshift> tscshiftList = new List<tscshift>();
        
        public tscshiftfile(string sFile)
        {
            if (!System.IO.File.Exists(sFile))
                return;
            tscshift _tscshift = new tscshift(0, 0, 0);

            //read and parse the file
            try
            {
                System.IO.TextReader tr = new System.IO.StreamReader(sFile);
                string sLine = "";
                byte inChar = 0;
                byte outIdx = 0;
                byte flag = 0;
                while ((sLine = tr.ReadLine()) != null)
                {
                    //first test for comment line
                    if (sLine.StartsWith("//") || sLine.Length==0)
                    {
                        continue;
                    }
                    string[] s = sLine.Split(new char[] { ' ' });
                    // 0x1B 0x1B 0 => ESC char -> idx=0x1B no Shift flag
                    string sC = "";
                    if (s.Length > 2)
                    {
                        for (int i = 2; i < s.Length; i++)
                            sC += s[i] + " ";
                    }
                    inChar = Convert.ToByte(s[0], 16);
                    outIdx = Convert.ToByte(s[1], 16);
                    flag = Convert.ToByte(s[2], 16);
                    //add tscshift objects to the list
                    tscshiftList.Add(new tscshift(inChar, outIdx, flag));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }

            //get the scancode by looking up the tscscan.txt

        }
    }
}
