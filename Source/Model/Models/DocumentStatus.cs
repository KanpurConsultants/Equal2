﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DocumentStatus : EntityBase, IHistoryLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int DocumentStatusId { get; set; }

        [Display (Name="Name")]
        [MaxLength(50, ErrorMessage = "Document Status Name cannot exceed 50 characters"), Required]
        [Index("IX_DocumentStatus_DocumentStatusName", IsUnique = true)]
        public string DocumentStatusName { get; set; }
                     
        [Display(Name = "Is Active ?")]
        public Boolean IsActive { get; set; }

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
