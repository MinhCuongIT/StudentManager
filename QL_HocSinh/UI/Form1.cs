using QL_HocSinh.BUS;
using QL_HocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HocSinh
{
    public partial class Form1 : Form
    {
        HocSinhBUS hocSinhBUS = new HocSinhBUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgvHocSinh.DataSource = hocSinhBUS.LoadData().Tables[0].DefaultView;
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 || e.ColumnIndex > 0)
            {
                this.dgvHocSinh.Rows[e.RowIndex].Selected = true;
                this.txtMaHocSinh.Text = this.dgvHocSinh.Rows[e.RowIndex].Cells["MaHS"].Value.ToString();
                this.txtTenHocSinh.Text = this.dgvHocSinh.Rows[e.RowIndex].Cells["TenHS"].Value.ToString();
                this.txtDiaChi.Text = this.dgvHocSinh.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnThemHocSinh_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh() { TenHS = this.txtTenHocSinh.Text, DiaChi = this.txtDiaChi.Text, MaHS = this.txtMaHocSinh.Text };
            if (hocSinhBUS.Insert(hs))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllTextbox();
                this.dgvHocSinh.DataSource = hocSinhBUS.LoadData().Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaHocSinh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HocSinh hs = new HocSinh() { TenHS = this.txtTenHocSinh.Text, DiaChi = this.txtDiaChi.Text, MaHS = this.txtMaHocSinh.Text };
                if (hocSinhBUS.Delete(hs))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllTextbox();
                    this.dgvHocSinh.DataSource = hocSinhBUS.LoadData().Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh() { TenHS = this.txtTenHocSinh.Text, DiaChi = this.txtDiaChi.Text, MaHS = this.txtMaHocSinh.Text };
            if (hocSinhBUS.Update(hs))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllTextbox();
                this.dgvHocSinh.DataSource = hocSinhBUS.LoadData().Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllTextbox()
        {
            this.txtTenHocSinh.Clear();
            this.txtMaHocSinh.Clear();
            this.txtDiaChi.Clear();
        }
    }
}
