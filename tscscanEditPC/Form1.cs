using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tscscan_edit;

namespace tscscanEditPC
{
    public partial class Form1 : Form
    {
        List<tscshift> _tscshiftList = new List<tscshift>();
        List<tscscan> _tscscanList = new List<tscscan>();

        public Form1()
        {
            InitializeComponent();
            tscshiftfile shiftFile = new tscshiftfile(util.getAppPath() + "tscshift.txt");
            _tscshiftList = shiftFile.tscshiftList;            
            dataGridView1.DataSource = _tscshiftList;

            tscscanfile scanFile = new tscscanfile(util.getAppPath() + "tscscan.txt");
            _tscscanList = scanFile.tscscanList;
            dataGridView2.DataSource = _tscscanList;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToByte(e.Value.ToString(), 10) > 32)
                    e.Value = Convert.ToChar(e.Value).ToString();
                else
                    e.Value = "0x"+Convert.ToByte(e.Value.ToString(), 10).ToString("x02");
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = "0x" + Convert.ToByte(e.Value.ToString(), 10).ToString("x02");
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = "0x" + Convert.ToByte(e.Value.ToString(), 10).ToString("x02");
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = "0x" + Convert.ToByte(e.Value.ToString(), 10).ToString("x02") + " ("
                    + tscutil.getScanCodeStr((int)(e.Value)) + ")"; 
                
            }
            else if (e.ColumnIndex == 2)
            {
                e.Value = "0x" + Convert.ToByte(e.Value.ToString(), 10).ToString("x02");
            }

        }
    }
    public class util{
        public static string getAppPath()
        {
            string AppPath;
            AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (!AppPath.EndsWith(@"\"))
                AppPath += @"\";
            Uri uri = new Uri(AppPath);
            AppPath = uri.AbsolutePath;
            System.Diagnostics.Debug.WriteLine("AppPath=" + AppPath);
            return AppPath;
        }
    }
}
