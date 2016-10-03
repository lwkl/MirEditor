namespace MirEditor
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewMap = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelImageNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewMap
            // 
            this.listViewMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMap.FullRowSelect = true;
            this.listViewMap.Location = new System.Drawing.Point(12, 24);
            this.listViewMap.Name = "listViewMap";
            this.listViewMap.Size = new System.Drawing.Size(382, 512);
            this.listViewMap.TabIndex = 0;
            this.listViewMap.UseCompatibleStateImageBehavior = false;
            this.listViewMap.View = System.Windows.Forms.View.Details;
            this.listViewMap.DoubleClick += new System.EventHandler(this.listViewMap_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "总数量";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(59, 9);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(11, 12);
            this.labelNum.TabIndex = 2;
            this.labelNum.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "图片数";
            // 
            // labelImageNum
            // 
            this.labelImageNum.AutoSize = true;
            this.labelImageNum.Location = new System.Drawing.Point(138, 9);
            this.labelImageNum.Name = "labelImageNum";
            this.labelImageNum.Size = new System.Drawing.Size(11, 12);
            this.labelImageNum.TabIndex = 2;
            this.labelImageNum.Text = "0";
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 804);
            this.Controls.Add(this.labelImageNum);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewMap);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MapForm";
            this.Text = "地图";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapForm_FormClosing);
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMap;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelImageNum;
    }
}