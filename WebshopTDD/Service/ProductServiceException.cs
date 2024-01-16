using System.Runtime.Serialization;


[Serializable]
internal class ProductServiceException : Exception
{
    public ProductServiceException()
    {
    }

    public ProductServiceException(string? message) : base(message)
    {
    }

    public ProductServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}