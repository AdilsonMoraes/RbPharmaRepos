namespace RbPharma.Domain.Enums.V1
{
    public class UserEnumException : BaseEnum<UserEnumException, string>
    {
        public static UserEnumException DATA_NOT_INFO = new UserEnumException(1, "Data not information, valid your request!");
        public static UserEnumException RESQUEST_ERROR = new UserEnumException(2, "Request contains error!.");
        public static UserEnumException INVALID_ID = new UserEnumException(3, "Invalid Id, Request contains error!.");

        protected UserEnumException(int errorCode, string value) : base(errorCode, value)
        {
        }
    }
}
