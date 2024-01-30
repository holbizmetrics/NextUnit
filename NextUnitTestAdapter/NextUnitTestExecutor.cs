﻿using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace NextUnit.TestAdapter
{
    [ExtensionUri("executor://NextUnitTestDiscoverer")]
    public class NextUnitTestExecutor : NextUnitBaseExecutor, ITestExecutor
    {
        public void Cancel()
        {
            Debugger.Launch();
        }

        public void RunTests(IEnumerable<TestCase>? tests, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
        {
            Debugger.Launch();
            var settings = runContext.RunSettings.SettingsXml;
            frameworkHandle.SendMessage(Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging.TestMessageLevel.Error, "RunTests");
            foreach (TestCase test in tests)
            {
                // Example: Mark the start of the test
                frameworkHandle.RecordStart(test);

                try
                {
                    // Execute the test and get the result
                    TestResult result = ExecuteTest(test);

                    // Example: Record the outcome of the test
                    frameworkHandle.RecordResult(result);
                }
                catch(FileLoadException ex)
                {

                }
                catch (Exception ex)
                {
                    // Handle any exceptions during test execution
                    frameworkHandle.RecordEnd(test, TestOutcome.Failed);
                    //frameworkHandle.RecordException(ex);
                }
            }
        }

        public void RunTests(IEnumerable<string>? sources, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
        {
            Debugger.Launch();

            var settings = runContext.RunSettings.SettingsXml;
            frameworkHandle.SendMessage(Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging.TestMessageLevel.Error, "RunTests");
        }
    }
}
