﻿namespace Meg.Ui.Expressions
{
    public abstract class OperationExpression<TInput, TResult> : Expression<TResult>
        where TInput : struct
        where TResult : struct
    {
        protected OperationExpression(OperationType operationType, params Expression<TInput>[] expressions)
        {
            if (expressions.Length < 2)
            {
                throw new ArgumentException("Minimal length of expression array is 2");
            }

            OperationType = operationType;
            Expressions = expressions;
        }

        public Expression<TInput>[] Expressions { get; }

        public OperationType OperationType { get; }

        public string GetOperationString() => OperationType switch
        {
            OperationType.Sum => "+",
            OperationType.Subtraction => "-",
            OperationType.Multiplication => "*",
            OperationType.Division => ":",
            OperationType.Equality => "=",
            _ => throw new ArgumentException("Unexpected operation case."),
        };
    }
}
