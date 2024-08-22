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
    public partial class AddProductForm : Form
    {
        NpgsqlConnection con;
        public AddProductForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }
        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO products (name, description, unit) VALUES (@name, @description, @unit)", con);
                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@description", description.Text);
                command.Parameters.AddWithValue("@unit", unit.Text);
                command.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void offButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
