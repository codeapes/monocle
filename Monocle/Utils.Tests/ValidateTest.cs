// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using NUnit.Framework;

namespace CodeApes.Monocle
{
    [TestFixture]
    [Category(TestCategory.ContinousIntegration)]
    public static class ValidateTest
    {
        [Test]
        public static void ThrowIfNull_ValueNotNull_ShouldNotThrowException()
        {
            object testValue = new object();

            Assert.DoesNotThrow(() => Validate.ThrowIfNull(testValue, () => testValue));
        }

        [Test]
        public static void ThrowIfNull_ValueIsNull_ShouldThrowArgumentNullException()
        {
            object testValue = null;

            // ReSharper disable ExpressionIsAlwaysNull
            Assert.Throws<ArgumentNullException>(() => Validate.ThrowIfNull(testValue, () => testValue));
            // ReSharper restore ExpressionIsAlwaysNull
        }

        [Test]
        public static void ThrowIfNull_ValueIsNull_ShouldHaveCorrectMessage()
        {
            object testValue = null;

            // ReSharper disable ExpressionIsAlwaysNull
            var exception = Assert.Throws<ArgumentNullException>(() => Validate.ThrowIfNull(testValue, () => testValue));
            // ReSharper restore ExpressionIsAlwaysNull

            Assert.That(exception.Message, Is.StringContaining("testValue"));
        }

        [Test]
        public static void ThrowIfNull_ValueIsNullAndExpressionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Validate.ThrowIfNull<object>(null, null));
        }

        [Test]
        public static void ThrowIfNull_ValueIsNullAndExpressionIsNull_ShouldHaveCorrectMessage()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Validate.ThrowIfNull<object>(null, null));

            Assert.That(exception.Message, Is.StringContaining("expression"));
        }
    }
}
