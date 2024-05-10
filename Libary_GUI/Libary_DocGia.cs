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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Libary_Manager
{
    public partial class Libary_DocGia : Form
    {
        int _PAGE = 1;

        private BUS_Sach sachBUS;

        // ................................................

        private DTO_Sach sachDTO;

        // ................................................

        public Libary_DocGia()
        {
            InitializeComponent();
        }

        // ................................................

        // Chọn sách thư viện
        void TabSachThuVienAction()
        {
            this.sachBUS = new BUS_Sach();
            this.sachDTO = new DTO_Sach();

            // Load toàn bộ danh sách Sách
            DataTable data = sachBUS.dataPagination(_PAGE);
            Controller.isLoadData(data, DgvSachThuVien);
        }

        // Chọn đổi mật khẩu 
        void TabDoiMatKhauAction()
        {

        }

        // ................................................

        // Load form TrangChu
        private void Libary_TrangChu_Load(object sender, EventArgs e)
        {
            TabChiTietSach.Parent = null;
        }

        // ................................................

        // Load form tương thích
        private void TcLibary_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage selectedTabPage = tabControl.SelectedTab;

            if (selectedTabPage == TabSachThuVien)
            {
                TabSachThuVienAction();
            }

            else if (selectedTabPage == TabDoiMatKhau)
            {
                TabDoiMatKhauAction();
            }
        }

        private void DgvSachThuVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = DgvSachThuVien.Columns[e.ColumnIndex];
                DataGridViewRow row = DgvSachThuVien.Rows[e.RowIndex];

                // TabChiTietSach.Parent = TcLibary;
                TcLibary.SelectedIndex = TcLibary.TabPages.IndexOf(TabChiTietSach);
            }
        }

        private void BtnTiepTuc_Click(object sender, EventArgs e)
        {
            if (_PAGE < BUS_Sach._TOTAL_BOOK)
            {
                _PAGE += 1;
            }    
            else
            {
                _PAGE = BUS_Sach._TOTAL_BOOK;
            }
            // Load toàn bộ danh sách Sách
            DataTable data = sachBUS.dataPagination(_PAGE);
            Controller.isLoadData(data, DgvSachThuVien);
        }

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            if (_PAGE < 1)
            {
                _PAGE -= 1;
            }
            else
            {
                _PAGE = 1;
            }
            // Load toàn bộ danh sách Sách
            DataTable data = sachBUS.dataPagination(_PAGE);
            Controller.isLoadData(data, DgvSachThuVien);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }




        // ................................................

        // Sách thư viện
    }
}
