using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TestsArchitecture.Utils
{
    [Serializable]
    public class ResultTestInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ResultTestInfo() {}

        public ResultTestInfo(TestContext testContext)
        {
            ID = testContext.Test.ID;
            Name = testContext.Test.Name;
            FullName = testContext.Test.FullName;
            MethodName = testContext.Test.MethodName;

            switch (testContext.Result.Outcome.Status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive: Status = "Inconclusive"; break;
                case NUnit.Framework.Interfaces.TestStatus.Failed: Status = "Failed"; break;
                case NUnit.Framework.Interfaces.TestStatus.Passed: Status = "Succeeded"; break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped: Status = "Skipped"; break;
                case NUnit.Framework.Interfaces.TestStatus.Warning: Status = "Warning"; break;
                default: Status = "Succeeded"; break;
            }

            Message = testContext.Result.Message;
            StackTrace = testContext.Result.StackTrace;
        }
    }
}
