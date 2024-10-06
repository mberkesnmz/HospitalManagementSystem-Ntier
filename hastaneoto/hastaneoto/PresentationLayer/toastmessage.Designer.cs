namespace hastaneoto.PresentationLayer
{
    partial class toastmessage
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
            this.components = new System.ComponentModel.Container();
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.Lbltoasttext = new System.Windows.Forms.Label();
            this.Lbltoasttitle = new System.Windows.Forms.Label();
            this.toastpnl = new System.Windows.Forms.Panel();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(12, 5);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(60, 60);
            this.PicAlertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicAlertBox.TabIndex = 0;
            this.PicAlertBox.TabStop = false;
            // 
            // Lbltoasttext
            // 
            this.Lbltoasttext.AutoSize = true;
            this.Lbltoasttext.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Lbltoasttext.Location = new System.Drawing.Point(94, 40);
            this.Lbltoasttext.Name = "Lbltoasttext";
            this.Lbltoasttext.Size = new System.Drawing.Size(104, 20);
            this.Lbltoasttext.TabIndex = 1;
            this.Lbltoasttext.Text = "Text Alert Box";
            // 
            // Lbltoasttitle
            // 
            this.Lbltoasttitle.AutoSize = true;
            this.Lbltoasttitle.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold);
            this.Lbltoasttitle.Location = new System.Drawing.Point(91, 6);
            this.Lbltoasttitle.Name = "Lbltoasttitle";
            this.Lbltoasttitle.Size = new System.Drawing.Size(161, 27);
            this.Lbltoasttitle.TabIndex = 2;
            this.Lbltoasttitle.Text = "Title Alert Box";
            // 
            // toastpnl
            // 
            this.toastpnl.Location = new System.Drawing.Point(0, 68);
            this.toastpnl.Name = "toastpnl";
            this.toastpnl.Size = new System.Drawing.Size(1, 7);
            this.toastpnl.TabIndex = 3;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // toastmessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 75);
            this.Controls.Add(this.toastpnl);
            this.Controls.Add(this.Lbltoasttitle);
            this.Controls.Add(this.Lbltoasttext);
            this.Controls.Add(this.PicAlertBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "toastmessage";
            this.Opacity = 0.95D;
            this.Text = "toastmessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.toastmessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Label Lbltoasttext;
        private System.Windows.Forms.Label Lbltoasttitle;
        private System.Windows.Forms.Panel toastpnl;
        private System.Windows.Forms.Timer timerAnimation;
    }
}