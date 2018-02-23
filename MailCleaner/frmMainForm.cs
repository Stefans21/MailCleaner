using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace MailCleaner
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            LoadMail();
        }
        
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            frmSendMail sendMail = new frmSendMail();
            sendMail.Show();
        }
        
        private void btnReceive_Click(object sender, EventArgs e)
        {
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            webBrowser1.DocumentText = dataGrid.CurrentRow.Cells["Body"].Value.ToString();
        }

        public void StartForm()
        {
            Application.Run(new frmLoadingForm());
        }

        private void LoadMail()
        {
            Thread thread = new Thread(StartForm);
            thread.Start();
            InitializeComponent();
            Users users = new Users();
            ReceiveMail receiveMail = new ReceiveMail();
            receiveMail.Receive(users.MailUser, users.MailUserPwd, dataGrid);
            thread.Abort();
        }
    }
}
