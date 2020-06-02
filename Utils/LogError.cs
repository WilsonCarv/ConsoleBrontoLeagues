using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues.Utils
{
    public class LogError
    {
        public void LogErrors(string pClass, string pMethod, string pExceptionMessage, string pNote = null, bool sendEmail = true)
        {
            try
            {
                var _path = "C:\\Bronto\\LogErrors";

                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                StreamWriter writer;
                if (!File.Exists($"{_path}{pClass}.txt"))
                    writer = File.CreateText($"{_path}{pClass}.txt");
                else
                    writer = File.AppendText($"{_path}{pClass}.txt");
                writer.WriteLine("");
                writer.WriteLine("**********************************" + DateTime.Now.ToString("dd MMMM yyyy H:mm:ss") + "****************************************");
                writer.WriteLine("MethodName: " + pMethod);
                writer.WriteLine("EXMessage: " + pExceptionMessage);
                writer.WriteLine("Notes: " + pNote);
                writer.WriteLine("-----------------------------------------------" + "END" + "------------------------------------------------");
                writer.WriteLine("");
                writer.Close();

                if (sendEmail)
                {
                    EmailsUtil ObjEmailUtil = new EmailsUtil();
                    ObjEmailUtil.SendEmailError(pExceptionMessage, pClass, pMethod);
                }

            }
            catch (Exception ex)
            {
                if (sendEmail)
                    LogErrors(pClass, "LogErrors", ex.Message, null, false);
            }
        }
    }
}
