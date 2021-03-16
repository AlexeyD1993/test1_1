using System;
using System.Collections.Generic;
using System.Text;

namespace test1_1.Parcers
{
    interface IParcer
    {
        string TryParce(string str);
    }

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

    class ParcerException : ArgumentException
    {
        public string message;
        public ParcerException()
        {
            this.message = "Ошибка обработки строки. Обработка данного типа пока не реализована";
        }
    }

}
