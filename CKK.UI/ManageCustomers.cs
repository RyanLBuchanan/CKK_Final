using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CKK.UI;

namespace CKK.UI
{
    public partial class ManageCustomers : Form
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

        public ManageCustomers()
        {
            InitializeComponent();
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
                manageCustomersDataGridView.DataSource = ds.Tables[0];
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

        private void manageCustomersAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CustomerTbl VALUES('" + manageCustomersCustomerIdTextBox.Text + "', " +
                "'" + manageCustomersCustomerNameTextBox.Text + "', '" + manageCustomersCustomerTelephoneTextBox.Text + "');", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCustomersGridView();
                MessageBox.Show("Customer successfully added.");
            }
            catch
            {

            }

            ClearTextBoxes();
        }

        private void manageCustomersEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CustomerTbl SET CustomerId = '" + manageCustomersCustomerIdTextBox.Text + "', CustomerName = '" + manageCustomersCustomerNameTextBox.Text + "' WHERE CustomerTelephone = '" + manageCustomersCustomerTelephoneTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCustomersGridView();
                MessageBox.Show("Customer successfully updated.");
            }
            catch
            {

            }
        }

        private void manageCustomersDeleteButton_Click(object sender, EventArgs e)
        {
            if (manageCustomersCustomerTelephoneTextBox.Text == "")
            {
                MessageBox.Show("Enter the customer's phone number");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CustomerTbl WHERE CustomerTelephone = '" + manageCustomersCustomerTelephoneTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCustomersGridView();
                MessageBox.Show("Customer successfully deleted.");
            }

            ClearTextBoxes();
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            PopulateCustomersGridView();
        }

        private void manageCustomersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manageCustomersCustomerIdTextBox.Text = manageCustomersDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            manageCustomersCustomerNameTextBox.Text = manageCustomersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            manageCustomersCustomerTelephoneTextBox.Text = manageCustomersDataGridView.SelectedRows[0].Cells[2].Value.ToString();
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

        }

        private void manangeProductsStoreButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageOrders manageOrders = new ManageOrders();
            manageOrders.Show();
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
    }
}
