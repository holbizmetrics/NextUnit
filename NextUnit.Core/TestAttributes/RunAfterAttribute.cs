﻿namespace NextUnit.Core.TestAttributes
{
    /// <summary>
    /// This will only run when the certain test time has been exceeded.
    /// So, in other words, this test will start to work after the specified time.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RunAfterAttribute : CommonTestAttribute
    {
        public DateTime ExecuteAfter { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        public RunAfterAttribute(string dateTime)
        {
            DateTime dateTimeExecuteAfter;
            bool success = DateTime.TryParse(dateTime, out dateTimeExecuteAfter);
            if (!success)
            {
                return;
            }
            ExecuteAfter = dateTimeExecuteAfter;
        }
    }
}
