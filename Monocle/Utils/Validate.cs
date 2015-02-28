// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using System.Linq.Expressions;

namespace CodeApes.Monocle
{
    public static class Validate
    {
        public static void ThrowIfNull<T>(T value, Expression<Func<T>> expression)
        {
            if (value != null)
            {
                return;
            }

            if (expression == null)
            {
                throw ExceptionBuilder.ArgumentNull(() => expression);
            }

            throw ExceptionBuilder.ArgumentNull(expression);
        }
    }
}
