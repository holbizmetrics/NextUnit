﻿namespace NextUnit.Core.TestAttributes
{
    /// <summary>
    /// Use this to execute for instance
    /// Test1, Test2, Test3 in all possible permutations.
    /// 
    /// So result should be (e.g.):
    /// 
    /// 1, 2, 3
    /// 1, 3, 2
    /// 2, 1, 3
    /// 2, 3, 1
    /// 3, 1, 2
    /// 3, 2, 1
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RunAllDelegatePermutationsAttribute : Attribute
    {
        public string[] Actions { get; set; }
        public RunAllDelegatePermutationsAttribute(params string[] actionDelegateName)
        {
            Actions = actionDelegateName;
        }
    }
}