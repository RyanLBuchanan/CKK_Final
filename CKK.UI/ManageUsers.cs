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
    public partial class ManageUsers : Form
    {
        //public SqlConnection Con { get; private set; }

        // Razer Blade laptop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home Desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home Desktop - Final CKKDB
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = CKKDB");

        // OTech Desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\4400113921\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManagerUsers_Load(object sender, EventArgs e)
        {
            PopulateUsersGridView();
        }

        private void PopulateUsersGridView()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageUsersDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }


        private void manageUsersAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserTbl VALUES('" + manageUsersUserNameTextBox.Text + "', " +
                "'" + manageUsersFullNameTextBox.Text + "', '" + manageUsersPasswordTextBox.Text + "'," +
                " '" + manageUsersTelephoneTextBox.Text + "');", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateUsersGridView();
                MessageBox.Show("User successfully added.");
            }
            catch
            {

            }
        }

        private void manageUsersEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE UserTbl SET Username = '" + manageUsersUserNameTextBox.Text + "', Ufullname = '" + manageUsersFullNameTextBox.Text + "', Upassword = '" + manageUsersPasswordTextBox.Text + "' WHERE Utelephone = '" + manageUsersTelephoneTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateUsersGridView();
                MessageBox.Show("User successfully updated.");
            }
            catch
            {

            }
        }

        private void manageUsersDeleteButton_Click(object sender, EventArgs e)
        {
            if (manageUsersTelephoneTextBox.Text == "")
            {
                MessageBox.Show("Enter the user's phone number");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM UserTbl WHERE Utelephone = '" + manageUsersTelephoneTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateUsersGridView();
                MessageBox.Show("User successfully deleted.");
            }
        }

        private void manageUsersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manageUsersUserNameTextBox.Text = manageUsersDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            manageUsersFullNameTextBox.Text = manageUsersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            manageUsersPasswordTextBox.Text = manageUsersDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            manageUsersTelephoneTextBox.Text = manageUsersDataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void manageProductsHomeButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ManageUsers manageUsers = new ManageUsers();
            //manageUsers.Show();
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
