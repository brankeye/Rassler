using rassler.backend.domain.Data.Enums;

namespace rassler.backend.infrastructure.Database.Objects
{
    public class DbResult<T>
    {
        public DbResult(ResultCode resultCode, T item)
        {
            ResultCode = resultCode;
            Content = item;
        }

        public ResultCode ResultCode { get; set; }

        public T Content { get; set; }
    }
}
