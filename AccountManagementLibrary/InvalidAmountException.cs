namespace AccountManagementLibrary
{
    public class InvalidAmountException:ApplicationException
    {
        private ApplicationException applicationException;
        private string msg;

        public InvalidAmountException(string? message) : base(message)
        {
        }

        public InvalidAmountException(ApplicationException applicationException, string msg)
        {
            this.applicationException = applicationException;
            this.msg = msg;
        }
    }
}
