using QL_HocSinh.DAO;
using QL_HocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HocSinh.BUS
{
    public class HocSinhBUS
    {
        HocSinhDAO hocSinhDAO = new HocSinhDAO();

        public DataSet LoadData()
        {
            return hocSinhDAO.LoadData();
        }
        public bool Insert(HocSinh hocSinh)
        {
            if (string.IsNullOrEmpty(hocSinh.MaHS) || string.IsNullOrEmpty(hocSinh.TenHS) || string.IsNullOrEmpty(hocSinh.DiaChi))
            {
                return false;
            }
            if (hocSinhDAO.IsExisted(hocSinh.MaHS))
            {
                return false;
            }
            return hocSinhDAO.Insert(hocSinh);
        }
        public bool Update(HocSinh hocSinh)
        {
            if (string.IsNullOrEmpty(hocSinh.MaHS) || string.IsNullOrEmpty(hocSinh.TenHS) || string.IsNullOrEmpty(hocSinh.DiaChi))
            {
                return false;
            }
            if (!hocSinhDAO.IsExisted(hocSinh.MaHS))
            {
                return false;
            }
            return hocSinhDAO.Update(hocSinh);
        }
        public bool Delete(HocSinh hocSinh)
        {
            if (string.IsNullOrEmpty(hocSinh.MaHS) || string.IsNullOrEmpty(hocSinh.TenHS) || string.IsNullOrEmpty(hocSinh.DiaChi))
            {
                return false;
            }
            if (!hocSinhDAO.IsExisted(hocSinh.MaHS))
            {
                return false;
            }
            return hocSinhDAO.Delete(hocSinh);
        }
    }
}
