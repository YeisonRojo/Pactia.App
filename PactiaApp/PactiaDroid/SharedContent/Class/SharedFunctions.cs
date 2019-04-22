using System;
using System.Net.Mail;
using System.Text;
using Plugin.Connectivity;


namespace SharedContent
{
    public class SharedFunctions
    {
        /// <summary>
        /// Check if a string is empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsEmptyOrNullString(string text)
        {
            bool response;
            if (String.IsNullOrEmpty(text))
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }

        /// <summary>
        /// Check if is valid number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsValidNumber(string number)
        {
            bool response;
            try
            {
                int.Parse(number);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        /// <summary>
        /// Check the internet connection
        /// </summary>
        /// <returns></returns>
        public bool CheckInternetConnection()
        {
            bool IsInternetConnectionAvailable = false;
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    IsInternetConnectionAvailable = true;
                }
                else
                {
                    IsInternetConnectionAvailable = false;
                }
            }
            catch (Exception)
            {
                IsInternetConnectionAvailable = false;
            }
            return IsInternetConnectionAvailable;
        }

        /// <summary>
        /// Send the email
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="emailfor"></param>
        /// <param name="emailfrom"></param>
        /// <param name="password"></param>
        /// <param name="smtp"></param>
        /// <returns></returns>
        public string SendEmail(string subject, string message, string emailfor, string emailfrom, string password, string smtp)
        {
            string state = string.Empty;
            try
            {
                SmtpClient client = new SmtpClient(smtp, 25);
                client.EnableSsl = true;            
                client.Credentials = new System.Net.NetworkCredential(emailfrom, password);
                MailAddress from = new MailAddress(emailfrom, String.Empty, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(emailfor);
                MailMessage mailmessage = new MailMessage(from, to);
                mailmessage.Body = message;
                mailmessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailmessage.Subject = subject;
                mailmessage.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(mailmessage);
                state = "Su mensaje ha sido enviado correctamente";
            }
            catch (Exception)
            {
                state = "Ha ocurrido un error al enviar el mensaje, intente nuevamente.";
            }
            return state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool TimeoutExecute(Delegate method, int seconds)
        {
            bool actionResult = false;
            IAsyncResult result;
            Action action = () =>
            {
                method.DynamicInvoke(new object[] { });
            };
            result = action.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(seconds))
                actionResult = true;
            else
                actionResult = false;
            return actionResult;
        }
    }
}





