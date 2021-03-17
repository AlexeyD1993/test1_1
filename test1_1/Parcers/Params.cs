using System;
using System.Collections.Generic;
using System.Text;

namespace test1_1.Parcers
{
    // Хотя по-факту, лучше закинуть в конфигурационный файл и читать оттуда
    class Params
    {
        public static string[] findedNames = new string[] { "user", "users", "login", "name", "pass", "passwd", "password" };
        public static string ChangeName(string str)
        {
            string res = str;
            for (int i = 0; i < str.Length; i++)
            {
                if (res[i] != '/')
                    res = res.Replace(res[i], 'X');
            }
            return res;
        }
    }
}
