namespace NewPlanWithUserInput
{
    partial class FormUserInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPatientID = new System.Windows.Forms.TextBox();
            this.textBoxTotalDose = new System.Windows.Forms.TextBox();
            this.textBoxFractionation = new System.Windows.Forms.TextBox();
            this.comboBoxPlanTemplate = new System.Windows.Forms.ComboBox();
            this.comboBoxTU = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Plan Template";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Dose (Gy)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Fractions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Treatment Unit";
            // 
            // textBoxPatientID
            // 
            this.textBoxPatientID.Location = new System.Drawing.Point(117, 21);
            this.textBoxPatientID.Name = "textBoxPatientID";
            this.textBoxPatientID.Size = new System.Drawing.Size(111, 20);
            this.textBoxPatientID.TabIndex = 1;
            // 
            // textBoxTotalDose
            // 
            this.textBoxTotalDose.Location = new System.Drawing.Point(117, 113);
            this.textBoxTotalDose.Name = "textBoxTotalDose";
            this.textBoxTotalDose.Size = new System.Drawing.Size(111, 20);
            this.textBoxTotalDose.TabIndex = 3;
            // 
            // textBoxFractionation
            // 
            this.textBoxFractionation.Location = new System.Drawing.Point(117, 159);
            this.textBoxFractionation.Name = "textBoxFractionation";
            this.textBoxFractionation.Size = new System.Drawing.Size(111, 20);
            this.textBoxFractionation.TabIndex = 4;
            // 
            // comboBoxPlanTemplate
            // 
            this.comboBoxPlanTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanTemplate.FormattingEnabled = true;
            this.comboBoxPlanTemplate.Location = new System.Drawing.Point(117, 66);
            this.comboBoxPlanTemplate.Name = "comboBoxPlanTemplate";
            this.comboBoxPlanTemplate.Size = new System.Drawing.Size(111, 21);
            this.comboBoxPlanTemplate.TabIndex = 2;
            // 
            // comboBoxTU
            // 
            this.comboBoxTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTU.FormattingEnabled = true;
            this.comboBoxTU.Location = new System.Drawing.Point(117, 208);
            this.comboBoxTU.Name = "comboBoxTU";
            this.comboBoxTU.Size = new System.Drawing.Size(111, 21);
            this.comboBoxTU.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(22, 250);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 30);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(153, 250);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormUserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 294);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxTU);
            this.Controls.Add(this.comboBoxPlanTemplate);
            this.Controls.Add(this.textBoxFractionation);
            this.Controls.Add(this.textBoxTotalDose);
            this.Controls.Add(this.textBoxPatientID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Variables Input";
            this.Load += new System.EventHandler(this.FormUserInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPatientID;
        private System.Windows.Forms.TextBox textBoxTotalDose;
        private System.Windows.Forms.TextBox textBoxFractionation;
        private System.Windows.Forms.ComboBox comboBoxPlanTemplate;
        private System.Windows.Forms.ComboBox comboBoxTU;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}