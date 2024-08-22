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
    public partial class SuppliersForm : Form
    {
        NpgsqlConnection con;
        int id;
        DataTable dt;
        DataSet ds;
        public SuppliersForm(NpgsqlConnection con)
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
                String sql = "SELECT * FROM suppliers ORDER BY id";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                ds.Reset();
                name.Text = "";
                address.Text = "";
                phone.Text = "";
                da.Fill(ds);
                dt = ds.Tables[0];
                suppliersGridView.DataSource = dt;
                suppliersGridView.Columns[0].HeaderText = "Название";
                suppliersGridView.Columns[1].HeaderText = "Адрес";
                suppliersGridView.Columns[2].HeaderText = "Телефон";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "2");
            }
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplierForm addSupplierForm = new AddSupplierForm(con);
            addSupplierForm.ShowDialog();
            Update();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE suppliers SET name = '{0}', address = '{1}', phone = '{2}' WHERE id = '{3}'", name.Text, address.Text, phone.Text, id);
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
                int id = (int)suppliersGridView.CurrentRow.Cells["id"].Value;
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("DELETE FROM suppliers WHERE id = :id", con);
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

        private void suppliersGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = suppliersGridView.SelectedRows;
            if (selectedRows.Count > 0)
            {
                DataGridViewRow row = selectedRows[0];
                id = Convert.ToInt32(row.Cells[0].Value);
                name.Text = Convert.ToString(row.Cells[1].Value);
                address.Text = Convert.ToString(row.Cells[2].Value);
                phone.Text = Convert.ToString(row.Cells[3].Value);
            }
        }
        private void suppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SuppliersForm_Load(object sender, EventArgs e)
        {

        }

        private void offButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
