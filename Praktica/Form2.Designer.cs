namespace Praktica
{
    partial class Form2
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
            this.labelnewprjc = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.ClientNamelbl = new System.Windows.Forms.Label();
            this.startDlbl = new System.Windows.Forms.Label();
            this.finishDlbl = new System.Windows.Forms.Label();
            this.pricelbl = new System.Windows.Forms.Label();
            this.Realizationlbl = new System.Windows.Forms.Label();
            this.rollbacklbl = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.ClientTB = new System.Windows.Forms.TextBox();
            this.startDateTB = new System.Windows.Forms.MaskedTextBox();
            this.endDateTB = new System.Windows.Forms.MaskedTextBox();
            this.PriceTB = new System.Windows.Forms.NumericUpDown();
            this.RealizTB = new System.Windows.Forms.NumericUpDown();
            this.RollbackTB = new System.Windows.Forms.NumericUpDown();
            this.Addbtn = new System.Windows.Forms.Button();
            this.posTB = new System.Windows.Forms.NumericUpDown();
            this.posLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealizTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RollbackTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posTB)).BeginInit();
            this.SuspendLayout();
            // 
            // labelnewprjc
            // 
            this.labelnewprjc.AutoSize = true;
            this.labelnewprjc.Location = new System.Drawing.Point(110, 20);
            this.labelnewprjc.Name = "labelnewprjc";
            this.labelnewprjc.Size = new System.Drawing.Size(85, 13);
            this.labelnewprjc.TabIndex = 0;
            this.labelnewprjc.Text = "NEW PROJECT";
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Namelbl.Location = new System.Drawing.Point(28, 59);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(35, 13);
            this.Namelbl.TabIndex = 1;
            this.Namelbl.Text = "Name";
            // 
            // ClientNamelbl
            // 
            this.ClientNamelbl.AutoSize = true;
            this.ClientNamelbl.Location = new System.Drawing.Point(28, 86);
            this.ClientNamelbl.Name = "ClientNamelbl";
            this.ClientNamelbl.Size = new System.Drawing.Size(64, 13);
            this.ClientNamelbl.TabIndex = 2;
            this.ClientNamelbl.Text = "Client Name";
            // 
            // startDlbl
            // 
            this.startDlbl.AutoSize = true;
            this.startDlbl.Location = new System.Drawing.Point(28, 122);
            this.startDlbl.Name = "startDlbl";
            this.startDlbl.Size = new System.Drawing.Size(55, 13);
            this.startDlbl.TabIndex = 3;
            this.startDlbl.Text = "Start Date";
            // 
            // finishDlbl
            // 
            this.finishDlbl.AutoSize = true;
            this.finishDlbl.Location = new System.Drawing.Point(28, 148);
            this.finishDlbl.Name = "finishDlbl";
            this.finishDlbl.Size = new System.Drawing.Size(60, 13);
            this.finishDlbl.TabIndex = 4;
            this.finishDlbl.Text = "Finish Date";
            // 
            // pricelbl
            // 
            this.pricelbl.AutoSize = true;
            this.pricelbl.Location = new System.Drawing.Point(28, 182);
            this.pricelbl.Name = "pricelbl";
            this.pricelbl.Size = new System.Drawing.Size(31, 13);
            this.pricelbl.TabIndex = 5;
            this.pricelbl.Text = "Price";
            // 
            // Realizationlbl
            // 
            this.Realizationlbl.AutoSize = true;
            this.Realizationlbl.Location = new System.Drawing.Point(28, 211);
            this.Realizationlbl.Name = "Realizationlbl";
            this.Realizationlbl.Size = new System.Drawing.Size(59, 13);
            this.Realizationlbl.TabIndex = 6;
            this.Realizationlbl.Text = "Realization";
            // 
            // rollbacklbl
            // 
            this.rollbacklbl.AutoSize = true;
            this.rollbacklbl.Location = new System.Drawing.Point(28, 245);
            this.rollbacklbl.Name = "rollbacklbl";
            this.rollbacklbl.Size = new System.Drawing.Size(49, 13);
            this.rollbacklbl.TabIndex = 7;
            this.rollbacklbl.Text = "Rollback";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(168, 55);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(120, 20);
            this.NameTB.TabIndex = 8;
            // 
            // ClientTB
            // 
            this.ClientTB.Location = new System.Drawing.Point(168, 86);
            this.ClientTB.Name = "ClientTB";
            this.ClientTB.Size = new System.Drawing.Size(120, 20);
            this.ClientTB.TabIndex = 9;
            // 
            // startDateTB
            // 
            this.startDateTB.Location = new System.Drawing.Point(168, 118);
            this.startDateTB.Mask = "0000.00.00";
            this.startDateTB.Name = "startDateTB";
            this.startDateTB.Size = new System.Drawing.Size(120, 20);
            this.startDateTB.TabIndex = 10;
            // 
            // endDateTB
            // 
            this.endDateTB.Location = new System.Drawing.Point(168, 148);
            this.endDateTB.Mask = "0000.00.00";
            this.endDateTB.Name = "endDateTB";
            this.endDateTB.Size = new System.Drawing.Size(120, 20);
            this.endDateTB.TabIndex = 11;
            // 
            // PriceTB
            // 
            this.PriceTB.Location = new System.Drawing.Point(168, 182);
            this.PriceTB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PriceTB.Name = "PriceTB";
            this.PriceTB.Size = new System.Drawing.Size(120, 20);
            this.PriceTB.TabIndex = 13;
            // 
            // RealizTB
            // 
            this.RealizTB.Location = new System.Drawing.Point(168, 207);
            this.RealizTB.Name = "RealizTB";
            this.RealizTB.Size = new System.Drawing.Size(120, 20);
            this.RealizTB.TabIndex = 14;
            // 
            // RollbackTB
            // 
            this.RollbackTB.Location = new System.Drawing.Point(168, 241);
            this.RollbackTB.Name = "RollbackTB";
            this.RollbackTB.Size = new System.Drawing.Size(120, 20);
            this.RollbackTB.TabIndex = 15;
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(113, 303);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 16;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // posTB
            // 
            this.posTB.Location = new System.Drawing.Point(168, 267);
            this.posTB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.posTB.Name = "posTB";
            this.posTB.Size = new System.Drawing.Size(120, 20);
            this.posTB.TabIndex = 18;
            this.posTB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // posLbl
            // 
            this.posLbl.AutoSize = true;
            this.posLbl.Location = new System.Drawing.Point(28, 271);
            this.posLbl.Name = "posLbl";
            this.posLbl.Size = new System.Drawing.Size(68, 13);
            this.posLbl.TabIndex = 17;
            this.posLbl.Text = "<<Position>>";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 338);
            this.Controls.Add(this.posTB);
            this.Controls.Add(this.posLbl);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.RollbackTB);
            this.Controls.Add(this.RealizTB);
            this.Controls.Add(this.PriceTB);
            this.Controls.Add(this.endDateTB);
            this.Controls.Add(this.startDateTB);
            this.Controls.Add(this.ClientTB);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.rollbacklbl);
            this.Controls.Add(this.Realizationlbl);
            this.Controls.Add(this.pricelbl);
            this.Controls.Add(this.finishDlbl);
            this.Controls.Add(this.startDlbl);
            this.Controls.Add(this.ClientNamelbl);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.labelnewprjc);
            this.Name = "Form2";
            this.Text = "Add New";
            ((System.ComponentModel.ISupportInitialize)(this.PriceTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealizTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RollbackTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelnewprjc;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Label ClientNamelbl;
        private System.Windows.Forms.Label startDlbl;
        private System.Windows.Forms.Label finishDlbl;
        private System.Windows.Forms.Label pricelbl;
        private System.Windows.Forms.Label Realizationlbl;
        private System.Windows.Forms.Label rollbacklbl;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox ClientTB;
        private System.Windows.Forms.MaskedTextBox startDateTB;
        private System.Windows.Forms.MaskedTextBox endDateTB;
        private System.Windows.Forms.NumericUpDown PriceTB;
        private System.Windows.Forms.NumericUpDown RealizTB;
        private System.Windows.Forms.NumericUpDown RollbackTB;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.NumericUpDown posTB;
        
        private System.Windows.Forms.Label posLbl;
    }
}