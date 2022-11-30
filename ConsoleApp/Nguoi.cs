using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class Nguoi
    {
        protected string hoVaTen;
        protected string cccd;
        protected string sdt;
        protected bool gioiTinh; // true là nam, false là nữ
        protected DateTime ngaySinh;
        protected int tuoi;
        protected string diaChi;
        protected string ngheNghiep;
        protected string tenDangNhap;
        protected string matKhau;

        public Nguoi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string tenDangNhap, string matKhau)
        {
            this.hoVaTen = hoVaTen;
            this.cccd = cccd;
            this.sdt = sdt;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            tuoi = DateTime.Now.Year - ngaySinh.Year;
            this.diaChi = diaChi;
            this.ngheNghiep = ngheNghiep;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }

        public Nguoi() {

        }

        ~Nguoi() { }

        protected void XuatThongTin()
        {
            Program.OutputUnicode();
            Console.WriteLine("Họ và tên:   " + hoVaTen);
            Console.WriteLine("CCCD:        " + cccd);
            Console.WriteLine("SĐT:         " + sdt);
            Console.WriteLine("Giới tính:   " + string.Format(gioiTinh ? "Nam" : "Nữ"));
            Console.WriteLine("Ngày sinh:   " + ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tuổi:        " + tuoi);
            Console.WriteLine("Địa chỉ:     " + diaChi);
            Console.WriteLine("Nghề nghiệp: " + ngheNghiep);
        }

        public Nguoi (bool nhap)
        {
            Console.WriteLine("--- Nhập thông tin cơ bản ---");
            hoVaTen = Inputter.GetString("Họ và tên: ", "Tên không được bỏ trống");
            cccd = Inputter.GetStringF("Số CCCD: ", "CCCD không hợp lệ", "^[0-9]{9}$|^[0-9]{12}$");
            sdt = Inputter.GetStringF("Số điện thoại: ", "Số điện thoại không hợp lệ", "^0[0-9]{9}$");
            gioiTinh = Inputter.GetInteger("Giới tính ('1' - Nam|'0' - Nữ): ", "Không hợp lệ!", 0, 1) == 1 ? true : false;
            NHAP_LAI_NGAY_SINH:
            try
            {
                ngaySinh = DateTime.ParseExact(
                    Inputter.GetStringF(
                        "Ngày tháng năm sinh (dd/MM/yyyy): ", "Ngày tháng năm sinh không hợp lệ",
                        "((0|1)[0-9]|2[0-9]|3[0-9])/(0[0-9]|1[0-2])/((19|20)[0-9][0-9])$"), "dd/MM/yyyy", null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ngày tháng năm sinh không hợp lệ.");
                goto NHAP_LAI_NGAY_SINH;
            }
            ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
            diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
            tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");  
        }


        public virtual void HeThong()
        {

        }

    }
}
