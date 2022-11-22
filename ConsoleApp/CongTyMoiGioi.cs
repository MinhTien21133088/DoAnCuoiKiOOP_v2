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

        public CongTyMoiGioi(string ten, string diaChi, string maSoThue)
        {
            Ten = ten;
            this.diaChi = diaChi;
            this.maSoThue = maSoThue;
        }

        ~CongTyMoiGioi() { }


        public void XuatThongTin(int mode)
        {
            if (mode == 0)
            {
                Console.WriteLine("Công ty môi giới " + Ten);
            }
            Console.WriteLine("Địa chỉ: " + diaChi);
            Console.WriteLine("Mã số thuế: " + maSoThue);
        }

    }
}
