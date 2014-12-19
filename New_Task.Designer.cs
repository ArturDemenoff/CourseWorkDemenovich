namespace TaskManager
{
    partial class New_Task
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Title_TB = new System.Windows.Forms.TextBox();
            this.Description_TB = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Perfomer_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_combobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // Title_TB
            // 
            this.Title_TB.Location = new System.Drawing.Point(185, 25);
            this.Title_TB.Name = "Title_TB";
            this.Title_TB.Size = new System.Drawing.Size(155, 20);
            this.Title_TB.TabIndex = 1;
            // 
            // Description_TB
            // 
            this.Description_TB.Location = new System.Drawing.Point(12, 64);
            this.Description_TB.Multiline = true;
            this.Description_TB.Name = "Description_TB";
            this.Description_TB.Size = new System.Drawing.Size(155, 63);
            this.Description_TB.TabIndex = 2;
            // 
            // Add
            // 
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Location = new System.Drawing.Point(346, 25);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(82, 107);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date";
            // 
            // Perfomer_TB
            // 
            this.Perfomer_TB.Location = new System.Drawing.Point(185, 64);
            this.Perfomer_TB.Name = "Perfomer_TB";
            this.Perfomer_TB.Size = new System.Drawing.Size(155, 20);
            this.Perfomer_TB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Perfomer";
            // 
            // Status_combobox
            // 
            this.Status_combobox.FormattingEnabled = true;
            this.Status_combobox.Items.AddRange(new object[] {
            "Achieved",
            "Not performed",
            "postponed"});
            this.Status_combobox.Location = new System.Drawing.Point(185, 106);
            this.Status_combobox.Name = "Status_combobox";
            this.Status_combobox.Size = new System.Drawing.Size(155, 21);
            this.Status_combobox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Description";
            // 
            // New_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 133);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Status_combobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Perfomer_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Description_TB);
            this.Controls.Add(this.Title_TB);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "New_Task";
            this.Text = "New Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox Title_TB;
        private System.Windows.Forms.TextBox Description_TB;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Perfomer_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Status_combobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}