
using System;
using System.IO;
using System.Text;


/// <summary>
/// Summary description for MessageLog
/// </summary>
    public class MessageLogger
    {
        private string sLogFormat;
        private string sMessageTime;
        private string sFilePath;

        public void hello(string x)
        {

        }
        public MessageLogger(string FilePath)
        {
            sFilePath = FilePath;
        }

        public void LogMessage(string sErrMsg)
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : MessageLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sMessageTime = sYear + sMonth + sDay;

            StreamWriter sw = new StreamWriter(sFilePath + sMessageTime + ".txt", true);
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }
    }



