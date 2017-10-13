using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using UtilityManager.ui;

namespace UtilityManager.util
{
    public class UtilClass
    {
        #region "Excel Import"
        //public static List<Enrollee> ImportEnrollees(string path)
        //{
        //    var listEnrollee = new List<Enrollee>();
        //    var app = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        //    var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

        //    int index = 0;
        //    object rowIndex = 2;

        //    try
        //    {
        //        while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
        //        {
        //            rowIndex = 2 + index;
        //            var enrollee = new Enrollee();
        //            enrollee.EnrolleeNo = Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
        //            enrollee.EnrolleeIdNo = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
        //            enrollee.LastName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);
        //            enrollee.FirstName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 3]).Value2);
        //            enrollee.MiddleName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 4]).Value2);
        //            enrollee.Sex = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 5]).Value2);
        //            enrollee.IsActive = true;
        //            listEnrollee.Add(enrollee);
        //            index++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(@"Error - " + ex.Message);
        //        //throw;
        //    }
        //    app.Workbooks.Close();
        //    return listEnrollee;
        //}

        //public static List<AttLog> ImportLogsFromExcel(String path)
        //{
        //    var listLogs = new List<AttLog>();
        //    var app = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        //    var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

        //    int index = 0;
        //    object rowIndex = 2;

        //    try
        //    {
        //        while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
        //        {
        //            rowIndex = 2 + index;
        //            var log = new AttLog();
        //            log.MachineNo = 1;
        //            if (Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2) <=
        //                0) continue;
        //            log.EnrolleeNo =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
        //            log.EnrollNumber =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
        //            log.IYear =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);
        //            log.IMonth =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 3]).Value2);
        //            log.IDay =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 4]).Value2);
        //            log.IHour =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 5]).Value2);
        //            log.IMin =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 6]).Value2);
        //            log.IMinute =
        //                Convert.ToInt32(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 6]).Value2);
        //            listLogs.Add(log);
        //            index++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(@"Error - " + ex.Message);
        //        //throw;
        //    }
        //    app.Workbooks.Close();
        //    return listLogs;
        //}
        #endregion

        #region "app.config"
        //public static string GetIPAddress()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
        //}

        //public static int GetIPort()
        //{
        //    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IPort"]);
        //}

