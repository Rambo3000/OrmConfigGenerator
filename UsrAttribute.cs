using OrmConfigGenerator.Blueriq;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;

namespace OrmConfigGenerator
{
    public partial class UsrAttribute : UserControl
    {
        public event EventHandler? CheckChanged;

        private Attribute attribute;

        public bool Checked
        {
            get
            {
                return chkAttributeName.Checked;
            }
            set
            {
                chkAttributeName.Checked = value;
            }
        }

        public UsrAttribute()
        {
            InitializeComponent();

            txtSize.TextChanged += TxtSize_TextChanged;
            txtPrecisionBefore.TextChanged += TxtPrecision_TextChanged;
            txtPrecisionAfter.TextChanged += TxtPrecision_TextChanged;

            attribute = new(string.Empty, BlueriqDataType.Integer, false, string.Empty, string.Empty);
        }

        // Pass the attribute to the user control and populate the fields
        public void SetAttribute(Attribute attribute)
        {
            this.attribute = attribute;

            // Set the initial values
            chkAttributeName.Text = this.attribute.Name;
            string multiValue = attribute.MultiValued ? " (multivalued)" : "";
            lblBlueriqType.Text = attribute.BlueriqDataType + multiValue + " →";
            cboOracleDataType.SelectedItem = this.attribute.OracleDataType.ToString();

            if (attribute.BlueriqDataType == BlueriqDataType.Integer)
            {
                txtPrecisionAfter.Text = "0";
            }
            if (attribute.BlueriqDataType == BlueriqDataType.Boolean)
            {
                txtPrecisionBefore.Text = "1";
                txtPrecisionAfter.Text = "0";
            }

            PopulateOracleDataTypeCombo(attribute);

            UpdateControlsForDataType();

            ValidateTextBoxes();
        }

        // Populate the Oracle Data Type ComboBox
        private void PopulateOracleDataTypeCombo(Attribute attribute)
        {
            bool IsString = attribute.MultiValued || attribute.BlueriqDataType == BlueriqDataType.Text;

            cboOracleDataType.Enabled = IsString;
            cboOracleDataType.Items.Clear();
            if (IsString)
            {
                cboOracleDataType.Items.AddRange(
                [
                    OracleDataType.VARCHAR2.ToString(),
                    OracleDataType.CLOB.ToString()
                ]);
            }
            else cboOracleDataType.Items.Add(attribute.OracleDataType);
            cboOracleDataType.SelectedIndex = 0;
        }

        // Control visibility and options based on OracleDataType
        private void UpdateControlsForDataType()
        {
            bool showPrecision = attribute.BlueriqDataType == BlueriqDataType.Integer
                || attribute.BlueriqDataType == BlueriqDataType.Number
                || attribute.BlueriqDataType == BlueriqDataType.Currency
                || attribute.BlueriqDataType == BlueriqDataType.Percentage
                || attribute.BlueriqDataType == BlueriqDataType.Boolean;
            bool isFloat = attribute.BlueriqDataType == BlueriqDataType.Number
                || attribute.BlueriqDataType == BlueriqDataType.Currency
                || attribute.BlueriqDataType == BlueriqDataType.Percentage;

            if (cboOracleDataType == null || cboOracleDataType.SelectedItem == null) return;

            bool showSize = cboOracleDataType.SelectedItem.ToString() == OracleDataType.VARCHAR2.ToString();

            txtPrecisionBefore.Visible = showPrecision;
            txtPrecisionBefore.Enabled = attribute.BlueriqDataType == BlueriqDataType.Integer
                || attribute.BlueriqDataType == BlueriqDataType.Number
                || attribute.BlueriqDataType == BlueriqDataType.Currency
                || attribute.BlueriqDataType == BlueriqDataType.Percentage;

            txtPrecisionAfter.Visible = showPrecision;
            lblSeperator.Visible = showPrecision;
            txtPrecisionAfter.Enabled = isFloat;

            txtSize.Visible = showSize;
            lblSize.Visible = showPrecision || showSize;

            chkPrimaryKey.Visible = !isFloat;
        }

