using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace MirEditor
{
    public partial class MainForm : Form
    {
        public static void SaveError(string ex)
        {
            try
            {
                if (Settings.RemainingErrorLogs-- > 0)
                {
                    File.AppendAllText(@".\Error.txt",
                                       string.Format("[{0}] {1}{2}", DateTime.Now, ex, Environment.NewLine));
                }
            }
            catch
            {
            }
        }

        public MapForm mapForm = null;
        public DrawForm  drawForm = null;
        public InfoForm infoForm = null;

        public static MainForm s_instance;

        public MainForm()
        {
            s_instance = this;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 装载配置文件

            Settings.Load();

            mapForm = new MapForm();


            infoForm = new InfoForm();
            drawForm = new DrawForm();
            drawForm.CloseButtonVisible = false;

            bool isAutoDock = false;

            if (File.Exists("dock.xml"))
            {
                isAutoDock = true;
                dockPanel.LoadFromXml("dock.xml", dockCallBack);
            }

            mapForm.Show(this.dockPanel);
            drawForm.Show(this.dockPanel);
            infoForm.Show(this.dockPanel);

            if( !isAutoDock )
            {
                mapForm.DockTo(this.dockPanel, DockStyle.Right);
                infoForm.DockTo(this.dockPanel, DockStyle.Right);
            }

            System.Diagnostics.Trace.WriteLine(Libraries.Title);
            
        }

        WeifenLuo.WinFormsUI.Docking.IDockContent dockCallBack(string persistString)
        {
            if (persistString == typeof(DrawForm).ToString())
                return drawForm;
            if (persistString == typeof(InfoForm).ToString())
                return infoForm;

            if (persistString == typeof(MapForm).ToString())
                return mapForm;
            
            {
                return null;
            }
        }

        // 地图切换了
        public void onSelChanged( Point sel) 
        {
            CellInfo info = drawForm.drawPanel.getCellInfo(sel);
            infoForm.setInfo( sel, info );



        }


        private void InISetting_Click(object sender, EventArgs e)
        {
            InIForm ini = new InIForm();
            ini.ShowDialog();
        }

        private void showMapList_Click(object sender, EventArgs e)
        {
            mapForm.Show();
        }

        public void openMap( string filePath )
        {
            drawForm.openMap(filePath);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 重绘
            drawForm.drawPanel.redrawBmp();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 归0
            drawForm.drawPanel.resetPos();
            drawForm.drawPanel.resetScaleDelta();
        }


        private void toolStripButton3_CheckedChanged(object sender, EventArgs e)
        {
            drawForm.drawPanel.setDrawBack(toolStripButton3.Checked);
        }

        private void toolStripButton4_CheckedChanged(object sender, EventArgs e)
        {
            drawForm.drawPanel.setDrawMiddle(toolStripButton4.Checked);
        }

        private void toolStripButton5_CheckedChanged(object sender, EventArgs e)
        {
            drawForm.drawPanel.setDrawFront(toolStripButton5.Checked);
        }

        private void toolStripButton6_CheckedChanged(object sender, EventArgs e)
        {
            drawForm.drawPanel.setDrawGrid(toolStripButton6.Checked);
        }

        private void toolStripButton7_CheckedChanged(object sender, EventArgs e)
        {
            drawForm.drawPanel.setDrawFrontLimit(toolStripButton7.Checked);
        }

        private void toolStripButton8_CheckedChanged(object sender, EventArgs e)
        {

            drawForm.drawPanel.setDrawBackLimit(toolStripButton8.Checked);

        }

        private void toolStripButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dockPanel_DockChanged(object sender, EventArgs e)
        {
            
        }

        private void SaveLayout_Click(object sender, EventArgs e)
        {
            dockPanel.SaveAsXml("dock.xml");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dockPanel.SaveAsXml("dock.xml");
        }



    }
}
