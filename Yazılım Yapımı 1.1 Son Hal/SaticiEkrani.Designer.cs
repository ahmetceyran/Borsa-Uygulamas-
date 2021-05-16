
namespace Yazılım_Yapımı_1._1
{
    partial class SaticiEkrani
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
            this.btnbakiye = new System.Windows.Forms.Button();
            this.btnalicilar = new System.Windows.Forms.Button();
            this.btnurunler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttur = new System.Windows.Forms.TextBox();
            this.txtmiktar = new System.Windows.Forms.TextBox();
            this.txtfiyat = new System.Windows.Forms.TextBox();
            this.btnekle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnbakiye
            // 
            this.btnbakiye.Location = new System.Drawing.Point(12, 12);
            this.btnbakiye.Name = "btnbakiye";
            this.btnbakiye.Size = new System.Drawing.Size(95, 54);
            this.btnbakiye.TabIndex = 0;
            this.btnbakiye.Text = "Bakiye";
            this.btnbakiye.UseVisualStyleBackColor = true;
            this.btnbakiye.Click += new System.EventHandler(this.btnbakiye_Click);
            // 
            // btnalicilar
            // 
            this.btnalicilar.Location = new System.Drawing.Point(245, 12);
            this.btnalicilar.Name = "btnalicilar";
            this.btnalicilar.Size = new System.Drawing.Size(95, 54);
            this.btnalicilar.TabIndex = 1;
            this.btnalicilar.Text = "Alıcılar";
            this.btnalicilar.UseVisualStyleBackColor = true;
            this.btnalicilar.Click += new System.EventHandler(this.btnalicilar_Click);
            // 
            // btnurunler
            // 
            this.btnurunler.Location = new System.Drawing.Point(132, 12);
            this.btnurunler.Name = "btnurunler";
            this.btnurunler.Size = new System.Drawing.Size(95, 54);
            this.btnurunler.TabIndex = 2;
            this.btnurunler.Text = "Ürünlerim";
            this.btnurunler.UseVisualStyleBackColor = true;
            this.btnurunler.Click += new System.EventHandler(this.btnurunler_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ürün Türü:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Miktar(Kg):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birim Fiyatı:";
            // 
            // txttur
            // 
            this.txttur.Location = new System.Drawing.Point(115, 110);
            this.txttur.Name = "txttur";
            this.txttur.Size = new System.Drawing.Size(112, 20);
            this.txttur.TabIndex = 6;
            // 
            // txtmiktar
            // 
            this.txtmiktar.Location = new System.Drawing.Point(115, 150);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(112, 20);
            this.txtmiktar.TabIndex = 7;
            // 
            // txtfiyat
            // 
            this.txtfiyat.Location = new System.Drawing.Point(115, 184);
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Size = new System.Drawing.Size(112, 20);
            this.txtfiyat.TabIndex = 8;
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(115, 235);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(112, 44);
            this.btnekle.TabIndex = 9;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // SaticiEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 364);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.txtfiyat);
            this.Controls.Add(this.txtmiktar);
            this.Controls.Add(this.txttur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnurunler);
            this.Controls.Add(this.btnalicilar);
            this.Controls.Add(this.btnbakiye);
            this.Name = "SaticiEkrani";
            this.Text = "SaticiEkrani";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbakiye;
        private System.Windows.Forms.Button btnalicilar;
        private System.Windows.Forms.Button btnurunler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttur;
        private System.Windows.Forms.TextBox txtmiktar;
        private System.Windows.Forms.TextBox txtfiyat;
        private System.Windows.Forms.Button btnekle;
    }
}