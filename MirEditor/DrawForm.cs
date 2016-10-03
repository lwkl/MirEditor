using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirEditor
{
    public partial class DrawForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DrawPanel drawPanel = null;
        public DrawForm()
        {
            InitializeComponent();
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
            drawPanel = new DrawPanel();
            drawPanel.Parent = this;
            drawPanel.Dock = DockStyle.Fill;
        }

        public void openMap(string filePath)
        {
            this.Text = System.IO.Path.GetFileName(filePath);

            drawPanel.open(filePath);
        }


    }
}
