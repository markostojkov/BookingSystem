namespace BookingSystem.Common.Utils
{
    public enum ResultType : short
    {
        InternalError = 0,
        Ok = 1,
        NotFound = 2,
        Forbidden = 3,
        Conflicted = 4,
        Validation = 5,
        PartiallyOk = 6,
        Unauthorized
    }
}
