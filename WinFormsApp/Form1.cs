
namespace WinFormsApp
{
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }
      

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (tBTenDangNhap.Text == "")
                lbLoiTDN.Text = "Tên đăng nhập không được bỏ trống!";
            else
                lbLoiTDN.Text = "";
            if (tBMatKhau.Text == "")
                lbLoiMK.Text = "Mật khẩu không được bỏ trống!";
            else
                lbLoiMK.Text = "";
            if (rbNguoiChu.Checked == true)
            {
                
            }
            else
            {

            }
        }
    }
}