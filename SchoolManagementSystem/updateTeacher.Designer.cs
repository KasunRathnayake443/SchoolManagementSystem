namespace SchoolManagementSystem
{
    partial class updateTeacher
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
            this.teacher_status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tteacher_updateBtn = new System.Windows.Forms.Button();
            this.teacher_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.teacher_gender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.teacher_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teacher_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.teacher_status);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.tteacher_updateBtn);
            this.panel1.Controls.Add(this.teacher_address);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.teacher_gender);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.teacher_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.teacher_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 233);
            this.panel1.TabIndex = 0;
            // 
            // teacher_status
            // 
            this.teacher_status.FormattingEnabled = true;
            this.teacher_status.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.teacher_status.Location = new System.Drawing.Point(536, 26);
            this.teacher_status.Name = "teacher_status";
            this.teacher_status.Size = new System.Drawing.Size(134, 21);
            this.teacher_status.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Status:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(557, 172);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(113, 34);
            this.CancelBtn.TabIndex = 29;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // tteacher_updateBtn
            // 
            this.tteacher_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.tteacher_updateBtn.FlatAppearance.BorderSize = 0;
            this.tteacher_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tteacher_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tteacher_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tteacher_updateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tteacher_updateBtn.ForeColor = System.Drawing.Color.White;
            this.tteacher_updateBtn.Location = new System.Drawing.Point(423, 172);
            this.tteacher_updateBtn.Name = "tteacher_updateBtn";
            this.tteacher_updateBtn.Size = new System.Drawing.Size(113, 34);
            this.tteacher_updateBtn.TabIndex = 28;
            this.tteacher_updateBtn.Text = "Update";
            this.tteacher_updateBtn.UseVisualStyleBackColor = false;
            this.tteacher_updateBtn.Click += new System.EventHandler(this.tteacher_updateBtn_Click);
            // 
            // teacher_address
            // 
            this.teacher_address.Location = new System.Drawing.Point(334, 29);
            this.teacher_address.Multiline = true;
            this.teacher_address.Name = "teacher_address";
            this.teacher_address.Size = new System.Drawing.Size(119, 71);
            this.teacher_address.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Address:";
            // 
            // teacher_gender
            // 
            this.teacher_gender.FormattingEnabled = true;
            this.teacher_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Others"});
            this.teacher_gender.Location = new System.Drawing.Point(104, 116);
            this.teacher_gender.Name = "teacher_gender";
            this.teacher_gender.Size = new System.Drawing.Size(134, 21);
            this.teacher_gender.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gender:";
            // 
            // teacher_name
            // 
            this.teacher_name.Location = new System.Drawing.Point(104, 73);
            this.teacher_name.Multiline = true;
            this.teacher_name.Name = "teacher_name";
            this.teacher_name.Size = new System.Drawing.Size(134, 23);
            this.teacher_name.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Full Name:";
            // 
            // teacher_id
            // 
            this.teacher_id.Location = new System.Drawing.Point(104, 35);
            this.teacher_id.Multiline = true;
            this.teacher_id.Name = "teacher_id";
            this.teacher_id.Size = new System.Drawing.Size(100, 23);
            this.teacher_id.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Teacher ID:";
            // 
            // updateTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 257);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "updateTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "updateTeacher";
            this.Load += new System.EventHandler(this.updateTeacher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox teacher_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button tteacher_updateBtn;
        private System.Windows.Forms.TextBox teacher_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox teacher_gender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox teacher_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox teacher_id;
        private System.Windows.Forms.Label label2;
    }
}