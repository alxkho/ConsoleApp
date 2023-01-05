namespace Coursework.Interfaces
{
    public interface IMyCollection<T>
    {
        public void Add(T item);
        public void AddRange(List<T> items);
        public T? GetByName(string name);
    }
}
