using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAnCuoiKiOOP_v2
{
    public class Inputter
    {
        // Ai ko hiểu nhớ liên lạc riêng tui qua zalo nha :v

        private static void VuiLongNhapLai()
        {
            Console.Write("Vui lòng nhập lại: ");
        }

        private static void VuiLongNhapLai(object lowerBound, object upperBound)
        {
            Console.Write("Vui lòng nhập từ {0} đến {1} nha: ", lowerBound, upperBound);
        }

        // method ép người dùng nhập số nguyên
        public static int GetInteger(string inputMsg)
        {
            Console.Write(inputMsg);
            int number;
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai();
                }
            }
        }

        public static int GetInteger(string inputMsg, string errorMsg)
        {
            Console.Write(inputMsg);
            int number;
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai();
                }
            }
        }

        // method ép người dùng nhập số nguyên trong khoảng nào đó
        public static int GetInteger(string inputMsg, int lowerBound, int upperBound)
        {
            Console.Write(inputMsg);

            if (lowerBound > upperBound)
            {
                int tmp = lowerBound;
                lowerBound = upperBound;
                upperBound = tmp;
            }

            int number;
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number > upperBound || number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai(lowerBound, upperBound);
                }
            }
        }

        public static int GetInteger(string inputMsg, string errorMsg, int lowerBound, int upperBound)
        {
            Console.Write(inputMsg);

            if (lowerBound > upperBound)
            {
                int tmp = lowerBound;
                lowerBound = upperBound;
                upperBound = tmp;
            }

            int number;
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number > upperBound || number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai(lowerBound, upperBound);
                }
            }
        }

        // method ép người dùng nhập số thực
        public static double GetDouble(string inputMsg)
        {
            Console.Write(inputMsg);
            double number;
            while (true)
            {
                try
                {
                    number = double.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai();
                }
            }
        }

        public static double GetDouble(string inputMsg, string errorMsg)
        {
            Console.Write(inputMsg);
            double number;
            while (true)
            {
                try
                {
                    number = double.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai();
                }
            }
        }

        // method ép người dùng nhập số thực trong khoảng nào đó
        public static double GetDouble(string inputMsg, double lowerBound, double upperBound)
        {
            Console.Write(inputMsg);
            if (lowerBound > upperBound)
            {
                double tmp = lowerBound;
                lowerBound = upperBound;
                upperBound = tmp;
            }
            double number;
            while (true)
            {
                try
                {
                    number = double.Parse(Console.ReadLine());
                    if (number > upperBound || number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai(lowerBound, upperBound);
                }
            }
        }

        public static double GetDouble(string inputMsg, string errorMsg, double lowerBound, double upperBound)
        {
            Console.Write(inputMsg);
            if (lowerBound > upperBound)
            {
                double tmp = lowerBound;
                lowerBound = upperBound;
                upperBound = tmp;
            }
            double number;
            while (true)
            {
                try
                {
                    number = double.Parse(Console.ReadLine());
                    if (number > upperBound || number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai(lowerBound, upperBound);
                }
            }
        }

        // method ép nhập String ko bỏ trống
        public static string GetStringF(string inputMsg)
        {
            Program.InputUnicode();
            Console.Write(inputMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str == "")
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return str;
                    }
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai();
                }
            }
        }

        public static string GetString(string inputMsg, string errorMsg)
        {
            Program.InputUnicode();
            Console.Write(inputMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str == "")
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return str;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai();
                }
            }
        }

        // method ép nhập String ko bỏ trống và phải nhập theo format
        public static string GetStringF(string inputMsg, string regex)
        {
            Program.InputUnicode();
            Console.Write(inputMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str == "" || !Regex.IsMatch(str, regex))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return str;
                    }
                }
                catch (Exception e)
                {
                    
                    VuiLongNhapLai();
                }
            }
        }

        public static string GetStringF(string inputMsg, string errorMsg, string regex)
        {
            Program.InputUnicode();
            Console.Write(inputMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str == "" || !Regex.IsMatch(str, regex))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return str;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(errorMsg);
                    VuiLongNhapLai();
                }
            }
        }

    }
}
// Regex
// "^0\d{9}" check sđt
// "^\d{9}$|^\d{12}$" check CMND/CCCD
// "((0|1)\d|2\d|3\d)\/(0\d|1[0-2])\/((19|20)\d\d)$" check DateTime nhập vào
// all code by Tiến
