using System;

namespace DoAnCuoiKiOOP_v2
{
    public class Menu
    {
        // class chuyên về Menu

        private string title = "";
        private List<string> optionList = new List<string>();
        private int size = 0;

        public Menu(string title)
        {
            this.title = title;
        }

        ~Menu() { }

        public void AddNewOption(string newOption)
        {
            optionList.Add(newOption);
            size++;
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine(title);
            Console.WriteLine("------------------------");
            for (int i = 0; i <= size - 1; i++)
            {
                string str = string.Format("{0}. {1}", i + 1, optionList[i]);
                Console.WriteLine(str);
            }
        }

        public int GetChoice()
        {
            int choice = Inputter.GetInteger("Vui lòng nhập lựa chọn: ", 1, size);
            return choice;
        }

        public void Clear()
        {
            optionList.Clear();
            size = 0;
        }

    }
}
