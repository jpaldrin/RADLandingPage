using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class ISOStandardsLocation
    {
        //public string UrlWikiPage { get; set; }

        public string LocationName { get; set; }
        public string Year { get; set; }
        public string ccTLD { get; set; }

        public string ISO3166_2 { get; set; }
    }
}
