using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

public class MedarbejderCollection<TKey> where TKey : notnull
{
    private readonly Dictionary<TKey, IHarAdresse> _collection = new Dictionary<TKey, IHarAdresse>();
    public void AddElement(TKey key, IHarAdresse element)
    {
        if (_collection.ContainsKey(key))
        {
            throw new ArgumentException();
        }
        _collection.Add(key, element);
    }
    public IHarAdresse? GetElement(TKey key)
    {
        try
        {
            return _collection[key];
        }
        catch
        {
            return null;
        }
    }
    public int Size()
    {
        return _collection.Count;
    }
}
