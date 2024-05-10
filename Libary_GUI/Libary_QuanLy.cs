using Libary_Manager.Libary_BUS;
using Libary_Manager.Libary_DAO;
using Libary_Manager.Libary_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libary_Manager.Libary_GUI
{
    public partial class Libary_QuanLy : Form
    {
        // Xác nhận đã load dữ liệu Dgv
        private bool valueChangeDgvSach = false;

        // ____________________________________________________________

        private BUS_Sach sachBUS;
        private BUS_ChiNhanh chiNhanhBUS;

        // ____________________________________________________________

        private DTO_Sach sachDTO;
        private DTO_ChiNhanh chiNhanhDTO;

        // ____________________________________________________________

        public Libary_QuanLy()
        {
            InitializeComponent();
        }

        // ____________________________________________________________

        // Chọn quản lý chi nhánh 
        void TabChiNhanhAction()
        {
            // Chí nhánh 
            this.chiNhanhBUS = new BUS_ChiNhanh();
            this.chiNhanhDTO = new DTO_ChiNhanh();

            DgvChiNhanh.DataSource = chiNhanhBUS.getToanBoSach();
        }

        // Chọn quản lý sách sách
        void TabSachThuVienAction()
        {
            // Sách 
            this.sachBUS = new BUS_Sach();
            this.sachDTO = new DTO_Sach();

            this.chiNhanhBUS = new BUS_ChiNhanh();
        }

        // ____________________________________________________________

        private void BtnChiNhanh_Click(object sender, EventArgs e)
        {
            if (Controller.isEmpty(TbChiNhanh.Text) && Controller.isEmpty(TbDiaChi.Text))
            {
                chiNhanhDTO.chiNhanh = TbChiNhanh.Text;
                chiNhanhDTO.diaChi = TbDiaChi.Text;
                chiNhanhDTO.ngayThem = DateTime.Now;

                // Thêm chi nhánh
                if (chiNhanhBUS.insertChiNhanh(chiNhanhDTO))
                {
                    DgvChiNhanh.DataSource = chiNhanhBUS.getToanBoSach();
                }
            }
            else
            {
                Controller.isAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", MessageBoxIcon.Error);
            }
        }

        // ____________________________________________________________

        // Load form tương thích
        private void TcLibaryQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage selectedTabPage = tabControl.SelectedTab;

            if (selectedTabPage == TabChiNhanh)
            {
                TabChiNhanhAction();
            }
        }

        // ____________________________________________________________

        // Chi nhánh

        // Set giá trị hàng click
        private void DgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = DgvChiNhanh.Rows[e.RowIndex];
                object value = row.Cells[0].Value;

                if (value != null)
                {
                    chiNhanhDTO.id = int.Parse(value.ToString());
                }
            }
        }

        // Nhấn delete xóa
        private void DgvChiNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (chiNhanhBUS.deleteChiNhanh(chiNhanhDTO)) { };
            }
        }

        // Chuột phải xóa
        private void DgvChiNhanh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && chiNhanhDTO.id != 0)
                {
                    if (Controller.isQuestion("Xóa chi nhánh Id: " + chiNhanhDTO.id, "Bạn có chắc muốn xóa chi nhánh"))
                    {
                        if (chiNhanhBUS.deleteChiNhanh(chiNhanhDTO))
                        {
                            DgvChiNhanh.DataSource = chiNhanhBUS.getToanBoSach();
                        };
                    }
                }
                else
                {
                    Controller.isAlert("Vui lòng chọn 1 hàng thông tin!", "Lỗi xảy ra", MessageBoxIcon.Error);
                }
            }
        }

        // ____________________________________________________________

        // Sách

        // Chỉnh sửa sách
        private void DgvSachThuVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*if (valueChangeDgvSach)
            {
                sachDTO.tuaSach = TbTuaSach.Text;
                sachDTO.photo = "";
                sachDTO.tacGia = TbTacGia.Text;
                sachDTO.nhaXuatBan = TbNhaXuatBan.Text;
                sachDTO.namXuatBan = TbNamXuatBan.Text;
                sachDTO.maChiNhanh = CbbChiNhanh.Text;
                sachDTO.soLuong = int.Parse(TbSoLuong.Text);
                sachDTO.loiGioiThieu = TbLoiGioiThieu.Text;

                // sachBUS.insertSach(sachDTO);
            }*/
        }

        private void DgvSachThuVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (sachBUS.deleteSach(sachDTO)) { };
            }
        }

        private void DgvSachThuVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && sachDTO.maSach != null)
                {
                    if (Controller.isQuestion("Xóa sách Id: " + sachDTO.id, "Bạn có chắc muốn xóa sách"))
                    {
                        
                    }
                }
                else
                {
                    Controller.isAlert("Vui lòng chọn 1 hàng thông tin!", "Lỗi xảy ra", MessageBoxIcon.Error);
                }
            }
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = Controller.isOpenfile(OfdAnhSach);
            // PtXemAnhTruoc.Image = Image.FromFile(file.FileName);
        }

        // ____________________________________________________________
    }
}
