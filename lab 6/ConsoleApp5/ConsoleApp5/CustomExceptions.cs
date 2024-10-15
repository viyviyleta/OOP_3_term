using System;

namespace CustomExceptions
{
    public class ControlElementException : Exception
    {
        public ControlElementException(string message) : base(message) { }
    }

    public class InvalidPositionException : ControlElementException
    {
        public InvalidPositionException(string message) : base(message) { }
    }

    public class UnsupportedControlTypeException : ControlElementException
    {
        public UnsupportedControlTypeException(string message) : base(message) { }
    }

    public class GeometricShapeException : Exception
    {
        public GeometricShapeException(string message) : base(message) { }
    }

    public class InvalidShapeDimensionsException : GeometricShapeException
    {
        public InvalidShapeDimensionsException(string message) : base(message) { }
    }
}