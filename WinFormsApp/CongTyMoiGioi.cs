using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class CongTyMoiGioi
    {
        public string ten { get; }
        private string diaChi;
        private string maSoThue;

        public CongTyMoiGioi(string ten, string diaChi, string maSoThue)
        {
            this.ten = ten;
            this.diaChi = diaChi;
            this.maSoThue = maSoThue;
        }

        ~CongTyMoiGioi() { }

        public void XuatThongTin(int mode)
        {
            if (mode == 0)
            {
                Console.WriteLine("Công ty môi giới " + ten);
            }
            Console.WriteLine("Địa chỉ: " + diaChi);
            Console.WriteLine("Mã số thuế: " + maSoThue);
        }

    }
}
