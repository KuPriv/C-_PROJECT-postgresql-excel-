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
    public partial class ProductForm : Form
    {
        NpgsqlConnection con;
        int id;
        DataTable dt;
        DataSet ds;
        public ProductForm(NpgsqlConnection con)
        {
            this.con = con;
            dt = new DataTable();
            ds = new DataSet();
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            try
            {
                String sql = "SELECT * FROM products ORDER BY id";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                ds.Reset();
                name.Text = "";
                da.Fill(ds);
                dt = ds.Tables[0];
                productsGridView.DataSource = dt;
                productsGridView.Columns[0].HeaderText = "Номер";
                productsGridView.Columns[1].HeaderText = "Наименование";
                productsGridView.Columns[2].HeaderText = "Описание";
                productsGridView.Columns[3].HeaderText = "Единица измерения";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "2");
            }
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm(con);
            addProductForm.ShowDialog();
            Update();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE products SET name = '{0}', description = '{1}', unit = '{2}' WHERE id = '{3}'", name.Text, description.Text, unit.Text, id);
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить?";
            string caption = "Подтверждение операции";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = (int)productsGridView.CurrentRow.Cells["id"].Value;
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("DELETE FROM products WHERE id = :id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Update();
            }
        }
        private void productsGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = productsGridView.SelectedRows;
            if (selectedRows.Count > 0)
            {
                DataGridViewRow dataGridViewRow = selectedRows[0];
                id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
                name.Text = Convert.ToString(dataGridViewRow.Cells[1].Value);
                description.Text = Convert.ToString(dataGridViewRow.Cells[2].Value);
                unit.Text = Convert.ToString(dataGridViewRow.Cells[3].Value);
            }
        }


        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void offButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
