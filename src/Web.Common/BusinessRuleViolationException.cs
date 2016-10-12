using System;


namespace Web.Common
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string incorrectTaskStatus) :
                base(incorrectTaskStatus)
        { }
    }
}
