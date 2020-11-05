using System;

namespace Myntra_App.ExceptionHandling
{
    public class CustomException:Exception
    {
        public ExceptionType type;

        // Constructor of custom exception
        public CustomException(string message, ExceptionType type) : base(message)
        {
            this.type = type;
        }

        // Custom exception types
        public enum ExceptionType
        {
            COULD_NOT_SEND_EMAIL,
            SCREENSHOT_NOT_CAPTURED,
            TIME_AND_DATE_NOT_FOUND
        }
    }
}