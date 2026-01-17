namespace DGPCI
{
    partial class MainForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabelDgpci = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.subB = new System.Windows.Forms.Button();
            this.subC = new System.Windows.Forms.Button();
            this.subD = new System.Windows.Forms.Button();
            this.subF = new System.Windows.Forms.Button();
            this.inserareDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelDgpci)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CATEGORIE",
            "DETALII_PERMIS",
            "INMATRICULARE",
            "ISTORIC_INSTRAINARE",
            "ITP",
            "PERMIS",
            "PERSOANA",
            "RCA",
            "SANCTIUNE",
            "VEHICUL"});
            this.comboBox1.Location = new System.Drawing.Point(12, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabelDgpci
            // 
            this.tabelDgpci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelDgpci.ContextMenuStrip = this.contextMenuStrip1;
            this.tabelDgpci.Location = new System.Drawing.Point(173, 28);
            this.tabelDgpci.Name = "tabelDgpci";
            this.tabelDgpci.Size = new System.Drawing.Size(1393, 569);
            this.tabelDgpci.TabIndex = 1;
            this.tabelDgpci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelDgpci_CellContentClick);
            this.tabelDgpci.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tabelDgpci_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem1.Text = "Modifica";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.modificare_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem2.Text = "Sterge";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.stergere_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Afiseaza tabel:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // subB
            // 
            this.subB.Location = new System.Drawing.Point(11, 176);
            this.subB.Name = "subB";
            this.subB.Size = new System.Drawing.Size(121, 74);
            this.subB.TabIndex = 4;
            this.subB.Text = "Afiseaza persoanele de sex masculin care detin permis categoria B";
            this.subB.UseVisualStyleBackColor = true;
            this.subB.Click += new System.EventHandler(this.subB_Click);
            // 
            // subC
            // 
            this.subC.Location = new System.Drawing.Point(11, 256);
            this.subC.Name = "subC";
            this.subC.Size = new System.Drawing.Size(121, 104);
            this.subC.TabIndex = 5;
            this.subC.Text = "Afiseaza marca, numarul de masini si puterea medie pentru marcile care au o puter" +
    "e medie intre 100 si 200 kW";
            this.subC.UseVisualStyleBackColor = true;
            this.subC.Click += new System.EventHandler(this.subC_Click);
            // 
            // subD
            // 
            this.subD.Location = new System.Drawing.Point(13, 366);
            this.subD.Name = "subD";
            this.subD.Size = new System.Drawing.Size(120, 58);
            this.subD.TabIndex = 6;
            this.subD.Text = "Afiseaza detalii despre persoane si permisele detinute";
            this.subD.UseVisualStyleBackColor = true;
            this.subD.Click += new System.EventHandler(this.subD_Click);
            // 
            // subF
            // 
            this.subF.Location = new System.Drawing.Point(12, 430);
            this.subF.Name = "subF";
            this.subF.Size = new System.Drawing.Size(120, 167);
            this.subF.TabIndex = 7;
            this.subF.Text = "Pentru fiecare tip de combustibil, afiseaza cate masini sunt in total pe acel tip" +
    ", cea mai puternica masina pe acel tip si media de putere a masinilor de pe acel" +
    " tip";
            this.subF.UseVisualStyleBackColor = true;
            this.subF.Click += new System.EventHandler(this.subF_Click);
            // 
            // inserareDate
            // 
            this.inserareDate.Location = new System.Drawing.Point(12, 102);
            this.inserareDate.Name = "inserareDate";
            this.inserareDate.Size = new System.Drawing.Size(120, 35);
            this.inserareDate.TabIndex = 8;
            this.inserareDate.Text = "Insereaza date";
            this.inserareDate.UseVisualStyleBackColor = true;
            this.inserareDate.Click += new System.EventHandler(this.inserareDate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 609);
            this.Controls.Add(this.inserareDate);
            this.Controls.Add(this.subF);
            this.Controls.Add(this.subD);
            this.Controls.Add(this.subC);
            this.Controls.Add(this.subB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabelDgpci);
            this.Controls.Add(this.comboBox1);
            this.Name = "MainForm";
            this.Text = "DGPCI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.subC_Click);
            ((System.ComponentModel.ISupportInitialize)(this.tabelDgpci)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView tabelDgpci;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button subB;
        private System.Windows.Forms.Button subC;
        private System.Windows.Forms.Button subD;
        private System.Windows.Forms.Button subF;
        private System.Windows.Forms.Button inserareDate;
    }
}

