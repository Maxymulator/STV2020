using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STVrogue.GameLogic;

namespace MSUnitTests
{
    [TestClass]
    /* Just an example of an MSUnit test class to show how to write one. */
    public class MSUnitTestClass1
    {
        /* An example of a simple test. We will test the constructor of Creature. */
        [TestMethod]
        [Description("Test the constructor of Creature")]
        public void test_1_Creature_contr()
        {
            Creature C = new Creature("smaegol",10, 1);
            Assert.IsTrue(C.Hp == 10 && C.HpMax == 10 );
            Assert.IsTrue(C.AttackRating > 0);
        }

         /*
         Below is an example of a parameterized test, that allows you to reuse the
         same testcode over multiple testdata. Essentially, the idea is similar
         to property-based testing.
         */
        [DataTestMethod]
        [DataRow(-1,1)]
        [DataRow(0,1)]
        [DataRow(1,-1)]
        [DataRow(1,0)]
        [DataRow(0,0)]
        [DataRow(1,1)]
        [DataRow(99,9)]
        public void parameterizedTest_Creature_contr(int hp, int ar)
        {
            Debug.WriteLine("** (" + hp + "," + ar + ")");
            if (hp <= 0 || ar <= 0)
            {
                // on negative hp or ar the constructor should throws an
                // illegal-argument-exception:
                Assert.ThrowsException<ArgumentException>(() => new Creature("smaegol", hp, ar));
            }
            else
            {
                // on other arguments, we want to verify these correctness properties:
                Creature C = new Creature("smaegol",hp,ar);
                Assert.IsTrue(C.Hp==hp && C.HpMax==hp);
                Assert.IsTrue(C.AttackRating > 0);
            }
        }
    }
}
