using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace External.RadProApp.Models
{
    public class ApplicationUserRole : IdentityUserRole<string> { }
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Use a sensible display name for views:
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public byte[] ImageData { get; set; }
        public string AcceptTerms { get; set; }

        public string IpAddress { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImageMimeType { get; set; }
        public string Radius { get; set; }

        public string DisplayCommonName
        {
            get
            {
                string dspFName =
                string.IsNullOrWhiteSpace(this.FName) ? "" : this.FName;
                string dspLName =
                string.IsNullOrWhiteSpace(this.LName) ? "" : this.LName;

                return string
                .Format("{0}, {1}", dspFName, dspLName);
            }
        }
    }

    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        // Add any custom Role properties/code here
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
     
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}