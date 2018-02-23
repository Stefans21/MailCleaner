using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using OpenPop.Mime;
using OpenPop.Pop3;
using Message = OpenPop.Mime.Message;

namespace MailCleaner
{
    public class ReceiveMail
    {
        public void Receive(string mailUser, string mailUserPwd, DataGridView dataGrid)
        {
            try
            {
                Pop3Client client = new Pop3Client();
                StringBuilder builder = new StringBuilder();
                client.Connect("pop-mail.outlook.com", 995, true);
                client.Authenticate(mailUser, mailUserPwd);
                var count = client.GetMessageCount();
                DataTable dt = new DataTable("Inbox");
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Sender", typeof(string));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Body", typeof(string));
                for (int i = 1; i <= count; i++)
                {
                    Application.DoEvents();
                    string body;
                    Message message = client.GetMessage(i);
                    MessagePart planeText = message.FindFirstHtmlVersion();
                    if (planeText != null)
                    {
                        // The message had a text/plain version - show that one
                        body = planeText.GetBodyAsText();
                    }
                    else
                    {
                        // Try to find a body to show in some of the other text versions
                        List<MessagePart> textVersions = message.FindAllTextVersions();
                        if (textVersions.Count >= 1)
                            body = textVersions[0].GetBodyAsText();
                        else
                            body = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
                    }
                    dt.Rows.Add(message.Headers.Subject, message.Headers.From, message.Headers.DateSent, body);
                }
                dataGrid.DataSource = dt;
                dataGrid.Sort(dataGrid.Columns[2], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
