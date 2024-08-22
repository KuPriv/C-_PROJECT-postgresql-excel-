using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Project
{
    public partial class DeliveriesForm : Form
    {
        private NpgsqlConnection connection;

        public DeliveriesForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            LoadDeliveries();
            LoadSuppliers();
        }

        private void LoadDeliveries()
        {
            try
            {
                String sql = "SELECT * FROM deliveries ORDER BY id";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "id";
                dataGridView1.Columns[1].HeaderText = "supplier_id";
                dataGridView1.Columns[2].HeaderText = "delivery_date";
                dataGridView1.Columns[3].HeaderText = "invoice_number";
                dataGridView1.Columns[4].HeaderText = "is_paid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "2");
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT id, name FROM suppliers ORDER by id", connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbSuppliers.DataSource = dt;
                        cmbSuppliers.DisplayMember = "name";
                        cmbSuppliers.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}");
            }
        }
        private void Update()
        {
            try
            {
                String sql = "SELECT * FROM deliveries ORDER BY id";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "id";
                dataGridView1.Columns[1].HeaderText = "supplier_id";
                dataGridView1.Columns[2].HeaderText = "delivery_date";
                dataGridView1.Columns[3].HeaderText = "invoice_number";
                dataGridView1.Columns[4].HeaderText = "is_paid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "2");
            }
        }
        private void LoadPayments(int deliveryId)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(@"SELECT id, delivery_id, payment_date, paid FROM payments WHERE delivery_id = @deliveryId ORDER by id", connection))
                {
                    command.Parameters.AddWithValue("@deliveryId", deliveryId);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки оплат: {ex.Message}");
            }
        }

       
        private void DeliveriesForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InvoiceNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO deliveries (supplier_id, delivery_date, invoice_number) VALUES (@supplierId, @deliveryDate, @invoiceNumber)", connection))
                {
                    command.Parameters.AddWithValue("@supplierId", cmbSuppliers.SelectedValue);
                    command.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value);
                    command.Parameters.AddWithValue("@invoiceNumber", invoiceNumber.Text);
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LASTVAL()";
                    int deliveryId = Convert.ToInt32(command.ExecuteScalar());

                    AddDeliveryItemsForm addDeliveryItemsForm = new AddDeliveryItemsForm(connection, deliveryId);
                    if (addDeliveryItemsForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDeliveries();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления поставки: {ex.Message}");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int deliveryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                EditDeliveryForm editDeliveryForm = new EditDeliveryForm(connection, deliveryId);
                if (editDeliveryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDeliveries();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить поставку?", "Удаление поставки", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int deliveryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    try
                    {
                        using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM delivery_items WHERE delivery_id = @deliveryId;DELETE FROM deliveries WHERE id = @deliveryId", connection))
                        {
                            command.Parameters.AddWithValue("@deliveryId", deliveryId);
                            command.ExecuteNonQuery();
                            LoadDeliveries();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления поставки: {ex.Message}");
                    }
                }
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int deliveryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                AddDeliveryItemsForm addDeliveryItemsForm = new AddDeliveryItemsForm(connection, deliveryId);
                addDeliveryItemsForm.ShowDialog();
                LoadDeliveries(); 
            }
        }

        private void ExportToExcelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                char invoiceNumber = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["invoice_number"].Value);
                worksheet.Cells[1, 1] = "Отправитель:";
                worksheet.Cells[2, 1] = "Получатель:";
                worksheet.Cells[2, 3] = "Безымянный человек";
                worksheet.Cells[3, 1] = "Дата:";
                worksheet.Cells[3, 3] = dataGridView1.SelectedRows[0].Cells[2].Value;
                worksheet.Cells[5, 2] = "НАКЛАДНАЯ № ";
                worksheet.Cells[5, 4] = invoiceNumber.ToString();
                string sql = string.Format(@"SELECT di.product_id,p.name AS product_name,p.unit,di.amount,di.price, s.name AS supplier_name FROM delivery_items di JOIN deliveries d ON di.delivery_id = d.id
                                            JOIN products p ON di.product_id = p.id JOIN suppliers s ON d.supplier_id = s.id WHERE d.invoice_number = @invoiceNumber ORDER BY p.id;");
                worksheet.Cells[7, 1] = "Код товара";
                worksheet.Cells[7, 3] = "Количество";
                worksheet.Cells[7, 5] = "Цена";
                worksheet.Cells[7, 7] = "Наименование";
                worksheet.Cells[7, 9] = "Единица измерения";
                worksheet.Cells[7, 11] = "Сумма";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dt);
                    worksheet.Cells[1, 3] = dt.Rows[0]["supplier_name"];
                    int sum = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        worksheet.Cells[i + 8, 1] = dt.Rows[i]["product_id"];
                        worksheet.Cells[i + 8, 3] = dt.Rows[i]["amount"];
                        worksheet.Cells[i + 8, 5] = dt.Rows[i]["price"];
                        worksheet.Cells[i + 8, 7] = dt.Rows[i]["product_name"];
                        worksheet.Cells[i + 8, 9] = dt.Rows[i]["unit"];
                        worksheet.Cells[i + 8, 11] = (Convert.ToInt32(dt.Rows[i]["amount"]) * Convert.ToInt32(dt.Rows[i]["price"])).ToString();
                        sum += (Convert.ToInt32(dt.Rows[i]["amount"]) * Convert.ToInt32(dt.Rows[i]["price"]));
                    }
                    worksheet.Cells[10, 9] = "Итого:";
                    worksheet.Cells[10, 11] = sum;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }

                excelApp.Quit();
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Нет данных для экспорта");
            }
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
                if (selectedRows.Count > 0)
                {
                    int deliveryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    if (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) <= 0)
                    {
                        DateTime date = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["delivery_date"].Value);
                        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO payments (delivery_id, payment_date, paid) VALUES (:delivery_id, :payment_date, :paid)", connection);
                        command.Parameters.AddWithValue("delivery_id", deliveryId);
                        command.Parameters.AddWithValue("payment_date", dtpPaymentDate.Value);
                        command.Parameters.AddWithValue("paid", Convert.ToInt32(cmbAmount.Text));
                        if (Convert.ToInt32(cmbAmount.Text) <= Convert.ToInt32(full_price.Text))
                        {
                            DateTime dat = dtpPaymentDate.Value.Date;

                            //else
                            string d_dat = dat.ToString("dd");
                            int d_da = Convert.ToInt32(d_dat);
                            string d_date = date.ToString("dd");
                            int d_da2 = Convert.ToInt32(d_date);
                            string m_dat = dat.ToString("MM");
                            int m_da = Convert.ToInt32(m_dat);
                            string m_date = date.ToString("MM");
                            int m_da2 = Convert.ToInt32(m_date);
                            string y_dat = dat.ToString("yyyy");
                            int y_da = Convert.ToInt32(y_dat);
                            string y_date = date.ToString("yyyy");
                            int y_da2 = Convert.ToInt32(y_date);
                            if ((d_da + m_da * 30 + y_da * 30 * 12) - (d_da2 + m_da2 * 30 + y_da2 * 30 * 12) < 0)
                                MessageBox.Show("Вы не можете оплатить раньше формирования накладной");
                            else
                            {
                                if ((y_da * 12 + m_da) - (y_da2 * 12 + m_da2) < 3)
                                {
                                    command.ExecuteNonQuery();
                                }
                                else MessageBox.Show("Вы не можете оплатить позднее 3 месяцев, товар КОНФИСКУЕТСЯ!!!!!!!!!!");
                            }
                        }
                        else MessageBox.Show("Дорого богато живете, переплачиваете");
                    } else MessageBox.Show("У вас уже есть инфа по оплате");
                    LoadPayments(deliveryId);
                    LoadSuppliers();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Вы не выбрали накладную: {ex.Message}");
            }

        }

        private void cmbAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
                if (selectedRows.Count > 0) 
                {
                    LoadPayments((int)dataGridView1.SelectedRows[0].Cells["id"].Value);
                    char invoiceNumber = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["invoice_number"].Value);
                    int sum = 0;
                    string sql = string.Format(@"SELECT di.product_id,p.name AS product_name,p.unit,di.amount,di.price FROM delivery_items di JOIN deliveries d ON di.delivery_id = d.id
                                                JOIN products p ON di.product_id = p.id WHERE d.invoice_number = @invoiceNumber ORDER BY p.id;");
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                        DataTable dt = new DataTable();
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                        da.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sum += (Convert.ToInt32(dt.Rows[i]["amount"]) * Convert.ToInt32(dt.Rows[i]["price"]));
                        }
                        DataGridViewRow dataGridViewRow = selectedRows[0];
                        full_price.Text = sum.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения суммы: {ex.Message}");
            }
        }

        private void checkIsPaidButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
                if (selectedRows.Count > 0)
                {
                    int delivery_id = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    string sql = string.Format(@"SELECT delivery_id, paid FROM payments where delivery_id = @delivery_id and paid is not null");
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["delivery_id"]) == delivery_id)
                        {
                            int v = Convert.ToInt32(dt.Rows[i]["paid"]);
                            int d = Convert.ToInt32(full_price.Text);
                            if (v == d)
                            {
                                string sql3 = string.Format("UPDATE deliveries SET is_paid = '{0}' WHERE id = '{1}'", true, delivery_id);
                                NpgsqlCommand command2 = new NpgsqlCommand(sql3, connection);
                                command2.ExecuteNonQuery();
                            }
                        } 
                    }
                    LoadDeliveries();
                    LoadPayments((int)delivery_id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления оплаты в поставщиках: {ex.Message}");
            }
        }

        private void payBut_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGridView2.SelectedRows;
                if (selectedRows.Count > 0)
                {
                    int selectId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                    NpgsqlCommand command = new NpgsqlCommand("SELECT paid, delivery_id from payments where id= @selectId", connection);
                    command.Parameters.AddWithValue("selectId", selectId);
                    int amou = Convert.ToInt32(payPart.Text);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    int cons = Convert.ToInt32(dt.Rows[0]["paid"]) + amou;
                    int delivery_id = Convert.ToInt32(dt.Rows[0]["delivery_id"]);
                    DataGridViewSelectedRowCollection selectedRows2 = dataGridView2.SelectedRows;
                    if (selectedRows2.Count > 0)
                    {
                        int d = Convert.ToInt32(full_price.Text);
                        if (cons <= d)
                        {
                            DateTime dtp = Convert.ToDateTime(dtpLast.Value);
                            string sql3 = string.Format(@"UPDATE payments SET paid = '{0}', payment_date = '{1}' WHERE id = '{2}'", cons, dtp, selectId);
                            NpgsqlCommand command2 = new NpgsqlCommand(sql3, connection);
                            DateTime dat = dtpLast.Value.Date;
                            DateTime date = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["delivery_date"].Value);
                            string d_dat = dat.ToString("dd");
                            int d_da = Convert.ToInt32(d_dat);
                            string d_date = date.ToString("dd");
                            int d_da2 = Convert.ToInt32(d_date);
                            string m_dat = dat.ToString("MM");
                            int m_da = Convert.ToInt32(m_dat);
                            string m_date = date.ToString("MM");
                            int m_da2 = Convert.ToInt32(m_date);
                            string y_dat = dat.ToString("yyyy");
                            int y_da = Convert.ToInt32(y_dat);
                            string y_date = date.ToString("yyyy");
                            int y_da2 = Convert.ToInt32(y_date);
                            if ((d_da + m_da * 30 + y_da * 30 * 12) - (d_da2 + m_da2 * 30 + y_da2 * 30 * 12) < 0)
                                MessageBox.Show("Вы не можете оплатить раньше формирования накладной");
                            else
                            {
                                if ((y_da * 12 + m_da) - (y_da2 * 12 + m_da2) < 3)
                                {
                                    command.ExecuteNonQuery();
                                }
                                else MessageBox.Show("Вы не можете оплатить позднее 3 месяцев, товар КОНФИСКУЕТСЯ!!!!!!!!!!");
                            }
                            command2.ExecuteNonQuery();
                        }
                        else MessageBox.Show("Платеж больше нужного");
                    }
                        else MessageBox.Show("Выделите нужную ячейку поставки");
                    LoadPayments(delivery_id);
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Вы не выбрали накладную: {ex.Message}");
            }
        }

        private void delBut_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить?";
            string caption = "Подтверждение операции";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView2.CurrentRow.Cells["id"].Value;
                int deliveryId = (int)dataGridView2.CurrentRow.Cells["delivery_id"].Value;
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("DELETE FROM payments WHERE id = :id", connection);
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                    LoadPayments(deliveryId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deliveryItemCheckButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                char invoiceNumber = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["invoice_number"].Value);
                DeliveryItemCheckForm delicheckForm = new DeliveryItemCheckForm(connection, invoiceNumber);
                delicheckForm.ShowDialog();
            }
        }
    }
}
