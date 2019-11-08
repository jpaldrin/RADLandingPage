using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace External.RadProApp.ViewModel
{
    public class EmailViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "How can we help you is required.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public List<Email> GetAllEmails { get; set; }

        public List<LandingPage> GetLandingPageData { get; set; }
    }
}