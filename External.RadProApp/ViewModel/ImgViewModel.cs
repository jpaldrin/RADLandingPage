using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace External.RadProApp.ViewModel
{
    public class ImgViewModel
    {
        #region Properties  

        /// <summary>  
        /// Gets or sets Image file.  
        /// </summary>  
        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase FileAttach { get; set; }

        /// <summary>  
        /// Gets or sets Image file list.  
        /// </summary>  
        public List<ImgObj> ImgLst { get; set; }

        #endregion
    }
}