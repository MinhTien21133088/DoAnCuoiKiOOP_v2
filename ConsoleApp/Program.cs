using System;

namespace DoAnCuoiKiOOP_v2
{
    public static class Program
    {
        public static void Main()
        {
            // Lưu ý:
            // Định dạng tiền nhập vào sẽ là 10000 - tương đương với 10k VNĐ
            InputUnicode();
            OutputUnicode();
            //NguoiChoThue testChoThue = new NguoiChoThue("Tiến", "123456789", "0986046847", false, new(2003, 04, 25), "SV", "Số 1 VVN", "123");
            //Console.WriteLine(testChoThue.Tuoi);

            QuanLyPhongTro.DSCongTyMoiGioi = new List<CongTyMoiGioi>
            {
                new("Công ty HCMUTE", "Số 1 VVN", "123"),
                new("Công ty FIT", "Cũng là Số 1 VVN", "456"),
                new("Công ty cô An", "A mấy quên rùi", "999999999999999999999"),
            };
            XuLyFileCSV<CongTyMoiGioi>.Write(QuanLyPhongTro.DSCongTyMoiGioi, "congtymoigioi.csv");

            try
            {
                QuanLyPhongTro.DSNguoiChoThue = XuLyFileCSV<NguoiChoThue>.Read("nguoichothue.csv");
                QuanLyPhongTro.DSNguoiThue = XuLyFileCSV<NguoiThue>.Read("nguoithue.csv");
                QuanLyPhongTro.DSHopDong = XuLyFileCSV<HopDong>.Read("hopdong.csv");
                QuanLyPhongTro.DSPhongTro = XuLyFileCSV<PhongTro>.Read("phongtro.csv");
                QuanLyPhongTro.DSNguoiMoiGioi = XuLyFileCSV<NguoiMoiGioi>.Read("nguoimoigioi.csv");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Đọc file có vấn đề nhó");
                Console.WriteLine(ex.ToString());
            }
            foreach (NguoiChoThue test in QuanLyPhongTro.DSNguoiChoThue)
                test.XuatThongTin();

            QuanLyPhongTro.HeThong();
            
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
