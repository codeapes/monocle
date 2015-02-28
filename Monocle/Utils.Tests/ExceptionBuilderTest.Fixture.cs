// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

namespace CodeApes.Monocle
{
    using System;

    public static partial class ExceptionBuilderTest
    {
        private static class Fixture
        {
            public static Exception CreateException(string test)
            {
                return ExceptionBuilder.ArgumentNull(() => test);
            }
        }
    }
}
