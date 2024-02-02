﻿using NextUnit.Core.Extensions;
using NextUnit.Core.TestAttributes;
using System.Reflection;

namespace NextUnit.Core.AttributeLogic
{
    /// <summary>
    /// Use this to combine attributes.
    /// 
    /// For example thos combinations should be possible:
    /// 
    /// An attribute in () means it could also be added and still should work. But doesn't have to for this case.
    /// This may be change a few times. Until we get the hang of it.
    /// 
    /// [RunAfter, InjectData, (Group)] -> yes
    /// [RunBefore, InjectData, (Group)] -> yes
    /// [RunBefore, RunBefore, (Group)] -> In a sophisticated way should be 
    /// [Condition, Group]
    /// etc.
    /// </summary>
    public class AttributeCombinator
    {
        private Dictionary<Type, Delegate> delegateDictionary = new Dictionary<Type, Delegate>();
        private readonly Attribute[] attributes;

        private AttributeLogicMapper AttributeLogicMapper = new AttributeLogicMapper();


        public class AttributeCombinationKey
        {
            public Type[] AttributeTypes { get; }

            public AttributeCombinationKey(params Type[] attributeTypes)
            {
                AttributeTypes = attributeTypes;
            }

            // Optionally, override Equals() and GetHashCode() if needed
        }

        public AttributeCombinator(params Attribute[] attributes)
        {
            //Definition of combinable attributes.
            Dictionary<CombinableAttribute, Delegate> keyValuePairs = new Dictionary<CombinableAttribute, Delegate>
            {
                { Combine.And(attributes.AnyIsOf(
                        typeof(TestAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunAfterAttribute), 
                        typeof(InjectDataAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunBeforeAttribute),
                        typeof(InjectDataAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunDuringAttribute),
                        typeof(InjectDataAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunBeforeAttribute),
                        typeof(InjectDataAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunBeforeAttribute),
                        typeof(InjectDataAttribute))), null },

                { Combine.And(attributes.AnyIsOf(
                        typeof(RunBeforeAttribute),
                        typeof(InjectDataAttribute))), null }
            };

            var blub =  keyValuePairs.Keys.Where(x => x.Method.Name.Contains("C"));

            this.attributes = attributes;
            delegateDictionary.Add(typeof(TestAttribute), ProcessAttribute);
        }

        public class Definition
        {
            public Type[] AttributeTypes = new Type[] { typeof(TestAttribute), typeof(SkipAttribute)};
            public Type[] OptionalTypes = new Type[] { typeof(SkipAttribute), typeof(GroupAttribute)};
            //CombinableAttribute combinableAttribute = CombinableAttribute.Combine(AttributeTypes);
        }

        public void ProcessAttribute(Attribute attribute, MethodInfo testMethod, object testInstance)
        {
            var handler = AttributeLogicMapper.GetHandlerFor(attributes[0]);
            handler?.ProcessAttribute(attributes[0], testMethod, testInstance);
            return;
        }

        public void ProcessCombinedAttributes(MethodInfo testMethod, object testInstance)
        {
            CheckSimpleCases(testMethod, testInstance);
            CombinableAttribute ANDABLEAttributes = Combine.And(attributes.AnyIsOf(typeof(SkipAttribute), typeof(SkipAttribute)));
            bool result = ANDABLEAttributes.Invoke(null);
            foreach (var attribute in attributes)
            {
                // Process each attribute as per the combined effect
                // This might involve invoking the respective attribute logic handler
                if (attribute is TestAttribute)
                {
                    continue;
                }
            }
        }

        private void CheckSimpleCases(MethodInfo testMethod, object testInstance)
        {

            // Apply interaction rules to attributes
            // This might involve invoking specific logic handlers in a certain order,
            // overriding some attributes with others, or even discarding some attributes.

            //I guess if the attributes are null we shouldn't even get here?
            if (attributes == null)
            {
                return;
            }
            if (attributes.Length == 1)
            {
                Attribute firstAttribute = attributes[0];

                Type firstAttributeType = firstAttribute.GetType();
                string assertText = $"First attribute of method shouldn't be a {firstAttributeType}.";
                //None of those should happen
                //Debug.Assert(firstAttribute is GroupAttribute, assertText);
                //Debug.Assert(firstAttribute is CommonTestAttribute, assertText);
                //Debug.Assert(firstAttribute is SkipAttribute, assertText);
                //Debug.Assert(firstAttribute is not TestAttribute, assertText);

                if (firstAttribute is TestAttribute)
                {
                    Delegate @delegate = delegateDictionary[firstAttributeType];

                    @delegate.DynamicInvoke(attributes[0], testMethod, testInstance);
                    return;
                }
                // If we only find a SkipAttribute we'll don't do anything.
                else if (firstAttribute is SkipAttribute)
                {
                    return;
                }

                if (firstAttribute is not TestAttribute)
                {
                    return;
                }
            }

            if (attributes.Length == 2)
            {
                if (attributes.AnyIsOf(typeof(SkipAttribute), typeof(TestAttribute)))
                {
                    return;
                }
                if (attributes.AnyIsOf(typeof(GroupAttribute), typeof(TestAttribute)))
                {
                    var handler = AttributeLogicMapper.GetHandlerFor(attributes[0]);
                    handler?.ProcessAttribute(attributes[0], testMethod, testInstance);
                    return;
                }
            }
        }
    }
}