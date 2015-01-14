using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common.Utilities
{
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
