using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace GitUtility.Command
{
    public class Commander
    {
        private ProcessStartInfo cmdStartInfo;
        private Process cmdProcess;
        private List<string> output;
        private Print printout;
        private Print printerr;

        public bool WaitForExit { get; set; }
        public int StreamDelay { get; set; }
        public delegate void Print(string txt);
        
        public Commander(string exec, string args = "")
        {
            InitCommander(exec, args);
        }

        public Commander(Print p, string exec, string args = "")
        {
            InitCommander(exec, args);
            SetPrintDelegate(p);
        }

        // destructor
        ~Commander()
        {
            Close();
            output.Clear();
            printout = null;
            printerr = null;
        }

        private void InitCommander(string exec, string args)
        {
            printout = null;
            printerr = null;
            WaitForExit = false;
            StreamDelay = 5;
            output = new List<string>();

            // prepare process info
            cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = exec;
            cmdStartInfo.Arguments = args;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;
        }

        private void PrintOut(Print print, string msg)
        {
            // if delegate has been declared, then execute
            if (print != null)
            {
                Thread.Sleep(StreamDelay);
                print.Invoke(msg);
            }
            else
            {
                lock (output)
                {
                    output.Add(msg);
                }
            }
        }

        public void SetPrintDelegate(Print outp, Print err = null)
        {
            printout = outp;
            printerr = err;
        }
        
        public void Start()
        {
            if (cmdProcess!=null)
            {
                Close();
            }

            // setup process
            cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.ErrorDataReceived += Error;
            cmdProcess.OutputDataReceived += Received;
            cmdProcess.EnableRaisingEvents = true;

            // start process
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
        }

        public void Execute(string cmd)
        {
            cmdProcess.StandardInput.Write(cmd+"\n");
            cmdProcess.StandardInput.Flush();
        }

        public void Close()
        {
            if (WaitForExit) cmdProcess.WaitForExit();
            cmdProcess.Close();
        }

        public bool HasOutput()
        {
            lock (output)
            {
                return output.Count > 0;
            }
        }
        
        public string GetOutput()
        {
            lock (output)
            {
                string msg = output[0];
                output.RemoveAt(0);
                return msg;
            }
        }

        // ============================================================================
        //                  console events
        // ============================================================================

        void Received(object sender, DataReceivedEventArgs e)
        {
            PrintOut(printout, e.Data);
        }

        void Error(object sender, DataReceivedEventArgs e)
        {
            PrintOut(printerr, e.Data);
        }
    }
}
