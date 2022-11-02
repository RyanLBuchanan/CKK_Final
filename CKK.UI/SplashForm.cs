using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.UI
{
    public partial class SplashForm : Form
    {
        private int startPoint = 0; 

        public SplashForm()
        {
            InitializeComponent();
        }

        private void splashFormTimer_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            splashFormCircleProgressBar.Value = startPoint;
            if (splashFormCircleProgressBar.Value == 100)
            {
                splashFormCircleProgressBar.Value = 0;
                splashFormTimer.Stop();
                this.Hide();
                Login login = new Login();
                login.Show();
                //ManageProducts manageProducts = new ManageProducts();
                //manageProducts.Show();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            splashFormTimer.Start();
        }
    }
}
