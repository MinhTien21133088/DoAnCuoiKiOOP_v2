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

        public string Ten { get => ten; set => ten = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MaSoThue { get => maSoThue; set => maSoThue = value; }

        public CongTyMoiGioi(string ten, string diaChi, string maSoThue)
        {
            Ten = ten;
            DiaChi = diaChi;
            MaSoThue = maSoThue;
        }

        public CongTyMoiGioi() { }

        ~CongTyMoiGioi() { }

        public void XuatThongTin(int mode)
        {
            if (mode == 0)
            {
                Console.WriteLine("Công ty môi giới " + Ten);
            }
            Console.WriteLine("Địa chỉ: " + DiaChi);
            Console.WriteLine("Mã số thuế: " + MaSoThue);
        }

    }
}
