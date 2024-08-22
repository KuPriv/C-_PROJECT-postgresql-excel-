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
    public partial class AddDeliveryItemsForm : Form
    {
        private NpgsqlConnection connection;
        private int deliveryId;

        public AddDeliveryItemsForm(NpgsqlConnection connection, int deliveryId)
        {
            InitializeComponent();
            this.connection = connection;
            this.deliveryId = deliveryId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT id, name FROM products", connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbProducts.DataSource = dt;
                        cmbProducts.DisplayMember = "name";
                        cmbProducts.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO delivery_items (delivery_id, product_id, amount, price) VALUES (@deliveryId, @productId, @amount, @price)", connection))
                {
                    command.Parameters.AddWithValue("@deliveryId", deliveryId);
                    command.Parameters.AddWithValue("@productId", cmbProducts.SelectedValue);
                    command.Parameters.AddWithValue("@amount", nudAmount.Value);
                    command.Parameters.AddWithValue("@price", nudPrice.Value);
                    command.ExecuteNonQuery();

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления товара в поставку: {ex.Message}");
            }
        }

        private void AddDeliveryItemsForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
