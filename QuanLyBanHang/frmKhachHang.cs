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
    public partial class frmKhachHang : Form
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public frmKhachHang()
        {
            InitializeComponent();
            LoadDataKhachHang();
        }
        enum LuaChon
        {
            Them,
            Sua,
            Xoa
        }
        LuaChon lc;

        void LoadDataKhachHang()
        {
            var s = from kh in db.tblKhachHangs
                    select new { kh.IDKhachHang, kh.TenKhachHang, kh.DiaChi, kh.DienThoai };
            dgrkhachhang.DataSource = s;
            TenCot();
            ChiDoc();

        }
        private void TenCot()
        {
            dgrkhachhang.Columns["IDKhachHang"].HeaderText = "Mã Khách Hàng";
            dgrkhachhang.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dgrkhachhang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgrkhachhang.Columns["DienThoai"].HeaderText = "Điện Thoại Liên Lạc";
        }

        private void dgrkhachhang_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgrkhachhang.SelectedRows[0];
            txtmakh.Text = row.Cells["IDKhachHang"].Value.ToString();
            txttenkh.Text = row.Cells["TenKhachHang"].Value.ToString();
            txtdiachi.Text = row.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = row.Cells["DienThoai"].Value.ToString();
        }
        private void ChiDoc()
        {
            txtmakh.ReadOnly = true;
            txttenkh.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtsdt.ReadOnly = true;
        }
        private void ThaoTac()
        {
            txtmakh.ReadOnly = false;
            txttenkh.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtsdt.ReadOnly = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txttenkh.Clear();
            txtmakh.Text = (db.tblKhachHangs.Select(n => n.IDKhachHang).Max() + 1).ToString();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtmakh.ReadOnly = true;
            ThaoTac();
            lc = LuaChon.Them;
        }
        void ThemKhachHang()
        {
            tblKhachHang kh = new tblKhachHang();
            kh.IDKhachHang = db.tblKhachHangs.Select(n => n.IDKhachHang).Max() + 1;
            kh.TenKhachHang = txttenkh.Text;
            kh.DiaChi = txtdiachi.Text;
            kh.DienThoai = txtsdt.Text;

            db.tblKhachHangs.Add(kh);
            db.SaveChanges();
            ChiDoc();
            LoadDataKhachHang();
        }
        void SuaKhachHang()
        {
            tblKhachHang kh = new tblKhachHang();
            kh.TenKhachHang = txttenkh.Text;
            kh.DienThoai = txtsdt.Text;
            kh.DiaChi = txtdiachi.Text;

            db.SaveChanges();
            ChiDoc();
            LoadDataKhachHang();
        }
        void XoaKhachHang()
        {
            tblKhachHang kh = db.tblKhachHangs.Where(n => n.IDKhachHang == int.Parse(txtmakh.Text)).First();
            db.tblKhachHangs.Remove(kh);
            db.SaveChanges();
            LoadDataKhachHang();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            switch(lc)
            {
                case LuaChon.Them: 
                    ThemKhachHang(); break;
                case LuaChon.Sua:
                    SuaKhachHang();
                    break;
                case LuaChon.Xoa:
                    XoaKhachHang();
                    break;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Sua;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Xoa;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            dgrkhachhang.DataSource = db.tblKhachHangs.Where(n => n.TenKhachHang.Contains(txttimkiem.Text)).Select(kh => new { kh.IDKhachHang, kh.TenKhachHang, kh.DiaChi, kh.DienThoai });
        }

    }
}
