using System.Runtime.Serialization;

namespace WebshopTDD.Service
{
    [Serializable]
    internal class CategoryServiceException : Exception
    {
        public CategoryServiceException()
        {
        }

        public CategoryServiceException(string? message) : base(message)
        {
        }

        public CategoryServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CategoryServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}