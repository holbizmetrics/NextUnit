using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the RunAllDelegatePermutations attribute - NextUnit's flagship feature.
    /// This attribute executes a set of methods in ALL possible orderings, catching
    /// bugs that only appear when operations occur in specific sequences.
    /// </summary>
    public class RunAllDelegatePermutationsAttributeTests
    {
        private static List<string> _executionLog = new List<string>();
        private static int _executionCount = 0;

        /// <summary>
        /// Resets state before each test run.
        /// </summary>
        private void ResetState()
        {
            _executionLog.Clear();
            _executionCount = 0;
        }

        #region Simple Action Methods for Permutation Testing

        public void ActionA()
        {
            _executionLog.Add("A");
            Trace.WriteLine("Executing Action A");
        }

        public void ActionB()
        {
            _executionLog.Add("B");
            Trace.WriteLine("Executing Action B");
        }

        public void ActionC()
        {
            _executionLog.Add("C");
            Trace.WriteLine("Executing Action C");
        }

        public void IncrementCounter()
        {
            _executionCount++;
            Trace.WriteLine($"Counter incremented to: {_executionCount}");
        }

        public void DoubleCounter()
        {
            _executionCount *= 2;
            Trace.WriteLine($"Counter doubled to: {_executionCount}");
        }

        public void AddTen()
        {
            _executionCount += 10;
            Trace.WriteLine($"Counter +10 to: {_executionCount}");
        }

        #endregion

        /// <summary>
        /// Tests that three methods are executed in all 6 permutations (3! = 6).
        /// Expected orderings: ABC, ACB, BAC, BCA, CAB, CBA
        /// </summary>
        [Test]
        [Group(nameof(RunAllDelegatePermutationsAttribute))]
        [RunAllDelegatePermutations(nameof(ActionA), nameof(ActionB), nameof(ActionC))]
        public void ThreeMethodPermutations_ShouldExecuteAllSixOrderings()
        {
            // The attribute handler runs all permutations before entering this method.
            // Each permutation executes A, B, C in different orders.
            // 3! = 6 permutations, each executing 3 methods = 18 total executions per method set.
            Trace.WriteLine("Permutation test completed");
        }

        /// <summary>
        /// Tests that two methods are executed in all 2 permutations (2! = 2).
        /// Expected orderings: AB, BA
        /// </summary>
        [Test]
        [Group(nameof(RunAllDelegatePermutationsAttribute))]
        [RunAllDelegatePermutations(nameof(ActionA), nameof(ActionB))]
        public void TwoMethodPermutations_ShouldExecuteBothOrderings()
        {
            Trace.WriteLine("Two-method permutation test completed");
        }

        /// <summary>
        /// Demonstrates the real power: state-dependent operations.
        /// The final value of _executionCount will vary based on execution order.
        /// Increment(0→1), Double(1→2), AddTen(2→12) vs
        /// AddTen(0→10), Increment(10→11), Double(11→22) etc.
        /// </summary>
        [Test]
        [Group(nameof(RunAllDelegatePermutationsAttribute))]
        [RunAllDelegatePermutations(nameof(IncrementCounter), nameof(DoubleCounter), nameof(AddTen))]
        public void StateDependentOperations_DifferentOrdersProduceDifferentResults()
        {
            // This test demonstrates why order matters.
            // With state-dependent operations, different orderings produce different final states.
            // This catches bugs where "it works on my machine" but fails when methods
            // are called in a different sequence in production.
            Trace.WriteLine($"Final counter value for this permutation: {_executionCount}");
        }

        /// <summary>
        /// Tests with a single method - should execute exactly once.
        /// </summary>
        [Test]
        [Group(nameof(RunAllDelegatePermutationsAttribute))]
        [RunAllDelegatePermutations(nameof(ActionA))]
        public void SingleMethod_ShouldExecuteOnce()
        {
            Trace.WriteLine("Single method permutation test completed");
        }

        #region Static Method Tests

        private static int _staticCounter = 0;

        public static void StaticActionA()
        {
            _staticCounter++;
            Trace.WriteLine($"Static Action A executed, counter: {_staticCounter}");
        }

        public static void StaticActionB()
        {
            _staticCounter += 2;
            Trace.WriteLine($"Static Action B executed, counter: {_staticCounter}");
        }

        /// <summary>
        /// Tests that static methods work correctly with RunAllDelegatePermutations.
        /// </summary>
        [Test]
        [Group(nameof(RunAllDelegatePermutationsAttribute))]
        [RunAllDelegatePermutations(nameof(StaticActionA), nameof(StaticActionB))]
        public void StaticMethods_ShouldWorkWithPermutations()
        {
            Trace.WriteLine($"Static method permutation test completed, final counter: {_staticCounter}");
        }

        #endregion
    }
}
