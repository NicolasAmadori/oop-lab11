namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        IList<Tuple<TKey1, TKey2, TValue>> map;

        public Map2D() => map = new List<Tuple<TKey1, TKey2, TValue>>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => map.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get
            {
                foreach(var t in map)
                    if(t.Item1.Equals(key1) && t.Item2.Equals(key2))
                        return t.Item3;
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                foreach(var t in map)
                    if(t.Item1.Equals(key1) && t.Item2.Equals(key2))
                    {
                        map.Remove(t);
                        map.Add(new Tuple<TKey1, TKey2, TValue>(key1, key2, value));
                    }
            }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            var rows = new List<Tuple<TKey2, TValue>>();
            foreach(var t in map)
                if(t.Item1.Equals(key1))
                    rows.Add(new Tuple<TKey2, TValue>(t.Item2, t.Item3));
            return rows;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            var columns = new List<Tuple<TKey1, TValue>>();
            foreach(var t in map)
                if(t.Item2.Equals(key2))
                    columns.Add(new Tuple<TKey1, TValue>(t.Item1, t.Item3));
            return columns;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            var elem = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach(var t in map)
                elem.Add(t);
            return elem;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (TKey1 k1 in keys1)
                foreach (TKey2 k2 in keys2)
                    map.Add(new Tuple<TKey1, TKey2, TValue>(k1, k2, generator(k1, k2)));
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if(NumberOfElements != other.NumberOfElements) return false;
            var l1 = GetElements();
            var l2 = other.GetElements();
            for(int i = 0; i < NumberOfElements; i++)
                if(!l1[i].Equals(l2[i])) return false;
            return true;
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            IMap2D<TKey1, TKey2, TValue> iMap = obj as IMap2D<TKey1, TKey2, TValue>;
            return iMap != null && Equals(iMap);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO: improve
            return base.GetHashCode();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            string s = "";
            foreach(var el in map)
                s+= $"{el.Item1} {el.Item2} {el.Item3},";
            return s;
        }
    }
}
