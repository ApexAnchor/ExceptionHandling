
namespace ExceptionHandling.Domain.DomainExceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string? message) : base(message)
        {
                
        }        
    }

    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string? message) : base(message)
        {

        }
    }
}
