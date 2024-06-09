namespace QuanLyBanVeMayBay.UCs
{
    partial class UC_ButtonChonViTriChuaMua
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_MaGhe = new System.Windows.Forms.Button();
            this.Lbl_MaGhe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_MaGhe
            // 
            this.Btn_MaGhe.BackColor = System.Drawing.Color.SkyBlue;
            this.Btn_MaGhe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_MaGhe.Location = new System.Drawing.Point(0, 0);
            this.Btn_MaGhe.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_MaGhe.Name = "Btn_MaGhe";
            this.Btn_MaGhe.Size = new System.Drawing.Size(80, 40);
            this.Btn_MaGhe.TabIndex = 1;
            this.Btn_MaGhe.Text = "Mã ghế";
            this.Btn_MaGhe.UseVisualStyleBackColor = false;
            // 
            // Lbl_MaGhe
            // 
            this.Lbl_MaGhe.AutoSize = true;
            this.Lbl_MaGhe.Location = new System.Drawing.Point(3, 9);
            this.Lbl_MaGhe.Name = "Lbl_MaGhe";
            this.Lbl_MaGhe.Size = new System.Drawing.Size(56, 22);
            this.Lbl_MaGhe.TabIndex = 2;
            this.Lbl_MaGhe.Text = "MaVe";
            this.Lbl_MaGhe.Visible = false;
            // 
            // UC_ButtonChonViTriChuaMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_MaGhe);
            this.Controls.Add(this.Lbl_MaGhe);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_ButtonChonViTriChuaMua";
            this.Size = new System.Drawing.Size(80, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Btn_MaGhe;
        public System.Windows.Forms.Label Lbl_MaGhe;
    }
}
