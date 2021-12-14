using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestsArchitecture.Utils
{
    public static class TestLogger
    {
        public static void LogStat(TestContext testContext)
        {
            string xmlFileName;

            if (!Directory.Exists("XmlResultTests")) Directory.CreateDirectory("XmlResultTests");
            if (Directory.GetFiles(@"XmlResultTests\").Length == 0)
                xmlFileName = @"XmlResultTests\Xml" + testContext.Test.MethodName + "_0.xml";
            else
            {
                xmlFileName = @"XmlResultTests\Xml" + testContext.Test.MethodName + "_" + System.Convert.ToString(
                    Directory.GetFiles(@"XmlResultTests\").Select(item => System.Convert.ToInt32(item.Split('_')[1].Split(".")[0]))
                    .OrderByDescending(item => item).First() + 1) + ".xml";
            }

            XmlSerializer formatter = new XmlSerializer(typeof(Utils.ResultTestInfo));
            using (FileStream fs = new FileStream(xmlFileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, new Utils.ResultTestInfo(testContext));
            }

            if (testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                try
                {
                    Screenshot screenshot = ((ITakesScreenshot)Driver.DriverInstance.GetInstance()).GetScreenshot();

                    if (!Directory.Exists("Screenshots")) Directory.CreateDirectory("Screenshots");
                    if (Directory.GetFiles(@"Screenshots\").Length == 0)
                        screenshot.SaveAsFile(@"Screenshots\Screen" + testContext.Test.MethodName + "_0.jpg");
                    else
                    {
                        string fileName = @"Screenshots\Screen" + testContext.Test.MethodName + "_" + System.Convert.ToString(
                            Directory.GetFiles(@"Screenshots\").Select(item => System.Convert.ToInt32(item.Split('_')[1].Split(".")[0]))
                            .OrderByDescending(item => item).First() + 1) + ".jpg";

                        screenshot.SaveAsFile(fileName);
                    }
                }
                catch {}
            }
        }
    }
}
