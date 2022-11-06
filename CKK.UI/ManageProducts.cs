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
using CKK.Logic.Models;
using CKK.Logic.Exceptions;
using CKK.Persistence;
using Guna.UI2.WinForms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CKK.UI
{
    public partial class ManageProducts : Form
    {
        //public SqlConnection Con { get; private set; }

        // Razer Blade laptop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        //// Home Desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home Desktop - Final CKKDB
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = CKKDB");

        // OTech Desktop
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\4400113921\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        //private IStore Store;

        //private FileStore fileStore;

        // Obeject for providing serialization
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream output;

        // Counter for un-numbered storeItems
        private int newProductIdCounter = 1;

        public ManageProducts()
        {
            //Store = new Store();
            InitializeComponent(); 
        }

        /**** WORKING CODE FROM TUTORIAL ****/
        // Populate category search drop down combobox
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
                manageProductsProductCategoryComboBox.ValueMember = "CategoryName";
                manageProductsProductCategoryComboBox.DataSource = dt;
                manageProductsSearchComboBox.ValueMember = "CategoryName";
                manageProductsSearchComboBox.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }

        // Populate name search drop down combobox
        private void FillName()
        {
            string nameQuery = "SELECT ProductName FROM NameTbl";
            SqlCommand cmd = new SqlCommand(nameQuery, Con);
            SqlDataReader rdr;

            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductName", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                //manageProductsProductCategoryComboBox.ValueMember = "ProductName";
                //manageProductsProductCategoryComboBox.DataSource = dt;
                searchNameComboBox.ValueMember = "ProductName";
                searchNameComboBox.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }


        /**** WORKING CODE FROM TUTORIAL ****/
        private void PopulateProductsGridView()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageProductsDataGridView.DataSource = ds.Tables[0];
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

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            // Populate products DataGridView
            //if (fileStore != null)
            //{
            //    FileStore fileStore = new FileStore();
            //    fileStore.Load();
            //}

            //manageProductsProductIdTextBox.Enabled = false;

            /**** WORKING CODE FROM MYCODESPACE TUTORIAL ****/
            FillCategory();
            FillName();
            PopulateProductsGridView();
        }

        private void manageProductsAddButton_Click(object sender, EventArgs e)
        {
            /**** WORKING CODE FROM TUTORIAL ****/
            try
            {
                // Insert new product into table
                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Products VALUES('" + manageProductsProductNameTextBox.Text + "', '" + manageProductsProductDescriptionTextBox.Text + "', ROUND('" + manageProductsProductPriceTextBox.Text + "', 2), '" + manageProductsProductQuantityTextBox.Text + "', '" + manageProductsProductCategoryComboBox.Text + "');", Con);
                cmd.ExecuteNonQuery();
                Con.Close();

                // Insert new product name into NameTbl for population of Name Filter search
                Con.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO NameTbl VALUES('" + manageProductsProductIdTextBox.Text + "', " +
                "'" + manageProductsProductNameTextBox.Text + "');", Con);
                cmd1.ExecuteNonQuery();
                Con.Close();

                PopulateProductsGridView();
                MessageBox.Show("Product successfully added.");
            }
            catch
            {
            }

            // Clear all TextBoxes for entry of new product data
            ClearTextBoxes();



            ///*** WORKING CODE FROM DELIVERABLE 12 ****/
            //Product newProduct = new Product();
            //string newProductDescription;
            //int newProductQuantity;
            //string productCategory;

            //// If no product exists of that id, give new id
            //newProduct.Id = newProductIdCounter++; // Add new product ID from counter
            //newProduct.Name = manageProductsProductNameTextBox.Text; // Give product a name
            //newProductDescription = manageProductsProductDescriptionTextBox.Text;
            //newProduct.Price = decimal.Parse(manageProductsProductPriceTextBox.Text); // Give product a price
            //newProductQuantity = int.Parse(manageProductsProductQuantityTextBox.Text);
            //productCategory = manageProductsProductCategoryComboBox.Text;

            //// Add new product to DataGridView
            //DataGridViewRow row = (DataGridViewRow)manageProductsDataGridView.Rows[0].Clone();
            //row.Cells[0].Value = newProduct.Id;
            //row.Cells[1].Value = newProduct.Name;
            //row.Cells[2].Value = newProductDescription;
            //row.Cells[3].Value = newProduct.Price;
            //row.Cells[4].Value = newProductQuantity;
            //row.Cells[5].Value = productCategory;
            //manageProductsDataGridView.Rows.Add(row);


            //FileStore fileStore = new FileStore();
            //fileStore.Save(newProduct, newProductDescription, newProductQuantity);

            //// Notify user of correctly added product
            //MessageBox.Show($"Product successfully added.\n" +
            //                $"\nID:\t\t{newProduct.Id,10:D3}\n" +
            //                $"Name:\t\t{newProduct.Name,10}\n" +
            //                $"Description:\t{newProductDescription,10}\n" +
            //                $"Price:\t\t{newProduct.Price,10:C}\n" +
            //                $"Quantity:\t\t{newProductQuantity,10}\n");
        }

        private void manageProductsEditButton_Click(object sender, EventArgs e)
        {
            /**** WORKING CODE FROM MYCODESPACE TUTORIAL ****/
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Products SET Name = '" + manageProductsProductNameTextBox.Text + "', Description = '" + manageProductsProductDescriptionTextBox.Text + "', Price = '" + manageProductsProductPriceTextBox.Text + "', Quantity = '" + manageProductsProductQuantityTextBox.Text + "', Category = '" + manageProductsProductCategoryComboBox.Text + "' WHERE ID = '" + manageProductsProductIdTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateProductsGridView();
                MessageBox.Show("Product successfully updated.");
            }
            catch
            {

            }

            // Clear all TextBoxes for entry of new product data
            ClearTextBoxes();
        }

        private void manageProductsDeleteButton_Click(object sender, EventArgs e)
        {
            ///*** WORKING CODE FROM DELIVERABLE 12 ****/
            //foreach (DataGridViewRow item in this.manageProductsDataGridView.SelectedRows)
            //{
            //    manageProductsDataGridView.Rows.RemoveAt(item.Index);
            //}

            //ClearTextBoxes();

            //MessageBox.Show("Product successfully deleted.");



            /**** WORKING CODE FROM TUTORIAL ****/
            if (manageProductsProductIdTextBox.Text == "")
            {
                MessageBox.Show("Enter the product ID.");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ID = '" + manageProductsProductIdTextBox.Text + "';", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                PopulateProductsGridView();
                MessageBox.Show("Product successfully deleted.");
            }

            ClearTextBoxes();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\vreed\Documents\Persistence\ProductsList.dat")) /**** FOR HOME PC ****/
            //using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\ryanl\Documents\Persistence\StoreItems.dat")) /**** FOR RAZER BLADE LAPTOP ****/
            //using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\4400113921\Desktop\Documents\Persistence\ProductsList.dat")) /**** FOR OTECH PC ****/
            {
                // Write the header
                streamWriter.WriteLine($"ID\tName\t\tDescription\t\tPrice\tQuantity\tCategory\n");

                for (int i = 0; i < manageProductsDataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 6; j < manageProductsDataGridView.Columns.Count; j++)
                    {
                        // Write each new product
                        streamWriter.Write($"{manageProductsDataGridView.Rows[i].Cells[j].Value}\t");

                        // Add tab space between columns' output
                        if (j == 10)
                        {
                            streamWriter.Write("\t");
                        }

                        // Add $ sign to Price column output
                        //if (j == 8 /*|| j == 3 || j == 4*/)
                        //{
                        //    streamWriter.Write("\t$");
                        //}
                    }

                    if (i != manageProductsDataGridView.Columns.Count - 1)
                    {
                        streamWriter.Write("\n");
                    }
                }
            }

            //SerializeToPersistence();

            MessageBox.Show("Products saved");
        }



        ///*** WORKING CODE FROM DELIVERABLE 12 ****/
        //private void SerializeToPersistence() 
        //{
        //    /**** FROM TEXTBOOK CHAPTER 17 PAGE 722 ****/
        //    string[] values = GetTextBoxValues();
        //    /**** Determine whether DataGridView row is empty ****/
        //    if (!string.IsNullOrEmpty(values[(int) TextBoxIndices.GuiId]))
        //    {
        //        // Store TextBox values in RecordSerializable and serialize it
        //        try
        //        {
        //            // Get ID number value from TextBox
        //            int guiId = int.Parse(values[(int) TextBoxIndices.GuiId]);

        //            // Determine whether guiId is valid
        //            if (guiId > 0)
        //            {
        //                // RecordSerializable to serialize
        //                var productRecord = new RecordSerializable(guiId,
        //                    values[(int) TextBoxIndices.GuiName],
        //                    values[(int) TextBoxIndices.GuiDescription],
        //                    decimal.Parse(values[(int) TextBoxIndices.GuiPrice]),
        //                    int.Parse(values[(int) TextBoxIndices.GuiQuantity]),
        //                    values[(int) TextBoxIndices.GuiCategory]);

        //                // Write Record to FileStream (serializable object)
        //                formatter.Serialize(output, productRecord);
        //            }
        //            else
        //            {
        //                // Notify user if invalid product ID number
        //                MessageBox.Show("Invalid product ID", "Error",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        catch (SerializationException)
        //        {
        //            MessageBox.Show("Error writing to File", "Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        catch (FormatException)
        //        {
        //            MessageBox.Show("Invalid format", "Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        ///*** WORKING CODE FROM DELIVERABLE 12 ****/
        //protected int TextBoxCount { get; set; } = 6;  // Number of TextBoxes conributing to new product in DataGridView

        //public enum TextBoxIndices {GuiId, GuiName, GuiDescription, GuiPrice, GuiQuantity, GuiCategory}

        //public void SetTextBoxValues(string[] values)
        //{
        //    // Determine whether string array has correct length
        //    if (values.Length != TextBoxCount)
        //    {
        //        // Throw exception if not correct length
        //        throw (new ArgumentException($"There must be {TextBoxCount} entries in the array", 
        //            nameof(values)));
        //    }
        //    else // Set array values if array has correct length 
        //    {
        //        // Set array values to TextBox values
        //        manageProductsProductIdTextBox.Text = values[(int)TextBoxIndices.GuiId];
        //        manageProductsProductNameTextBox.Text = values[(int)TextBoxIndices.GuiName];
        //        manageProductsProductDescriptionTextBox.Text = values[(int)TextBoxIndices.GuiDescription];
        //        manageProductsProductPriceTextBox.Text = values[(int)TextBoxIndices.GuiPrice];
        //        manageProductsProductQuantityTextBox.Text = values[(int)TextBoxIndices.GuiQuantity];
        //        manageProductsProductCategoryComboBox.Text = values[(int)TextBoxIndices.GuiCategory];
        //    }
        //}

        //public string[] GetTextBoxValues()
        //{
        //    return new string[] {
        //    manageProductsProductIdTextBox.Text, manageProductsProductNameTextBox.Text,
        //    manageProductsProductDescriptionTextBox.Text, manageProductsProductPriceTextBox.Text,
        //    manageProductsProductQuantityTextBox.Text, manageProductsProductCategoryComboBox.Text};
        //}
        ///*** ABOVE TO SERIALIZABLETOPERSISTENT() WORKING CODE FROM DELIVERABLE 12 ****/
        
        

        private void manageProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /**** DATAGRIDVIEW CELL INDICES BELOW SET TO 6-11 TO ACCOUNT FOR DELIVERABLE 12 COLUMNS WHERE VISIBLE SET TO FALSE (INDICES 0-5) ****/
            manageProductsProductIdTextBox.Text = manageProductsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            manageProductsProductNameTextBox.Text = manageProductsDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            manageProductsProductDescriptionTextBox.Text = manageProductsDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            manageProductsProductPriceTextBox.Text = manageProductsDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            manageProductsProductQuantityTextBox.Text = manageProductsDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            manageProductsProductCategoryComboBox.SelectedValue = manageProductsDataGridView.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void manageProductsSearchButton_Click(object sender, EventArgs e)
        {
            /**** WORKING CODE FROM MYCODESPACE TUTORIAL ****/
            if (manageProductsSearchComboBox.Text != "Category")
            {
                FilterByCategory();
            }
            else if (searchNameComboBox.Text != "Name")
            {
                FilterByName();
            }
            else if (searchPriceComboBox.Text != "Price")
            {
                SortByPrice();
            }
            else if (searchPriceComboBox.Text != "Quantity")
            {
                SortByQuantity();
            }
            else
            {

            }
        }

        private void SortByPrice()
        {
            
        }

        private void SortByQuantity()
        {

        }

        private void FilterByName()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Products WHERE Name = '" + searchNameComboBox.SelectedValue.ToString() + "';";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageProductsDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        /**** WORKING CODE FROM TUTORIAL ****/
        private void FilterByCategory()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Products WHERE Category = '" + manageProductsSearchComboBox.SelectedValue.ToString() + "';";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                manageProductsDataGridView.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void manageProductsRefreshButton_Click(object sender, EventArgs e)
        {
            /**** WORKING CODE FROM TUTORIAL ****/
            PopulateProductsGridView();
        }

        private void manageProductsHomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private void manageProductsProductsButton_Click(object sender, EventArgs e)
        {

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
