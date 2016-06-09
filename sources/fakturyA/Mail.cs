using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace fakturyA
{
    static class Mail
    {
        public static void Send()
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("@gmail.com", ""); // set receiver


            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("faktury2017@gmail.com", "MojaFirma");
            mm.To.Add(new MailAddress("arkadiusz.duliban@gmail.com", "Arkadiusz Duliban"));
            mm.Subject = "Nowa faktura VAT";
            mm.IsBodyHtml = true;
            mm.Body = "<b>Źródło szczęścia!</b>";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("d:/cos.pdf");
            mm.Attachments.Add(attachment);

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
            MessageBox.Show("Email wysłany!");
        }
    }
}
