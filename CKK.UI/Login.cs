using System.Data;
using System.Data.SqlClient;

namespace CKK.UI
{
    public partial class Login : Form
    {
        // Razer Blade laptop
        //public SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // Home Desktop
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        // OTech Desktop
        //public SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\4400113921\Documents\CKKdb.mdf;Integrated Security=True;Connect Timeout=30");

        //private string passwordInput;

        public Login()
        {
            InitializeComponent();
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked == true)
            {
                passwordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void clearLoginFormLabel_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void loginPowerButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM UserTbl WHERE Username = '" + 
                usernameTextBox.Text + "' AND Upassword = '" + passwordTextBox.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                ManageProducts cust = new ManageProducts();
                cust.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
            Con.Close();
        }
    }
}