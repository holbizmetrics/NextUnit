using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class RandomAttributeTests
    {
        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(1, 2)]
        public void TestRandomAttributeOnce()
        {

        }

        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(1, 2)]
        [Random(5, 2, 1)]
        [Random(1, 1, 1)]
        public void TestSeveralRandomAttributesEachOnlyExecutedOnce()
        {

        }

        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(7, 9)]
        public void TestSeveralRandomAttributesEachSeveralTimes()
        {

        }

        /// <summary>
        /// Mixed Random attributes, but all are specified correctly.
        /// </summary>
        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(1, 3, 2)]
        public void TestSeveralRandomLegalAttributesMixed()
        {

        }

        /// <summary>
        /// Testing with specifications that either shouldn't be allowed or make no sense.
        /// </summary>
        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(0, 0, 0)]   //it wouldn't make sense to execute 0 times. As well as max = min.
        [Random(0, 0, -1)]  //it wouldn't make sense to execute -1 times. As well as max = min.
        [Random(1, 5, -1)]   //it wouldn't make sense to execute -1 times. Though the intervals are ok.
        public void TestSeveralRandomAttributesMixedInvalid()
        {

        }

        /// <summary>
        /// This test will be executed multiple times.
        /// It's not allowed that ALL random values are the same. They have to be different.
        /// </summary>
        [Test]
        [Group(nameof(RandomAttribute))]
        [Random(-200, 200, 5)]
        public void TestRandomAttributeMultiple(int min, int max)
        {

        }
    }
}
