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
    public partial class Libary_TrangChu : Form
    {
        private BUS_Sach sachBUS;
        private BUS_ChiNhanh chiNhanhBUS;

        // ____________________________________________________________

        private DTO_Sach sachDTO;

        // ____________________________________________________________

        public Libary_TrangChu()
        {
            InitializeComponent();
        }

        // ____________________________________________________________

        // Chọn sách thư viện
        void TabSachThuVienAction()
        {
            // Sách 
            this.sachBUS = new BUS_Sach();
            this.sachDTO = new DTO_Sach();

            this.chiNhanhBUS = new BUS_ChiNhanh();

            // Load toàn bộ danh sách, SÁCH
            DgvSachThuVien.DataSource = sachBUS.getToanBoSach();
        }

        // Chọn đổi mật khẩu 
        void TabDoiMatKhauAction()
        {

        }

        // ____________________________________________________________

        // Load form TrangChu
        private void Libary_TrangChu_Load(object sender, EventArgs e)
        {

        }

        // ____________________________________________________________

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

        // ____________________________________________________________

        // Sách thư viện
    }
}
