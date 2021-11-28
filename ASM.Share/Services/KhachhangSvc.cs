using ASM.Share.Helpers;
//using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Share.Models
{
    public interface IKhachhangSvc
    {
        List<Khachhang> GetKhachhangAll();

        Khachhang GetKhachhang(int id);
        Task<Khachhang> GetKhachhangAsync(int id);
        Khachhang GetKhachhang(string email);

        int AddKhachhang(Khachhang khachhang);

        int EditKhachhang(int id, Khachhang khachhang);

        //Task<Khachhang> LoginAsync(ViewWebLogin viewWebLogin);
        Task<int> AddKhachhangAsync(Khachhang khachhang);

        Khachhang Login(ViewWebLogin viewWebLogin);
        Khachhang LoginAsync(ViewWebLogin viewWebLogin);
    }
    public class KhachhangSvc : IKhachhangSvc
    {
        protected DataContext _context;
        protected IMahoaHelper _mahoaHelper;
        public KhachhangSvc(DataContext context, IMahoaHelper mahoaHelper)
        {
            _context = context;
            _mahoaHelper = mahoaHelper;
        }

        public List<Khachhang> GetKhachhangAll()
        {
            List<Khachhang> list = new List<Khachhang>();
            list = _context.Khachhangs.ToList();
            return list;
        }
        public Khachhang GetKhachhang(int id)
        {
            Khachhang khachhang = null;
            khachhang = _context.Khachhangs.Find(id); //cách này chỉ dùng cho Khóa chính
            //product = _context.Products.Where(e=>e.Id==id).FirstOrDefault(); //cách tổng quát
            return khachhang;
        }
        public async Task<Khachhang> GetKhachhangAsync(int id)
        {
            Khachhang khachhang = null;
            khachhang = await _context.Khachhangs.FindAsync(id);
            return khachhang;
        }

        public Khachhang GetKhachhang(string email)
        {
            Khachhang khachhang = null;
            //khachhang = _context.Khachhangs.Find(id); //cách này chỉ dùng cho Khóa chính
            khachhang = _context.Khachhangs.Where(e => e.EmailAddress == email).FirstOrDefault(); //cách tổng quát
            return khachhang;
        }

        public int AddKhachhang(Khachhang khachhang)
        {
            int ret = 0;
            try
            {
                khachhang.Password = _mahoaHelper.Mahoa(khachhang.Password);
                khachhang.ConfirmPassword = khachhang.Password;

                _context.Add(khachhang);
                _context.SaveChanges();
                ret = khachhang.KhachhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public async Task<int> AddKhachhangAsync(Khachhang khachhang)
        {
            int ret = 0;
            try
            {
                khachhang.Password = _mahoaHelper.Mahoa(khachhang.Password);
                khachhang.ConfirmPassword = khachhang.Password;

                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                ret = khachhang.KhachhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditKhachhang(int id, Khachhang khachhang)
        {
            int ret = 0;
            try
            {
                Khachhang _khachhang = null;
                _khachhang = _context.Khachhangs.Find(id); //cách này chỉ dùng cho Khóa chính

                _khachhang.FullName = khachhang.FullName;
                _khachhang.Ngaysinh = khachhang.Ngaysinh;
                _khachhang.PhoneNumber = khachhang.PhoneNumber;
                _khachhang.EmailAddress = khachhang.EmailAddress;
                if (_khachhang.Password != null)
                {
                    khachhang.Password = _mahoaHelper.Mahoa(khachhang.Password);
                    _khachhang.Password = khachhang.Password;
                    _khachhang.ConfirmPassword = khachhang.Password;
                }
                //_khachhang.Password = khachhang.Password;
                _khachhang.Mota = khachhang.Mota;

                _context.Update(_khachhang);
                _context.SaveChanges();
                ret = _khachhang.KhachhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        //public async Task<Khachhang> LoginAsync(ViewWebLogin viewWebLogin)
        //{
        //    var u = await _context.Khachhangs.Where(
        //        p => p.EmailAddress.Equals(viewWebLogin.Email)
        //        && p.Password.Equals(_mahoaHelper.Mahoa(viewWebLogin.Password))
        //       ).FirstOrDefaultAsync();
        //    return u;
        //}

        public Khachhang Login(ViewWebLogin viewWebLogin)
        {
            var u = _context.Khachhangs.Where(
                p => p.EmailAddress.Equals(viewWebLogin.Email)
                && p.Password.Equals(_mahoaHelper.Mahoa(viewWebLogin.Password))
               ).FirstOrDefault();
            return u;
        }
        public Khachhang LoginAsync(ViewWebLogin viewWebLogin)
        {
            return _context.Khachhangs.
                AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault(x => x.Password == _mahoaHelper.Mahoa(viewWebLogin.Password) && x.EmailAddress == viewWebLogin.Email);

        }
    }

}
