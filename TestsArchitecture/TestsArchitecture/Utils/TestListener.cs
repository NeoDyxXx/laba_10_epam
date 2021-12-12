using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;
using System.IO;
using OpenQA.Selenium;
using System.Linq;

namespace TestsArchitecture.Utils
{
    public class TestListener : ITestListener
    {
        public void SendMessage(TestMessage message)
        {
            
        }

        public void TestFinished(ITestResult result)
        {
            try
            {
                string fileName;
                if (!Directory.Exists("Logs")) Directory.CreateDirectory("Logs");

                if (Directory.GetFiles(@"Logs\").Length == 0)
                {
                    fileName = @"Logs\Log_0.xml";
                }
                else
                {
                    fileName = @"Logs\Log_" + System.Convert.ToString(
                        Directory.GetFiles(@"Logs\").Select(item => System.Convert.ToInt32(item.Split('_')[1]))
                        .OrderByDescending(item => item).First() + 1) + ".xml";
                }

                using (StreamWriter fstream = new StreamWriter(fileName))
                {
                    fstream.Write(result.ToXml(true).OuterXml);
                }
            }
            catch {}

            if (result.ResultState.Status == TestStatus.Failed)
            {
                try
                {
                    Screenshot screenshot = ((ITakesScreenshot)Driver.DriverInstance.GetInstance()).GetScreenshot();

                    if (!Directory.Exists("Screenshots")) Directory.CreateDirectory("Screenshots");
                    if (Directory.GetFiles(@"Screenshots\").Length == 0)
                        screenshot.SaveAsFile(@"Screenshots\Screen_0.jpg");
                    else
                    {
                        string fileName = @"Screenshots\Screen_" + System.Convert.ToString(
                            Directory.GetFiles(@"Screenshots\").Select(item => System.Convert.ToInt32(item.Split('_')[1]))
                            .OrderByDescending(item => item).First() + 1) + ".jpg";

                        screenshot.SaveAsFile(fileName);
                    }
                }
                catch {}
            }
        }

        public void TestOutput(TestOutput output)
        {
            
        }

        public void TestStarted(ITest test)
        {
            
        }
    }
}
