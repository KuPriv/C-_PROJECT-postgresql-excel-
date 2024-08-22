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
    public partial class ReportsForm : Form
    {
        private NpgsqlConnection connection;
        public ReportsForm(NpgsqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            LoadSuppliers();
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
                        cmbSupplier.DataSource = dt;
                        cmbSupplier.DisplayMember = "name";
                        cmbSupplier.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}");
            }
        }
        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtp1.Value;
                DateTime endDate = dtp2.Value;
                int supplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                string sql = string.Format(@"
                    SELECT
  s.name AS supplier_name,
  COALESCE(SUM(di.amount * di.price), 0) AS turnover,
  COALESCE(SUM(CASE WHEN d.is_paid = FALSE THEN di.amount * di.price END), 0) AS unpaid_amount
FROM
  suppliers s
JOIN
  deliveries d ON s.id = d.supplier_id
JOIN
  delivery_items di ON d.id = di.delivery_id
LEFT JOIN
  payments p ON d.id = p.delivery_id
WHERE s.id = @supplierId and d.delivery_date BETWEEN @startDate AND @endDate
GROUP BY
  s.name");
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SupplierId", supplierId);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}");
            }
        }
        
    }
}
