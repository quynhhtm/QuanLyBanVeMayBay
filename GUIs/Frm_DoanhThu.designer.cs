namespace QuanLyBanVeMayBay.GUIs
{
    partial class Frm_DoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Pnl_Body = new System.Windows.Forms.Panel();
            this.Btn_DoanhThu = new System.Windows.Forms.Button();
            this.Cmb_Nam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_DoanhThu_LoiNhuan = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Pnl_Body.SuspendLayout();
            this.pnl_DoanhThu_LoiNhuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Body
            // 
            this.Pnl_Body.Controls.Add(this.pnl_DoanhThu_LoiNhuan);
            this.Pnl_Body.Controls.Add(this.Btn_DoanhThu);
            this.Pnl_Body.Controls.Add(this.Cmb_Nam);
            this.Pnl_Body.Controls.Add(this.label2);
            this.Pnl_Body.Location = new System.Drawing.Point(3, 12);
            this.Pnl_Body.Name = "Pnl_Body";
            this.Pnl_Body.Size = new System.Drawing.Size(1260, 660);
            this.Pnl_Body.TabIndex = 4;
            // 
            // Btn_DoanhThu
            // 
            this.Btn_DoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DoanhThu.Location = new System.Drawing.Point(662, 20);
            this.Btn_DoanhThu.Name = "Btn_DoanhThu";
            this.Btn_DoanhThu.Size = new System.Drawing.Size(137, 45);
            this.Btn_DoanhThu.TabIndex = 3;
            this.Btn_DoanhThu.Text = "Doanh thu";
            this.Btn_DoanhThu.UseVisualStyleBackColor = true;
            this.Btn_DoanhThu.Click += new System.EventHandler(this.Btn_DoanhThu_Click);
            // 
            // Cmb_Nam
            // 
            this.Cmb_Nam.FormattingEnabled = true;
            this.Cmb_Nam.Location = new System.Drawing.Point(484, 28);
            this.Cmb_Nam.Name = "Cmb_Nam";
            this.Cmb_Nam.Size = new System.Drawing.Size(121, 30);
            this.Cmb_Nam.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // pnl_DoanhThu_LoiNhuan
            // 
            this.pnl_DoanhThu_LoiNhuan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_DoanhThu_LoiNhuan.Controls.Add(this.chart1);
            this.pnl_DoanhThu_LoiNhuan.Location = new System.Drawing.Point(3, 83);
            this.pnl_DoanhThu_LoiNhuan.Name = "pnl_DoanhThu_LoiNhuan";
            this.pnl_DoanhThu_LoiNhuan.Size = new System.Drawing.Size(1244, 566);
            this.pnl_DoanhThu_LoiNhuan.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(110, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1048, 470);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Frm_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Pnl_Body);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_DoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh Thu";
            this.Load += new System.EventHandler(this.Frm_DoanhThu_Load);
            this.Pnl_Body.ResumeLayout(false);
            this.Pnl_Body.PerformLayout();
            this.pnl_DoanhThu_LoiNhuan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Body;
        private System.Windows.Forms.Button Btn_DoanhThu;
        private System.Windows.Forms.ComboBox Cmb_Nam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_DoanhThu_LoiNhuan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}