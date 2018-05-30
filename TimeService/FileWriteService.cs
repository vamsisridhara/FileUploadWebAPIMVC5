using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TimeService
{
    public partial class FileWriteService : ServiceBase
    {
        System.Timers.Timer timeDelay;
        int count;
        public FileWriteService()
        {
            InitializeComponent();
            timeDelay = new System.Timers.Timer();
            timeDelay.Elapsed += new System.Timers.ElapsedEventHandler(WorkProcess);
        }
        public void WorkProcess(object sender, System.Timers.ElapsedEventArgs e)
        {
            string process = "Timer Tick " + count;
            LogService(process);
            count++;
        }
        protected override void OnStart(string[] args)
        {
            LogService("Service Started");
            timeDelay.Enabled = true;
        }
        protected override void OnStop()
        {
            LogService("Service Stoped");
            timeDelay.Enabled = false;
        }
        private void LogService(string content)
        {
            using (FileStream fs = new FileStream(@"c:\TestServiceLog.txt", FileMode.OpenOrCreate, 
                FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(content);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}
