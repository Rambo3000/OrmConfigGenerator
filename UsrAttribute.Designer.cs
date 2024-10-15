namespace OrmConfigGenerator
{
    partial class UsrAttribute
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboOracleDataType = new ComboBox();
            txtPrecisionBefore = new TextBox();
            txtPrecisionAfter = new TextBox();
            lblSize = new Label();
            chkAttributeName = new CheckBox();
            txtSize = new TextBox();
            pnlOptions = new Panel();
            chkPrimaryKey = new CheckBox();
            lblBlueriqType = new Label();
            lblSeperator = new Label();
            pnlOptions.SuspendLayout();
            SuspendLayout();
            // 
            // cboOracleDataType
            // 
            cboOracleDataType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboOracleDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOracleDataType.FormattingEnabled = true;
            cboOracleDataType.Location = new Point(107, 0);
            cboOracleDataType.Name = "cboOracleDataType";
            cboOracleDataType.Size = new Size(86, 23);
            cboOracleDataType.TabIndex = 1;
            cboOracleDataType.SelectedIndexChanged += CboOracleDataType_SelectedIndexChanged;
            // 
            // txtPrecisionBefore
            // 
            txtPrecisionBefore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrecisionBefore.Location = new Point(233, 0);
            txtPrecisionBefore.Name = "txtPrecisionBefore";
            txtPrecisionBefore.Size = new Size(48, 23);
            txtPrecisionBefore.TabIndex = 2;
            // 
            // txtPrecisionAfter
            // 
            txtPrecisionAfter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrecisionAfter.Location = new Point(287, 0);
            txtPrecisionAfter.Name = "txtPrecisionAfter";
            txtPrecisionAfter.Size = new Size(48, 23);
            txtPrecisionAfter.TabIndex = 3;
            // 
            // lblSize
            // 
            lblSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSize.AutoSize = true;
            lblSize.Location = new Point(200, 3);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(27, 15);
            lblSize.TabIndex = 4;
            lblSize.Text = "Size";
            // 
            // chkAttributeName
            // 
            chkAttributeName.AutoSize = true;
            chkAttributeName.Location = new Point(0, 1);
            chkAttributeName.Name = "chkAttributeName";
            chkAttributeName.Size = new Size(58, 19);
            chkAttributeName.TabIndex = 5;
            chkAttributeName.Text = "Name";
            chkAttributeName.UseVisualStyleBackColor = true;
            chkAttributeName.CheckedChanged += ChkAttributeName_CheckedChanged;
            // 
            // txtSize
            // 
            txtSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSize.Location = new Point(233, 0);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(48, 23);
            txtSize.TabIndex = 7;
            // 
            // pnlOptions
            // 
            pnlOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlOptions.Controls.Add(chkPrimaryKey);
            pnlOptions.Controls.Add(lblBlueriqType);
            pnlOptions.Controls.Add(cboOracleDataType);
            pnlOptions.Controls.Add(txtSize);
            pnlOptions.Controls.Add(txtPrecisionBefore);
            pnlOptions.Controls.Add(txtPrecisionAfter);
            pnlOptions.Controls.Add(lblSize);
            pnlOptions.Controls.Add(lblSeperator);
            pnlOptions.Location = new Point(73, -1);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(374, 26);
            pnlOptions.TabIndex = 8;
            pnlOptions.Visible = false;
            // 
            // chkPrimaryKey
            // 
            chkPrimaryKey.AutoSize = true;
            chkPrimaryKey.Location = new Point(341, 2);
            chkPrimaryKey.Name = "chkPrimaryKey";
            chkPrimaryKey.Size = new Size(40, 19);
            chkPrimaryKey.TabIndex = 9;
            chkPrimaryKey.Text = "PK";
            chkPrimaryKey.UseVisualStyleBackColor = true;
            // 
            // lblBlueriqType
            // 
            lblBlueriqType.Location = new Point(20, -1);
            lblBlueriqType.Name = "lblBlueriqType";
            lblBlueriqType.Size = new Size(85, 23);
            lblBlueriqType.TabIndex = 8;
            lblBlueriqType.Text = "→";
            lblBlueriqType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSeperator
            // 
            lblSeperator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeperator.AutoSize = true;
            lblSeperator.Location = new Point(280, 3);
            lblSeperator.Name = "lblSeperator";
            lblSeperator.Size = new Size(10, 15);
            lblSeperator.TabIndex = 10;
            lblSeperator.Text = ",";
            // 
            // UsrAttribute
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(chkAttributeName);
            Controls.Add(pnlOptions);
            Name = "UsrAttribute";
            Size = new Size(447, 22);
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cboOracleDataType;
        private TextBox txtPrecisionBefore;
        private TextBox txtPrecisionAfter;
        private Label lblSize;
        private CheckBox chkAttributeName;
        private TextBox txtSize;
        private Panel pnlOptions;
        private Label lblBlueriqType;
        private Label lblSeperator;
        private CheckBox chkPrimaryKey;
    }
}
