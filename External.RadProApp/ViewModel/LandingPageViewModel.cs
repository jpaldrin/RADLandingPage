using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace External.RadProApp.ViewModel
{
    public class LandingPageViewModel
    {
        public int LandingPageId { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsCenterParagraph { get; set; }

        public string AboutUsOverview { get; set; }

        public string AboutUsIconTitleOneSectionOne { get; set; }
        public string AboutUsIconTItleTwoSectionOne { get; set; }

        public string AboutUsIconTitleThreeSectionOne { get; set; }

        //Image Upload for AboutUsSEctionOne

        public string AboutUsIconTitleOneSectionTwo { get; set; }
        public string AboutUsIconTItleTwoSectionTwo { get; set; }

        public string AboutUsIconTitleThreeSectionTwo { get; set; }

        //Image Upload for AboutUsSectionTwo
        public string AboutUsIconTitleOneSectionThree { get; set; }
        public string AboutUsIconTItleTwoSectionThree { get; set; }

        public string AboutUsIconTitleThreeSectionThree { get; set; }
        //Image Upload for AboutUsSectionThree

        public string ServicesTitle { get; set; }
        public string ServicesSubTitle { get; set; }

        public string ServicesCardTitleONE { get; set; }
        public string ServicesCardTextONE { get; set; }

        public string ServicesCardTitleTWO { get; set; }
        public string ServicesCardTextTWO { get; set; }

        public string ServicesCardTitleTHREE { get; set; }
        public string ServicesCardTextTHREE { get; set; }

        public string ServicesCardTitleFOUR { get; set; }
        public string ServicesCardTextFOUR { get; set; }

        public string ServicesCardTitleFIVE { get; set; }
        public string ServicesCardTextFIVE { get; set; }

        public string ServicesCardTitleSIX { get; set; }
        public string ServicesCardTextSIX { get; set; }
        // Why choose us.
        public string WhyChooseUsTitle { get; set; }
        public string WhyChooseUsSubTitle { get; set; }

        public string WhyChooseUsBOXTitleOne { get; set; }
        public string WhyChooseUsBoxTextOne { get; set; }

        public string WhyChooseUsBOXTitleTwo { get; set; }
        public string WhyChooseUsBoxTextTwo { get; set; }

        public string WhyChooseUsBOXTitleThree { get; set; }
        public string WhyChooseUsBoxTextThree { get; set; }

        //Set Image from image list.

        // Blog pushed testimonials

        public string TeamSubTitleText { get; set; }

        public string OurClientsSubTitleText { get; set; }

        public string ContactUsAddress { get; set; }
        public string ContactUsEmail { get; set; }
        public string ContactUsTelephone { get; set; }

        public List<LandingPage> GetAllContentForLandingPage { get; set; }
    }
}