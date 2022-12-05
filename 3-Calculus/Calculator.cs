using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final _result is requested, all pending operations are performed and the final _result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final _result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        private char _operation = ' ';
        private Complex _result = null;

        public Complex Value { get; set; }

        public char Operation
        {
            get
            {
                return _operation;
            }

            set
            {                
                if(_operation == ' ') _result = Value;
                else if (_operation.Equals(OperationPlus)) _result = _result.Plus(Value);
                else if (_operation.Equals(OperationMinus)) _result = _result.Minus(Value);
                _operation = value;
                Value = null;
            }
        }

        public Calculator(){}

        public void ComputeResult()
        {
            Operation= ' ';
            Value = _result;            
        }

        public void Reset()
        {
            Value = null;
            _result = null;
            _operation = ' ';
        }

        public override string ToString() => $"{(Value == null ? "null" : Value.ToString())}, {(_operation == ' ' ? "null" : _operation.ToString())}";
    }
}