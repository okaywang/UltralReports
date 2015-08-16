using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
namespace Rinch.Common
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class MailProcess
    {
        /// <summary>
        /// 邮件服务器
        /// </summary>
        private static readonly String Host = "Smtpsrv02.vancloa.cn";
        /// <summary>
        /// 服务器用户名
        /// </summary>
        private static readonly String ServerUser = "webmaster@vancloa.cn";
        /// <summary>
        /// 服务器密码
        /// </summary>
        private static readonly String Pwd  = ".u8x9y1m4k7r3h6";
        /// <summary>
        /// 发送者
        /// </summary>
        private static readonly String From = "webmaster@vancl.cn";
        /// <summary>
        /// 发送地址
        /// </summary>
        public string[] To { get; set; }
        /// <summary>
        /// 抄送地址
        /// </summary>
        public string[] CC { get; set; }
        /// <summary>
        /// 暗送地址
        /// </summary>
        public string[] BCC { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string[] Attach { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 邮件编码，默认utf-8
        /// </summary>
        public string Encoding = "UTF-8";
        /// <summary>
        /// 端口号，默认25
        /// </summary>
        public int Port = 25;
        /// <summary>
        /// 是否以html编码方式发送邮件，默认是
        /// </summary>
        public bool isBodyHtml = true;
        /// <summary>
        /// 发送邮件
        /// </summary>
        public void Send()
        {
            SmtpClient sc = new SmtpClient();
            sc.Host = Host;
            sc.Port = Port;
            sc.Credentials = new System.Net.NetworkCredential(ServerUser, Pwd);
            MailMessage mm = new MailMessage();
            //发送到的地址
            this.getMailAddr(mm.Bcc, BCC);
            this.getMailAddr(mm.CC, CC);
            this.getMailAddr(mm.To, To);
            mm.From = new MailAddress(From);
            mm.Subject = Title;
            mm.Body = Content;
            mm.IsBodyHtml = isBodyHtml;
            mm.BodyEncoding = System.Text.Encoding.GetEncoding(this.Encoding);
            mm.SubjectEncoding = System.Text.Encoding.GetEncoding(this.Encoding);
            if (Attach != null)
            {
                foreach (string attaddr in Attach)
                {
                    mm.Attachments.Add(new System.Net.Mail.Attachment(attaddr));
                }
            }
            sc.Send(mm);
        }



        private void getMailAddr(MailAddressCollection m, string[] straddr)
        {
            if (straddr != null)
            {
                foreach (string toaddr in straddr)
                {
                    m.Add(toaddr);
                }
            }

        }

    }
}
