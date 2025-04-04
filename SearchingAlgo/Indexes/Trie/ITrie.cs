namespace AeroportSearch.Indexes.Trie
{
    public interface ITrie
    {
        void Insert(string word);
        void Remove(string word);
        List<string> Search(string word);
    }
}
