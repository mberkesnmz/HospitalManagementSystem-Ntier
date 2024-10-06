namespace hastaneoto
{
    partial class login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kullanici_cmb = new System.Windows.Forms.ComboBox();
            this.reset_lbl = new System.Windows.Forms.Label();
            this.ıconButton2 = new FontAwesome.Sharp.IconButton();
            this.girisyap_btn = new FontAwesome.Sharp.IconButton();
            this.loginekran_ustpnl = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.loginekran_ustpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 421);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::hastaneoto.Properties.Resources.hastanelogo1;
            this.pictureBox1.Location = new System.Drawing.Point(5, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LEMON MILK Bold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(349, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOŞGELDİNİZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("LEMON MILK", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(354, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "LÜTFEN KULLANICI RÖLÜNÜZÜ SEÇİNİZ";
            // 
            // kullanici_cmb
            // 
            this.kullanici_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.kullanici_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kullanici_cmb.Font = new System.Drawing.Font("LEMON MILK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kullanici_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.kullanici_cmb.FormattingEnabled = true;
            this.kullanici_cmb.Items.AddRange(new object[] {
            "Doktor",
            "Sekreter"});
            this.kullanici_cmb.Location = new System.Drawing.Point(389, 155);
            this.kullanici_cmb.Name = "kullanici_cmb";
            this.kullanici_cmb.Size = new System.Drawing.Size(205, 31);
            this.kullanici_cmb.TabIndex = 3;
            // 
            // reset_lbl
            // 
            this.reset_lbl.AutoSize = true;
            this.reset_lbl.Font = new System.Drawing.Font("LEMON MILK Light", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(118)))), ((int)(((byte)(165)))));
            this.reset_lbl.Location = new System.Drawing.Point(461, 189);
            this.reset_lbl.Name = "reset_lbl";
            this.reset_lbl.Size = new System.Drawing.Size(56, 21);
            this.reset_lbl.TabIndex = 6;
            this.reset_lbl.Text = "Reset";
            this.reset_lbl.Click += new System.EventHandler(this.reset_lbl_Click);
            // 
            // ıconButton2
            // 
            this.ıconButton2.FlatAppearance.BorderSize = 0;
            this.ıconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton2.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.ıconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ıconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton2.IconSize = 36;
            this.ıconButton2.Location = new System.Drawing.Point(657, 3);
            this.ıconButton2.Name = "ıconButton2";
            this.ıconButton2.Size = new System.Drawing.Size(45, 37);
            this.ıconButton2.TabIndex = 5;
            this.ıconButton2.UseVisualStyleBackColor = true;
            this.ıconButton2.Click += new System.EventHandler(this.ıconButton2_Click);
            // 
            // girisyap_btn
            // 
            this.girisyap_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.girisyap_btn.FlatAppearance.BorderSize = 0;
            this.girisyap_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.girisyap_btn.Font = new System.Drawing.Font("LEMON MILK Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.girisyap_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.girisyap_btn.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.girisyap_btn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.girisyap_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.girisyap_btn.IconSize = 56;
            this.girisyap_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.girisyap_btn.Location = new System.Drawing.Point(358, 266);
            this.girisyap_btn.Name = "girisyap_btn";
            this.girisyap_btn.Size = new System.Drawing.Size(265, 78);
            this.girisyap_btn.TabIndex = 4;
            this.girisyap_btn.Text = "GİRİŞ YAP";
            this.girisyap_btn.UseVisualStyleBackColor = false;
            this.girisyap_btn.Click += new System.EventHandler(this.girisyap_btn_Click);
            // 
            // loginekran_ustpnl
            // 
            this.loginekran_ustpnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(162)))), ((int)(((byte)(227)))));
            this.loginekran_ustpnl.Controls.Add(this.ıconButton2);
            this.loginekran_ustpnl.Location = new System.Drawing.Point(0, 0);
            this.loginekran_ustpnl.Name = "loginekran_ustpnl";
            this.loginekran_ustpnl.Size = new System.Drawing.Size(705, 40);
            this.loginekran_ustpnl.TabIndex = 1;
            this.loginekran_ustpnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginekran_ustpnl_MouseDown);
            this.loginekran_ustpnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.loginekran_ustpnl_MouseMove);
            this.loginekran_ustpnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loginekran_ustpanel_MouseUp);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(704, 421);
            this.Controls.Add(this.loginekran_ustpnl);
            this.Controls.Add(this.reset_lbl);
            this.Controls.Add(this.girisyap_btn);
            this.Controls.Add(this.kullanici_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.loginekran_ustpnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kullanici_cmb;
        private FontAwesome.Sharp.IconButton girisyap_btn;
        private FontAwesome.Sharp.IconButton ıconButton2;
        private System.Windows.Forms.Label reset_lbl;
        private System.Windows.Forms.Panel loginekran_ustpnl;
    }
}

