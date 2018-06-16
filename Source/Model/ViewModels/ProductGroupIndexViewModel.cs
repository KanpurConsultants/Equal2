using System.ComponentModel.DataAnnotations;

// New namespace imports:
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Model.Models;
using System;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Model.ViewModel;

namespace Model.ViewModels
{
    public class ProductGroupIndexViewModel
    {
        [Key]
        [Display(Name = "ProductGroup Id")]
        public int ProductGroupId { get; set; }


        [MaxLength(50), Required]
        [Display(Name = "ProductGroup Name")]
        public string ProductGroupName { get; set; }

        [Display(Name = "Is System Define ?")]
        public Boolean IsSystemDefine { get; set; }

        [Display(Name = "Is Active ?")]
        public Boolean IsActive { get; set; }

        [Display(Name = "ProductType Name")]
        public string ProductTypeName { get; set; }


    }

}
