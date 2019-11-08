using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace External.RadProApp.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A first name is required.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "A Sur name or Last name is required.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "A number we can use to text messages to.")]
        public string Telephone { get; set; }

        // Add the Address Info:
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Use a sensible display name for views:
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Radius { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public List<ApplicationUser> GetAllUsersForSearchScreen { get; set; }
    }
}