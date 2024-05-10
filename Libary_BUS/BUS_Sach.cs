using Libary_Manager.Libary_DAO;
using Libary_Manager.Libary_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libary_Manager.Libary_BUS
{
    class BUS_Sach
    {
        private DAO_Sach sachDAO;

        public BUS_Sach()
        {
            this.sachDAO = new DAO_Sach();
        }

        public DataTable getToanBoSach()
        {
            return sachDAO.readSach();
        }

        public string createMaSach()
        {
            try
            {
                DataTable data = sachDAO.createMaSach();
                if (data.Rows.Count != 0)
                {
                    string maSach = data.Rows[0][0].ToString();
                    int numberMaSach = int.Parse(maSach.Substring(4)) + 1;
                    return "SDTA" + numberMaSach;
                } else
                {
                    return "SDTA0";
                }
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể tạo mới sách: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxIcon.Error);
                return "SDTA0";
            };
        }

        public bool deleteSach(DTO_Sach sachDTO)
        {
            try
            {
                sachDAO.deleteSach(sachDTO); return true;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể xóa sách: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            };
        }

        public bool insertSach(DTO_Sach sachDTO)
        {
            try
            {
                sachDAO.insertSach(sachDTO);
                return true;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể thêm sách!", ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            };
        }

        public bool updateSach(DTO_Sach sachDTO)
        {
            try
            {
                sachDAO.updateSach(sachDTO);
                return true;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể chỉnh sửa sách!", ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            };
        }


        public string prepareDeletePhoto(DTO_Sach sachDTO)
        {
            try
            {
                string path = Controller._PATH_PHOTO_BOOK + sachDAO.getInfoBasedMaSach(sachDTO);
                return path;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể chỉnh sửa sách!", ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            };
        }    
    }
}
