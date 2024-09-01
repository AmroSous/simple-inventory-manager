
namespace SimpleInventoryManagement.Util
{
    /**
     * summary: 
     * this is a custom Exception class, used to throw a 
     * new exception from this type when the user decide to abort 
     * the current process.
     * 
     * this process must be handled by methods that reads inputs 
     * from user.
     */
    public class OperationAbortedException : Exception
    {
        public OperationAbortedException() 
            : base() { }

        public OperationAbortedException(string message) 
            : base(message) { }

        public OperationAbortedException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
