using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using RICH.Common;
namespace RICH.Common.Utilities
{
    public sealed partial class SystemNotification
    {
        public const string SubjectElementName = "Subject",
                            MessageElementName = "Message";
        private string emailContentName = null;
        private string subject = null;
        private string message = null;
        private IDictionary<string, string> parameters;
        private XElement xEmailContent = null;
        private string emailContentXmlPath = null;

        public string Host { get; set; }
        public int Port { get; set; }
        public ICredentialsByHost Credential { get; set; }

        public SystemNotification(string subject, string message)
        {
            if (subject.IsHtmlNullOrWiteSpace())
            {
                throw new ArgumentNullException("subject");
            }
            if (message.IsHtmlNullOrWiteSpace())
            {
                throw new ArgumentNullException("message");
            }
            this.Subject = subject;
            this.Message = message;
        }

        public SystemNotification(string emailContentName, string emailContentXmlPath, IDictionary<string, string> parameters)
        {
            this.emailContentName = emailContentName;
            this.parameters = parameters;
            this.emailContentXmlPath = emailContentXmlPath;
            Init();
        }

        #region ICompanyNotification

        public bool EnableNotification
        {
            get { return true; }
        }

        public string From { get; set; }
        public IEnumerable<string> To { get; set; }
        public IEnumerable<string> CC { get; set; }
        public IEnumerable<string> BCC { get; set; }
        public IEnumerable<Pair<string, Byte[]>> Attachments { get; set; }

        public string Subject
        {
            get
            {
                if (subject.IsNullOrWhiteSpace() && !xEmailContent.IsEmpty)
                {
                    var xSubject = xEmailContent.Element(SubjectElementName);
                    if (xSubject == null || xSubject.Value.IsNullOrWhiteSpace())
                    {
                        throw new ArgumentNullException(SubjectElementName);
                    }
                    subject = xSubject.Value;
                    foreach (var item in parameters)
                    {
                        subject = subject.Replace(item.Key, item.Value);
                    }
                }
                return subject;
            }
            private set
            {
                subject = value;
            }
        }

        public string Message
        {
            get
            {
                if (message.IsNullOrWhiteSpace() && !xEmailContent.IsEmpty)
                {
                    var xMessage = xEmailContent.Element(MessageElementName);
                    if (xMessage == null || xMessage.Value.IsNullOrWhiteSpace())
                    {
                        throw new ArgumentNullException(MessageElementName);
                    }
                    message = xMessage.Value;
                    foreach (var item in parameters)
                    {
                        message = message.Replace(item.Key, item.Value);
                    }
                }
                return message;
            }
            private set
            {
                message = value;
            }
        }

        public void SendNotification(bool isAsync = true)
        {
            Mail.SendMail
            (
                To,
                Subject,
                Message,
                Attachments,
                ccAddresses: CC,
                bccAddresses: BCC,
                senderAddress: From,
                host: Host,
                port: Port,
                credential: Credential,
                isAsync: isAsync
            );
        }

        #endregion

        #region Methods

        private void Init()
        {
            var xEmailContents = XElement.Load(emailContentXmlPath);
            var currentContents = xEmailContents
                .Elements("EmailContent")
                .Where(item => item.Attribute("name") != null && item.Attribute("name").Value.Equals(emailContentName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (currentContents.IsNullOrEmpty())
            {
                throw new Exception("EmailContent");
            }
            xEmailContent = currentContents.FirstOrDefault();
        }
        #endregion
    }
}
