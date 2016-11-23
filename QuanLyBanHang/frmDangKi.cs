using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDangKi : Form
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public frmDangKi()
        {
            InitializeComponent();

        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            tblTaiKhoan checktk = db.tblTaiKhoans.SingleOrDefault(n => n.TenDangNhap == txtTenDangNhap.Text);
            if(checktk!=null)
            {
                MessageBox.Show("Tài khoản đã tồn tại , mời bạn làm lại");
                return;
            }
            tblTaiKhoan tk = new tblTaiKhoan();
            tk.IDTaiKhoan = db.tblTaiKhoans.Select(n => n.IDTaiKhoan).Max() + 1;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.tblTaiKhoans.Add(tk);
            db.SaveChanges();
            MessageBox.Show("Tạo tài khoản thành công!");
            this.Close();
        }
    }
}
