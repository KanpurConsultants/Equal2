﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surya.Notification
{
    class NotificationServiceEmailContent
    {
        public string GetNotificationContent()
        {
            NotificationServicesDataAccess notificationDataAcce = new NotificationServicesDataAccess();

            var purchaseOrder = notificationDataAcce.GetData();

            return HtmlContent(purchaseOrder);
        }

        private string HtmlContent(IEnumerable<PurchaseOrderHeader> purchaseOrder)
        {

            StringBuilder sb = new StringBuilder();


            string srtContent = @"<html><head><title></title></head><body><div style='color: blue;'><span style='font-size:14px;'><span style='font-family:verdana,geneva,sans-serif;'>Dear all ,</span></span></div><div style='color: blue;'&nbsp;</div><div style='color: blue;'><span style='font-size:14px;'><span style='font-family:verdana,geneva,sans-serif;'>Please find below the summary of the status of the PO as on "+DateTime.Now+".</span></span></div><div style='color: blue;'>&nbsp;</div><div style='color: blue;'><span style='font-family:verdana,geneva,sans-serif;'><span style='font-size:16px;'>";

            string strHeading = @"<strong>PO Number &nbsp; &nbsp; &nbsp;Order Date &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Ship Date &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Status &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Progress % &nbsp; &nbsp; &nbsp;&nbsp;</strong></span></span></div>";

            foreach (PurchaseOrderHeader poDetail in purchaseOrder)
            {

                string srtData = @"<p><span style='color:" + EmailCategory(poDetail) + ";'><span style='font-size:12px;'><span style='font-family:verdana,geneva,sans-serif;'>&nbsp; &nbsp; &nbsp; " + poDetail.OrderNumber + "   &nbsp; &nbsp; &nbsp; " + poDetail.OrderDate + " &nbsp; &nbsp; &nbsp; &nbsp;" + poDetail.ShipDate + "  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " + poDetail.Status + " &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + poDetail.ProgressPer + "&nbsp;</span></span></span></p>";

                sb.Append(srtData);
            }

            string strFooter = @"<p>&nbsp;</p><p><span style='font-size:12px;'><span style='font-family:verdana,geneva,sans-serif;'>Kindly review the status and take appropriate action.</span></span></p><p><font face='verdana, geneva, sans-serif'><span style='font-size: 12px;'>Regards,</span></font></p><p><font face='verdana, geneva, sans-serif'><span style='font-size: 12px;'>IT Devision</span></font></p><p><span style='font-size: 12px; font-family: verdana, geneva, sans-serif;'>Surya Industries &nbsp;PVT. LTD.</span></p>   <p><span style='font-size: 12px; font-family: verdana, geneva, sans-serif;'>*** THIS IS AN AUTOGENERATED MAIL. PLEASE DO NOT REPLY TO THIS MESSAGE *** </span></p>   </body></html>";

            return srtContent + strHeading + sb.ToString() + strFooter;
        }

        private string EmailCategory(PurchaseOrderHeader purchaseOrder)
        {
            TimeSpan ts = purchaseOrder.ShipDate - purchaseOrder.OrderDate;
            int totalDays = ts.Days;

            TimeSpan tsRemaining = purchaseOrder.ShipDate - DateTime.Today;

            int daysRemaining = tsRemaining.Days;

            int perDaysRemaining = 0;

            if (daysRemaining != null && daysRemaining != 0)
                perDaysRemaining = (daysRemaining / totalDays) * 100;

            if ((purchaseOrder.ProgressPer - perDaysRemaining) >= 0 || (purchaseOrder.ProgressPer - perDaysRemaining) >= -5 || (purchaseOrder.ProgressPer - perDaysRemaining) >= 5)
                return "#31B404";
            else if ((purchaseOrder.ProgressPer - perDaysRemaining) > -5 && (purchaseOrder.ProgressPer - perDaysRemaining) < -30)
                return "#FF8000";
            else
                return "#ff0000";
        }

        public string GetEscalationContent(PurchaseOrderHeader purchaseOrder)
        {
           
            return HtmlContentEscalation(purchaseOrder);
        }

        private string HtmlContentEscalation(PurchaseOrderHeader purchaseOrder)
        {
            StringBuilder sb = new StringBuilder();

            string emailCategory=EmailCategory(purchaseOrder);

            if (emailCategory == "#FF8000" || emailCategory == "#ff0000")
            {
                string srtContent = @"<html><head><title></title></head><body style='color: #ff0000;'><div style='color: #ff0000;'><span style='font-size:14px;'><span style='font-family:verdana,geneva,sans-serif;'>Dear " + purchaseOrder.SupplierName + " ,</span></span></div><div style='color: #ff0000;'&nbsp;</div><div style='color: #ff0000;'><span style='font-size:14px;'><span style='font-family:verdana,geneva,sans-serif;'>Please take immediate action on following PO. As per our record ship date is very close or passed and progress is " + purchaseOrder.ProgressPer + "%.</span></span></div><div style='color: #ff0000;'>&nbsp;</div><div style='color: #ff0000;'><span style='font-family:verdana,geneva,sans-serif;'><span style='font-size:16px;'>";

            string strHeading = @"<strong>PO Number &nbsp; &nbsp; &nbsp;Order Date &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Ship Date &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Status &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Progress % &nbsp; &nbsp; &nbsp;&nbsp;</strong></span></span></div>";

            string srtData = @"<p><span style='color:" + emailCategory + ";'><span style='font-size:12px;'><span style='font-family:verdana,geneva,sans-serif;'>&nbsp; &nbsp; &nbsp; " + purchaseOrder.OrderNumber + "   &nbsp; &nbsp; &nbsp; " + purchaseOrder.OrderDate + " &nbsp; &nbsp; &nbsp; &nbsp;" + purchaseOrder.ShipDate + "  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " + purchaseOrder.Status + " &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + purchaseOrder.ProgressPer + "&nbsp;</span></span></span></p>";

                sb.Append(srtData);
            
            string strFooter = @"<p>&nbsp;</p><p><span style='font-size:12px;'><span style='font-family:verdana,geneva,sans-serif;'>Kindly ensure that appropriate action has been taken on above.</span></span></p><p><font face='verdana, geneva, sans-serif'><span style='font-size: 12px;'>Regards,</span></font></p><p><font face='verdana, geneva, sans-serif'><span style='font-size: 12px;'>IT Devision</span></font></p><p><span style='font-size: 12px; font-family: verdana, geneva, sans-serif;'>Surya Industries &nbsp;PVT. LTD.</span></p>   <p><span style='font-size: 12px; font-family: verdana, geneva, sans-serif;'>*** THIS IS AN AUTOGENERATED MAIL. PLEASE DO NOT REPLY TO THIS MESSAGE *** </span></p>   </body></html>";

            return srtContent + strHeading + sb.ToString() + strFooter;
            }

            return sb.ToString();
        }

    }
}
