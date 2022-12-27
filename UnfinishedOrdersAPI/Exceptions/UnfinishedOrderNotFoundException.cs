namespace UnfinishedOrdersAPI.Exceptions
{
    public class UnfinishedOrderNotFoundException : Exception
    {
        public UnfinishedOrderNotFoundException(string orderId)
            : base($"Unfinished order with id: '{orderId}' not found.")
        {
        }
    }
}
