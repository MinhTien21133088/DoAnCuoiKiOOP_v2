using FileGeneric;
using System;

namespace DoAnCuoiKiOOP_v2
{
    public static class Program
    {
        static void Main()
        {
            // Lưu ý:
            // Định dạng tiền nhập vào sẽ là 10000 - tương đương với 10k VNĐ
            InputUnicode();
            OutputUnicode();
            QuanLyPhongTro quanLyPhongTro = new QuanLyPhongTro();
            quanLyPhongTro.HeThong();
            quanLyPhongTro.GhiFile();
            return;
        }

        public static void InputUnicode()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }

        public static void OutputUnicode()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }
    }
}
