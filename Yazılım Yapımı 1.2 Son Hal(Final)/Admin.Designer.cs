
namespace Yazılım_Yapımı_1._1
{
    partial class Admin
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
            this.btnonay = new System.Windows.Forms.Button();
            this.btncikis = new System.Windows.Forms.Button();
            this.btngöster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnonay
            // 
            this.btnonay.Location = new System.Drawing.Point(156, 33);
            this.btnonay.Name = "btnonay";
            this.btnonay.Size = new System.Drawing.Size(116, 59);
            this.btnonay.TabIndex = 2;
            this.btnonay.Text = "Onayla";
            this.btnonay.UseVisualStyleBackColor = true;
            this.btnonay.Click += new System.EventHandler(this.btnonay_Click);
            // 
            // btncikis
            // 
            this.btncikis.Location = new System.Drawing.Point(308, 33);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(116, 59);
            this.btncikis.TabIndex = 3;
            this.btncikis.Text = "Çıkış";
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // btngöster
            // 
            this.btngöster.Location = new System.Drawing.Point(12, 33);
            this.btngöster.Name = "btngöster";
            this.btngöster.Size = new System.Drawing.Size(116, 59);
            this.btngöster.TabIndex = 4;
            this.btngöster.Text = "Onay Bekleye Kullanıcılar";
            this.btngöster.UseVisualStyleBackColor = true;
            this.btngöster.Click += new System.EventHandler(this.btngöster_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 132);
            this.Controls.Add(this.btngöster);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.btnonay);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnonay;
        private System.Windows.Forms.Button btncikis;
        private System.Windows.Forms.Button btngöster;
    }
}