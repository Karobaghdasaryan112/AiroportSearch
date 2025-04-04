using System.Text;

namespace AeroportSearch.Indexes.Trie
{
    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;
            foreach (char @char in word)
            {
                if (!node.Children.ContainsKey(@char))
                    node.Children[@char] = new TrieNode();

                node = node.Children[@char];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            var node = _root;
            foreach (char @char in word)
            {
                if (!node.Children.ContainsKey(@char))
                    return false;
                node = node.Children[@char];
            }
            return node.IsEndOfWord;
        }

        public StringBuilder StartsWith(string prefix)
        {
            var node = _root;
            foreach (char @char in prefix)
            {
                if (!node.Children.ContainsKey(@char))
                    return new StringBuilder(); 
                node = node.Children[@char];
            }

            StringBuilder results = new();
            DFS(node, prefix, results);
            return results;
        }

        private void DFS(TrieNode node, string prefix, StringBuilder results)
        {
            if (node.IsEndOfWord)
            {
                results.Append(prefix);
                results.AppendLine();
            }

            foreach (var keyValuePair in node.Children)
            {
                DFS(keyValuePair.Value, prefix + keyValuePair.Key, results);
            }
        }
    }

}
