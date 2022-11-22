using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class Nguoi
    {
        #region Fields
        private string hoVaTen;
        private string cccd;
        private string sdt;
        private bool gioiTinh; // true là nam, false là nữ
        private DateTime ngaySinh;
        private int tuoi;
        private string diaChi;
        private string ngheNghiep;
        private string tenDangNhap;
        private string matKhau;
        #endregion

        #region Properties
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgheNghiep { get => ngheNghiep; set => ngheNghiep = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        #endregion

        public Nguoi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string tenDangNhap, string matKhau)
        {
            this.HoVaTen = hoVaTen;
            this.Cccd = cccd;
            this.Sdt = sdt;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            Tuoi = DateTime.Now.Year - ngaySinh.Year;
            this.DiaChi = diaChi;
            this.NgheNghiep = ngheNghiep;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
        }

        public Nguoi() { }
        
        ~Nguoi() { }

        protected void XuatThongTin()
        {
            Program.OutputUnicode();
            Console.WriteLine("Họ và tên:   " + HoVaTen);
            Console.WriteLine("CCCD:        " + Cccd);
            Console.WriteLine("SĐT:         " + Sdt);
            Console.WriteLine("Giới tính:   " + string.Format(GioiTinh ? "Nam" : "Nữ"));
            Console.WriteLine("Ngày sinh:   " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tuổi:        " + Tuoi);
            Console.WriteLine("Địa chỉ:     " + DiaChi);
            Console.WriteLine("Nghề nghiệp: " + NgheNghiep);
        }

        /*public bool DangKi()
        {
            Console.WriteLine("--- Nhập thông tin cơ bản ---");
            string hoVaTen = Inputter.GetString("Họ và tên: ", "Tên không được bỏ trống");
            string cccd = Inputter.GetStringF("Số CCCD: ", "CCCD không hợp lệ", "^[0-9]{9}$|^[0-9]{12}$");
            string sdt = Inputter.GetStringF("Số điện thoại: ", "Số điện thoại không hợp lệ", "^0[0-9]{9}$");
            int gioiTinh = Inputter.GetInteger("Giới tính ('1' - Nam|'0' - Nữ): ", "Không hợp lệ!", 0, 1);
            DateTime ngaySinh;
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
            string ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
            string diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
            string tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            //return new Nguoi(hoVaTen, cccd, sdt, gioiTinh == 1 ? true : false, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau);           
        }*/


        public virtual void HeThong()
        {

        }

        //public bool TimKiem(string ten, string mK)
        //{

        //    return true;
        //}



    }
}
