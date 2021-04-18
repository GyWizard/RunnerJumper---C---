using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace RunnerJumper
{
    public static class ExampleExtensions
        {
            public static int Count(this string self)
            {
                int n = 0;
                foreach(char c in self)
                {
                    n++;
                }
                return n;
            }  
            public static int Count(this string self,char ch)
            {
                int n = 0;
                foreach(char c in self)
                {
                    if(c.Equals(ch))
                    {
                        n++;    
                    }               
                }
                return n;
            } 
            public static  Dictionary<T,int> ValuesCount<T>(this List<T> self)
            {
                Dictionary<T,int> d = new Dictionary<T, int>();
                foreach(T value in self)
                {
                    if(d.ContainsKey(value))
                    {
                        d[value]++;
                    }
                    else
                    {
                        d.Add(value,1);
                    }
                }
                return d;
            }

            public static  Dictionary<T,int> ValuesCountLinq<T>(this List<T> self)
            {
                Dictionary<T,int> d = new Dictionary<T, int>();
                foreach(T value in self)
                {
                    if(!d.ContainsKey(value))
                    {
                        d.Add(value, (from v in self where v.Equals(value) select v).Count());    
                    }             
                }
                return d;
            }

            
        }   
        public static class WorkWithList
        {
            public static void Start()
            {
                List<int> list = new List<int>()
                {
                    1,0,1,3,4,5,1,4,2
                };
                
                Dictionary<int,int> t = list.ValuesCount();//1
                foreach(int k in t.Keys)
                {
                    Debug.Log($"Key {k} = {t[k]} times");
                }

                Dictionary<int,int> tt = list.ValuesCountLinq();//2
                foreach(int k in tt.Keys)
                {
                    Debug.Log($"Key {k} = {t[k]} times");
                }

               
                List<string> listS = new List<string>() // 3
                {
                    "asd","ddd","asd","123"
                };
                
                var result = list.GroupBy(n => n)
                    .Select(c => new { Key = c.Key, total = c.Count() });
                    foreach(var c in result)
                    {
                        Debug.Log($"Key {c.Key} = {c.total} times");
                    }
            }
        }
}
