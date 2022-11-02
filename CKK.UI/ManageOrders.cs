using CKK.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.UI
{
    public partial class ManageOrders : Form
    {
        //public SqlConnection Con { get; private set; }

        // Razer Blade laptop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home Desktop - Final CKKDB
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = CKKDB");

        // OTech Desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\4400113921\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        int number = 0;
        int uprice, totprice, qty;
        string product;
        int flag = 0;

        public ManageOrders()
        {
            InitializeComponent();
        }

        private void FillCategory()
        {
            string categoryQuery = "SELECT * FROM CategoryTbl";
            SqlCommand cmd = new SqlCommand(categoryQuery, Con);
            SqlDataReader rdr;

            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("CategoryName", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                //manageProductsSearchComboBox.ValueMember = "CategoryName";
                //manageProductsSearchComboBox.DataSource = dt;
                manageOrdersProductsSearchComboBox.ValueMember = "CategoryName";
                manageOrdersProductsSearchComboBox.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }

        private void PopulateCustomersGridView()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM CustomerTbl";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageOrdersCustomersDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void PopulateProductsGridView()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM ProductTbl";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageOrdersProductsDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        // Clear all TextBoxes
        public void ClearTextBoxes()
        {
            // Iterate through every Control on the form
            foreach (Control guiControl in Controls)
            {
                // If Control is a TextBox, clear it
                (guiControl as TextBox)?.Clear();
            }
        }

        private void ManageOrders_Load(object sender, EventArgs e)
        {
            PopulateCustomersGridView();
            PopulateProductsGridView();
            FillCategory();
        }

        private void manageProductsHomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private void manageProductsProductsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
        }

        private void manageProductsCustomersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.Show();
        }

        private void manangeProductsStoreButton_Click(object sender, EventArgs e)
        {

        }

        private void manageProductsLogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void manageProductsExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageProductsSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCategories manageCategories = new ManageCategories();
            manageCategories.Show();
        }

        private void manageOrdersCustomersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manageOrdersCustomerTextBox.Text = manageOrdersCustomersDataGridView.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void manageOrdersProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //product = manageOrdersProductsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            //qty = Convert.ToInt32(manageOrdersProductQuantityTextBox.Text);
            uprice = Convert.ToInt32(manageOrdersProductsDataGridView.SelectedRows[0].Cells[3].Value.ToString());
            //totprice = qty * uprice;
            flag = 1;

        }

        private void manageOrdersAddButton_Click(object sender, EventArgs e)
        {
            int sum = 0;

            if (manageOrdersProductQuantityTextBox.Text == "")
            {
                MessageBox.Show("Enter quantity of product");
            }
            else if (flag == 0)
            {
                MessageBox.Show("Select product");
            }
            else
            {
                number++;
                qty = Convert.ToInt32(manageOrdersProductQuantityTextBox.Text);
                totprice = qty * uprice;

                DataTable table = new DataTable();
                table.Rows.Add(number, product, qty, uprice, totprice);
                manageOrdersOrderDataGridView.DataSource = table;
                flag = 0;
            }

            sum = sum + totprice;
            dollarsLabel.Text = "$" + sum.ToString();
        }

        private void manageOrdersProductsSearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageOrdersProductsSearchComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM ProductTbl WHERE Category = '" + manageOrdersProductsSearchComboBox.SelectedValue.ToString() + "';";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageOrdersProductsDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
    }
}
