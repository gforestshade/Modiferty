using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

using UnityEngine.TestTools.Constraints;
using Uis = UnityEngine.TestTools.Constraints.Is;


using MackySoft.Modiferty;

namespace Tests
{
    public class ModifiableIntTest
    {
        [Test]
        public void Solo([Random(100)] int a)
        {
            ModifiableInt i = new ModifiableInt(a);
            Assert.AreEqual(a, i.Evaluate());
        }

        [Test]
        public void Add(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99999, 99999, 10)] int b)
        {
            ModifiableInt i = new ModifiableInt(a);
            i.Modifiers.Add(new AdditiveModifierInt(b));
            Assert.AreEqual(a + b, i.Evaluate());
        }

        [Test]
        public void Sub(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99999, 99999, 10)] int b)
        {
            ModifiableInt i = new ModifiableInt(a);
            i.Modifiers.Add(new SubtractiveModifierInt(b));
            Assert.AreEqual(a - b, i.Evaluate());
        }

        [Test]
        public void Mul(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99, 99, 5)] int b)
        {
            ModifiableInt i = new ModifiableInt(a);
            i.Modifiers.Add(new MultiplyModifierInt(b));
            Assert.AreEqual(a * b, i.Evaluate());
        }

        [Test]
        public void Div(
            [Random(-99999, 99999, 10)] int a,
            [Values(-24, -99, -1, 1, 2, 3, 10, 99)] int b)
        {
            ModifiableInt i = new ModifiableInt(a);
            i.Modifiers.Add(new DivisionModifierInt(b));
            Assert.AreEqual(a / b, i.Evaluate());
        }

        [Test]
        public void OverflowMul()
        {
            int a = (int)1e9, b = (int)1e9;
            ModifiableInt i = new ModifiableInt(a);
            i.Modifiers.Add(new MultiplyModifierInt(b));
            Assert.DoesNotThrow(() => i.Evaluate());
        }

        [Test]
        public void StructAdd(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99999, 99999, 10)] int b)
        {
            ModifiableStruct<int> i = new ModifiableStruct<int>(a);
            i.Add(b);
            Assert.AreEqual(a + b, i.Evaluate());
        }

        [Test]
        public void StructSub(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99999, 99999, 10)] int b)
        {
            ModifiableStruct<int> i = new ModifiableStruct<int>(a);
            i.Subtract(b);
            Assert.AreEqual(a - b, i.Evaluate());
        }

        [Test]
        public void StructMul(
            [Random(-99999, 99999, 10)] int a,
            [Random(-99, 99, 5)] int b)
        {
            ModifiableStruct<int> i = new ModifiableStruct<int>(a);
            i.Multiply(b);
            Assert.AreEqual(a * b, i.Evaluate());
        }

        [Test]
        public void StructDiv(
            [Random(-99999, 99999, 10)] int a,
            [Values(-24, -99, -1, 1, 2, 3, 10, 99)] int b)
        {
            ModifiableStruct<int> i = new ModifiableStruct<int>(a);
            i.Divide(b);
            Assert.AreEqual(a / b, i.Evaluate());
        }
    }
}
