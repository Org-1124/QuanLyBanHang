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
    public partial class frmMain : Form
    {
        TabPage tab;
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmNhanVien frm = new frmNhanVien();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí nhân viên           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmHangHoa frm = new frmHangHoa();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí hàng hóa           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmKhachHang frm = new frmKhachHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí khách hàng           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frm_BanHang frm = new frm_BanHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí bán hàng           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí tài khoản           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }
    }
}
