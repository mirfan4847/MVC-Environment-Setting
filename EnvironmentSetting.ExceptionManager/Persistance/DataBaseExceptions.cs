using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Web;
using System.Configuration;

namespace EnvironmentSetting.ExceptionManager
{
    public class DataBaseExceptions : Exception , IDataBaseExceptions
    {

        #region Constructor
        public DataBaseExceptions()
        {

        }
        public DataBaseExceptions(string message)
                : base(message)
        {

        }
        public DataBaseExceptions(string message, Exception innerException)
                : base(message, innerException)
        {

        }

        #endregion

     

        #region Static Methods
        public static void WriteExceptionMessageToFile(string message, Exception exception)
        {
            try
            {
                //string fileName =  HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DataBaseExceptionFileName"]);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["DataBaseExceptionFileName"]);

                StringBuilder errorMessages = new StringBuilder();
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                //errorMessages.AppendLine("UserName : " + HttpContext.Current.Session[SessionVariables.email] + "\n");

                if (exception != null)
                {
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + exception.Message + "\n");
                    errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                    errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                    errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                    errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                }
                else
                {
                    errorMessages.AppendLine("Message : " + message + "\n");
                }
                errorMessages.AppendLine("----------------------------------------------" + "\n");

                if (File.Exists(fileName) && fileName != null)
                {
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
            }
            catch (Exception)
            {

                var fileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DataBaseExceptionFileName"]);

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
        #endregion
    }
}
