using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues.Utils
{
    public class EmailsUtil
    {
        public void SendEmailError(string message, string className, string method)
        {
            try
            {
                string addressTo = ConfigurationManager.AppSettings["errorEmailTo"].ToString();
                string addressFrom = ConfigurationManager.AppSettings["prmEmail"].ToString();
                string pass = ConfigurationManager.AppSettings["prmPass"].ToString();
                string host = ConfigurationManager.AppSettings["smtpHost"].ToString();
                string port = ConfigurationManager.AppSettings["prmPort"].ToString();
                /*----------------------------------------------------------------*/
                /*---------------------------EMAIL MESSAGE------------------------*/
                //Create the new mesaje objet
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                //set the email adress
                mmsg.To.Add(addressTo);

                //Important: the "to" property let to send email to many adress

                //Subject
                mmsg.Subject = $"Bronto API ERROR: {className}-{method}";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Email adress that want to recive the message.
                //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Optional

                //Message
                mmsg.Body = message;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

                //Email "From"
                mmsg.From = new System.Net.Mail.MailAddress(addressFrom);

                /*----------------------------------------------------------------*/
                /*----------------------------EMAIL CLIENT------------------------*/
                //Generate the client objet
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                // Create credentials to sender email
                cliente.Credentials =
                    new System.Net.NetworkCredential(addressFrom, pass);

                //this is needed to send a email from GMAIL.
                // /*
                cliente.Port = Convert.ToInt32(port);
                //cliente.EnableSsl = true;
                // */

                //cliente.Host = "mail.servidordominio.com"; //for Gmail "smtp.gmail.com";
                cliente.Host = host;
                cliente.Send(mmsg);

            }
            catch (Exception ex)
            {
                new LogError().LogErrors("EmailUtil", "SendEMail", ex.Message, $"content msj: {message}", false);
            }

        }
    }
}
