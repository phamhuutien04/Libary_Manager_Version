using Libary_Manager.Libary_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libary_Manager.Libary_DAO
{
    class DAO_Sach
    {
        public DataTable readSach()
        {
            string sql = "SELECT maSach, tuaSach, photo, tacGia, nhaXuatBan, namXuatBan, " +
                "TRIM(cn.chiNhanh) as chiNhanh, loiGioiThieu, soLuong, TV_Sach.ngayThem " +
                "FROM TV_ChiNhanh cn " +
                "INNER JOIN TV_Sach ON TV_Sach.maChiNhanh = cn.id ORDER BY TV_Sach.id DESC";
            return Database.read(sql);
        }

        public DataTable createMaSach()
        {
            string sql = "SELECT TOP 1 maSach FROM TV_Sach ORDER BY id DESC";
            return Database.read(sql);
        }

        public bool deleteSach(DTO_Sach sachDTO)
        {
            try
            {
                string condition = "maSach = '" + sachDTO.maSach + "'";
                Database.delete("TV_Sach", condition); return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi databse " + ex.Message, "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool insertSach(DTO_Sach sachDTO)
        {
            try
            {
                var data = new Dictionary<string, object>()
                {
                    { "maSach", sachDTO.maSach },
                    { "tuaSach", sachDTO.tuaSach },
                    { "tacGia", sachDTO.tacGia },
                    { "nhaXuatBan", sachDTO.nhaXuatBan },
                    { "namXuatBan", sachDTO.namXuatBan },
                    { "maChiNhanh", sachDTO.maChiNhanh },
                    { "loiGioiThieu", sachDTO.loiGioiThieu },
                    { "soLuong", sachDTO.soLuong },
                    { "photo", sachDTO.photo },
                    { "ngayThem", sachDTO.ngayThem },
                };
                Database.insert("TV_Sach", data); return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi databse " + ex.Message, "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool updateSach(DTO_Sach sachDTO)
        {
            try
            {
                var data = new Dictionary<string, object>()
                {
                    { "tuaSach", sachDTO.tuaSach },
                    { "tacGia", sachDTO.tacGia },
                    { "nhaXuatBan", sachDTO.nhaXuatBan },
                    { "namXuatBan", sachDTO.namXuatBan },
                    { "maChiNhanh", sachDTO.maChiNhanh },
                    { "loiGioiThieu", sachDTO.loiGioiThieu },
                    { "soLuong", sachDTO.soLuong },
                };

                string condition = " maSach = '" + sachDTO.maSach +"'";
                Database.update("TV_Sach", data, condition); return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi databse " + ex.Message, "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
