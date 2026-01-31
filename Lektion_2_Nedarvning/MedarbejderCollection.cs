using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MedarbejderCollection<TKey> where TKey : notnull
{
    private readonly Dictionary<TKey, Medarbejder> _collection = new Dictionary<TKey, Medarbejder>();
    public void AddElement(TKey key, Medarbejder medarbejder)
    {
        if (_collection.ContainsKey(key))
        {
            throw new ArgumentException();
        }
        _collection.Add(key, medarbejder);
    }
    public Medarbejder? GetElement(TKey key)
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