        // Save the modified settings back to the attribute object
        public void SaveChanges()
        {
            attribute.UseForExport = chkAttributeName.Checked;
            attribute.UseClob = (cboOracleDataType.SelectedItem != null && cboOracleDataType.SelectedItem.ToString() == OracleDataType.CLOB.ToString());
            attribute.IsPrimaryKey = chkPrimaryKey.Checked;

            if (int.TryParse(txtSize.Text, out int size))
                attribute.Size = size;

            if (int.TryParse(txtPrecisionBefore.Text, out int precisionBefore))
                attribute.PrecisionBeforeSeperator = precisionBefore;

            if (int.TryParse(txtPrecisionAfter.Text, out int precisionAfter))
                attribute.PrecisionAfterSeperator = precisionAfter;
        }

        public Attribute GetAttribute()
        {
            SaveChanges();
            return attribute;
        }

        private void ChkAttributeName_CheckedChanged(object sender, EventArgs e)
        {
            pnlOptions.Visible = chkAttributeName.Checked;
            OnCheckChanged();
        }

        private void CboOracleDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsForDataType();
        }
        protected virtual void OnCheckChanged()
        {
            // Only raise the event if there are subscribers
            CheckChanged?.Invoke(this, new EventArgs());
        }

        // Event handler for Size TextBox
        private void TxtSize_TextChanged(object? sender, EventArgs e)
        {
            if (attribute.OracleDataType == OracleDataType.VARCHAR2)
            {
                ValidateTextBoxes(); // Validate the field when text changes
            }
        }

        // Event handler for Precision TextBoxes
        private void TxtPrecision_TextChanged(object? sender, EventArgs e)
        {
            if (attribute.OracleDataType == OracleDataType.NUMBER)
            {
                ValidateTextBoxes(); // Validate the precision fields when text changes
            }
        }

        private static bool IsValidInteger(string text)
        {
            return int.TryParse(text, out _);
        }

        // Validation method to check if the Size and Precision fields should be filled and valid
        private void ValidateTextBoxes()
        {
            // Validate Size for VARCHAR2
            if (attribute.OracleDataType == OracleDataType.VARCHAR2)
            {
                if (string.IsNullOrEmpty(txtSize.Text) || !IsValidInteger(txtSize.Text))
                {
                    txtSize.BackColor = Color.LightPink; // Highlight the invalid field
                }
                else
                {
                    txtSize.BackColor = SystemColors.Window; // Reset to default color if valid
                }
            }

            // Validate Precision for NUMBER
            if (attribute.OracleDataType == OracleDataType.NUMBER)
            {
                // Validate PrecisionBeforeSeparator
                if (string.IsNullOrEmpty(txtPrecisionBefore.Text) && string.IsNullOrEmpty(txtPrecisionAfter.Text) && 
                    (attribute.BlueriqDataType == BlueriqDataType.Currency|| attribute.BlueriqDataType == BlueriqDataType.Percentage|| attribute.BlueriqDataType == BlueriqDataType.Number))
                {
                    txtPrecisionBefore.BackColor = SystemColors.Window;
                    txtPrecisionAfter.BackColor = SystemColors.Window;
                    return;
                }

                // Validate PrecisionBeforeSeparator
                if (string.IsNullOrEmpty(txtPrecisionBefore.Text) || !IsValidInteger(txtPrecisionBefore.Text))
                {
                    txtPrecisionBefore.BackColor = Color.LightPink;
                }
                else
                {
                    txtPrecisionBefore.BackColor = SystemColors.Window;
                }

                // Validate PrecisionAfterSeparator
                if (string.IsNullOrEmpty(txtPrecisionAfter.Text) || !IsValidInteger(txtPrecisionAfter.Text))
                {
                    txtPrecisionAfter.BackColor = Color.LightPink;
                }
                else
                {
                    txtPrecisionAfter.BackColor = SystemColors.Window;
                }
            }
        }

    }
}
