using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using util.Core;
using FluentAssertions;

namespace util.test
{
    [TestClass]
    public class PersonTests_Class
    {


        [TestClass]
        private class Age_Tests:BaseTest
        {
            protected Person _person;
            protected int _expected_Age;
            protected int _actual_Age;

            public override void Arrange()
            {
                _person = new Person() { Id = 10, BirthDate = new DateTime(1999, 1, 1), Name = "Yi Vang", Sex = "Male", Address = new Address() { City = "Bloomington", State = "MN", ZipCode = "55431", Line1 = "8624 Thomas Ave S." } };
            }

            public override void Act()
            {
                _actual_Age = _person.Age();
            }

            public override void Assert()
            {
                throw new NotImplementedException();
            }

            [TestClass]
            public class TestFor_Age_IsAdult:Age_Tests
            {

                public override void Arrange()
                {
                    base.Arrange();
                    _expected_Age = 18;
                }
                public override void Assert()
                {
                    _actual_Age.Should().Be(_expected_Age);
                }

                [TestMethod]
                public void TestFor_IsAdult()
                {
                    base.Test();
                }
            }

            [TestClass]
            public class TestFor_Age_IsAdult_Wisconsin:Age_Tests
            {
                public override void Arrange()
                {
                    base.Arrange();
                    _expected_Age = 17;
                }
                public override void Assert()
                {
                    _actual_Age.Should().Be(_expected_Age);
                }

                [TestMethod]
                public void TestFor_IsAdult_Wisconsin()
                {
                    
                    base.Test();
                }
            }

        }

        private class Age_Property : BaseTest
        {
            public override void Act()
            {
                throw new NotImplementedException();
            }

            public override void Arrange()
            {
                throw new NotImplementedException();
            }

            public override void Assert()
            {
                throw new NotImplementedException();
            }
        }
    }
}
