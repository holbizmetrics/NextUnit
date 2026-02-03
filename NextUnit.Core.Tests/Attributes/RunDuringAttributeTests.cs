using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the RunDuring attribute which only executes a test within a specified time window.
    /// </summary>
    public class RunDuringAttributeTests
    {
        /// <summary>
        /// Test that should run during a very wide time window (always runs).
        /// </summary>
        [Test]
        [Group(nameof(RunDuringAttribute))]
        [RunDuring("2020-01-01T00:00:00", "2050-12-31T23:59:59")]
        public void RunDuringAttributeTest_WideTimeWindow()
        {
            Trace.WriteLine($"Test executed at: {DateTime.Now}");
        }

        /// <summary>
        /// Test with a time window that has already passed (should be skipped).
        /// </summary>
        [Test]
        [Group(nameof(RunDuringAttribute))]
        [RunDuring("2020-01-01T00:00:00", "2020-12-31T23:59:59")]
        public void RunDuringAttributeTest_PastTimeWindow()
        {
            Trace.WriteLine("This should be skipped if the time window is enforced");
        }

        /// <summary>
        /// Test with a time window in the future (should be skipped).
        /// </summary>
        [Test]
        [Group(nameof(RunDuringAttribute))]
        [RunDuring("2050-01-01T00:00:00", "2050-12-31T23:59:59")]
        public void RunDuringAttributeTest_FutureTimeWindow()
        {
            Trace.WriteLine("This should be skipped if the time window is enforced");
        }
    }
}
