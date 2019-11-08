using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.DropDownHelpers
{
    public class AssignUserToSiteHelper
    {
        public static IEnumerable<SelectListItem> GetJudicialCourt()
        {
            IList<SelectListItem> court = new List<SelectListItem>
            {
                 new SelectListItem() { Text="American Tower Contractor", Value="American Tower"},
                new SelectListItem() { Text="VersaCom Contractor", Value="VersaComm"}
            };
            return court;
        }
    }
}