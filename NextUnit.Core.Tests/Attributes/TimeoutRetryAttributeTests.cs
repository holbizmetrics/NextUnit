using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the TimeoutRetry attribute which combines retry logic with timeout constraints.
    /// The test will retry until either the retry count is exhausted or the timeout is exceeded.
    /// </summary>
    public class TimeoutRetryAttributeTests
    {
        private static int _attemptCount = 0;

        /// <summary>
        /// Test that passes within the timeout and retry limits.
        /// </summary>
        [Test]
        [Group(nameof(TimeoutRetryAttribute))]
        [TimeoutRetry(3, "00:00:05")]
        public void TimeoutRetryTest_PassesWithinLimits()
        {
            _attemptCount++;
            Trace.WriteLine($"Attempt {_attemptCount}");
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Test with a generous timeout.
        /// </summary>
        [Test]
        [Group(nameof(TimeoutRetryAttribute))]
        [TimeoutRetry(5, "00:00:30")]
        public void TimeoutRetryTest_GenerousTimeout()
        {
            Assert.IsTrue(true);
            Trace.WriteLine("Test completed within generous timeout");
        }

        /// <summary>
        /// Test with minimal retry and timeout.
        /// </summary>
        [Test]
        [Group(nameof(TimeoutRetryAttribute))]
        [TimeoutRetry(1, "00:00:01")]
        public void TimeoutRetryTest_MinimalRetryAndTimeout()
        {
            Assert.IsTrue(true);
        }
    }
}
