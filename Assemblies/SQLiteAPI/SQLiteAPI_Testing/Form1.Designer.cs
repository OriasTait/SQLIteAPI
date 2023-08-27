namespace SQLiteAPI_Testing
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
            this.Group_Box_DB_Status = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Group_Box_Panel = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Connection_Status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Group_Box_DB_Status.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Group_Box_Panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_Box_DB_Status
            // 
            this.Group_Box_DB_Status.Controls.Add(this.Group_Box_Panel);
            this.Group_Box_DB_Status.Location = new System.Drawing.Point(3, 319);
            this.Group_Box_DB_Status.Name = "Group_Box_DB_Status";
            this.Group_Box_DB_Status.Size = new System.Drawing.Size(790, 124);
            this.Group_Box_DB_Status.TabIndex = 1;
            this.Group_Box_DB_Status.TabStop = false;
            this.Group_Box_DB_Status.Text = " Database Status ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Group_Box_DB_Status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // Group_Box_Panel
            // 
            this.Group_Box_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Group_Box_Panel.Controls.Add(this.Connection_Status);
            this.Group_Box_Panel.Controls.Add(this.Label1);
            this.Group_Box_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Group_Box_Panel.Location = new System.Drawing.Point(3, 16);
            this.Group_Box_Panel.Name = "Group_Box_Panel";
            this.Group_Box_Panel.Size = new System.Drawing.Size(784, 105);
            this.Group_Box_Panel.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(4, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(113, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Database Connection:";
            // 
            // Connection_Status
            // 
            this.Connection_Status.AutoSize = true;
            this.Connection_Status.Location = new System.Drawing.Point(115, 4);
            this.Connection_Status.Name = "Connection_Status";
            this.Connection_Status.Size = new System.Drawing.Size(35, 13);
            this.Connection_Status.TabIndex = 1;
            this.Connection_Status.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Create a Database ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 150);
            this.panel2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLite Testing";
            this.Group_Box_DB_Status.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Group_Box_Panel.ResumeLayout(false);
            this.Group_Box_Panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_Box_DB_Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Group_Box_Panel;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Connection_Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
    }
}

