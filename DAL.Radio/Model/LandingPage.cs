using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class LandingPage
    {
        public LandingPage()
        {
            ImgObjs = new HashSet<ImgObj>();
        }

        [Key]
        public int LandingPageId { get; set; }
        public string One { get; set; }
        public string Two { get; set; }

        public string Three { get; set; }

        public string Four { get; set; }
        public string Five { get; set; }

        public string Six { get; set; }

        //Image Upload for AboutUsSEctionOne

        public string Seven { get; set; }
        public string Eight { get; set; }

        public string Nine { get; set; }

        //Image Upload for AboutUsSectionTwo
        public string Ten { get; set; }
        public string Eleven { get; set; }

        public string Tweleve { get; set; }
        //Image Upload for AboutUsSectionThree

        public string Thirteen { get; set; }
        public string Fourteen { get; set; }

        public string Fifteen { get; set; }
        public string Seventeen { get; set; }

        public string Eighteen { get; set; }
        public string Nineteen { get; set; }

        public string Twenty { get; set; }
        public string TwentyOne { get; set; }

        public string TwentyTwo { get; set; }
        public string TwentyThree { get; set; }

        public string TwentyFour { get; set; }
        public string TwentyFive { get; set; }

        public string TwentySIx { get; set; }
        public string TwentySeven { get; set; }
        // Why choose us.
        public string TwentyEight { get; set; }
        public string TwentyNine { get; set; }

        public string Thirty { get; set; }
        public string ThirtyOne { get; set; }

        public string ThirtyTwo { get; set; }
        public string ThirtyThree { get; set; }

        public string ThirtyFour { get; set; }
        public string ThirtyFive { get; set; }

        //Set Image from image list.

        // Blog pushed testimonials

        public string ThirtySix { get; set; }

        public string ThirtySeven { get; set; }

        public string ThirtyEight { get; set; }
        public string ThirtyNine { get; set; }
        public string Fourty { get; set; }

        public string FourtyOne { get; set; }

        public string fourtyTwo { get; set; }

        public string FourtyThree { get; set; }

        public string FourtyFour { get; set; }

        //Inherit images for landing page.
        public virtual ICollection<ImgObj> ImgObjs { get; set; }
    }
}
