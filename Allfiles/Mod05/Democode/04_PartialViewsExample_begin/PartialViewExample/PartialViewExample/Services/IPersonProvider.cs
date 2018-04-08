namespace PartialViewExample.Services
{
    public interface IPersonProvider
    {
        Person this[int index] { get; }
    }
}