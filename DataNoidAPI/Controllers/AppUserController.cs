using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DataNoidAPI.Data;
using DataNoidAPI.Helpers;
using DataNoidAPI.Models;

namespace DataNoidAPI.Controllers
{
    public class AppUserController : ApiController
    {
        private readonly DataNoidAPIContext db;
        private readonly Helper help;
        public AppUserController()
        {
            db = new DataNoidAPIContext();
            help = new Helper();
        }


        // GET: api/AppUser
        public IEnumerable<AppUser> GetAppUsers()
        {
            help.SetAllAddress(db.AppUsers);
            return db.AppUsers;
        }
        //public IQueryable<AppUser> GetAppUsers()
        //{
        //    return db.AppUsers;
        //}

        // GET: api/AppUser/5
        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> GetAppUser(int id)
        {
            AppUser appUser = await db.AppUsers.FindAsync(id);
            if (appUser == null) return NotFound();
            help.SetAddressById(appUser);
            return Ok(appUser);
        }

        // PUT: api/AppUser/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppUser(int id, AppUser appUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != appUser.AppUserId) return BadRequest();
            if (help.IsPhoneDuplicate(appUser)) return BadRequest("Duplicate Property");
            db.Entry(appUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))return NotFound();
                else throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppUser
        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> PostAppUser(AppUser appUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (help.IsPhoneDuplicate(appUser)) return BadRequest("Duplicate Property");
            db.AppUsers.Add(appUser);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appUser.AppUserId }, appUser);
        }

        // DELETE: api/AppUser/5
        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> DeleteAppUser(int id)
        {
            AppUser appUser = await db.AppUsers.FindAsync(id);
            if (appUser == null) return NotFound();

            db.AppUsers.Remove(appUser);
            await db.SaveChangesAsync();

            return Ok(appUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }

        private bool AppUserExists(int id) => db.AppUsers.Count(e => e.AppUserId == id) > 0;
    }
}