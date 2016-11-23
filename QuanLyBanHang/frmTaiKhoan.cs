using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmTaiKhoan : Form
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        LuaChon lc;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        void ThemTaiKhoan()
        {
            tblTaiKhoan tk = new tblTaiKhoan();
            if (dgvTaiKhoan.Rows.Count <= 1) tk.IDTaiKhoan = 1;
            else tk.IDTaiKhoan = db.tblTaiKhoans.Select(n => n.IDTaiKhoan).Max() + 1;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.tblTaiKhoans.Add(tk);
            db.SaveChanges();
            LoadDataTaiKhoan();
        }

        void SuaTaiKhoan()
        {
            int id = int.Parse(txtIDTaiKhoan.Text);
            tblTaiKhoan tk = db.tblTaiKhoans.Where(n => n.IDTaiKhoan == id).First();
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.SaveChanges();
            LoadDataTaiKhoan();
        }

        void XoaTaiKhoan()
        {
            int id = int.Parse(txtIDTaiKhoan.Text);
            tblTaiKhoan tk = db.tblTaiKhoans.Where(n => n.IDTaiKhoan == id).First();
            db.tblTaiKhoans.Remove(tk);
            db.SaveChanges();
            LoadDataTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Them;
            AnButton();
            ChoViet();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Sua;
            ChoViet();
            AnButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Xoa;
            AnButton();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (lc)
            {
                case LuaChon.Them:
                    if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                    {
                        MessageBox.Show("Yêu cầu bạn điền đầy đủ thông tin");
                        return;
                    }
                    ThemTaiKhoan();
                    break;
                case LuaChon.Sua:
                    if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                    {
                        MessageBox.Show("Yêu cầu bạn điền đầy đủ thông tin");
                        return;
                    }
                    SuaTaiKhoan();
                    break;
                case LuaChon.Xoa:
                    XoaTaiKhoan();
                    break;
            }
            ChiDoc();
            HienButton();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienButton();
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTaiKhoan.SelectedRows[0];
            txtIDTaiKhoan.Text = row.Cells["IDTaiKhoan"].Value?.ToString();
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
        }
        void LoadDataTaiKhoan()
        {
            dgvTaiKhoan.DataSource = db.tblTaiKhoans.Select(n => n).ToList();
            dgvTaiKhoan.Columns["IDTaiKhoan"].HeaderText = "Mã tài khoản";
            dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataTaiKhoan();
            ChiDoc();
            HienButton();
        }
        private void AnButton()
        {
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnThem.Visible = false;
        }
        private void HienButton()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnThem.Visible = true;
        }
        private void ChiDoc()
        {
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtIDTaiKhoan.ReadOnly = true;
        }
        private void ChoViet()
        {
            txtIDTaiKhoan.ReadOnly = true;
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = db.tblTaiKhoans.Where(n => n.TenDangNhap.Contains(txtTimKiem.Text)).ToList();
        }
    }
}
