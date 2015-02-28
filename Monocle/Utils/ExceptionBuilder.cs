// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using System.Linq.Expressions;

namespace CodeApes.Monocle
{
    public static class ExceptionBuilder
    {
        public static ArgumentNullException ArgumentNull<T>(Expression<Func<T>> expression)
        {
            var body = (MemberExpression) expression.Body;
            return new ArgumentNullException(body.Member.Name);
        }
    }
}
