namespace rassler.backend.domain.Data.Enums
{
    public enum ResultCode
    {
        DeleteFailed,
        DeleteSuccessful,

        InsertFailed,
        InsertSuccessful,
        
        RecordFound,
        RecordNotFound,

        UpdateFailed,
        UpdateSuccessful,

        SaveFailed,
        SaveSuccessful,

        Success,
        Failed,

        Authorized,
        Unauthorized
    }
}
