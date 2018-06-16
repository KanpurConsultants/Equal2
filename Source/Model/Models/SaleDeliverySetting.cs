﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class SaleDeliverySetting : EntityBase, IHistoryLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int SaleDeliverySettingId { get; set; }

        [ForeignKey("DocType"), Display(Name = "Order Type")]
        public int ? DocTypeId { get; set; }
        public virtual DocumentType DocType { get; set; }
        public int ? SiteId { get; set; }
        public virtual Site Site { get; set; }
        public int ? DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public bool? isVisibleDimension1 { get; set; }
        public bool? isVisibleDimension2 { get; set; }
        public bool? isVisibleDimension3 { get; set; }
        public bool? isVisibleDimension4 { get; set; }

        //For Index
        public bool? isVisibleProductUid_Index { get; set; }
        public bool? isVisibleProduct_Index { get; set; }
        public bool? isVisibleProductGroup_Index { get; set; }
        public bool? isVisibleSaleInvoice_Index { get; set; }


        public string filterLedgerAccountGroups { get; set; }
        public string filterLedgerAccounts { get; set; }
        public string filterProductTypes { get; set; }
        public string filterProductGroups { get; set; }
        public string filterProducts { get; set; }
        public string filterContraDocTypes { get; set; }
        public string filterContraSites { get; set; }
        public string filterContraDivisions { get; set; }
        public string filterPersonRoles { get; set; }

        [ForeignKey("DocumentPrintReportHeader")]
        public int? DocumentPrintReportHeaderId { get; set; }
        public virtual ReportHeader DocumentPrintReportHeader { get; set; }



        /// <summary>
        /// DocId will be passed as a parameter in specified procedure.
        /// Procedure should have only one parameter of type int.
        /// </summary>
        [MaxLength(100)]
        public string SqlProcDocumentPrint { get; set; }

        /// <summary>
        /// DocId will be passed as a parameter in specified procedure.
        /// Procedure should have only one parameter of type int.
        /// </summary>
        [MaxLength(100)]
        public string SqlProcDocumentPrint_AfterSubmit { get; set; }

        /// <summary>
        /// DocId will be passed as a parameter in specified procedure.
        /// Procedure should have only one parameter of type int.
        /// </summary>
        [MaxLength(100)]
        public string SqlProcDocumentPrint_AfterApprove { get; set; }

        [MaxLength(100)]
        public string SqlProcGatePass { get; set; }


        [ForeignKey("UnitConversionFor")]
        [Display(Name = "Unit Conversion For Type")]
        public byte? UnitConversionForId { get; set; }
        public virtual UnitConversionFor UnitConversionFor { get; set; }



        [ForeignKey("ImportMenu")]
        [Display(Name = "ImportMenu")]
        public int? ImportMenuId { get; set; }
        public virtual Menu ImportMenu { get; set; }


        [ForeignKey("WizardMenu")]
        [Display(Name = "WizardMenu")]
        public int? WizardMenuId { get; set; }
        public virtual Menu WizardMenu { get; set; }


        [ForeignKey("ExportMenu")]
        [Display(Name = "ExportMenu")]
        public int? ExportMenuId { get; set; }
        public virtual Menu ExportMenu { get; set; }




        public bool? isVisibleDealUnit { get; set; }


        public bool? isVisibleProductUid { get; set; }





        [ForeignKey("Process")]
        public int? ProcessId { get; set; }
        public virtual Process Process { get; set; }






        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
