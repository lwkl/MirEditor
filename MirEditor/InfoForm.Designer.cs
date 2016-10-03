namespace MirEditor
{
    partial class InfoForm
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
            this.imageBack = new System.Windows.Forms.PictureBox();
            this.imageMiddle = new System.Windows.Forms.PictureBox();
            this.imageFront = new System.Windows.Forms.PictureBox();
            this.labelBack = new System.Windows.Forms.Label();
            this.labelMiddle = new System.Windows.Forms.Label();
            this.labelFront = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFront)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBack
            // 
            this.imageBack.Location = new System.Drawing.Point(323, 190);
            this.imageBack.Name = "imageBack";
            this.imageBack.Size = new System.Drawing.Size(100, 50);
            this.imageBack.TabIndex = 0;
            this.imageBack.TabStop = false;
            // 
            // imageMiddle
            // 
            this.imageMiddle.Location = new System.Drawing.Point(323, 60);
            this.imageMiddle.Name = "imageMiddle";
            this.imageMiddle.Size = new System.Drawing.Size(100, 50);
            this.imageMiddle.TabIndex = 1;
            this.imageMiddle.TabStop = false;
            // 
            // imageFront
            // 
            this.imageFront.Location = new System.Drawing.Point(12, 60);
            this.imageFront.Name = "imageFront";
            this.imageFront.Size = new System.Drawing.Size(239, 180);
            this.imageFront.TabIndex = 2;
            this.imageFront.TabStop = false;
            // 
            // labelBack
            // 
            this.labelBack.AutoSize = true;
            this.labelBack.Location = new System.Drawing.Point(323, 172);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(53, 12);
            this.labelBack.TabIndex = 3;
            this.labelBack.Text = "背景图片";
            // 
            // labelMiddle
            // 
            this.labelMiddle.AutoSize = true;
            this.labelMiddle.Location = new System.Drawing.Point(325, 42);
            this.labelMiddle.Name = "labelMiddle";
            this.labelMiddle.Size = new System.Drawing.Size(53, 12);
            this.labelMiddle.TabIndex = 4;
            this.labelMiddle.Text = "中间图片";
            // 
            // labelFront
            // 
            this.labelFront.AutoSize = true;
            this.labelFront.Location = new System.Drawing.Point(10, 42);
            this.labelFront.Name = "labelFront";
            this.labelFront.Size = new System.Drawing.Size(53, 12);
            this.labelFront.TabIndex = 5;
            this.labelFront.Text = "前景图片";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(14, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(29, 12);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "信息";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 486);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelFront);
            this.Controls.Add(this.labelMiddle);
            this.Controls.Add(this.labelBack);
            this.Controls.Add(this.imageFront);
            this.Controls.Add(this.imageMiddle);
            this.Controls.Add(this.imageBack);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "InfoForm";
            this.Text = "信息";
            ((System.ComponentModel.ISupportInitialize)(this.imageBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFront)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBack;
        private System.Windows.Forms.PictureBox imageMiddle;
        private System.Windows.Forms.PictureBox imageFront;
        private System.Windows.Forms.Label labelBack;
        private System.Windows.Forms.Label labelMiddle;
        private System.Windows.Forms.Label labelFront;
        private System.Windows.Forms.Label labelInfo;
    }
}