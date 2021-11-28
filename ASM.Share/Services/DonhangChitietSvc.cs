using ASM.Share.Helpers;
//using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ASM.Share.Models
{
    public interface IDonhangChitietSvc
    {
        int AddDonhangChitietSvc(DonhangChitiet donhangChitiet);
    }

    public class DonhangChitietSvc : IDonhangChitietSvc
    {
        protected DataContext _context;

        public DonhangChitietSvc(DataContext context)
        {
            _context = context;
        }
        public int AddDonhangChitietSvc(DonhangChitiet donhangChitiet)
        {
            int ret = 0;
            try
            {
                _context.Add(donhangChitiet);
                _context.SaveChanges();
                ret = donhangChitiet.ChitietID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

    }
}
