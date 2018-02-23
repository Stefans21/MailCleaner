using System;
using System.Windows.Forms;

namespace MailCleaner
{
    public partial class frmSendMail : Form
    {
        public frmSendMail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            SendMail sendReceiveMail = new SendMail(users.MailUser, users.MailUserPwd);
            sendReceiveMail.Send(txtTo.Text, txtSubject.Text, txtMessage.Text);
            MessageBox.Show("Mail is sent");
            Close();
        }
    }
}
