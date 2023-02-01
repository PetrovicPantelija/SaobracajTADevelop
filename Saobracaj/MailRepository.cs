using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj
{
    public class MailRepository : IMailRepository
    {
        public void Connect(string hostname, string username, string password, int port, bool isUseSsl)
        {
            this._client = new Pop3Client();
            this._client.Connect(hostname, port, isUseSsl);
            this._client.Authenticate(username, password);
        }

        public List<Pop3Mail> GetMail()
        {
            int messageCount = this._client.GetMessageCount();

            var allMessages = new List<Pop3Mail>(messageCount);

            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(new Pop3Mail() { MessageNumber = i, Message = this._client.GetMessage(i) });
            }

            return allMessages;
        }

        public List<Pop3Mail> GetMail(string fromAddress)
        {
            int messageCount = this._client.GetMessageCount();

            var allMessages = new List<Pop3Mail>();

            for (int i = messageCount; i > 0; i--)
            {
                var msg = this._client.GetMessage(i);

                allMessages.Add(new Pop3Mail { Message = msg, MessageNumber = i });
            }

            var relevantMail = allMessages.Where(m => m.Message.Headers.From.Address == fromAddress).ToList();

            return relevantMail;
        }

        public List<Pop3Mail> GetMail(string fromAddress, string toAddress)
        {
            int messageCount = this._client.GetMessageCount();

            var allMessages = new List<Pop3Mail>();

            for (int i = messageCount; i > 0; i--)
            {
                var msg = this._client.GetMessage(i);

                allMessages.Add(new Pop3Mail { Message = msg, MessageNumber = i });
            }

            var relevantMail = allMessages.Where(m => m.Message.Headers.From.Address == fromAddress && m.Message.Headers.To.Any(n => n.Address == toAddress)).ToList();

            return relevantMail;
        }

        public List<string> GetAttachments(Message msg)
        {
            var getAttachments = new List<string>();

            var attachments = msg.FindAllAttachments();
            var attachmentdirectory = @"c:\temp\mail\attachments";

            Directory.CreateDirectory(attachmentdirectory);

            foreach (var att in attachments)
            {
                string filename = string.Format(@"{0}{1}_{2}{3}", attachmentdirectory, Path.GetFileNameWithoutExtension(att.FileName), DateTime.Now.ToString("MMddyyyyhhmmss"), Path.GetExtension(att.FileName));
                att.Save(new FileInfo(filename));

                getAttachments.Add(filename);
            }

            return getAttachments;
        }

        public void DeleteAll()
        {
            this._client.DeleteAllMessages();
        }

        public void Delete(int msgNumber)
        {
            this._client.DeleteMessage(msgNumber);
        }

        private Pop3Client _client { get; set; }
    }

    public class Pop3Mail
    {
        public int MessageNumber { get; set; }
        public Message Message { get; set; }
    }
}
