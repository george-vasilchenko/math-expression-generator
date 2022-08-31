﻿using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class DivisionExpression : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        public DivisionExpression(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
            : base(OperationType.Division, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
        }

        public override Func<double> ToResultFunc() => () =>
        {
            var result = Expressions[0].ToResultFunc().Invoke();

            for (var i = 1; i < Expressions.Length; i++)
            {
                var exp = Expressions[i];
                var value = exp.ToResultFunc().Invoke();
                result /= value;
            }

            return result;
        };

        public override string ToFormat() => expressionFormatVisitor.Visit(this);
    }
}
