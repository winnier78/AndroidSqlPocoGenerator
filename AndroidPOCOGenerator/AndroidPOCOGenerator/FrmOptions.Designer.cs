namespace AndroidPOCOGenerator
{
    partial class FrmOptions
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ckImports = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.ckAllObjects = new System.Windows.Forms.CheckBox();
            this.ObjectList = new System.Windows.Forms.CheckedListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtClass = new System.Windows.Forms.RichTextBox();
            this.ckTableName = new System.Windows.Forms.CheckBox();
            this.ckAllColumnsString = new System.Windows.Forms.CheckBox();
            this.ckAllColumnsArray = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDml = new System.Windows.Forms.RadioButton();
            this.rbDdl = new System.Windows.Forms.RadioButton();
            this.rbDao = new System.Windows.Forms.RadioButton();
            this.rbPoco = new System.Windows.Forms.RadioButton();
            this.ckColumnNameStrings = new System.Windows.Forms.CheckBox();
            this.ckProperties = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(909, 459);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ckImports);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.txtPackage);
            this.splitContainer3.Panel1.Controls.Add(this.ckAllObjects);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ObjectList);
            this.splitContainer3.Panel2MinSize = 30;
            this.splitContainer3.Size = new System.Drawing.Size(334, 459);
            this.splitContainer3.TabIndex = 1;
            // 
            // ckImports
            // 
            this.ckImports.AutoSize = true;
            this.ckImports.Checked = true;
            this.ckImports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckImports.Location = new System.Drawing.Point(111, 9);
            this.ckImports.Name = "ckImports";
            this.ckImports.Size = new System.Drawing.Size(60, 17);
            this.ckImports.TabIndex = 3;
            this.ckImports.Text = "Imports";
            this.ckImports.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Package Name:";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(111, 28);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(220, 20);
            this.txtPackage.TabIndex = 1;
            this.txtPackage.Text = "com.logistika360grados.ddl";
            // 
            // ckAllObjects
            // 
            this.ckAllObjects.AutoSize = true;
            this.ckAllObjects.Location = new System.Drawing.Point(15, 9);
            this.ckAllObjects.Name = "ckAllObjects";
            this.ckAllObjects.Size = new System.Drawing.Size(70, 17);
            this.ckAllObjects.TabIndex = 0;
            this.ckAllObjects.Text = "Select All";
            this.ckAllObjects.UseVisualStyleBackColor = true;
            this.ckAllObjects.CheckStateChanged += new System.EventHandler(this.ckAllObjects_CheckStateChanged);
            // 
            // ObjectList
            // 
            this.ObjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectList.FormattingEnabled = true;
            this.ObjectList.Location = new System.Drawing.Point(0, 0);
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.Size = new System.Drawing.Size(334, 405);
            this.ObjectList.TabIndex = 0;
            this.ObjectList.SelectedIndexChanged += new System.EventHandler(this.ObjectList_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtClass);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ckTableName);
            this.splitContainer2.Panel2.Controls.Add(this.ckAllColumnsString);
            this.splitContainer2.Panel2.Controls.Add(this.ckAllColumnsArray);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.ckColumnNameStrings);
            this.splitContainer2.Panel2.Controls.Add(this.ckProperties);
            this.splitContainer2.Size = new System.Drawing.Size(571, 459);
            this.splitContainer2.SplitterDistance = 255;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtClass
            // 
            this.txtClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClass.Location = new System.Drawing.Point(0, 0);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(571, 255);
            this.txtClass.TabIndex = 0;
            this.txtClass.Text = "";
            // 
            // ckTableName
            // 
            this.ckTableName.AutoSize = true;
            this.ckTableName.Checked = true;
            this.ckTableName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTableName.Location = new System.Drawing.Point(103, 37);
            this.ckTableName.Name = "ckTableName";
            this.ckTableName.Size = new System.Drawing.Size(84, 17);
            this.ckTableName.TabIndex = 5;
            this.ckTableName.Text = "Table Name";
            this.ckTableName.UseVisualStyleBackColor = true;
            this.ckTableName.CheckStateChanged += new System.EventHandler(this.ckTableName_CheckStateChanged);
            // 
            // ckAllColumnsString
            // 
            this.ckAllColumnsString.AutoSize = true;
            this.ckAllColumnsString.Checked = true;
            this.ckAllColumnsString.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAllColumnsString.Location = new System.Drawing.Point(367, 13);
            this.ckAllColumnsString.Name = "ckAllColumnsString";
            this.ckAllColumnsString.Size = new System.Drawing.Size(110, 17);
            this.ckAllColumnsString.TabIndex = 4;
            this.ckAllColumnsString.Text = "All Columns String";
            this.ckAllColumnsString.UseVisualStyleBackColor = true;
            this.ckAllColumnsString.CheckStateChanged += new System.EventHandler(this.ckAllColumnsString_CheckStateChanged);
            // 
            // ckAllColumnsArray
            // 
            this.ckAllColumnsArray.AutoSize = true;
            this.ckAllColumnsArray.Checked = true;
            this.ckAllColumnsArray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAllColumnsArray.Location = new System.Drawing.Point(253, 13);
            this.ckAllColumnsArray.Name = "ckAllColumnsArray";
            this.ckAllColumnsArray.Size = new System.Drawing.Size(107, 17);
            this.ckAllColumnsArray.TabIndex = 3;
            this.ckAllColumnsArray.Text = "All Columns Array";
            this.ckAllColumnsArray.UseVisualStyleBackColor = true;
            this.ckAllColumnsArray.CheckStateChanged += new System.EventHandler(this.ckAllColumnsArray_CheckStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDml);
            this.groupBox1.Controls.Add(this.rbDdl);
            this.groupBox1.Controls.Add(this.rbDao);
            this.groupBox1.Controls.Add(this.rbPoco);
            this.groupBox1.Location = new System.Drawing.Point(13, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(74, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Type";
            // 
            // rbDml
            // 
            this.rbDml.AutoSize = true;
            this.rbDml.Location = new System.Drawing.Point(7, 90);
            this.rbDml.Name = "rbDml";
            this.rbDml.Size = new System.Drawing.Size(48, 17);
            this.rbDml.TabIndex = 7;
            this.rbDml.TabStop = true;
            this.rbDml.Text = "DML";
            this.rbDml.UseVisualStyleBackColor = true;
            // 
            // rbDdl
            // 
            this.rbDdl.AutoSize = true;
            this.rbDdl.Location = new System.Drawing.Point(7, 66);
            this.rbDdl.Name = "rbDdl";
            this.rbDdl.Size = new System.Drawing.Size(47, 17);
            this.rbDdl.TabIndex = 6;
            this.rbDdl.Text = "DDL";
            this.rbDdl.UseVisualStyleBackColor = true;
            // 
            // rbDao
            // 
            this.rbDao.AutoSize = true;
            this.rbDao.Location = new System.Drawing.Point(6, 42);
            this.rbDao.Name = "rbDao";
            this.rbDao.Size = new System.Drawing.Size(48, 17);
            this.rbDao.TabIndex = 5;
            this.rbDao.Text = "DAO";
            this.rbDao.UseVisualStyleBackColor = true;
            this.rbDao.CheckedChanged += new System.EventHandler(this.rbDao_CheckedChanged);
            // 
            // rbPoco
            // 
            this.rbPoco.AutoSize = true;
            this.rbPoco.Checked = true;
            this.rbPoco.Location = new System.Drawing.Point(6, 19);
            this.rbPoco.Name = "rbPoco";
            this.rbPoco.Size = new System.Drawing.Size(55, 17);
            this.rbPoco.TabIndex = 4;
            this.rbPoco.TabStop = true;
            this.rbPoco.Text = "POCO";
            this.rbPoco.UseVisualStyleBackColor = true;
            this.rbPoco.CheckedChanged += new System.EventHandler(this.rbPoco_CheckedChanged);
            // 
            // ckColumnNameStrings
            // 
            this.ckColumnNameStrings.AutoSize = true;
            this.ckColumnNameStrings.Checked = true;
            this.ckColumnNameStrings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckColumnNameStrings.Location = new System.Drawing.Point(103, 13);
            this.ckColumnNameStrings.Name = "ckColumnNameStrings";
            this.ckColumnNameStrings.Size = new System.Drawing.Size(121, 17);
            this.ckColumnNameStrings.TabIndex = 1;
            this.ckColumnNameStrings.Text = "ColumnNameStrings";
            this.ckColumnNameStrings.UseVisualStyleBackColor = true;
            this.ckColumnNameStrings.CheckStateChanged += new System.EventHandler(this.ckColumnNameStrings_CheckStateChanged);
            // 
            // ckProperties
            // 
            this.ckProperties.AutoSize = true;
            this.ckProperties.Checked = true;
            this.ckProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProperties.Location = new System.Drawing.Point(14, 13);
            this.ckProperties.Name = "ckProperties";
            this.ckProperties.Size = new System.Drawing.Size(73, 17);
            this.ckProperties.TabIndex = 0;
            this.ckProperties.Text = "Properties";
            this.ckProperties.UseVisualStyleBackColor = true;
            this.ckProperties.CheckStateChanged += new System.EventHandler(this.ckProperties_CheckStateChanged);
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 459);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatabaseObjects";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckedListBox ObjectList;
        private System.Windows.Forms.RichTextBox txtClass;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.CheckBox ckAllObjects;
        private System.Windows.Forms.CheckBox ckProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.CheckBox ckImports;
        private System.Windows.Forms.CheckBox ckColumnNameStrings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDdl;
        private System.Windows.Forms.RadioButton rbDao;
        private System.Windows.Forms.RadioButton rbPoco;
        private System.Windows.Forms.CheckBox ckAllColumnsString;
        private System.Windows.Forms.CheckBox ckAllColumnsArray;
        private System.Windows.Forms.RadioButton rbDml;
        private System.Windows.Forms.CheckBox ckTableName;
    }
}

