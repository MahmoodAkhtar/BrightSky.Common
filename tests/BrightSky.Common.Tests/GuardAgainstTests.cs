using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BrightSky.Common.Tests
{
    [TestClass]
    public class GuardAgainstTests
    {
        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            List<string> argument = null;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            List<string> argument = null;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            List<string> argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = new List<string>() { "value one" };
                var name = nameof(argument);

                // act
                GuardAgainst.AnyNulls(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>() { "value one" };
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_argument_and_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new List<string>() { "value one" };
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_argument_with_nulls_and_a_name_then_dont_throw_ann_ArgumenyNullException()
        {
            // arrange
            var argument = new List<string>() { "value one", null, "value three" };
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_empty_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>();
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_empty_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>();
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_empty_argument_and_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new List<string>();
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_not_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 0m;
                decimal value = 1m;
                var name = nameof(argument);

                // act
                GuardAgainst.EqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_not_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_decimal_when_given_an_argument_not_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_not_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 0D;
                double value = 1D;
                var name = nameof(argument);

                // act
                GuardAgainst.EqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_not_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_double_when_given_an_argument_not_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_not_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 0;
                float value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.EqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_not_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_float_when_given_an_argument_not_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_not_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 0;
                var value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.EqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_not_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_int_when_given_an_argument_not_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_not_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 0;
                long value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.EqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_not_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void EqualTo_for_long_when_given_an_argument_not_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.EqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 1m;
                decimal value = 1m;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 0m;
                decimal value = 1m;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_decimal_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 1D;
                double value = 1D;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 0D;
                double value = 1D;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_double_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 1;
                float value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 0;
                float value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_float_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 1;
                var value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 0;
                var value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_int_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 1;
                long value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 0;
                long value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThan_for_long_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThan(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 0m;
                decimal value = 1m;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 0D;
                double value = 1D;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 0;
                float value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 0;
                var value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 0;
                long value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.GreaterThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.GreaterThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_equal_to_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_equal_to_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_equal_to_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_greater_than_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_greater_than_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_and_min_is_greater_than_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 2;
            double min = 3;
            double max = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_in_range_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 2;
            double min = 1;
            double max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_in_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 2;
            double min = 1;
            double max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_in_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 2;
            double min = 1;
            double max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_out_of_range_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 4;
                double min = 1;
                double max = 3;
                var name = nameof(argument);

                // act
                GuardAgainst.InRange(argument, min, max, name);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_out_of_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 2;
            double min = 1;
            double max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_double_when_given_an_argument_out_of_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 4;
            double min = 1;
            double max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_equal_to_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_equal_to_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_equal_to_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_greater_than_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_greater_than_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_and_min_is_greater_than_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 2;
            float min = 3;
            float max = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_in_range_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 2;
            float min = 1;
            float max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_in_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 2;
            float min = 1;
            float max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_in_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 2;
            float min = 1;
            float max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_out_of_range_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 4;
                float min = 1;
                float max = 3;
                var name = nameof(argument);

                // act
                GuardAgainst.InRange(argument, min, max, name);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_out_of_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 2;
            float min = 1;
            float max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_float_when_given_an_argument_out_of_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 4;
            float min = 1;
            float max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_equal_to_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_equal_to_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_equal_to_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_greater_than_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_greater_than_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_and_min_is_greater_than_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 2;
            var min = 3;
            var max = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_in_range_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 2;
            var min = 1;
            var max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_in_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 2;
            var min = 1;
            var max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_in_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 2;
            var min = 1;
            var max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_out_of_range_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 4;
                var min = 1;
                var max = 3;
                var name = nameof(argument);

                // act
                GuardAgainst.InRange(argument, min, max, name);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_out_of_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 2;
            var min = 1;
            var max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_int_when_given_an_argument_out_of_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 4;
            var min = 1;
            var max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_equal_to_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_equal_to_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_equal_to_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_greater_than_max_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_greater_than_max_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_and_min_is_greater_than_max_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 2;
            long min = 3;
            long max = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_in_range_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 2;
            long min = 1;
            long max = 3;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_in_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 2;
            long min = 1;
            long max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_in_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 2;
            long min = 1;
            long max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_out_of_range_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 4;
                long min = 1;
                long max = 3;
                var name = nameof(argument);

                // act
                GuardAgainst.InRange(argument, min, max, name);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_out_of_range_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 2;
            long min = 1;
            long max = 3;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void InRange_for_long_when_given_an_argument_out_of_range_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 4;
            long min = 1;
            long max = 3;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.InRange(argument, min, max, name));
        }

        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_a_string_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange + act
                GuardAgainst.ThrowIfNullOrEmpty("value");
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_an_empty_string_then_throw_an_ArgumentException()
        {
            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.ThrowIfNullOrEmpty(string.Empty));
        }

        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_null_then_throw_an_ArgumentNullException()
        {
            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.ThrowIfNullOrEmpty(null));
        }
        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 1m;
                decimal value = 1m;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 1m;
                decimal value = 0m;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_decimal_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 1D;
                double value = 1D;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 1D;
                double value = 0D;
                var name = nameof(argument);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_double_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 1;
                float value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 1;
                float value = 0;
                var name = nameof(argument);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_float_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 1;
                var value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 1;
                var value = 0;
                string name = nameof(argument);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }
        [TestMethod]
        public void LessThan_for_int_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }
        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_equal_to_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 1;
                long value = 1;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThan(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 1;
                long value = 0;
                var name = nameof(argument);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThan(argument, value, name));
        }

        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThan(argument, value, name));
        }
        [TestMethod]
        public void LessThan_for_long_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThan(argument, value, name));
        }
        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                decimal argument = 1m;
                decimal value = 0m;
                var name = nameof(argument);

                // act
                GuardAgainst.LessThanOrEqualTo(argument, value, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 0m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_a_name_then_dont_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            decimal argument = 0m;
            decimal value = 1m;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                double argument = 1D;
                double value = 0D;
                var name = nameof(argument);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 1D;
            double value = 0D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_double_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            double argument = 0D;
            double value = 1D;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = nameof(argument);


            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                float argument = 1;
                float value = 0;
                var name = nameof(argument);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 1;
            float value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_float_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            float argument = 0;
            float value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = 1;
                var value = 0;
                var name = nameof(argument);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 1;
            var value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_int_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = 0;
            var value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = nameof(argument);


            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_equal_to_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                long argument = 1;
                long value = 0;
                var name = nameof(argument);

            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_greater_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 1;
            long value = 0;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void LessThanOrEqualTo_for_long_when_given_an_argument_less_than_value_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            long argument = 0;
            long value = 1;
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }

        [TestMethod]
        public void Null_of_T_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.Null(argument, name));
        }

        [TestMethod]
        public void Null_of_T_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = null;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.Null(argument, name));
        }

        [TestMethod]
        public void Null_of_T_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.Null(argument, name));
        }

        [TestMethod]
        public void Null_of_T_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                string argument = "some value";
                string name = nameof(argument);

                // act
                GuardAgainst.Null(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            Dictionary<string, string> argument = null;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            Dictionary<string, string> argument = null;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            Dictionary<string, string> argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = new Dictionary<string, string>() { { "Key one", "Value one" } };
                string name = nameof(argument);

                // act
                GuardAgainst.NullOrEmpty(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_an_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new Dictionary<string, string>() { { "Key one", "Value one" } };
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IDictionary_of_TKey_TValue_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new Dictionary<string, string>() { { "Key one", "Value one" } };
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            List<string> argument = null;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            List<string> argument = null;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            List<string> argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                var argument = new List<string>() { "value one" };
                string name = nameof(argument);

                // act
                GuardAgainst.NullOrEmpty(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new List<string>() { "value one" };
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>() { "value one" };
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_empty_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>();
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_empty_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new List<string>();
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_IEnumerable_of_T_when_given_an_empty_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>();
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = null;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                string argument = "some value";
                string name = nameof(argument);

                // act
                GuardAgainst.NullOrEmpty(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = "some value";
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = "some value";
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_empty_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = string.Empty;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_empty_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = string.Empty;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }

        [TestMethod]
        public void NullOrEmpty_for_string_when_given_an_empty_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = string.Empty;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrEmpty(argument, name));
        }
        [TestMethod]
        public void NullOrWhitespace_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = null;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_a_whitespace_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = " ";
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_a_whitespace_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = " ";
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_a_whitespace_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = " ";
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_argument_and_a_name_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange
                string argument = "some value";
                string name = nameof(argument);

                // act
                GuardAgainst.NullOrWhitespace(argument, name);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = "some value";
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = "some value";
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_empty_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = string.Empty;
            string name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_empty_argument_and_a_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = string.Empty;
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }

        [TestMethod]
        public void NullOrWhitespace_when_given_an_empty_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            string argument = string.Empty;
            string name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.NullOrWhitespace(argument, name));
        }
    }
}