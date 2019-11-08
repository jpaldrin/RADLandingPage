using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class LinkedInProfile
    {
        public LinkedInProfile()
        {

        }

        [Key]
        public int LinkedInProfileId {get; set;}

        public string EmailAddress { get; set; }
        public static string Fields { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Headline { get; set; }
        public string NumConnections { get; set; }
        public string PictureUrl { get; set; }
        public string PublicProfileUrl { get; set; }
        public string Summary { get; set; }

    }
}
