// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using NUnit.Framework;

namespace CodeApes.Monocle
{
    [TestFixture]
    [Category(TestCategory.ContinousIntegration)]
    public static partial class ExceptionBuilderTest
    {
        [Test]
        public static void ArgumentNull_WithExpression_ShouldThrowArgumentNullException()
        {
            var exception = Fixture.CreateException("test");

            Assert.That(exception, Is.TypeOf<ArgumentNullException>());
        }

        [Test]
        public static void ArgumentNull_WithExpression_ShouldHaveCorrectMessage()
        {
            var exception = Fixture.CreateException("test");

            Assert.That(exception.Message, Is.StringContaining("test"));
        }
    }
}
