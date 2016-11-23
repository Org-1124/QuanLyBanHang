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
    public partial class frmNhanVien : Form
    {
        public enum LuaChon
        {
            Them,
            Sua,
            Xoa
        }
        LuaChon lc;
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public frmNhanVien()
        {
            InitializeComponent();
            txtIDNhanVien.Enabled=false;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataNhanVien();
        }
        private void LoadDataNhanVien()
        {
            dgvNhanVien.DataSource = db.tblNhanViens.Select(n=>n).ToList();
            dgvNhanVien.Columns["IDNhanVien"].HeaderText="Mã Nhân Viên";
            dgvNhanVien.Columns["TenNhanVien"].HeaderText="Họ Tên";
            dgvNhanVien.Columns["GioiTinh"].HeaderText="Giới Tính";
            dgvNhanVien.Columns["NgaySinh"].HeaderText="Ngày Sinh";
            dgvNhanVien.Columns["DiaChi"].HeaderText="Địa Chỉ";
            ChiDoc();
            HienButton();
        }
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.SelectedRows[0];
            txtIDNhanVien.Text = row.Cells["IDNhanVien"].Value.ToString();
            txtHoTen.Text = row.Cells["TenNhanVien"].Value.ToString();
            DateTime dt;
            DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(),out dt);
            dtpNgaySinh.Value = dt;
            if(row.Cells["GioiTinh"].Value.ToString()=="Nam")   rdbNam.Checked=true;
            else if(row.Cells["NgaySinh"].Value.ToString()=="Nữ")   rdbNu.Checked=true;
            txtDiaChi.Text=row.Cells["DiaChi"].Value.ToString();
        }
        void ChiDoc()
        {
            txtHoTen.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            txtDiaChi.ReadOnly=true;
        }
        void ChoViet()
        {
            txtHoTen.ReadOnly = false;
            dtpNgaySinh.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            txtDiaChi.ReadOnly=false;
        }
        void AnButton()
        {
            btnHuy.Visible = true;
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
            btnHuy.Visible = false;
        }
        void ThemNhanVien()
        {
            tblNhanVien nv=new tblNhanVien();
            if(dgvNhanVien.Rows.Count==0) nv.IDNhanVien=1;
            else nv.IDNhanVien=db.tblNhanViens.Select(n=>n.IDNhanVien).Max()+1;
            nv.TenNhanVien=txtHoTen.Text;
            nv.NgaySinh=dtpNgaySinh.Value;
            if(rdbNam.Checked==true)    nv.GioiTinh="Nam";
            else if(rdbNu.Checked==true)     nv.GioiTinh="Nữ";
            else nv.GioiTinh=null;
            nv.DiaChi=txtDiaChi.Text;
            db.tblNhanViens.Add(nv);
            db.SaveChanges();
        }
        void SuaThongTinNhanVien()
        {
            int id = int.Parse(txtIDNhanVien.Text);
            tblNhanVien nv=db.tblNhanViens.Where(n=>n.IDNhanVien==id).First();
            nv.TenNhanVien=txtHoTen.Text;
            nv.NgaySinh=dtpNgaySinh.Value;
            if(rdbNam.Checked==true)    nv.GioiTinh="Nam";
            else if(rdbNu.Checked==true)     nv.GioiTinh="Nữ";
            else nv.GioiTinh=null;
            nv.DiaChi=txtDiaChi.Text;
            db.SaveChanges();
        }
        void XoaNhanVien()
        {
            int id = int.Parse(txtIDNhanVien.Text);
            tblNhanVien nv=db.tblNhanViens.Where(n=>n.IDNhanVien==id).First();
            db.tblNhanViens.Remove(nv);
            db.SaveChanges();
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dgvNhanVien.Enabled=false;
            lc=LuaChon.Them;
            AnButton();
            ChoViet();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            if (dgvNhanVien.Rows.Count == 0) txtIDNhanVien.Text = "1";
            else txtIDNhanVien.Text = (db.tblNhanViens.Select(n => n.IDNhanVien).Max() + 1).ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên cần sửa");
                return; 
            }
            dgvNhanVien.Enabled = false;
            lc = LuaChon.Sua;
            AnButton();
            ChoViet();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text == "") 
            {
                MessageBox.Show("Chưa chọn nhân viên cần xóa");
                return;
            }
            lc = LuaChon.Xoa;
            AnButton();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text=="")
            {
                MessageBox.Show("Chưa Nhập Tên Nhân Viên");
                return;
            }
            switch (lc)
            {
                case LuaChon.Them:
                    ThemNhanVien();
                    break;
                case LuaChon.Sua:
                    SuaThongTinNhanVien();
                    break;
                case LuaChon.Xoa:
                    XoaNhanVien();
                    break;
            }
            HienButton();
            LoadDataNhanVien();
            dgvNhanVien.Enabled = true;
            txtIDNhanVien.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            rdbNam.Checked=false;
            rdbNu.Checked=false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtIDNhanVien.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            rdbNam.Checked=false;
            rdbNu.Checked=false;
            HienButton();
            dgvNhanVien.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try { dgvNhanVien.DataSource = db.tblNhanViens.Where(n => n.IDNhanVien == int.Parse(txtTimKiem.Text)); }
            catch { LoadDataNhanVien(); }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender,e);
        }

    }
}
