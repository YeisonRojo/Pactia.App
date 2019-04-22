using System;
using System.Net.Mail;
using Plugin.Connectivity;


namespace SharedContent
{
    public class SharedFunctions
    {

     /// <summary>
     /// Ises the empty or null string.
     /// </summary>
     /// <returns><c>true</c>, if empty or null string was ised, <c>false</c> otherwise.</returns>
     /// <param name="text">Text.</param>
        public static bool IsEmptyOrNullString(string text)
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
        /// Ises the valid number.
        /// </summary>
        /// <returns><c>true</c>, if valid number was ised, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        public static bool IsValidNumber(string number)
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
        /// Checks the internet connection.
        /// </summary>
        /// <returns><c>true</c>, if internet connection was checked, <c>false</c> otherwise.</returns>
        public static bool CheckInternetConnection()
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
        /// Sends the email.
        /// </summary>
        /// <returns>The email.</returns>
        /// <param name="subject">Subject.</param>
        /// <param name="message">Message.</param>
        /// <param name="emailfor">Emailfor.</param>
        /// <param name="emailfrom">Emailfrom.</param>
        /// <param name="password">Password.</param>
        /// <param name="smtp">Smtp.</param>
        public static string SendEmail(string subject, string message, string emailfor, string emailfrom, string password, string smtp)
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





