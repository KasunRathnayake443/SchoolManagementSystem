namespace SchoolManagementSystem
{
    partial class updateStudent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.student_status = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.student_section = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.student_grade = new System.Windows.Forms.ComboBox();
            this.student_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.student_gender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.student_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.student_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.student_updateBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.student_updateBtn);
            this.panel1.Controls.Add(this.student_status);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.student_section);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.student_grade);
            this.panel1.Controls.Add(this.student_address);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.student_gender);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.student_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.student_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 261);
            this.panel1.TabIndex = 0;
            // 
            // student_status
            // 
            this.student_status.FormattingEnabled = true;
            this.student_status.Items.AddRange(new object[] {
            "Entrolled",
            "Pending",
            "Graduated"});
            this.student_status.Location = new System.Drawing.Point(504, 44);
            this.student_status.Name = "student_status";
            this.student_status.Size = new System.Drawing.Size(134, 21);
            this.student_status.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Status:";
            // 
            // student_section
            // 
            this.student_section.FormattingEnabled = true;
            this.student_section.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.student_section.Location = new System.Drawing.Point(504, 12);
            this.student_section.Name = "student_section";
            this.student_section.Size = new System.Drawing.Size(134, 21);
            this.student_section.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Section:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Grade:";
            // 
            // student_grade
            // 
            this.student_grade.FormattingEnabled = true;
            this.student_grade.Items.AddRange(new object[] {
            "Grade 1",
            "Grade 2",
            "Grade 3",
            "Grade 4",
            "Grade 5",
            "Grade 6",
            "Grade 7",
            "Grade 8",
            "Grade 9",
            "Grade 10",
            "Grade 11"});
            this.student_grade.Location = new System.Drawing.Point(306, 94);
            this.student_grade.Name = "student_grade";
            this.student_grade.Size = new System.Drawing.Size(119, 21);
            this.student_grade.TabIndex = 28;
            // 
            // student_address
            // 
            this.student_address.Location = new System.Drawing.Point(306, 12);
            this.student_address.Multiline = true;
            this.student_address.Name = "student_address";
            this.student_address.Size = new System.Drawing.Size(119, 71);
            this.student_address.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Address:";
            // 
            // student_gender
            // 
            this.student_gender.FormattingEnabled = true;
            this.student_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Others"});
            this.student_gender.Location = new System.Drawing.Point(76, 102);
            this.student_gender.Name = "student_gender";
            this.student_gender.Size = new System.Drawing.Size(134, 21);
            this.student_gender.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gender:";
            // 
            // student_name
            // 
            this.student_name.Location = new System.Drawing.Point(76, 56);
            this.student_name.Multiline = true;
            this.student_name.Name = "student_name";
            this.student_name.Size = new System.Drawing.Size(134, 23);
            this.student_name.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Full Name:";
            // 
            // student_id
            // 
            this.student_id.Location = new System.Drawing.Point(76, 18);
            this.student_id.Multiline = true;
            this.student_id.Name = "student_id";
            this.student_id.Size = new System.Drawing.Size(100, 23);
            this.student_id.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Student ID:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(498, 192);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(113, 34);
            this.cancelBtn.TabIndex = 35;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // student_updateBtn
            // 
            this.student_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.student_updateBtn.FlatAppearance.BorderSize = 0;
            this.student_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.student_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.student_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.student_updateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_updateBtn.ForeColor = System.Drawing.Color.White;
            this.student_updateBtn.Location = new System.Drawing.Point(364, 192);
            this.student_updateBtn.Name = "student_updateBtn";
            this.student_updateBtn.Size = new System.Drawing.Size(113, 34);
            this.student_updateBtn.TabIndex = 34;
            this.student_updateBtn.Text = "Update";
            this.student_updateBtn.UseVisualStyleBackColor = false;
            this.student_updateBtn.Click += new System.EventHandler(this.student_updateBtn_Click);
            // 
            // updateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 303);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "updateStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "updateStudent";
            this.Load += new System.EventHandler(this.updateStudent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox student_status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox student_section;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox student_grade;
        private System.Windows.Forms.TextBox student_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox student_gender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox student_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox student_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button student_updateBtn;
    }
}