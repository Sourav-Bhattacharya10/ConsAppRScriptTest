using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppRScriptTest
{
    class RScriptClass
    {
        public static string Run()
        {
            string result = null;

            string RCodeFilePath = @"C:\Users\Sourav Bhattacharya\Documents\Visual Studio 2017\Projects\ConsAppRScriptTest\ConsAppRScriptTest\Test1.R";

            string RScriptExecutablePath = @"C:\Program Files\R\R-3.4.3\bin\x64\Rscript.exe";

            try
            {
                var info = new ProcessStartInfo()
                {
                    FileName = RScriptExecutablePath,
                    WorkingDirectory = Path.GetDirectoryName(RScriptExecutablePath),
                    Arguments = RCodeFilePath,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    StreamReader sr = proc.StandardOutput;
                    result = sr.ReadToEnd();
                    proc.Close();
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }
    }
}
