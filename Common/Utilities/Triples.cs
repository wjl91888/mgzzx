using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common.Utilities
{
    public class Triples<TKey, TValue, TExtend> : Pair<TKey, TValue>
    {
        public TExtend Extend { get; set; }

        public Triples(TKey key, TValue val, TExtend ext)
            : base(key, val)
        {
            Extend = ext;
        }

        public Triples(Pair<TKey, TValue> pair)
            : base(pair.Key, pair.Value)
        {
            // empty
        }

        public Triples(Pair<TKey, TValue> pair, TExtend extend)
            : this(pair)
        {
            Extend = extend;
        }
    }
}
