using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    public sealed class SingletonThreaded
    {
        private SingletonThreaded()
        {

        }

        private static SingletonThreaded _instance;
        private static readonly object _lock = new object();

        public static SingletonThreaded GetInstance(string value)
        {
            if (_instance == null)
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreaded();
                        _instance.Value = value;
                    }
                        
                }
            return _instance;
        }

        public string Value { get; set; }

    }
}
