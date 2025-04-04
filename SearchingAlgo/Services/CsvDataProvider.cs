using System.Text.RegularExpressions;

namespace AeroportSearch.Services
{
    public class CsvDataProvider : IDataProvider
    {
        long lineNumber = 1;

        public IEnumerable<string> LoadInformation(StreamReader fileReader,int InfoColumnIndex)
        {
            string pattern = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";

            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();

                string[] columns = Regex.Split(line, pattern);

                if (InfoColumnIndex < columns.Length)
                {
                    columns[InfoColumnIndex] = columns[InfoColumnIndex].Trim('"');
                    yield return new(columns[InfoColumnIndex]);
                }
                lineNumber++;
            }
        }
    }
}
