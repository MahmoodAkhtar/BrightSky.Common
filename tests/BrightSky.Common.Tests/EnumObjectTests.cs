using System;
using BrightSky.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrightSky.Common.Tests
{
    [TestClass]
    public class EnumObjectTests
    {
        internal class SutEnumObject : EnumObject<SutEnumObject>
        { 
            public static SutEnumObject Audi => Create(1, "Audi").Value;
            public static SutEnumObject Bmw => Create(2, "BMW").Value;
            public static SutEnumObject Mercedes => Create(3, "Mercedes").Value;

            public static Result<SutEnumObject> Create(int value, string name) => Result.Combine(
                Guard.IfNullOrWhiteSpace(name, nameof(name)))
                .Map(() => new SutEnumObject(value, name));

            private SutEnumObject(int value, string name) : base(value, name)
            {
            }

            static SutEnumObject()
            {
                Add(Audi);
                Add(Bmw);
                Add(Mercedes);
            }

        }

        [TestMethod]
        public void Protected_EnumObject_constructor_when_passed_value_and_name_then_set_Value_and_Name_properties()
        {
            // Arrange + Act
            var sut = SutEnumObject.Create(99, "test_name").Value;

            // Assert
            Assert.AreEqual(99, sut.Value);
            Assert.AreEqual("test_name", sut.Name);
        }

        [TestMethod]
        public void Public_static_EnumObject_Audi()
        {
            // Arrange + Act
            var sut = SutEnumObject.Audi;

            // Assert
            Assert.AreEqual(1, sut.Value);
            Assert.AreEqual("Audi", sut.Name);
        }

        [TestMethod]
        public void Public_static_EnumObject_Bmw()
        {
            // Arrange + Act
            var sut = SutEnumObject.Bmw;

            // Assert
            Assert.AreEqual(2, sut.Value);
            Assert.AreEqual("BMW", sut.Name);
        }

        [TestMethod]
        public void Public_static_EnumObject_Mercedes()
        {
            // Arrange + Act
            var sut = SutEnumObject.Mercedes;

            // Assert
            Assert.AreEqual(3, sut.Value);
            Assert.AreEqual("Mercedes", sut.Name);
        }

        [TestMethod]
        public void Public_override_EnumObject_ToString()
        {
            // Arrange + Act
            var sut = SutEnumObject.Mercedes;

            // Assert
            Assert.AreEqual("Mercedes", sut.ToString());
        }

        [TestMethod]
        public void Public_static_EnumObject_FromName_passed_invalid_name()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromName("XXX");

            // Assert
            Assert.IsTrue(sut.HasNoValue);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromName_passed_valid_name_Audi()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromName("Audi");

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Audi, sut.Value);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromName_passed_valid_name_BMW()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromName("BMW");

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Bmw, sut.Value);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromName_passed_valid_name_Mercedes()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromName("Mercedes");

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Mercedes, sut.Value);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromValue_passed_invalid_value()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromValue(999);

            // Assert
            Assert.IsTrue(sut.HasNoValue);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromValue_passed_valid_value_Audi()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromValue(1);

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Audi, sut.Value);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromValue_passed_valid_value_BMW()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromValue(2);

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Bmw, sut.Value);
        }

        [TestMethod]
        public void Public_static_EnumObject_FromValue_passed_valid_value_Mercedes()
        {
            // Arrange + Act
            var sut = SutEnumObject.FromValue(3);

            // Assert
            Assert.IsTrue(sut.HasValue);
            Assert.AreEqual(SutEnumObject.Mercedes, sut.Value);
        }

    }
}
