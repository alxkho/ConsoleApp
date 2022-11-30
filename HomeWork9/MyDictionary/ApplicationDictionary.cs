namespace HomeWork9.MyDictionary
{
    public class ApplicationDictionary<TKey, TValue> where TKey : notnull
    {
        private Dictionary<TKey, TValue> _myDictionary;

        public ApplicationDictionary()
        {
            _myDictionary = new Dictionary<TKey, TValue>();
        }
        public ApplicationDictionary(Dictionary<TKey, TValue> dictionary)
        {
            _myDictionary = dictionary;
        }

        public void Add(TKey key, TValue value)
        {
            _myDictionary.Add(key, value);
        }

        public void Remove(TKey key)
        {
            _myDictionary.Remove(key);
        }

        public TValue GetByKey(TKey key)
        {
            if (_myDictionary.ContainsKey(key))
                return _myDictionary[key];

            return default(TValue);

        }

        public List<TKey> GetAllKeys()
        {
            var listKeys = new List<TKey>();
            foreach (var item in _myDictionary)
            {
                listKeys.Add(item.Key);
            }
            return listKeys;
        }
    }
}