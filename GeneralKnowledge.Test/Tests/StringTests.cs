using System;
using System.Collections.Generic;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below
            Console.WriteLine("=====================Anagram Test====================");
            AnagramTest();
            Console.WriteLine("=====================Get Unique Chars and Count====================");
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            
            Dictionary<char, int> lstChars = word.GetUniqueCharsAndCount();
            foreach (var item in lstChars) {
                Console.WriteLine($"Character= {item.Key}, Count= {item.Value}");
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            bool isAnagram = true;
            var uniqueCharsOfa = a.GetUniqueCharsAndCount();
            var uniqueCharsOfb = b.GetUniqueCharsAndCount();
            if (uniqueCharsOfa.Count == uniqueCharsOfb.Count)
            {
                foreach (var item in uniqueCharsOfa)
                {
                    if (uniqueCharsOfb.ContainsKey(item.Key))
                        isAnagram = isAnagram && item.Value == uniqueCharsOfb[item.Key];
                    else isAnagram = false;
                }
            }
            else { isAnagram = false; }
            return isAnagram;
        }

        public static Dictionary<char, int> GetUniqueCharsAndCount(this string word) {
            Dictionary<char, int> lstChars = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (lstChars.ContainsKey(c) && lstChars[c] > 0)
                {
                    lstChars[c] = lstChars[c] + 1;
                }
                else
                {
                    lstChars.Add(c, 1);
                }
            }

            return lstChars;
        }
    }
}
