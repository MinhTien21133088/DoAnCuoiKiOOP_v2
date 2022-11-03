using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiThue : Nguoi
    {
        private double tienNo;
        private PhongTro phongTro;

        public double TienConNo()
        {
            return tienNo;
        }

        public void ThanhToanNo()
        {
            tienNo = 0;
            return;
        }

        public void ghiNo(double soTienNo)
        {
            tienNo += soTienNo;
            return;
        }

        public void ThanhToanTro()
        {
            phongTro.ThanhToan();
        }
    }
}