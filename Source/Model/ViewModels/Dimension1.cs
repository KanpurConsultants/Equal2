﻿using System.ComponentModel.DataAnnotations;

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
    public class Dimension1ViewModel : EntityBase
    {
        public Dimension1ViewModel()
        {
        }

        [Key]
        public int Dimension1Id { get; set; }

        public virtual DocumentType DocType { get; set; }
        [ForeignKey("DocType")]
        public int? DocTypeId { get; set; }

        [Display (Name="Name")]
        [MaxLength(50), Required]
        [Index("IX_Dimension1_Dimension1Name", IsUnique = true)]
        public string Dimension1Name { get; set; }

        [ForeignKey("ProductType")]
        [Display(Name = "ProductType")]
        public int? ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public Decimal? Multiplier { get; set; }
        public int? CostCenterId { get; set; }


        [Display(Name = "Is Active ?")]
        public Boolean IsActive { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public ProductTypeSettingsViewModel ProductTypeSettings { get; set; }

        [ForeignKey("ReferenceDocType"), Display(Name = "Order Type")]
        public int? ReferenceDocTypeId { get; set; }
        public virtual DocumentType ReferenceDocType { get; set; }
        public int? ReferenceDocId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [MaxLength(50)]
        public string OMSId { get; set; }
    }
}
