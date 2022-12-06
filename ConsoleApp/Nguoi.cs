using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class Nguoi
    {
        private string hoVaTen;
        private string cccd;
        private string sdt;
        private bool gioiTinh; // true là nam, false là nữ
        private DateTime ngaySinh;
        private int tuoi;
        private string diaChi;
        private string ngheNghiep;
        //private string tenDangNhap; bỏ tên đăng nhập, dùng cccd thay vì dùng tên đăng nhập
        private string matKhau;

        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string CCCD { get => cccd; private set => cccd = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgheNghiep { get => ngheNghiep; set => ngheNghiep = value; }
        //public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }

        public Nguoi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, /*string tenDangNhap,*/ string matKhau)
        {
            HoVaTen = hoVaTen;
            CCCD = cccd;
            SDT = sdt;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Tuoi = DateTime.Now.Year - NgaySinh.Year;
            DiaChi = diaChi;
            NgheNghiep = ngheNghiep;
            //this.tenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }

        public Nguoi() { }

        ~Nguoi() { }

        protected void XuatThongTin()
        {
            Program.OutputUnicode();
            Console.WriteLine("Họ và tên:   " + HoVaTen);
            Console.WriteLine("CCCD:        " + CCCD);
            Console.WriteLine("SĐT:         " + SDT);
            Console.WriteLine("Giới tính:   " + string.Format(GioiTinh ? "Nam" : "Nữ"));
            Console.WriteLine("Ngày sinh:   " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tuổi:        " + Tuoi);
            Console.WriteLine("Địa chỉ:     " + DiaChi);
            Console.WriteLine("Nghề nghiệp: " + NgheNghiep);
        }

        //public Nguoi (bool nhap)
        //{
        //    Console.WriteLine("--- Nhập thông tin cơ bản ---");
        //    hoVaTen = Inputter.GetString("Họ và tên: ", "Tên không được bỏ trống");
        //    cccd = Inputter.GetStringF("Số CCCD: ", "CCCD không hợp lệ", "^[0-9]{9}$|^[0-9]{12}$");
        //    sdt = Inputter.GetStringF("Số điện thoại: ", "Số điện thoại không hợp lệ", "^0[0-9]{9}$");
        //    gioiTinh = Inputter.GetInteger("Giới tính ('1' - Nam|'0' - Nữ): ", "Không hợp lệ!", 0, 1) == 1 ? true : false;
        //    NHAP_LAI_NGAY_SINH:
        //    try
        //    {
        //        ngaySinh = DateTime.ParseExact(
        //            Inputter.GetStringF(
        //                "Ngày tháng năm sinh (dd/MM/yyyy): ", "Ngày tháng năm sinh không hợp lệ",
        //                "((0|1)[0-9]|2[0-9]|3[0-9])/(0[0-9]|1[0-2])/((19|20)[0-9][0-9])$"), "dd/MM/yyyy", null);
        //    }
        //    catch /*(Exception ex)*/
        //    {
        //        Console.WriteLine("Ngày tháng năm sinh không hợp lệ.");
        //        goto NHAP_LAI_NGAY_SINH;
        //    }
        //    ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
        //    diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
        //    //tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
        //    matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");  
        //}

        public virtual void HeThong()
        {

        }

        public bool DangNhapThanhCong(string cccd, string matKhau)
        {
            if (cccd == CCCD && matKhau == MatKhau)
                return true;
            return false;
        }

    }
}
