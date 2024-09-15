namespace Market.Domain.Common.Exceptions
{
    public class EntityNotFoundException(Type type) : Exception($"{type.Name} - not found.")
    { }
}
