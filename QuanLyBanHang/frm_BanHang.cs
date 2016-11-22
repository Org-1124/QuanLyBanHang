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
    public partial class frm_BanHang : Form
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        static int total=0;
        static int total_thanhtoan=0;
        public frm_BanHang()
        {
            InitializeComponent();
            LoadComboBox_NhanVien();
            
            Load_dgvHangHoa();
            SetHeaderColumn();
            txtTongTien.Enabled = false;
            txtTongTien.Text = "0";
            ResetAll();
        }
        public void ResetAll()
        {
            txtGia.ResetText();
            txtIDHangHoa.ResetText();
            txtInput.ResetText();
            txtSoluong.ResetText();
            txtSoLuongConLai.ResetText();
            txtTen.ResetText();
            txtTenKhach.ResetText();
            txtTongTien.Text = "0";
        }
        public void LoadComboBox_NhanVien()
        {
            //cbNhanVien.DataSource = null;
           var i =  (from p in db.tblNhanViens select new { p.DiaChi,p.GioiTinh,p.IDNhanVien,p.NgaySinh,p.TenNhanVien} ).ToList();
            cbNhanVien.DataSource = i;
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "IDNhanVien";
        }    
        public void SetHeaderColumn()
        {
            dgvHangHoa.Columns["IDHangHoa"].HeaderText = "Mã hàng hóa";
            dgvHangHoa.Columns["TenHang"].HeaderText = "Tên mặt hàng";
            dgvHangHoa.Columns["SoLuongCon"].HeaderText = "Còn lại";
            dgvHangHoa.Columns["DonGia"].HeaderText = "Đơn giá";
        }

        public void Load_dgvHangHoa()
        {
       
         
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                dgvHangHoa.DataSource = (from p in db.tblHangHoas.Where(x => x.TenHang.Contains(txtInput.Text))
                                         select new {  p.IDHangHoa, p.TenHang, p.SoLuongCon, p.DonGia }).ToList();//HangHoa.Where(x => x.IDHangHoa ==  || x.TenHang.Contains(searchString)).ToList();
            }
            else
            {
                var i = (from p in db.tblHangHoas select new { p.IDHangHoa, p.TenHang, p.SoLuongCon, p.DonGia }).ToList();
                dgvHangHoa.DataSource = i;
            }
          
        }
        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHangHoa.SelectedRows[0];
            txtIDHangHoa.Text = dr.Cells["IDHangHoa"].Value.ToString();
            txtSoLuongConLai.Text = dr.Cells["SoLuongCon"].Value.ToString();
            txtGia.Text = dr.Cells["DonGia"].Value.ToString();
            txtTen.Text = dr.Cells["TenHang"].Value.ToString();
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Load_dgvHangHoa();
        }
        static int G_ID;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if(DialogResult.Yes== MessageBox.Show("Bạn chắc không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
          //  {
                if(!string.IsNullOrEmpty(txtSoluong.Text) && !string.IsNullOrEmpty(txtTenKhach.Text))
                {
                    DataGridViewRow dr = dgvHangHoa.SelectedRows[0];
                // sinh IDHoaDon -> add vao
                tblHoaDon hd = new tblHoaDon();
                tblKhachHang kh = new tblKhachHang();
                for ( int i=1; i>0; i++)
                {
                    if(db.tblHoaDons.SingleOrDefault(x=>x.IDHoaDon ==i) == null)
                    {
                        hd.IDHoaDon = i;
                      
                        break;
                    }
                }
                if(lvHangHoa.Items.Count ==0)
                {
                    for (int i = 1; i > 0; i++)
                    {
                        if (db.tblKhachHangs.SingleOrDefault(x => x.IDKhachHang == i) == null)
                        {
                            hd.IDKhachHang = i;
                            G_ID = i;
                            break;
                        }
                    }
                }
                else { hd.IDKhachHang = G_ID; }
                total += int.Parse(dr.Cells["DonGia"].Value.ToString()) * int.Parse(txtSoluong.Text);
                    ListViewItem item = new ListViewItem(dr.Cells["TenHang"].Value.ToString());
                    item.SubItems.Add(txtSoluong.Text);
                    item.SubItems.Add(total.ToString());
                    item.SubItems.Add((hd.IDHoaDon).ToString());
                    item.SubItems.Add((hd.IDKhachHang).ToString());
                    lvHangHoa.Items.Add(item);
                    total = 0;

                // them vao trong tblHoaDon
                // sinh ra IDkhachhang
                hd.IDHangHoa = int.Parse(txtIDHangHoa.Text);
                hd.DonGia = int.Parse(txtGia.Text);
                hd.IDNhanVien = (int)cbNhanVien.SelectedValue;
                hd.ThoiGian = DateTime.Now.Date;
                hd.SoLuong = int.Parse(txtSoluong.Text);
                if(db.tblKhachHangs.SingleOrDefault(x=>x.IDKhachHang == G_ID) == null)
                {
                 //   kh.IDKhachHang = hd.IDKhachHang;
                    kh.DiaChi = "";
                    kh.DienThoai = "";
                    kh.TenKhachHang = txtTenKhach.Text;
                    db.tblKhachHangs.Add(kh);
                    db.SaveChanges();
                }
               
                 db.tblHoaDons.Add(hd);
                    db.SaveChanges();

                txtTongTien.Text = (int.Parse(txtTongTien.Text) + int.Parse(item.SubItems[2].Text)).ToString();
                }
                else
                {
                if( string.IsNullOrEmpty(txtSoluong.Text)==true && string.IsNullOrEmpty(txtTenKhach.Text)==true)
                {
                    MessageBox.Show("Tên khách và số lượng không bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtSoluong.Text))
                        MessageBox.Show("Nhập vào số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (string.IsNullOrEmpty(txtTenKhach.Text))
                        MessageBox.Show("Nhập vào tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            // }
           
        }

        private void btnTraLai_Click(object sender, EventArgs e)
        {
            foreach ( ListViewItem item in lvHangHoa.Items)
            {
                if(item.Selected == true)
                {
                    lvHangHoa.Items.Remove(item);
                    var k = db.tblHoaDons.Find(int.Parse(item.SubItems[3].Text));
                    db.tblHoaDons.Remove(k);
                    db.SaveChanges();
                    txtTongTien.Text = (int.Parse(txtTongTien.Text) - int.Parse(item.SubItems[2].Text)).ToString();
                }
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            total_thanhtoan = 0;
            foreach (ListViewItem item in lvHangHoa.Items)
            {
                //2
                total_thanhtoan += int.Parse(item.SubItems[2].Text);
            }
            txtTongTien.Text = total_thanhtoan.ToString();

                
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHangHoa.Items)
            {
                lvHangHoa.Items.Remove(item);
            }
            txtTongTien.Text = "0";
        }        
    }
}
