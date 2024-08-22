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
    public partial class AddSupplierForm : Form
    {
        NpgsqlConnection con;
        public AddSupplierForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO suppliers (name, address, phone) VALUES (@name, @address, @phone)", con);
                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@address", address.Text);
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void offButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {

        }

    }
}
