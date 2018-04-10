using System;

namespace Random_Browser.Classes
{
    public static class Helper
    {
        private static readonly Random Random = new Random();
        private static readonly char[] Alfabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly int[] Numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static string GenerateUrl()
        {
            string baseUrl = "https://prnt.sc/";
            for (int i = 0; i < 6; i++)
            {
                if (Random.Next(0, 2) == 0)
                {
                    if (i == 0)
                    {
                        baseUrl += Alfabet[Random.Next(0,8)];
                    }
                    else
                    {
                        baseUrl += Alfabet[Random.Next(0, 26)];
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        baseUrl += Numbers[Random.Next(6, 10)];
                    }
                    else
                    {
                        baseUrl += Numbers[Random.Next(0, 10)];
                    }
                }
            }
            return baseUrl;
        }
    }
}
