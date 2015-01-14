using System;
using System.ComponentModel;
using System.IO;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.Web.Configuration;

namespace RICH.Common.Utilities
{
    public static class Mail
    {
        public static void SendMail(
            IEnumerable<MailAddress> tos,
            string subject,
            string message,
            IEnumerable<Pair<string, byte[]>> attachments = null,
            bool isAsync = true,
            IEnumerable<MailAddress> ccs = null,
            IEnumerable<MailAddress> bccs = null,
            MailAddress sender = null,
            string host = null,
            int port = 0,
            ICredentialsByHost credential = null
        )
        {
            if (tos.IsNullOrEmpty() && ccs.IsNullOrEmpty() && bccs.IsNullOrEmpty())
            {
                throw new InvalidOperationException("No recipient specified");
            }
            if (subject.IsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("No message subject found");
            }
            if (message.IsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("No message body found");
            }
            MailMessage mailMessage = new MailMessage();
            if (!tos.IsNullOrEmpty())
            {
                mailMessage.To.AddRange(tos);
            }
            if (!ccs.IsNullOrEmpty())
            {
                mailMessage.CC.AddRange(ccs);
            }
            if (!bccs.IsNullOrEmpty())
            {
                mailMessage.Bcc.AddRange(bccs);
            }
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            if (sender != null)
            {
                mailMessage.ReplyToList.Add(sender);
                mailMessage.From = sender;
                mailMessage.Sender = sender;
            }
            if (!attachments.IsNullOrEmpty())
            {
                foreach (Pair<string, byte[]> attachment in attachments)
                {
                    MemoryStream ms = new MemoryStream(attachment.Value);
                    ContentType ct = GetContentType(attachment.Key.Substring(attachment.Key.LastIndexOf(".", StringComparison.Ordinal) + 1));
                    Attachment data = new Attachment(ms, ct);
                    data.ContentDisposition.FileName = attachment.Key;
                    mailMessage.Attachments.Add(data);
                }
            }
            SendMail(mailMessage, isAsync, host, port, credential);
        }

        public static void SendMail(
            IEnumerable<string> toAddresses,
            string subject,
            string message,
            IEnumerable<Pair<string, byte[]>> attachments = null,
            bool isAsync = true,
            IEnumerable<string> ccAddresses = null,
            IEnumerable<string> bccAddresses = null,
            string senderAddress = null,
            string host = null,
            int port = 0,
            ICredentialsByHost credential = null
        )
        {
            if (toAddresses.IsNullOrEmpty() && ccAddresses.IsNullOrEmpty() && bccAddresses.IsNullOrEmpty())
            {
                throw new InvalidOperationException("No recievers specified");
            }
            SendMail
            (
                toAddresses.IsNullOrEmpty() ? null : toAddresses.Where(address => address.IsValidEmail()).Select(address => new MailAddress(address)),
                subject,
                message,
                attachments,
                isAsync,
                ccAddresses.IsNullOrEmpty() ? null : ccAddresses.Where(address => address.IsValidEmail()).Select(address => new MailAddress(address)),
                bccAddresses.IsNullOrEmpty() ? null : bccAddresses.Where(address => address.IsValidEmail()).Select(address => new MailAddress(address)),
                senderAddress.IsValidEmail() ? new MailAddress(senderAddress) : null,
                host,
                port,
                credential
            );
        }

        private static void SendMail(MailMessage mailMessage, bool isAsync, string host = null, int port = 0, ICredentialsByHost credential = null)
        {
            if (null == mailMessage)
            {
                throw new ArgumentNullException("mailMessage");
            }
            if (mailMessage.To.IsNullOrEmpty() && mailMessage.CC.IsNullOrEmpty() && mailMessage.Bcc.IsNullOrEmpty())
            {
                throw new InvalidOperationException("No recievers specified");
            }
            if (mailMessage.Body.IsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("No message body found");
            }
            mailMessage.IsBodyHtml = true;
            if (host == null)
            {
                SmtpSection cfg = NetSectionGroup.GetSectionGroup(WebConfigurationManager.OpenWebConfiguration("~/web.config")).MailSettings.Smtp;
                host = cfg.Network.Host;
                port = cfg.Network.Port;
                credential = new System.Net.NetworkCredential(cfg.Network.UserName, cfg.Network.Password);
            }
            if (isAsync)
            {
                var thread = new Thread(() => { SendMailProc(mailMessage, host, port, credential); }) { IsBackground = true };
                thread.Start();
            }
            else
            {
                SendMailProc(mailMessage, host, port, credential);
            }
        }

        private static void SendMailProc(object mailMessage, string host = null, int port = 0, ICredentialsByHost credential = null)
        {
            try
            {
                var smtpClient = new SmtpClient(host, port);
                if (credential != null)
                {
                    smtpClient.Credentials = credential;
                }
                smtpClient.Send((MailMessage) mailMessage);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private static ContentType GetContentType(string extName = null)
        {
            if (extName.IsNullOrEmpty())
            {
                return new ContentType(MediaTypeNames.Text.Plain);
            }
            ContentType contentType = new ContentType();
            switch (extName.ToLower())
            {
                case "pdf":
                    contentType.MediaType = MediaTypeNames.Application.Pdf;
                    break;
                case "rtf":
                    contentType.MediaType = MediaTypeNames.Application.Rtf;
                    break;
                case "zip":
                    contentType.MediaType = MediaTypeNames.Application.Zip;
                    break;
                case "gif":
                    contentType.MediaType = MediaTypeNames.Image.Gif;
                    break;
                case "jpg":
                case "jpeg":
                    contentType.MediaType = MediaTypeNames.Image.Jpeg;
                    break;
                case "tiff":
                    contentType.MediaType = MediaTypeNames.Image.Tiff;
                    break;
                case "html":
                case "htm":
                    contentType.MediaType = MediaTypeNames.Text.Html;
                    break;
                case "txt":
                    contentType.MediaType = MediaTypeNames.Text.Plain;
                    break;
                case "xml":
                    contentType.MediaType = MediaTypeNames.Text.Xml;
                    break;
                default:
                    contentType.MediaType = MediaTypeNames.Text.Plain;
                    break;
            }
            return contentType;
        }
    }
}
