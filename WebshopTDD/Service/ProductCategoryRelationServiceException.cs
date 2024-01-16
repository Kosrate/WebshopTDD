using System.Runtime.Serialization;

namespace WebshopTDD.Service
{
    [Serializable]
    internal class ProductCategoryRelationServiceException : Exception
    {
        public ProductCategoryRelationServiceException()
        {
        }

        public ProductCategoryRelationServiceException(string? message) : base(message)
        {
        }

        public ProductCategoryRelationServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductCategoryRelationServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
