using BusinessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 frmMainPage = new Form2();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.Find(txtUserName.Text, txtPassword.Text) != null)
            {
                frmMainPage.Show();

                this.Hide();
            }
            else
            {

                MessageBox.Show("UserName Or Password Is Not Correct", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
