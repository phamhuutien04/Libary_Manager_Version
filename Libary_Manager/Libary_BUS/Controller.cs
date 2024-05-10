using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using System.Drawing;
using Guna.UI2.WinForms;
using System.Xml.Linq;

namespace Libary_Manager.Libary_BUS
{
    class Controller
    {
        private static string _Path_Folder_Book = @"C:\Users\Duc\source\repos\Libary_Manager\Photos\Books";


        // Kiểm tra giá trị có rỗng không 
        public static bool isEmpty(string value)
        {
            return (value.Trim() != "");
        }


        // kiểm tra độ dài có đủ
        public static bool isLength(string value, int length)
        {
            return value.Trim().Length > length;
        }


        // Alert thông báo 
        public static void isAlert(string title, string content, MessageBoxIcon name)
        {
            MessageBox.Show(title, content,
            MessageBoxButtons.OK, name);
        }


        // Đặt câu hỏi cho người dùng
        public static bool isQuestion(string content, string title)
        {
            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return (result == DialogResult.Yes);
        }


        // Hiển thị việc chọn file cho người dùng
        public static OpenFileDialog isOpenfile(OpenFileDialog file, string type = "path")
        {
            if (file.ShowDialog() == DialogResult.OK)
            {
                return file;
            }
            return null;
        }


        // Kiểm tra dữ liệu trống sll
        public static bool isAllEmpty(params string[] values)
        {
            foreach (var value in values)
            {
                if (!isEmpty(value)) 
                    return false; 
            }
            return true; 
        }


        // Kiểm tra tên file tải lên 
        public static bool isExistsName(string pathImage)
        {
            if (File.Exists(pathImage))
            {
                MessageBox.Show("Tên ảnh đã tồn tại vui lòng đổi tên khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        // Lưu file vào folder  
        public static string isSavedFile(string fileName, string type)
        {
            try
            {
                string fileNameNew;
                string destinationPath;

                if (type == "book")
                {
                    fileNameNew = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(fileName);
                    destinationPath = Path.Combine(_Path_Folder_Book, fileNameNew);
                    File.Copy(fileName, destinationPath, true);
                    return destinationPath;
                }   
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                isAlert("Lỗi không thể lưu!", ex.Message, MessageBoxIcon.Error);
                return null;
            }
        }


        // Load dữ liệu 
        public static void isPhotoLoad(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = dataGridView.Rows.Add();
                for (int columnIndex = 0; columnIndex < dataGridView.Columns.Count; columnIndex++)
                {
                    string columnName = dataGridView.Columns[columnIndex].Name;
                    if (dataTable.Columns.Contains(columnName))
                    {
                        object cellValue = row[columnName];
                        if (columnName == "photo")
                        {
                            if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                            {
                                string imagePath = cellValue.ToString();
                                if (File.Exists(imagePath))
                                {
                                    System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath);
                                    dataGridView.Rows[rowIndex].Cells[columnIndex].Value = img;
                                }
                            }
                        }
                        else
                        {
                            dataGridView.Rows[rowIndex].Cells[columnIndex].Value = cellValue;
                        }
                    }
                }
            }
        }


        // Reset dữ liệu 
        public static void isResetTb(params Guna2TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

    }
}
