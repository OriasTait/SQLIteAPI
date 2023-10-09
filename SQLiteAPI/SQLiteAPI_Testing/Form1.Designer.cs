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
            this.Group_Box_Panel = new System.Windows.Forms.Panel();
            this.DB_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DB_Directory = new System.Windows.Forms.Label();
            this.Process_Error = new System.Windows.Forms.Label();
            this.Connection_Status = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.TAB_EmptyDB = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_Create_EmptyDB = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BTN_Show_Data2 = new System.Windows.Forms.Button();
            this.BTN_Show_Data = new System.Windows.Forms.Button();
            this.BTN_Table_Create_and_Populate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTN_ShrinkDB = new System.Windows.Forms.Button();
            this.Group_Box_DB_Status.SuspendLayout();
            this.Group_Box_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TAB_EmptyDB.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.Group_Box_DB_Status.Text = " Database Information";
            // 
            // Group_Box_Panel
            // 
            this.Group_Box_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Group_Box_Panel.Controls.Add(this.DB_Name);
            this.Group_Box_Panel.Controls.Add(this.label3);
            this.Group_Box_Panel.Controls.Add(this.label2);
            this.Group_Box_Panel.Controls.Add(this.DB_Directory);
            this.Group_Box_Panel.Controls.Add(this.Process_Error);
            this.Group_Box_Panel.Controls.Add(this.Connection_Status);
            this.Group_Box_Panel.Controls.Add(this.Label1);
            this.Group_Box_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Group_Box_Panel.Location = new System.Drawing.Point(3, 16);
            this.Group_Box_Panel.Name = "Group_Box_Panel";
            this.Group_Box_Panel.Size = new System.Drawing.Size(784, 105);
            this.Group_Box_Panel.TabIndex = 2;
            // 
            // DB_Name
            // 
            this.DB_Name.AutoSize = true;
            this.DB_Name.Location = new System.Drawing.Point(69, 34);
            this.DB_Name.Name = "DB_Name";
            this.DB_Name.Size = new System.Drawing.Size(35, 13);
            this.DB_Name.TabIndex = 7;
            this.DB_Name.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Directory:";
            // 
            // DB_Directory
            // 
            this.DB_Directory.AutoSize = true;
            this.DB_Directory.Location = new System.Drawing.Point(69, 11);
            this.DB_Directory.Name = "DB_Directory";
            this.DB_Directory.Size = new System.Drawing.Size(35, 13);
            this.DB_Directory.TabIndex = 5;
            this.DB_Directory.Text = "label3";
            // 
            // Process_Error
            // 
            this.Process_Error.AutoSize = true;
            this.Process_Error.ForeColor = System.Drawing.Color.Red;
            this.Process_Error.Location = new System.Drawing.Point(10, 88);
            this.Process_Error.Name = "Process_Error";
            this.Process_Error.Size = new System.Drawing.Size(70, 13);
            this.Process_Error.TabIndex = 2;
            this.Process_Error.Text = "Process Error";
            // 
            // Connection_Status
            // 
            this.Connection_Status.AutoSize = true;
            this.Connection_Status.Location = new System.Drawing.Point(94, 58);
            this.Connection_Status.Name = "Connection_Status";
            this.Connection_Status.Size = new System.Drawing.Size(35, 13);
            this.Connection_Status.TabIndex = 1;
            this.Connection_Status.Text = "label2";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 58);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Process Status";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TAB_EmptyDB);
            this.panel1.Controls.Add(this.Group_Box_DB_Status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(779, 175);
            this.dataGridView1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data from the database";
            // 
            // TAB_EmptyDB
            // 
            this.TAB_EmptyDB.Controls.Add(this.tabPage1);
            this.TAB_EmptyDB.Controls.Add(this.tabPage2);
            this.TAB_EmptyDB.Controls.Add(this.tabPage3);
            this.TAB_EmptyDB.Location = new System.Drawing.Point(5, 10);
            this.TAB_EmptyDB.Name = "TAB_EmptyDB";
            this.TAB_EmptyDB.SelectedIndex = 0;
            this.TAB_EmptyDB.Size = new System.Drawing.Size(787, 104);
            this.TAB_EmptyDB.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EmptyDB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.BTN_Create_EmptyDB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 72);
            this.panel3.TabIndex = 0;
            // 
            // BTN_Create_EmptyDB
            // 
            this.BTN_Create_EmptyDB.Location = new System.Drawing.Point(3, 3);
            this.BTN_Create_EmptyDB.Name = "BTN_Create_EmptyDB";
            this.BTN_Create_EmptyDB.Size = new System.Drawing.Size(136, 23);
            this.BTN_Create_EmptyDB.TabIndex = 4;
            this.BTN_Create_EmptyDB.Text = "Create New Database";
            this.BTN_Create_EmptyDB.UseVisualStyleBackColor = true;
            this.BTN_Create_EmptyDB.Click += new System.EventHandler(this.BTN_Create_EmptyDB_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BTN_Show_Data2);
            this.tabPage2.Controls.Add(this.BTN_Show_Data);
            this.tabPage2.Controls.Add(this.BTN_Table_Create_and_Populate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BTN_Show_Data2
            // 
            this.BTN_Show_Data2.Location = new System.Drawing.Point(134, 36);
            this.BTN_Show_Data2.Name = "BTN_Show_Data2";
            this.BTN_Show_Data2.Size = new System.Drawing.Size(126, 23);
            this.BTN_Show_Data2.TabIndex = 7;
            this.BTN_Show_Data2.Text = "Show data in Table2";
            this.BTN_Show_Data2.UseVisualStyleBackColor = true;
            this.BTN_Show_Data2.Click += new System.EventHandler(this.BTN_Show_Data2_Click);
            // 
            // BTN_Show_Data
            // 
            this.BTN_Show_Data.Location = new System.Drawing.Point(7, 36);
            this.BTN_Show_Data.Name = "BTN_Show_Data";
            this.BTN_Show_Data.Size = new System.Drawing.Size(121, 23);
            this.BTN_Show_Data.TabIndex = 6;
            this.BTN_Show_Data.Text = "Show data in Table1";
            this.BTN_Show_Data.UseVisualStyleBackColor = true;
            this.BTN_Show_Data.Click += new System.EventHandler(this.BTN_Show_Data_Click);
            // 
            // BTN_Table_Create_and_Populate
            // 
            this.BTN_Table_Create_and_Populate.Location = new System.Drawing.Point(7, 7);
            this.BTN_Table_Create_and_Populate.Name = "BTN_Table_Create_and_Populate";
            this.BTN_Table_Create_and_Populate.Size = new System.Drawing.Size(156, 23);
            this.BTN_Table_Create_and_Populate.TabIndex = 0;
            this.BTN_Table_Create_and_Populate.Text = "Table Create and Populate";
            this.BTN_Table_Create_and_Populate.UseVisualStyleBackColor = true;
            this.BTN_Table_Create_and_Populate.Click += new System.EventHandler(this.BTN_Table_Create_and_Populate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BTN_ShrinkDB);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(779, 78);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Administration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BTN_ShrinkDB
            // 
            this.BTN_ShrinkDB.Location = new System.Drawing.Point(6, 3);
            this.BTN_ShrinkDB.Name = "BTN_ShrinkDB";
            this.BTN_ShrinkDB.Size = new System.Drawing.Size(115, 23);
            this.BTN_ShrinkDB.TabIndex = 0;
            this.BTN_ShrinkDB.Text = "Release Free Space";
            this.BTN_ShrinkDB.UseVisualStyleBackColor = true;
            this.BTN_ShrinkDB.Click += new System.EventHandler(this.BTN_ShrinkDB_Click);
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
            this.Group_Box_Panel.ResumeLayout(false);
            this.Group_Box_Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TAB_EmptyDB.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_Box_DB_Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Group_Box_Panel;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Connection_Status;
        private System.Windows.Forms.Button BTN_Create_EmptyDB;
        private System.Windows.Forms.TabControl TAB_EmptyDB;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Process_Error;
        private System.Windows.Forms.Button BTN_Table_Create_and_Populate;
        private System.Windows.Forms.Label DB_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DB_Directory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_Show_Data;
        private System.Windows.Forms.Button BTN_Show_Data2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BTN_ShrinkDB;
    }
}

