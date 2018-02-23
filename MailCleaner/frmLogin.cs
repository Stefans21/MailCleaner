using System;
using System.Windows.Forms;

namespace MailCleaner
{
    public partial class frmLogin : Form
    {
        string mailUser = "stefans_21@outlook.com";
        string mailUserPwd = "stefans1992";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Validation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Validation()
        {
            if (mailUser == txtUserName.Text && mailUserPwd == txtPassword.Text)
            {
                Hide();
                frmMainForm frm = new frmMainForm();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }
        
    }
}
