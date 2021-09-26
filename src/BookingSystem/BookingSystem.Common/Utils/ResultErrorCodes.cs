namespace BookingSystem.Common.Utils
{
    public static class ResultErrorCodes
    {
        public const string ResourceNameValueCantBeNull = "ResourceNameValueCantBeNull";
        public const string ResourceNameValueExceeded = "ResourceNameValueExceeded";
        public const string ResourceQuantityValueExceeded = "ResourceQuantityValueExceeded";
        public const string BookingQuantityValueExceeded = "BookingQuantityValueExceeded";
        public const string IntervalStartDateInvalid = "IntervalStartDateInvalid";
        public const string IntervalEndDateInvalid = "IntervalEndDateInvalid";
        public const string IntervalStartDateMustBeBeforeEndDate = "IntervalStartDateMustBeBeforeEndDate";
        public const string IntervalAlreadyExists = "IntervalAlreadyExists";
        public const string ResourceWithUidNotExist = "ResourceWithUidNotExist";
    }
}
