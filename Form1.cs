using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace OffersCreator
{
    public partial class Form1 : Form
    {
        private const string Address = "file:///C:/Users/stark/Desktop/SaveOnFoods/Pages/Page21212/Page2/Save%20on%20Foods%20(SOF)%20Incentives%20Manager.html"; //"https:///sof.adm.you.net";
        //private const string Address = "https:///sof.adm.you.net";

        public ChromiumWebBrowser wb1;

        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            wb1 = new ChromiumWebBrowser(Address);
            splitContainer1.Panel2.Controls.Add(wb1);
            wb1.Dock = DockStyle.Fill;
        }
        public Form1()
        {
            InitializeComponent();

            InitBrowser();
        }

        private void cb_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cb_sheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersWidth = 75;
            dataGridView1.Columns[1].Width = 180;
            setRowsNumber();
            
        }
        private void setRowsNumber()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        DataTableCollection tableCollection;
        private void btn_brows_Click(object sender, EventArgs e)
        {
            try
            {

            using(OpenFileDialog openFiledDalog = new OpenFileDialog() {Filter= "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if(openFiledDalog.ShowDialog() == DialogResult.OK)
                {
                    tb_name.Text = openFiledDalog.FileName;
                    using (var stream = File.Open(openFiledDalog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration() 
                            { 
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cb_sheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cb_sheet.Items.Add(table.TableName);
                            {

                            }
                        }
                    }
                }
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Try again or choose different file!");
            }
        }

        private void fill_func()
        {
          
                    try
                    {

                        string manId = (Convert.ToInt32(tb_ManId.Text) + Convert.ToInt32(dataGridView1.SelectedRows[0].HeaderCell.Value)).ToString(); //dataGridView1.SelectedRows[0].Index).ToString();
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').focus(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').paste(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').value = '{manId}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').textContent = '{manId}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').innerHTML = '{manId}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').setAttribute('value','{manId}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').setAttribute('textContent','{manId}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').dispatchEvent(new Event('change')); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('manufacturer_offer_id').blur(); ");


                        string ReqDollars = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Replace(" ", "");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').focus(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').paste(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').value = '{ReqDollars}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').textContent = '{ReqDollars}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').innerHTML = '{ReqDollars}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').setAttribute('value','{ReqDollars}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').setAttribute('textContent','{ReqDollars}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').dispatchEvent(new Event('change')); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_quantity').blur(); ");


                        string ShortDesc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').focus(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').paste(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').value = '{ShortDesc}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').textContent = '{ShortDesc}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').innerHTML = '{ShortDesc}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').setAttribute('value','{ShortDesc}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').setAttribute('textContent','{ShortDesc}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').dispatchEvent(new Event('change')); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_short_description').blur(); ");


                        int ind1 = ShortDesc.IndexOf("Get") + 3;
                        int ind2 = ShortDesc.Length - ind1 - (ShortDesc.Length - ShortDesc.IndexOf("points"));
                        string OfferPoints = ShortDesc.Substring(ind1, ind2).Replace(" ", "");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').focus(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').paste(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').value = '{OfferPoints}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').textContent = '{OfferPoints}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').innerHTML = '{OfferPoints}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').setAttribute('value','{OfferPoints}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').setAttribute('textContent','{OfferPoints}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').dispatchEvent(new Event('change')); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('requirement_value').blur(); ");


                        string ReceiptDesc = "myoffers-VIP " + OfferPoints;
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').focus(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').paste(); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').value = '{ReceiptDesc}'; "); //.Document.GetElementById("en_ca_receipt_description");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').textContent = '{ReceiptDesc}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').innerHTML = '{ReceiptDesc}'; ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').setAttribute('value','{ReceiptDesc}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').setAttribute('textContent','{ReceiptDesc}'); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').dispatchEvent(new Event('change')); ");
                        wb1.ExecuteScriptAsync($"document.getElementById('en_ca_receipt_description').blur(); ");


                        if (check_values(manId, ReqDollars, ShortDesc, OfferPoints, ReceiptDesc))
                        {
                            dataGridView1.SelectedRows[0].Cells[2].Value = manId;
                            dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.Gold;
                            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
                            timer1.Enabled = true;
                            timer1.Start();

                            lastFilledRow = dataGridView1.SelectedRows[0].HeaderCell.Value.ToString();
                            lastFilledManId = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong Values!");
                    }
               
        }
        private void btn_fill_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(tb_ManId.Text))
                {
                    MessageBox.Show("Enter the first Manufacturer ID you want to start filling with");
                }
                else if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select the row that you want to fill it's values in Youtech");

                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Select only one row please!");

                }
                else
                {
                   /* if (chb_auto.Checked)
                    {
                        for (int i = dataGridView1.SelectedRows[0].Index; i < dataGridView1.Rows.Count; i++)
                        {
                            fill_func();
                            if (dataGridView1.SelectedRows[0].Index < dataGridView1.Rows.Count - 1)
                            {
                                dataGridView1.Rows[dataGridView1.SelectedRows[0].Index + 1].Selected = true;
                            }
                        }
                    }
                    else
                    {*/
                        fill_func();
                   // }
                }
            }
            else { MessageBox.Show("Choose file and sheet first!"); }

        }

        private bool check_values(string manId, string ReqDollars, string ShortDesc, string OfferPoints, string ReceiptDesc)
        {
            
            try
            {

                var BrEv = wb1.EvaluateScriptAsync("document.getElementById('manufacturer_offer_id').value;");
                var response = BrEv.Result;

                if (response.Success != true || response.Result == "" || response.Result.ToString() != manId)
                { MessageBox.Show("Manufacturer ID value didn't applied! Try again.."); return false; }

                
                BrEv = wb1.EvaluateScriptAsync("document.getElementById('requirement_quantity').value;");
                response = BrEv.Result;
                if (response.Success == false || response.Result == "" || response.Result.ToString() != ReqDollars)
                {  MessageBox.Show("Requirement Dollars Amount value didn't applied! Try again.."); return false; }


                BrEv = wb1.EvaluateScriptAsync("document.getElementById('en_ca_short_description').value;");
                response = BrEv.Result;
                if (response.Success == false || response.Result == "" || response.Result.ToString() != ShortDesc)
                { MessageBox.Show("Short Description value didn't applied! Try again.."); return false; }


                BrEv = wb1.EvaluateScriptAsync("document.getElementById('requirement_value').value;");
                response = BrEv.Result;
                if (response.Success == false || response.Result == "" || response.Result.ToString() != OfferPoints)
                { MessageBox.Show("Offer value didn't applied! Try again.."); return false; }


                BrEv = wb1.EvaluateScriptAsync("document.getElementById('en_ca_receipt_description').value;");
                response = BrEv.Result;
                if (response.Success == false || response.Result == "" || response.Result.ToString() != ReceiptDesc)
                { MessageBox.Show("Receipt Description value didn't applied! Try again.."); return false; }


                
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Values! Please Navigate to the correct page");
                return false;
            }

            return true;
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            timer1.Stop();
            timer1.Enabled = false;
            
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            //string Address2 = "file:///C:/Users/stark/Desktop/SaveOnFoods/Pages/Page21212/Page2/Save%20on%20Foods%20(SOF)%20Incentives%20Manager.html";
            string Address2 = "https:///sof.adm.you.net";
            wb1.Load(Address2);
        }
        private string lastFilledRow;
        private string lastFilledManId;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string additionalMsg = "";

            if(!string.IsNullOrEmpty(lastFilledManId) && !string.IsNullOrEmpty(lastFilledRow))
            {
                additionalMsg = Environment.NewLine + Environment.NewLine + "Keep in mind that:" +
                    Environment.NewLine + "Your last filled row number was: " + lastFilledRow +
                        Environment.NewLine + "Your last filled Manufacturer ID was:" + lastFilledManId;
            }
            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close?" + additionalMsg
                    , "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }
    }
}
