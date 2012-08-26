using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace AcceptanceTests
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void VerbaitmString()
        {
            VerifyExpression("xxx", "'xxx'");
        }

        [Test]
        public void AddStringToIntegerTest()
        {
            VerifyExpression("xxx1", "'xxx' + 1");
        }

        [Test]
        public void AddIntegersTest()
        {
            VerifyExpression(3, "1 + 2");
        }

        static void VerifyExpression<T>(T expected, string expression)
        {
            var x = Execute(expression);
            Assert.AreEqual(expected, GetPSObjectSingleton<T>(x));
        }

        static T GetPSObjectSingleton<T>(Collection<PSObject> x)
        {
            return (T)(x.Single().ImmediateBaseObject);
        }

        static Collection<PSObject> Execute(string statement)
        {
            var myHost = new TestHost();
            var myRunSpace = RunspaceFactory.CreateRunspace(myHost);
            myRunSpace.Open();

            using (var currentPipeline = myRunSpace.CreatePipeline())
            {
                currentPipeline.Commands.Add(statement);
                return currentPipeline.Invoke();
            }
        }
    }
}
