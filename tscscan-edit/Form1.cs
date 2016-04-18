using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tscscan_edit
{
    public partial class Form1 : Form
    {
        List<tscscanmap.tscscanmapping> _mapping = new List<tscscanmap.tscscanmapping>();
        
        tscscnFile _tscscnFile = new tscscnFile();
        List<tscscanmap.comment> _comments = new List<tscscanmap.comment>();

        string _filename = "\\windows\\tscscan.txt";

        myChars.charvalues _myChars = new myChars.charvalues();

        public Form1()
        {
            InitializeComponent();
            fillScancodes();
        }

        void fillScancodes()
        {
            foreach (scancode S in scancode.scancodes)
                listBox2.Items.Add(S);
            listBox3.DataSource = _myChars.charlist;
        }

        void loadData(string sFile)
        {
            _tscscnFile.parseFile(sFile, ref _mapping, ref _comments);
            listBox1.DataSource = _mapping;
        }
        void saveData(string sFile)
        {
            //sort lists
            _mapping.Sort(sortByVKey);
            int iLine = 0;
            List<tscscanmap.comment> commentsforline;

            List<string> writeList=new List<string>();

            while (iLine < 256)
            {
                commentsforline = getCommentLines(iLine);
                if (commentsforline.Count > 0)
                    foreach (tscscanmap.comment C in commentsforline)
                        writeList.Add(C._comment);
                tscscanmap.tscscanmapping M = getMapping(iLine);
                if (M != null)
                    writeList.Add(M.getLine());
                else
                    writeList.Add("");
                iLine++;
            }
            string[] Lines = writeList.ToArray();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "tscscan.txt";
            sfd.Filter = "text files(*.txt)|*.txt|all files(*.*)|*.*";
            sfd.FilterIndex = 0;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.TextWriter tw = new System.IO.StreamWriter(sfd.FileName))
                {
                    for (int i = 0; i < Lines.Length; i++)
                        tw.WriteLine(Lines[i]);
                    tw.Flush();
                }
            }
            return;
        }

        tscscanmap.tscscanmapping getMapping(int iKey)
        {
            foreach (tscscanmap.tscscanmapping M in _mapping)
                if (M._vkey == iKey)
                    return M;
            return null;
        }
        List<tscscanmap.comment> getCommentLines(int iLine)
        {
            List<tscscanmap.comment> comments_for_line = new List<tscscanmap.comment>();
            foreach (tscscanmap.comment C in _comments)
                if(C._lineNumber==iLine)
                    comments_for_line.Add(C);
            return comments_for_line;
        }
        static int sortByVKey(tscscanmap.tscscanmapping map1, tscscanmap.tscscanmapping map2)
        {
            if (map1 == null)
            {
                if (map2 == null)
                    return 0; //equal
                else
                    return -1;//map1 is less
            }
            else
            {
                if (map2 == null)
                    return 1;//map1 is greater
                else
                {
                    return map1._vkey.CompareTo(map2._vkey);
                }
            }
        }
        static int sortByVKey(tscscanmap.comment comm1, tscscanmap.comment comm2)
        {
            if (comm1 == null)
            {
                if (comm2 == null)
                    return 0; //equal
                else
                    return -1;//map1 is less
            }
            else
            {
                if (comm2 == null)
                    return 1;//map1 is greater
                else
                {
                    return comm1._lineNumber.CompareTo(comm2._lineNumber);
                }
            }
        }

        private void mnuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(Text files)|*.txt|all files|*.*";
            ofd.FilterIndex = 0;
            ofd.InitialDirectory = "\\windows";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _filename = ofd.FileName;
            }
            label1.Text = _filename;
            loadData(_filename);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            saveData(_filename);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            tscscanmap.tscscanmapping M = (tscscanmap.tscscanmapping)listBox1.SelectedItem;
            //find scancode in listbox2
            for (int i = 0; i < listBox2.Items.Count; i++)
                if (((scancode)listBox2.Items[i])._scancode == M._scancode)
                {
                    listBox2.SelectedIndex = i;
                    break;
                }
            label4.Text = M.getLine();
            byte bChar = M._char;
            listBox3.SelectedIndex = bChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            if (listBox2.SelectedIndex == -1)
                return;
            scancode S = (scancode)listBox2.SelectedItem;
            tscscanmap.tscscanmapping M = (tscscanmap.tscscanmapping)listBox1.SelectedItem;
            
            int oldScancode = M._scancode;
            M._scancode = S._scancode;
            
            int oldChar = M._char;
            M._char = ((myChars.charvalue)listBox3.SelectedItem).bValue;
            //TODO: retrieve new char for scancode

            M._comment = "// "+ ((vkeys.VKEY)M._vkey).ToString() +" mapped from 0x" + oldScancode.ToString("x3") + " to 0x" + M._scancode.ToString("x4");
            M._comment += " char (old): 0x" + oldChar.ToString("x2") + " (new):0x" + M._char.ToString("x2");
            listBox1.SelectedItem = M;
        }
    }
}