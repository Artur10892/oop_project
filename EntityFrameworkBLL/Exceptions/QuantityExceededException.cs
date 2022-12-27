namespace EntityFrameworkBLL.Exceptions;

public class QuantityExceededException : Exception
{
    public QuantityExceededException()
        : base("Product quantity exceeded.")
    {
    }
}