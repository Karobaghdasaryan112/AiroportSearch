namespace AeroportSearch.Services
{
    public interface IDataProvider
    {
        IEnumerable<string> LoadInformation(StreamReader fileReader, int InfoColumnIndex);

    }
}
