using System;
using System.Collections.Generic;
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
        private string ngheNghiep;
        private string tenDangNhap;
        private string matKhau;

        public Nguoi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string tenDangNhap, string matKhau)
        {
            this.hoVaTen = hoVaTen;
            this.cccd = cccd;
            this.sdt = sdt;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            tuoi = DateTime.Now.Year - ngaySinh.Year;
            this.ngheNghiep = ngheNghiep;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }

        public void XuatThongTin()
        {
            Console.WriteLine("Họ và tên:   {0}", hoVaTen);
            Console.WriteLine("CCCD:        {0}", cccd);
            Console.WriteLine("SĐT:         {0}", sdt);
            Console.WriteLine("Giới tính:   {0}", gioiTinh ? "Nam" : "Nữ");
            Console.WriteLine("Ngày sinh:   {0}", ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tuổi:        {0}", tuoi);
            Console.WriteLine("Nghề nghiệp: {0}", ngheNghiep);
        }

        public void DangKy()
        {
            Console.WriteLine("--- Nhập thông tin cơ bản ---");
            string hoTen = Inputter.GetString("Họ và tên: ", "Tên không được bỏ trống");
            string cccd = Inputter.GetString("Số CCCD: ", "CCCD không hợp lệ", "^[0-9]{9}$|^[0-9]{12}$");
            DateTime ngaySinh;
        NHAP_LAI_NGAY_SINH:
            try
            {
                ngaySinh = DateTime.ParseExact(
                    Inputter.GetString(
                        "Ngày tháng năm sinh (dd/MM/yyyy): ", "Ngày tháng năm sinh không hợp lệ",
                        "((0|1)[0-9]|2[0-9]|3[0-9])/(0[0-9]|1[0-2])/((19|20)[0-9][0-9])$"), "dd/MM/yyyy", null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ngày tháng năm sinh không hợp lệ.");
                goto NHAP_LAI_NGAY_SINH;
            }
            string sdt = Inputter.GetString("Số điện thoại: ", "Số điện thoại không hợp lệ", "^0[0-9]{9}$");
            string ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
            string diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
            string tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
        }
    }
}