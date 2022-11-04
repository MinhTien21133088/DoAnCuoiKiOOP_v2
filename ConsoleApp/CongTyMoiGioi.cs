using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class CongTyMoiGioi
    {
        private string ten;
        private string diaChi;
        private string maSoThue;

        public CongTyMoiGioi(string ten, string diaChi, string maSoThue)
        {
            this.ten = ten;
            this.diaChi = diaChi;
            this.maSoThue = maSoThue;
        }

        public void XuatThongTin()
        {
            Console.WriteLine("Công ty môi giới " + ten);
            Console.WriteLine("Địa chỉ: " + diaChi);
            Console.WriteLine("Mã số thuế: " + maSoThue);
        }
    }
}