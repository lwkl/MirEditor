using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MirEditor
{
    public partial class MapForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            string[] maps = Directory.GetFiles(Settings.MapPath, @"*.map", SearchOption.AllDirectories);
            string[] mapnames = new string[maps.Length];
            for(int i=0; i<maps.Length; i ++)
            {
                mapnames[i] = maps[i].Replace( Settings.MapPath, "");
            }
            this.listViewMap.Items.Clear();
            this.listViewMap.BeginUpdate();
            for (int i = 0; i < maps.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = mapnames[i];
                lvi.Tag = maps[i];

                FileInfo fileInfo = new FileInfo(maps[i]);
                lvi.SubItems.Add( fileInfo.Length.ToString() );
                this.listViewMap.Items.Add(lvi);
            }
            this.labelNum.Text = maps.Length.ToString();

            this.listViewMap.EndUpdate();

        }

        private void MapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void listViewMap_DoubleClick(object sender, EventArgs e)
        {
            if (listViewMap.SelectedItems.Count > 0 )
            {
                string name = listViewMap.SelectedItems[0].Tag.ToString();
                // MessageBox.Show( name );
                MainForm.s_instance.openMap(name);
                
            }

        }

    }
}
