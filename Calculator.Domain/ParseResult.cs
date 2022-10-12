using System;

namespace Calculator.Domain
{
    public static class ParseResult
    {
        public static ParseResult<T> Success<T>(T value)
        {
            return new ParseResult<T>(true, value);
        }

        public static ParseResult<T> Failure<T>()
        {
            return new ParseResult<T>(false, default);
        }
    }


    public class ParseResult<T>
    {
        private T value;

        internal ParseResult(bool succeeded, T value)
        {
            Succeeded = succeeded;
            this.value = value;
        }

        public bool Succeeded { get; }
        public T Value
        {
            get
            {
                if (!Succeeded)
                    throw new InvalidOperationException("There is no value as the parse failed.");

                return value;
            }
        }
    }
}
