using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using util.Core;
using FluentAssertions;

namespace util.test
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonTest()
        {
            var p = new Person() {Id = 9, BirthDate = new DateTime(2010,10,20), Name="yi Leng vang", Sex="Male"};
            var validator = new PersonValidator().Validate(p);

            Assert.IsTrue(validator.IsValid, string.Join("\n", validator.Errors.Select(x=>x.ErrorMessage).ToArray()));
        }

        [TestMethod]
        public void PersonAddressValidTest()
        {
            var p = new Person() { Id = 9, BirthDate = new DateTime(2010, 10, 20), Name = "yi Leng vang", Address = new Address() { ZipCode = "1234" } };
            var validator = new PersonValidator().Validate(p);

            Assert.IsTrue(validator.IsValid, string.Join("\n", validator.Errors.Select(x => x.ErrorMessage).ToArray()));
        }


        [TestMethod]
        public void PersonInvalidSexTest()
        {
            var p = new Person() { Id = 9, BirthDate = new DateTime(2010, 10, 20), Name = "yi Leng vang", Sex = "Males" };
            var validator = new PersonValidator().Validate(p);

            Assert.IsFalse(validator.IsValid, string.Join("\n", validator.Errors.Select(x => x.ErrorMessage).ToArray()));
        }

        [TestMethod]
        public void NameLengthTest()
        {
            var p = new Person() { Id = 100, Name = "Superman" };

            p.Name.Should().HaveLength(8, "Because i said so").And.Should().Be("Superman", "equal check");

            //p.Id.Should().BeGreaterThan(200, "Id length test");


        }
    }
}
