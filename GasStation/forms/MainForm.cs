using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GasStation.dal.data;
using GasStation.dal.man;
using GasStation.dal.obj;
using GasStation.dal.sta;

namespace GasStation
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        private double _totalRebate = 0;
        private bool _transactionEdit = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitRecords();
            InitFuelData();
            InitEmployees();
            InitCustomers();
        }

        private void LoadTransactionHistory(int iId)
        {
            Cursor.Current = Cursors.WaitCursor;
            bindingSource1.DataSource = TransactionManager.GetAll(iId);
            Cursor.Current = Cursors.Default;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage1);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (customerBindingSource?.DataSource == null) return;
            transactionBindingSource.DataSource = TransactionManager.GetAll(((Customer)customerBindingSource.Current).CustomerId);
            jTabWizard1.SelectTab(tabPage2);
            transactionReceiptNoWaterMarkTextBox.Focus();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage3);
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage4);
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage5);
        }

        private void fuelTypeMetroGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (fuelTypeBindingSource == null) return;
            if (fuelTypeMetroGrid.Rows.Count <= 1) return;
            if (!fuelTypeMetroGrid.IsCurrentRowDirty) return;
            Validate();
            fuelTypeBindingSource.EndEdit();
            var iResult = FuelTypeManger.Save((FuelType)fuelTypeBindingSource.Current);
            //toolStripStatusLabel1.Text = iResult > 0 ? @"Category saved successfully." : @"Error occurred when saving Unit.";
            if (iResult > 0)
                InitRecords();
        }

        private void InitRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            fuelTypeBindingSource.DataSource = FuelTypeManger.GetAll();
            Cursor.Current = Cursors.WaitCursor;
        }
        private void InitFuelData()
        {
            Cursor.Current = Cursors.WaitCursor;
            fuelDataBindingSource.DataSource = StandardQueries.GetFuelDatas();
            Cursor.Current = Cursors.WaitCursor;
        }

        private void InitCustomers()
        {
            Cursor.Current = Cursors.WaitCursor;
            customerBindingSource.DataSource = CustomerManager.GetAll();
            Cursor.Current = Cursors.Default;
        }
        private void InitEmployees()
        {
            Cursor.Current = Cursors.WaitCursor;
            employeeBindingSource.DataSource = EmployeeManager.GetAll();
            Cursor.Current = Cursors.Default;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            customerBindingSource.AddNew();
            customerCardNoWaterMarkTextBox.Focus();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (customerBindingSource == null) return;
            Validate();
            customerBindingSource.EndEdit();
            var iResult = CustomerManager.Save((Customer)customerBindingSource.Current);
            if (iResult > 0)
            {
                MessageBox.Show(@"Record was successfully saved.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                customerCardNoWaterMarkTextBox.Focus();
            }
            else
            {
                MessageBox.Show(@"Error occurred in saving.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            employeeBindingSource.AddNew();
            employeeNameWaterMarkTextBox.Focus();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (employeeBindingSource == null) return;
            Validate();
            employeeBindingSource.EndEdit();
            var iResult = EmployeeManager.Save((Employee)employeeBindingSource.Current);
            if (iResult > 0)
            {
                MessageBox.Show(@"Record was successfully saved.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                employeeNameWaterMarkTextBox.Focus();
            }
            else
            {
                MessageBox.Show(@"Error occurred in saving.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            transactionBindingSource.AddNew();
            transactionReceiptNoWaterMarkTextBox.Focus();
            _transactionEdit = true;
            ((Transaction)transactionBindingSource.Current).TransactionIsActive = true;
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (transactionBindingSource == null) return;
            Validate();
            ((Transaction) transactionBindingSource.Current).CustomerId =
                ((Customer) customerBindingSource.Current).CustomerId;
            ((Transaction)transactionBindingSource.Current).TransactionRebate = _totalRebate;
            transactionBindingSource.EndEdit();
            var iResult = TransactionManager.Save((Transaction)transactionBindingSource.Current);
            if (iResult > 0)
            {
                MessageBox.Show(@"Record was successfully saved.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transactionReceiptNoWaterMarkTextBox.Focus();
            }
            else
            {
                MessageBox.Show(@"Error occurred in saving.", @"Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            _transactionEdit = false;
        }

        private void customerMetroGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerBindingSource?.DataSource == null) return;
            transactionBindingSource.DataSource = TransactionManager.GetAll(((Customer) customerBindingSource.Current).CustomerId);
            jTabWizard1.SelectTab(tabPage2);
        }

        private void fuelDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!_transactionEdit) return;
            if (fuelDataBindingSource?.Current == null) return;
            var rebate = Convert.ToDouble(((FuelData)fuelDataBindingSource.Current).FuelTypeRebate);
            if (transactionLitersTextBox.Text.Length > 0)
                _totalRebate = Convert.ToDouble(transactionLitersTextBox.Text.Trim()) * rebate;
            transactionRebateTextBox.Text = _totalRebate.ToString(CultureInfo.InvariantCulture);
            ((Transaction)transactionBindingSource.Current).TransactionRebate = _totalRebate;
        }

        private void fuelDataBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            
        }

        private void fuelTypeIdComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (fuelDataBindingSource?.Current == null) return;
            var rebate = Convert.ToDouble(((FuelData)fuelDataBindingSource.Current).FuelTypeRebate);
            if (transactionLitersTextBox.Text.Length > 0)
                _totalRebate = Convert.ToDouble(transactionLitersTextBox.Text.Trim()) * rebate;
            transactionRebateTextBox.Text = _totalRebate.ToString(CultureInfo.InvariantCulture);
            if (!_transactionEdit) return;
            ((Transaction)transactionBindingSource.Current).TransactionRebate = _totalRebate;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == tabPage7)
            {
                if (customerBindingSource?.Current == null) return;
                LoadTransactionHistory(((Customer) customerBindingSource.Current).CustomerId);
            }
        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (customerBindingSource?.Current == null) return;
            LoadTransactionHistory(((Customer)customerBindingSource.Current).CustomerId);
        }
        //======DeleteBtn===//
        private void metroButton2_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }
        private void DeleteCustomer()
        {
            if (customerBindingSource == null) return;
            Validate();
            var dResult = MessageBox.Show(@"Are you sure you want to Delete Customer Record?", @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if ((CustomerManager.Delete(((Customer)customerBindingSource.Current).CustomerId)))
            {
                MessageBox.Show(@"Customer is Deleted successfully..", @"Delete", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                customerBindingSource.RemoveCurrent();
            }
            else
            {
                MessageBox.Show(@"Error occured in Deleting Customers Record..",@"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //==DeleteTransaction==//
        private void metroButton11_Click(object sender, EventArgs e)
        {
            DeleteTransaction();
        }
        private void DeleteTransaction()
        {
            if (transactionBindingSource == null) return;
            Validate();
            var dResult = MessageBox.Show(@"Are you sure you want to Delete Transaction?", @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            if ((TransactionManager.Delete(((Transaction)transactionBindingSource.Current).TransactionId)))
            {
                MessageBox.Show(@"Transaction is Deleted sucessfully.", @"Delete", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transactionBindingSource.RemoveCurrent();
            }
            else
            {
                MessageBox.Show(@"Error occured in Deleting Transaction Record..", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //== DeleteEmployee===//
        private void metroButton7_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }
        private void DeleteEmployee()
        {
            if (employeeBindingSource == null) return;
            Validate();
            var dResult = MessageBox.Show(@"Are you sure you want to Delete Employee?", @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            if ((EmployeeManager.Delete(((Employee)employeeBindingSource.Current).EmployeeId)))
            {
                MessageBox.Show(@"Employee is Deleted successfully", @"Delete", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                employeeBindingSource.RemoveCurrent();
            }
            else
            {
                MessageBox.Show(@"Error is occured in Deleting Employee..",@"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            fuelDataBindingSource.AddNew();
        }
    }
}
