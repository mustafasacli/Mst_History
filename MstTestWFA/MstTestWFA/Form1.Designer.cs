namespace MstTestWFA
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVeriGetir = new System.Windows.Forms.Button();
            this.btnCreateAccessFile = new System.Windows.Forms.Button();
            this.btnGetFromAccess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnVeriGetir
            // 
            this.btnVeriGetir.Location = new System.Drawing.Point(12, 312);
            this.btnVeriGetir.Name = "btnVeriGetir";
            this.btnVeriGetir.Size = new System.Drawing.Size(146, 23);
            this.btnVeriGetir.TabIndex = 1;
            this.btnVeriGetir.Text = "Veri Getir -> MySQL";
            this.btnVeriGetir.UseVisualStyleBackColor = true;
            this.btnVeriGetir.Click += new System.EventHandler(this.btnVeriGetir_Click);
            // 
            // btnCreateAccessFile
            // 
            this.btnCreateAccessFile.Location = new System.Drawing.Point(337, 315);
            this.btnCreateAccessFile.Name = "btnCreateAccessFile";
            this.btnCreateAccessFile.Size = new System.Drawing.Size(106, 23);
            this.btnCreateAccessFile.TabIndex = 2;
            this.btnCreateAccessFile.Text = "Get Table MsSQL";
            this.btnCreateAccessFile.UseVisualStyleBackColor = true;
            this.btnCreateAccessFile.Click += new System.EventHandler(this.btnCreateAccessFile_Click);
            // 
            // btnGetFromAccess
            // 
            this.btnGetFromAccess.Location = new System.Drawing.Point(204, 311);
            this.btnGetFromAccess.Name = "btnGetFromAccess";
            this.btnGetFromAccess.Size = new System.Drawing.Size(102, 23);
            this.btnGetFromAccess.TabIndex = 3;
            this.btnGetFromAccess.Text = "Get From Access";
            this.btnGetFromAccess.UseVisualStyleBackColor = true;
            this.btnGetFromAccess.Click += new System.EventHandler(this.btnGetFromAccess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 350);
            this.Controls.Add(this.btnGetFromAccess);
            this.Controls.Add(this.btnCreateAccessFile);
            this.Controls.Add(this.btnVeriGetir);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVeriGetir;
        private System.Windows.Forms.Button btnCreateAccessFile;
        private System.Windows.Forms.Button btnGetFromAccess;
    }
}

