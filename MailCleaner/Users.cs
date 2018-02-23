using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailCleaner
{
    public class Users
    {
        string mailUser = "stefans_21@outlook.com";
        string mailUserPwd = "stefans1992";

        public string MailUser
        {
            get { return mailUser; }
            set { mailUser = value; }
        }

        public string MailUserPwd
        {
            get { return mailUserPwd; }
            set { mailUserPwd = value; }
        }

    }
}
