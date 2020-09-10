namespace MstTableClassGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public partial class TableClassGeneratorForm : Form
    {
        TableClassGenerator tableGenerator;
        ClassPrinter clsPrint;
        public TableClassGeneratorForm()
        {
            InitializeComponent();
            tableGenerator = new TableClassGenerator();
            clsPrint = new ClassPrinter();
        }


        #region [ Form Load - 0 ]

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                cmbConnectionType.DataSource = AppConfiguration.Settings.ConnTypes;
            }
            catch (Exception exc)
            {
                LogException(exc, 0);
            }
        }

        #endregion


        #region [ txtNameSpace Text Changing Event ]

        private void txtNameSpaceTextChangeEvent(object sender, EventArgs e)
        {
            clsPrint.ClassNameSpace = txtNameSpace.Text;
        }

        #endregion


        #region [ Method of Selected Index Changed of cmbConnectionTypes - 1 ]

        private void cmbConnectionTypeIndexChange(object sender, EventArgs e)
        {
            try
            {

                if (cmbConnectionType.SelectedIndex != -1)
                {
                    txtConnectionString.Text = AppConfiguration.Settings[
                        cmbConnectionType.Items[cmbConnectionType.SelectedIndex].ToString()].ToString();
                }
                else
                    txtConnectionString.Text = string.Empty;
            }
            catch (Exception exc)
            {
                LogException(exc, 1);
            }
            finally
            {
                TableClassGenerator.ConnStr = txtConnectionString.Text;
                TableClassGenerator.Index = cmbConnectionType.SelectedIndex;
            }
        }

        #endregion


        #region [ btnBrowse Click event - 2 ]

        private void Browse(object sender, EventArgs e)
        {
            try
            {
                browserDestinationDialog.Description = "Directory to Save Files";
                DialogResult dialogRes = browserDestinationDialog.ShowDialog();

                if (dialogRes == DialogResult.OK)
                {
                    clsPrint.SavingPath = browserDestinationDialog.SelectedPath;
                    txtSaveToPath.Text = clsPrint.SavingPath;
                }

            }
            catch (Exception exc)
            {
                tbpgLog.Select();
                LogException(exc, 2);
            }
        }

        #endregion


        #region [ btnGenerate Click event - 3 ]

        private void Generate(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(clsPrint.SavingPath))
                {
                    MessageBox.Show("Saving Path is not empty.");
                    return;
                }
                string namSpace = clsPrint.ClassNameSpace;
                if (!NameSpaceController.ControlNameSpace(namSpace))
                {
                    MessageBox.Show("NameSpace includes forbidden characters.");
                    return;
                }
                if (namSpace.ToCharArray()[0].Equals('.') || namSpace.ToCharArray()[namSpace.Length - 1].Equals('.'))
                {
                    MessageBox.Show("NameSpace could not start and end with '.'");
                    return;
                }
                chklstTables.Enabled = false;
                Generate();
                MessageBox.Show("All Tables created.", "Result Info:");
            }
            catch (Exception exc)
            {
                tbpgLog.Select();
                LogException(exc, 3);
            }
            finally
            {
                chklstTables.Enabled = true;
            }
        }

        private void Generate()
        {
            List<ClassTable> tables = new List<ClassTable>();
            foreach (var item in chklstTables.CheckedItems)
            {
                tables.Add(new ClassTable()
                {
                    TableName = item.ToString()
                });
            }

            foreach (var item in tables)
            {
                item.TableColumns = tableGenerator.GetColumnsOfTable(item.TableName);
            }
            foreach (var item in tables)
            {
                item.IdColumn = tableGenerator.GetIdColumnOfTable(item.TableName);
            }

            clsPrint.PrintClassTable(tables);
            StringBuilder sBuilder = new StringBuilder();
            foreach (ClassTable cls in tables)
            {
                sBuilder.AppendFormat("{0},\n", cls.TableName);
            }
            StringBuilder newBuilder = new StringBuilder(
                sBuilder.ToString().Substring(0, sBuilder.ToString().Length - 1));
            newBuilder.AppendLine(" tables created.");
            txtLog.AppendText(newBuilder.ToString());
        }

        #endregion


        #region [ btnGetTables Click event - 5 ]
        private void GetTables(object sender, EventArgs e)
        {
            try
            {
                chklstTables.Items.Clear();
                List<ClassTable> tables = tableGenerator.GetTableList();
                foreach (ClassTable clazztable in tables)
                {
                    chklstTables.Items.Add(clazztable.TableName, CheckState.Checked);
                }
            }
            catch (Exception exc)
            {
                tbpgLog.Select();
                LogException(exc, 5);
            }
        }
        #endregion


        #region [ LogException method ]

        private void LogException(Exception exc, int exceptionType)
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat(
                    "\nException Date: {0}\n", DateTime.Now.ToString("hh:mm:ss dd.MM.yyyy")).AppendFormat(
                    "Exception Type: {0}\n", exceptionType).AppendFormat(
                    "Exception Message: {0}\n", exc.Message).AppendFormat(
                    "Exception Stack Trace: {0}\n", exc.StackTrace);

                txtLog.AppendText(strBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "An Error has occured.");
            }
        }

        #endregion



        #region [ Save Settings - 5 ]

        private void SaveSettings(object sender, EventArgs e)
        {
            try
            {

                AppConfiguration.Settings.SaveSetting(
                    cmbConnectionType.SelectedItem.ToString(), txtConnectionString.Text);

                int index = cmbConnectionType.SelectedIndex;
                cmbConnectionType.SelectedIndex = index != -1 ? (index + 1) % cmbConnectionType.Items.Count : -1;
                cmbConnectionType.SelectedIndex = index;
            }
            catch (Exception exc)
            {
                tbpgLog.Select();
                LogException(exc, 5);
            }
        }

        #endregion


    }
}
