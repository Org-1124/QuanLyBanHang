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
    public enum LuaChon
    {
        Them,
        Sua,
        Xoa
    }
    public partial class frmHangHoa : Form
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        LuaChon lc;
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }
        void chidoc()
        {
            txtDonGia.ReadOnly = true;
            txtSoLuongCon.ReadOnly = true;
            txtTenHangHoa.ReadOnly = true;
            txtIDHangHoa.ReadOnly = true;
        }
        void choviet()
        {
            txtDonGia.ReadOnly = false;
            txtSoLuongCon.ReadOnly = false;
            txtTenHangHoa.ReadOnly = false;
            
            
        }
        void AnButton()
        {
            btnLuu.Visible = true;
            btnThem.Visible = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
        }

        void HienButton()
        {
            btnThem.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            btnSua.Visible = true;
        }
        void LoadDataHangHoa()
        {
            dgvHangHoa.DataSource = db.tblHangHoas.Select(n => n);
            dgvHangHoa.Columns["TenHang"].HeaderText = "Tên Hàng";
            dgvHangHoa.Columns["IDHangHoa"].HeaderText = "ID Hành Hóa";
            dgvHangHoa.Columns["SoLuongCon"].HeaderText = "Số Lượng Còn";
            dgvHangHoa.Columns["DonGia"].HeaderText = "Đơn Giá";
            chidoc();
            HienButton();
        }
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadDataHangHoa();
        }
        
        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvHangHoa.SelectedRows[0];
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            txtSoLuongCon.Text = row.Cells["SoLuongCon"].Value.ToString();
            txtTenHangHoa.Text = row.Cells["TenHang"].Value.ToString();
            txtIDHangHoa.Text = (row.Cells["IDHangHoa"].Value.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Them;
            AnButton();
            txtDonGia.Clear();
            txtSoLuongCon.Clear();
            txtTenHangHoa.Clear();
            choviet();
            txtIDHangHoa.Text = "Tự động";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Sua;
            AnButton();
            choviet();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HienButton();
            XoaHangHoa();
            LoadDataHangHoa();
        }
        void ThemHangHoa()
        {
            tblHangHoa hh = new tblHangHoa();
            if (dgvHangHoa.Rows.Count <= 1) hh.IDHangHoa = 1;
            else hh.IDHangHoa = db.tblHangHoas.Select(n => n.IDHangHoa).Max() + 1;
            hh.TenHang = txtTenHangHoa.Text;
            if (txtSoLuongCon.Text == "") hh.SoLuongCon = null;
            else hh.SoLuongCon = int.Parse(txtSoLuongCon.Text.ToString());
            if (txtDonGia.Text == "") hh.DonGia = null;
            else hh.DonGia = int.Parse(txtDonGia.Text);
            db.tblHangHoas.Add(hh);
            db.SaveChanges();
        }
        void SuaHangHoa()
        {
            tblHangHoa hh = db.tblHangHoas.Where(n => n.IDHangHoa == int.Parse(txtIDHangHoa.Text)).First();
            hh.TenHang = txtTenHangHoa.Text;
            if (txtDonGia.Text == "") hh.DonGia = null;
            else hh.DonGia = int.Parse(txtDonGia.Text);
            if (txtSoLuongCon.Text == "") hh.SoLuongCon = null;
            else hh.SoLuongCon = int.Parse(txtSoLuongCon.Text.ToString());
            db.SaveChanges();
        }
        void XoaHangHoa()
        {
            try
            {
                tblHangHoa hh = db.tblHangHoas.Where(n => n.IDHangHoa == int.Parse(txtIDHangHoa.Text)).First();
                db.tblHangHoas.Remove(hh);
                db.SaveChanges();
            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch(lc)
            {
                case LuaChon.Them:
                    ThemHangHoa();
                    break;
                case LuaChon.Sua:
                    SuaHangHoa();
                    break;
                case LuaChon.Xoa:
                    XoaHangHoa();
                    break;
            }
            HienButton();
            LoadDataHangHoa();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvHangHoa.DataSource = db.tblHangHoas.Where(n => n.TenHang.Contains(txtTimKiem.Text));
                dgvHangHoa.DataSource = db.tblHangHoas.Where(n => n.IDHangHoa == int.Parse(txtTimKiem.Text.ToString()));
            }
            catch
            {

            }

        }
    }
}
