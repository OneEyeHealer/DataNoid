using DataNoidAPI.Models;
using System.Data.Entity;

namespace DataNoidAPI.Data
{
    public class DataNoidAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataNoidAPIContext() : base("name=DataNoidAPIContext")
        {
        }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }

        public System.Data.Entity.DbSet<DataNoidAPI.Models.Address> Addresses { get; set; }
    }
}
