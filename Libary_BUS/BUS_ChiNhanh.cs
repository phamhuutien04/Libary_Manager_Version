﻿using Libary_Manager.Libary_DAO;
using Libary_Manager.Libary_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libary_Manager.Libary_BUS
{
    class BUS_ChiNhanh
    {
        private DAO_ChiNhanh chiNhanhDAO;

        public BUS_ChiNhanh()
        {
            this.chiNhanhDAO = new DAO_ChiNhanh();
        }

        public DataTable getToanBoSach()
        {
            return chiNhanhDAO.readChiNhanh();
        }

        public bool insertChiNhanh(DTO_ChiNhanh chiNhanhDTO)
        {
            try
            {
                chiNhanhDAO.insertChiNhanh(chiNhanhDTO); return true;
            }
            catch (Exception ex) 
            {
                Controller.isAlert("Không thể thêm chi nhánh: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            };
        }

        public bool deleteChiNhanh(DTO_ChiNhanh chiNhanhDTO)
        {
            try
            {
                chiNhanhDAO.deleteChiNhanh(chiNhanhDTO); return true;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể xóa chi nhánh: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            };
        }

        public int getMaChiNhanh(string chiNhanh)
        {
            try
            {
                DataTable data = chiNhanhDAO.getMaChiNhanh(chiNhanh);
                string maChiNhanh = data.Rows[0][0].ToString();
                int numberMaChiNhanh = int.Parse(maChiNhanh);
                return numberMaChiNhanh;
            }
            catch (Exception ex)
            {
                Controller.isAlert("Không thể thêm mới sách: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            };

        }
    }
}
