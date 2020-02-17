using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Web;
using System.IO;


namespace EnvironmentSetting.ExceptionManager
{
    public class CustomException : Exception , ICustomException
    {

        public CustomException()
        {

        }
        public CustomException(string message)
                : base(message)
        {

        }
        public CustomException(string message, Exception innerException)
                : base(message, innerException)
        {

        }


        public static void WriteMessageToFile(string message)
        {
            //Code to write file...
            try
            {
                var fileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CustomMessageFileName"]);

                var errorMessages = new StringBuilder();
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                errorMessages.AppendLine("Message : " + message + "\n");

                errorMessages.AppendLine("----------------------------------------------" + "\n");

                fileName = fileName.Replace(".txt", "_" + DateTime.Now.ToString("MMddyyyy") + ".txt");

                using (StreamWriter sw = (File.Exists(fileName)) ? File.AppendText(fileName) : File.CreateText(fileName))
                {
                    sw.Write(errorMessages.ToString());
                }

                //if (File.Exists(fileName) && fileName != null)
                //{
                //    File.AppendAllText(fileName, errorMessages.ToString());
                //}
            }
            catch (Exception)
            {



            }

        }

      
        public static void WriteExceptionMessageToFile(string message, Exception exception)
        {
            //Code to write file...
            try
            {
                var fileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CustomExceptionFileName"]);

                var errorMessages = new StringBuilder();
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                //errorMessages.AppendLine("UserName : " + HttpContext.Current.Session[SessionVariables.email] + "\n");
                errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                errorMessages.AppendLine("Message : " + exception.Message + "\n");
                errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                errorMessages.AppendLine("----------------------------------------------" + "\n");

                if (File.Exists(fileName) && fileName != null)
                {
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
            }
            catch (Exception)
            {

                var fileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CustomExceptionFileName"]);

                var errorMessages = new StringBuilder();
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                errorMessages.AppendLine("Message : " + exception.Message + "\n");
                errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                errorMessages.AppendLine("----------------------------------------------" + "\n");

                if (File.Exists(fileName) && fileName != null)
                {
                    File.AppendAllText(fileName, errorMessages.ToString());
                }

            }

        }

     

    }
}
