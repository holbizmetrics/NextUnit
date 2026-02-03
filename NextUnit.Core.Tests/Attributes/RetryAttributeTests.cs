using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the Retry attribute which re-executes a test if it fails.
    /// </summary>
    public class RetryAttributeTests
    {
        private static int _attemptCount = 0;

        /// <summary>
        /// Basic retry test - this test will pass on the first attempt.
        /// </summary>
        [Test]
        [Group(nameof(RetryAttribute))]
        [Retry(3)]
        public void RetryAttributeTest_PassesOnFirstAttempt()
        {
            Assert.IsTrue(true);
            Trace.WriteLine("Test passed on first attempt");
        }

        /// <summary>
        /// Simulates a flaky test that fails twice then succeeds.
        /// The Retry attribute should allow it to eventually pass.
        /// </summary>
        [Test]
        [Group(nameof(RetryAttribute))]
        [Retry(5)]
        public void RetryAttributeTest_FlakyTestEventuallyPasses()
        {
            _attemptCount++;
            Trace.WriteLine($"Attempt {_attemptCount}");

            // Fail on first two attempts, pass on third
            if (_attemptCount < 3)
            {
                Assert.IsTrue(false, $"Intentional failure on attempt {_attemptCount}");
            }

            Assert.IsTrue(true, "Test passed after retries");
        }

        /// <summary>
        /// Tests with retry count of 1 (essentially no retry).
        /// </summary>
        [Test]
        [Group(nameof(RetryAttribute))]
        [Retry(1)]
        public void RetryAttributeTest_SingleRetry()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests with default retry count.
        /// </summary>
        [Test]
        [Group(nameof(RetryAttribute))]
        [Retry]
        public void RetryAttributeTest_DefaultRetryCount()
        {
            Assert.IsTrue(true);
        }
    }
}
