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
    public partial class MainForm : Form
    {
        private NpgsqlConnection con;

        public MainForm()
        {
            InitializeComponent();
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            string cs = "Server=localhost;Port=5432;Database=mybase;User Id=postgres;Password=admin";
            con = new NpgsqlConnection(cs);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void suppliersButton_Click_1(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(con);
            suppliersForm.ShowDialog();
        }

        private void productsButton_Click_1(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(con);
            productForm.ShowDialog();
        }

        private void deliveriesButton_Click_1(object sender, EventArgs e)
        {
            DeliveriesForm deliviersForm = new DeliveriesForm(con);
            deliviersForm.ShowDialog();
        }

        private void reportsButton_Click_1(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm(con);
            reportsForm.ShowDialog();
        }
    }
}