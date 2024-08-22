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
    public partial class DeliveryItemCheckForm : Form
    {
        private NpgsqlConnection connection;
        private char invoiceNumber;
        public DeliveryItemCheckForm(NpgsqlConnection connection, char invoiceNumber)
        {
            InitializeComponent();
            this.connection = connection;
            this.invoiceNumber = invoiceNumber;
            Update();
        }
        private void Update()
        {
            try
            {
                string sql = string.Format(@"SELECT di.product_id,p.name AS product_name,p.unit,di.amount,di.price FROM delivery_items di JOIN deliveries d ON di.delivery_id = d.id
                                            JOIN products p ON di.product_id = p.id WHERE d.invoice_number = @invoiceNumber ORDER BY p.id;");
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dt);
                    int sum = 0;
                    dataGridView1.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sum += (Convert.ToInt32(dt.Rows[i]["amount"]) * Convert.ToInt32(dt.Rows[i]["price"]));
                    }
                    cmbfinalSum.Text = sum.ToString();
                }
                string sql2 = string.Format(@"SELECT s.name, d.delivery_date FROM suppliers s, deliveries d WHERE s.id=d.supplier_id and d.invoice_number = @invoiceNumber");
                using (NpgsqlCommand command2 = new NpgsqlCommand(sql2, connection))
                {
                    command2.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                    DataTable dt2 = new DataTable();
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(command2);
                    da2.Fill(dt2);
                    cmbSupplier.Text = Convert.ToString(dt2.Rows[0]["name"]);
                    dtp.Text = Convert.ToString(dt2.Rows[0]["delivery_date"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки накладной: {ex.Message}");
            }
        }
        private void DeliveryItemCheckForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
