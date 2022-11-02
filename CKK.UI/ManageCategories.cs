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
    public partial class ManageCategories : Form
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

        public ManageCategories()
        {
            InitializeComponent();
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

        private void PopulateCategoriesGridView()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM CategoryTbl";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageCategoriesDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void manageCategoriesAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CategoryTbl VALUES('" + manageCategoriesCategoryIdTextBox.Text + "', " +
                "'" + manageCategoriesCategoryNameTextBox.Text + "');", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCategoriesGridView();
                MessageBox.Show("Category successfully added.");
            }
            catch
            {

            }

            ClearTextBoxes();
        }

        private void manageCategoriesEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CategoryTbl SET CategoryName = '" + manageCategoriesCategoryNameTextBox.Text + "' WHERE CategoryId = '" + manageCategoriesCategoryIdTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCategoriesGridView();
                MessageBox.Show("Category successfully updated.");
            }
            catch
            {

            }
        }

        private void manageCategoriesDeleteButton_Click(object sender, EventArgs e)
        {
            if (manageCategoriesCategoryIdTextBox.Text == "")
            {
                MessageBox.Show("Enter the category's ID number");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CategoryTbl WHERE CategoryId = '" + manageCategoriesCategoryIdTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateCategoriesGridView();
                MessageBox.Show("Category successfully deleted.");
            }
        }

        private void manageCategoriesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manageCategoriesCategoryIdTextBox.Text = manageCategoriesDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            manageCategoriesCategoryNameTextBox.Text = manageCategoriesDataGridView.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            PopulateCategoriesGridView();
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
            //this.Hide();
            //ManageCategories manageCategories = new ManageCategories();
            //manageCategories.Show();
        }
    }
}
