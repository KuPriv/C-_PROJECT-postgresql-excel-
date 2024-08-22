using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Project
{
    public partial class EditDeliveryForm : Form
    {
        private NpgsqlConnection connection;
        private int deliveryId;

        public EditDeliveryForm(NpgsqlConnection connection, int deliveryId)
        {
            InitializeComponent();
            this.connection = connection;
            this.deliveryId = deliveryId;
            LoadDeliveryData();
            LoadSuppliers();
        }

        private void LoadDeliveryData()
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT supplier_id, delivery_date, invoice_number FROM deliveries WHERE id = @deliveryId", connection))
                {
                    command.Parameters.AddWithValue("@deliveryId", deliveryId);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmbSuppliers.SelectedValue = reader.GetInt32(0);
                            dtpDeliveryDate.Value = reader.GetDateTime(1);
                            InvoiceNumber.Text = reader.GetString(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных поставки: {ex.Message}");
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT id, name FROM suppliers", connection))
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE deliveries SET supplier_id = @supplierId, delivery_date = @deliveryDate, invoice_number = @invoiceNumber WHERE id = @deliveryId", connection))
                {
                    command.Parameters.AddWithValue("@supplierId", cmbSuppliers.SelectedValue);
                    command.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value);
                    command.Parameters.AddWithValue("@invoiceNumber", InvoiceNumber.Text);
                    command.Parameters.AddWithValue("@deliveryId", deliveryId);
                    command.ExecuteNonQuery();

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных поставки: {ex.Message}");
            }
        }

        private void EditDeliveryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
