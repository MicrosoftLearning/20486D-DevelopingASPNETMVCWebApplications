namespace CitiesDetails.Services
{
    public interface ICityProvider
    {
        CityDetails this[string name] { get; }
    }
}