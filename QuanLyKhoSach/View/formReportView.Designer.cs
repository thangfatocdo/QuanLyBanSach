namespace QuanLyKhoSach.View
{
    partial class formReportView
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Stock = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.CenterPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1124, 79);
            this.guna2Panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // btn_Stock
            // 
            this.btn_Stock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Stock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Stock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Stock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Stock.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_Stock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Stock.ForeColor = System.Drawing.Color.White;
            this.btn_Stock.Location = new System.Drawing.Point(223, 99);
            this.btn_Stock.Name = "btn_Stock";
            this.btn_Stock.Size = new System.Drawing.Size(180, 51);
            this.btn_Stock.TabIndex = 7;
            this.btn_Stock.Text = "Tồn kho";
            this.btn_Stock.Click += new System.EventHandler(this.btn_Stock_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrder.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(409, 99);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(180, 51);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "Đơn hàng";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Location = new System.Drawing.Point(34, 171);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(1062, 458);
            this.CenterPanel.TabIndex = 9;
            // 
            // formReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 659);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.btn_Stock);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "formReportView";
            this.Text = "formReportView";
            this.Load += new System.EventHandler(this.formReportView_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_Stock;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private Guna.UI2.WinForms.Guna2Panel CenterPanel;
    }
}