        public static bool IsValidIP(string addr)
        {
            return Regex.IsMatch(addr, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$\b");
        }

        //public static string GetScreenType()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["ScreenType"];
        //}

        //public static string GetMachineSN()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["MachineSN"];
        //}

        //public static string GetMacKeyFinal()
        //{
        //    //return System.Configuration.ConfigurationManager.AppSettings["MacKeyFinal-Roxas"];
        //    //return System.Configuration.ConfigurationManager.AppSettings["MacKeyFinal-RNF"];
        //    //return System.Configuration.ConfigurationManager.AppSettings["MacKeyFinal-Carmen"];
        //    return System.Configuration.ConfigurationManager.AppSettings["MacKeyFinal-Aleosan"];
        //}

        //public static string GetMacKeyTemp()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings["MacKeyTemp"];
        //}
        #endregion

        #region "others"
        public static DialogResult GetDeleteDialog(string className)
        {
            DialogResult dResult = DialogResult.No;
            dResult = MessageBox.Show(string.Format("You are about to delete a(n) {0} record, continue?", className.ToUpper()), "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return dResult;
        }

        public static void GetMessageBox(int iSaveMessage)
        {
            if (iSaveMessage > 0)
            {
                MessageBox.Show("Record saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (iSaveMessage == 0)
            {
                MessageBox.Show("Record not saved.", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void StatusBarText(ToolStripStatusLabel statusText, int iDisplayMode)
        {
            switch (iDisplayMode)
            {
                case 1:
                    statusText.Text = "Editing...";
                    break;
                case 2:
                    statusText.Text = "Done Editing...";
                    break;
                case 3:
                    statusText.Text = "Record Saved...";
                    Thread.Sleep(100);
                    break;
                case 4:
                    statusText.Text = "An Error Occured. Record was not Saved...";
                    break;
                case 5:
                    statusText.Text = "System Ready...";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region "date utilities"
        public static List<string> FillMonth()
        {
            var lMonth = new List<string>();
            string[] months = { "- Month -", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (var item in months)
            {
                lMonth.Add(item);
            }
            return lMonth;
        }

        public static List<string> FillMonth(int iMonths)
        {
            List<string> lMonth = new List<string>();
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (var item in months)
            {
                lMonth.Add(item);
                if (lMonth.Count == iMonths)
                    return lMonth;
            }
            return lMonth;
        }

        public static Dictionary<int, string> FillMonthDic()
        {
            var dMonth = new Dictionary<int, string>();
            dMonth.Add(0, @"- Month -");
            dMonth.Add(1, "January");
            dMonth.Add(2, "February");
            dMonth.Add(3, "March");
            dMonth.Add(4, "April");
            dMonth.Add(5, "May");
            dMonth.Add(6, "June");
            dMonth.Add(7, "July");
            dMonth.Add(8, "August");
            dMonth.Add(9, "September");
            dMonth.Add(10, "October");
            dMonth.Add(11, "November");
            dMonth.Add(12, "December");
            return dMonth;
        }

        public static List<int> FillYear()
        {
            var lYear = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                var iYear = i + 1;
                lYear.Add(DateTime.Now.Year - i);
            }
            return lYear;
        }

        public static List<int> FillDays()
        {
            var lDays = new List<int>();
            for (int i = 0; i < 31; i++)
            {
                lDays.Add(i + 1);
            }
            return lDays;
        }

        public static List<int> FillHours()
        {
            List<int> lHours = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                lHours.Add(i + 1);
            }
            return lHours;
        }

        public static List<int> FillMins()
        {
            List<int> lMins = new List<int>();
            for (int i = 0; i < 59; i++)
            {
                lMins.Add(i + 1);
            }
            return lMins;
        }

        public static List<int> FillSecs()
        {
            List<int> lSecs = new List<int>();
            for (int i = 0; i < 59; i++)
            {
                lSecs.Add(i + 1);
            }
            return lSecs;
        }
        #endregion

        # region "control utilities"
        public static void ClearControls(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Clear();
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).SelectedIndex = -1;
                    ((ComboBox)c).Text = "";
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (c.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                    ((DateTimePicker)c).CustomFormat = " ";
                }
            }
        }

        public static void ClearControls(Panel p, bool o)
        {
            foreach (Control c in p.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Clear();
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).SelectedIndex = -1;
                    ((ComboBox)c).Text = "";
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (c.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                    ((DateTimePicker)c).CustomFormat = " ";
                }
            }
        }

        public static void ChangeColor(Control c, bool o)
        {
            if (o == true)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).BackColor = Color.LemonChiffon;
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).BackColor = Color.LemonChiffon;
                }
                else if (c.GetType() == typeof(WaterMarkTextBox))
                {
                    ((WaterMarkTextBox) c).BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).BackColor = Color.White;
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).BackColor = Color.White;
                }
                else if (c.GetType() == typeof(WaterMarkTextBox))
                {
                    ((WaterMarkTextBox)c).BackColor = Color.White;
                }
            }
        }

        public static void ChangeColor(Control c, bool o, Color eColor, Color lColor)
        {
            if (o == true)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).BackColor = eColor;
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).BackColor = eColor;
                }
            }
            else
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).BackColor = lColor;
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).BackColor = lColor;
                }
            }
        }

        #endregion

        public static void ShowSaveMessageBox(int iResult)
        {
            if (iResult > 0)
                MessageBox.Show(@"Record save.", @"Save.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(@"Error on save.", @"Save error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowCutsomMessageBox(string customMessage)
        {
            MessageBox.Show(customMessage, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowDeleteMessageQuestion()
        {
            return MessageBox.Show(@"You are about to delete a record. Continue?", @"Delete.", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
        }

        public static void ShowDeleteMessageBox(bool bResult)
        {
            if (bResult)
                MessageBox.Show(@"Record deleted.", @"Delete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(@"Error on delete.", @"Delete Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowGradeValidateEntry()
        {
            MessageBox.Show(@"Entered value is not in the range/selection.", @"Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public static bool CheckSQLServerConnection(string sqlServerName)
        {
            var controller = new ServiceController(sqlServerName);
            if (controller.Status == ServiceControllerStatus.Running)
            {
                //sctl.Start();
                return true;
            }
            return false;
        }

        public static bool StartSQLServerConnection(string sqlServerName)
        {
            var controller = new ServiceController(sqlServerName);
            //controller.MachineName
            if (controller.Status == ServiceControllerStatus.Stopped || controller.Status == ServiceControllerStatus.Paused)
            {
                controller.Start();
                return true;
            }
            return false;
        }
    }
}
