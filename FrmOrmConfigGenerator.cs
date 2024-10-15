using OrmConfigGenerator.Blueriq;
using OrmConfigGenerator.ConfigGenerators;
using OrmConfigGenerator.Extensions;
using OrmConfigGenerator.XmlParser;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;
using Branch = OrmConfigGenerator.Blueriq.Branch;
using CheckBox = System.Windows.Forms.CheckBox;


namespace OrmConfigGenerator
{
    public partial class FrmOrmConfigGenerator : Form
    {
        private readonly System.Windows.Forms.Timer resizeTimer;

        public FrmOrmConfigGenerator()
        {
            InitializeComponent();

            resizeTimer = new()
            {
                Interval = 500
            };
            resizeTimer.Tick += ResizeTimer_Tick;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            Clear();

            string? filename = GetFileNameFromDialog();
            if (filename == null) return;

            lblFilename.Text = filename;
            Branch branch = BlueriqExportParser.ParseXmlToBranch(filename);
            PopulateTrunkAndProjects(branch);
        }

        public void PopulateTrunkAndProjects(Branch branch)
        {
            lblBranchValue.Text = branch.ToString();
            foreach (Project project in branch.Projects)
            {
                // Check if the project has at least one entity in any module
                bool hasEntities = project.Modules.Any(module => module.Entities.Count > 0);

                if (!hasEntities) continue;  // Skip the project if no entities are found in its modules

                cboProjects.Items.Add(project);
            }
            if (cboProjects.Items.Count > 0) cboProjects.SelectedIndex = 0;
        }

        public void Clear()
        {
            lblBranchValue.Text = "";
            cboProjects.Items.Clear();
        }

        public static string? GetFileNameFromDialog()
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\"; // Set initial directory
            openFileDialog.Filter = "XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Set filter for XML files
            openFileDialog.FilterIndex = 1; // Set default filter index
            openFileDialog.RestoreDirectory = true; // Restore directory after closing

            // Show the dialog and check if a file was selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }

            return null; // Return null if no file was selected
        }

        private void CboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjects.SelectedItem is not Project project) return;

            cboModules.Items.Clear();
            if (project.Modules.Count == 0) return;

            cboModules.Items.AddRange([.. project.Modules]);
            if (cboModules.Items.Count > 0) cboModules.SelectedIndex = 0;
        }

        private void CboModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            if (cboModules.SelectedItem is not Module module) return;

            foreach (Entity entity in module.Entities)
            {
                CheckBox checkBox = new()
                {
                    Text = entity.Name,
                    Tag = entity,
                    AutoSize = true
                };
                checkBox.Font = new Font(checkBox.Font, FontStyle.Bold);
                checkBox.CheckedChanged += EntityCheckBox_CheckedChanged;
                flowLayoutPanel1.Controls.Add(checkBox);

                foreach (Attribute attribute in entity.Attributes)
                {
                    UsrAttribute userControl = new();
                    userControl.SetAttribute(attribute);
                    userControl.Width = flowLayoutPanel1.Width;
                    userControl.Padding = new(20, 0, 0, 0);
                    userControl.Margin = new(0, 0, 0, 0);
                    userControl.Tag = entity;
                    userControl.CheckChanged += AttributeCheckBox_CheckedChanged;
                    flowLayoutPanel1.Controls.Add(userControl);
                }
            }
        }
        private bool disableEntityCheckBoxUpdate = false;
        private void EntityCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (disableEntityCheckBoxUpdate) return;

            if (sender is not CheckBox entityCheckbox) return;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is not UsrAttribute attributeCheckbox) continue;

                if (attributeCheckbox.Tag != entityCheckbox.Tag) continue;

                attributeCheckbox.Checked = entityCheckbox.Checked;
            }
        }
        private void AttributeCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not UsrAttribute attributeCheckbox) return;

            if (attributeCheckbox.Checked == false) return;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is not CheckBox entityCheckbox) continue;

                if (attributeCheckbox.Tag != entityCheckbox.Tag) continue;

                disableEntityCheckBoxUpdate = true;
                entityCheckbox.Checked = true;
                disableEntityCheckBoxUpdate = false;
                break;
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is not UsrAttribute attributeCheckbox) continue;

                attributeCheckbox.SaveChanges();
            }
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is not CheckBox checkboxEntity) continue;
                if (checkboxEntity.Tag is not Entity entity) continue;

                entity.UseForExport = checkboxEntity.Checked;
            }
            if (cboModules.SelectedItem is not Module module) return;

            txtLiquibaseScript.Text = LiquiBaseConfigGenerator.GenerateLiquiBaseScript(module, txtAuthor.Text, txtChangeSetId.Text);
            txtORMScheme.Text = OrmSchemaGenerator.Generate(module);
        }
        
        private void FlowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            // Reset the timer every time the resize event is triggered
            resizeTimer.Stop();
            resizeTimer.Start();
        }
        private void ResizeTimer_Tick(object? sender, EventArgs e)
        {
            // Stop the timer
            resizeTimer.Stop();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.SuspendDrawing();
            }
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.Width = flowLayoutPanel1.Width - 25;
            }
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.ResumeDrawing();
            }
        }
    }
}
