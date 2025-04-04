using AeroportSearch.Indexes.Trie;
using AeroportSearch.Services;
using System.Diagnostics;

namespace SearchingAlgo
{
    public class Program
    {
        private const string _fileName = "airports.csv";
        private const string _baseFileName = "Data";
        public static void Main(string[] args)
        {
            IDataProvider dataProvider = new CsvDataProvider();
            Trie trie = new Trie();
            using (var loadFile = new StreamReader(GetFilePath()))
            {
                foreach (var information in dataProvider.LoadInformation(loadFile,1))
                {
                    trie.Insert(information);
                }

            }
            while (true)
            {
                Stopwatch stopwatch = new Stopwatch();

                var inputString = Console.ReadLine();
                if (inputString == "Quit")
                    break;

                stopwatch.Start();
                var strings = trie.StartsWith(inputString);
                stopwatch.Stop();
                if(strings.Length == 0)
                {
                    Console.WriteLine("No Result!");
                }
                Console.WriteLine(strings);


                Console.WriteLine(stopwatch.ElapsedMilliseconds + ":Milisecond");
            }
        }
        private static string GetFilePath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = System.IO.Path.Combine(baseDirectory, _baseFileName, _fileName);
            return path;
        }

    }

}
