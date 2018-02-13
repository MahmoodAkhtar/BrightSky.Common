using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BrightSky.Common.Tests
{
    [TestClass]
    public class GuardAgainstTests
    {
        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_null_then_throw_an_ArgumentNullException()
        {
            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.ThrowIfNullOrEmpty(null));
        }

        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_an_empty_string_then_throw_an_ArgumentException()
        {
            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.ThrowIfNullOrEmpty(string.Empty));
        }

        [TestMethod]
        public void Internal_ThrowIfNullOrEmpty_when_given_a_string_then_dont_throw_an_Exception()
        {
            try
            {
                // arrange + act
                GuardAgainst.ThrowIfNullOrEmpty("value");
            }
            catch(Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
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
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_empty_argument_and_null_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            var argument = new List<string>();
            string name = null;

            // act + assert
            Assert.ThrowsException<ArgumentNullException>(() => GuardAgainst.AnyNulls(argument, name));
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
        public void AnyNulls_for_IEnumerable_of_T_when_given_a_null_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            List<string> argument = null;
            var name = string.Empty;

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
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_argument_and_an_empty_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>() { "value one" };
            var name = string.Empty;

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
        }

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
        public void AnyNulls_for_IEnumerable_of_T_when_given_an_empty_argument_and_a_name_then_throw_an_ArgumentException()
        {
            // arrange
            var argument = new List<string>();
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentException>(() => GuardAgainst.AnyNulls(argument, name));
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
                var name = nameof(argument);
            }
            catch (Exception ex)
            {
                // assert fail
                Assert.Fail($"Expected no exception, but actually got: {ex}.");
            }
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
        public void Null_of_T_when_given_a_null_argument_and_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = null;

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
        public void Null_of_T_when_given_a_null_argument_and_a_name_then_throw_an_ArgumentNullException()
        {
            // arrange
            string argument = null;
            string name = nameof(argument);

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
        public void LessThanOrEqualTo_for_decimal_when_given_an_argument_equal_to_value_and_a_name_then_throw_an_ArgumentOutOfRangeException()
        {
            // arrange
            decimal argument = 1m;
            decimal value = 1m;
            var name = nameof(argument);

            // act + assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GuardAgainst.LessThanOrEqualTo(argument, value, name));
        }
    }
}