using System;

namespace DoAnCuoiKiOOP_v2
{
    public class Menu
    {
        private string title = "";
        private string[] optionList = new string[100];
        private int size = 0;

        public Menu(string title)
        {
            this.title = title;
        }

        public void AddNewOption(string newOption)
        {
            optionList[size] = newOption;
            size++;
        }

        public void PrintMenu()
        {
            //Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine(title);
            for (int i = 0; i <= size - 1; i++)
            {
                string str = string.Format("{0}. {1}", i + 1, optionList[i]);
                Console.WriteLine(str);
            }
        }

        public int GetChoice()
        {
            Console.Write("Vui lòng nhập lựa chọn: ");
            while (true)
            {
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > size)
                    {
                        throw new Exception();
                    }
                    return choice;
                }
                catch (Exception)
                {
                    Console.Write("Vui lòng nhập từ 1 - " + size + " nha: ");
                }
            }
        }

    }
}
