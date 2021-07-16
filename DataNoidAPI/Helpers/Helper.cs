using DataNoidAPI.Data;
using DataNoidAPI.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataNoidAPI.Helpers
{
    public class Helper
    {
        private readonly DataNoidAPIContext db;

        public Helper()
        {
            db = new DataNoidAPIContext();
        }

        internal void SetAllAddress(DbSet<AppUser> appUser)
        {
            foreach (var item in appUser)
            {
                item.Addresses = db.Addresses.Where(d => d.AppUserId == item.AppUserId).ToList();
            }
        }

        internal void SetAddressById(AppUser appUser)
        {
            appUser.Addresses = db.Addresses.Where(d => d.AppUserId == appUser.AppUserId).ToList();
        }

        internal bool IsPhoneDuplicate(AppUser appUser)
        {
            bool isDuplicate = db.AppUsers
                .Where(d => d.Phone == appUser.Phone && d.AppUserId != appUser.AppUserId)
                .ToList()
                .Count > 1;
            return isDuplicate;
        }
    }
}