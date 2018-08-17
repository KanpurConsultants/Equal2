using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Core.Common;
using Model.Models;
using Data.Models;
using Service;
using Data.Infrastructure;
using Presentation.ViewModels;
using AutoMapper;
using Presentation;
using System.Text;
using Model.ViewModel;
using System.Xml.Linq;
using Reports.Controllers;
using Reports.Reports;
using Model.ViewModels;
using System.Configuration;
using Jobs.Helpers;


namespace Jobs.Controllers
{
    [Authorize]
    public class ProdOrderHeaderController : System.Web.Mvc.Controller
    {

        private ApplicationDbContext context = new ApplicationDbContext();

        List<string> UserRoles = new List<string>();
        ActiivtyLogViewModel LogVm = new ActiivtyLogViewModel();

        bool TimePlanValidation = true;
        string ExceptionMsg = "";
        bool Continue = true;

        IProdOrderHeaderService _ProdOrderHeaderService;
        IActivityLogService _ActivityLogService;
        IUnitOfWork _unitOfWork;
        IExceptionHandlingService _exception;
        public ProdOrderHeaderController(IProdOrderHeaderService PurchaseOrderHeaderService, IActivityLogService ActivityLogService, IUnitOfWork unitOfWork, IExceptionHandlingService exec)
        {
            _ProdOrderHeaderService = PurchaseOrderHeaderService;
            _ActivityLogService = ActivityLogService;
            _unitOfWork = unitOfWork;
            _exception = exec;

            UserRoles = (List<string>)System.Web.HttpContext.Current.Session["Roles"];

            //Log Initialization
            LogVm.SessionId = 0;
            LogVm.ControllerName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");
            LogVm.ActionName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");
            LogVm.User = System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.Name;
        }

        // GET: /ProdOrderHeader/

        public ActionResult DocumentTypeIndex(int id)//DocumentCategoryId
        {
            var p = new DocumentTypeService(_unitOfWork).FindByDocumentCategory(id).ToList();

            if (p != null)
            {
                if (p.Count == 1)
                    return RedirectToAction("Index", new { id = p.FirstOrDefault().DocumentTypeId });
            }

            return View("DocumentTypeList", p);
        }

        public ActionResult Index(int id, string IndexType)
        {
            if (IndexType == "PTS")
            {
                return RedirectToAction("Index_PendingToSubmit", new { id });
            }
            else if (IndexType == "PTR")
            {
                return RedirectToAction("Index_PendingToReview", new { id });
            }
            IQueryable<ProdOrderHeaderViewModel> p = _ProdOrderHeaderService.GetProdOrderHeaderList(id, User.Identity.Name);
            PrepareViewBag(id);
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "All";
            return View(p);
        }

        public ActionResult Index_PendingToSubmit(int id)
        {
            var PendingToSubmit = _ProdOrderHeaderService.GetProdOrderHeaderListPendingToSubmit(id, User.Identity.Name);

            PrepareViewBag(id);
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "PTS";
            return View("Index", PendingToSubmit);
        }

        public ActionResult Index_PendingToReview(int id)
        {
            var PendingtoReview = _ProdOrderHeaderService.GetProdOrderHeaderListPendingToReview(id, User.Identity.Name);
            PrepareViewBag(id);
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "PTR";
            return View("Index", PendingtoReview);
        }

        [HttpGet]
        public ActionResult NextPage(int DocId, int DocTypeId)//CurrentHeaderId
        {
            var nextId = new NextPrevIdService(_unitOfWork).GetNextPrevId(DocId, DocTypeId, User.Identity.Name, "", "Web.ProdOrderHeaders", "ProdOrderHeaderId", PrevNextConstants.Next);
            return Edit(nextId, "");
        }
        [HttpGet]
        public ActionResult PrevPage(int DocId, int DocTypeId)//CurrentHeaderId
        {
            var PrevId = new NextPrevIdService(_unitOfWork).GetNextPrevId(DocId, DocTypeId, User.Identity.Name, "", "Web.ProdOrderHeaders", "ProdOrderHeaderId", PrevNextConstants.Prev);
            return Edit(PrevId, "");
        }


        [HttpGet]
        public ActionResult History()
        {
            //To Be Implemented
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }

        [HttpGet]
        public ActionResult Email()
        {
            //To Be Implemented
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }

        [HttpGet]
        public ActionResult Report(int id)
        {
            DocumentType Dt = new DocumentType();
            Dt = new DocumentTypeService(_unitOfWork).Find(id);

            Dictionary<int, string> DefaultValue = new Dictionary<int, string>();

            if (!Dt.ReportMenuId.HasValue)
                throw new Exception("Report Menu not configured in document types");

            Model.Models.Menu menu = new MenuService(_unitOfWork).Find(Dt.ReportMenuId ?? 0);

            if (menu != null)
            {
                ReportHeader header = new ReportHeaderService(_unitOfWork).GetReportHeaderByName(menu.MenuName);

                ReportLine Line = new ReportLineService(_unitOfWork).GetReportLineByName("DocumentType", header.ReportHeaderId);
                if (Line != null)
                    DefaultValue.Add(Line.ReportLineId, id.ToString());
                ReportLine Site = new ReportLineService(_unitOfWork).GetReportLineByName("Site", header.ReportHeaderId);
                if (Site != null)
                    DefaultValue.Add(Site.ReportLineId, ((int)System.Web.HttpContext.Current.Session["SiteId"]).ToString());
                ReportLine Division = new ReportLineService(_unitOfWork).GetReportLineByName("Division", header.ReportHeaderId);
                if (Division != null)
                    DefaultValue.Add(Division.ReportLineId, ((int)System.Web.HttpContext.Current.Session["DivisionId"]).ToString());

            }

            TempData["ReportLayoutDefaultValues"] = DefaultValue;

            return Redirect((string)System.Configuration.ConfigurationManager.AppSettings["JobsDomain"] + "/Report_ReportPrint/ReportPrint/?MenuId=" + Dt.ReportMenuId);

        }

        private void PrepareViewBag(int id)
        {
            ViewBag.Name = new DocumentTypeService(_unitOfWork).Find(id).DocumentTypeName;
            ViewBag.id = id;

            var DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];
            var SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];

            var settings = new ProdOrderSettingsService(_unitOfWork).GetProdOrderSettingsForDocument(id, DivisionId, SiteId);
            if (settings != null)
            {
                ViewBag.SqlProcDocumentPrint = settings.SqlProcDocumentPrint;
                ViewBag.isVisibleBuyer = settings.isVisibleBuyer;
                ViewBag.ImportMenuId = settings.ImportMenuId;
                ViewBag.ExportMenuId = settings.ExportMenuId;
            }
        }

        // GET: /ProdOrderHeader/Create

        public ActionResult Create(int id)
        {

            ProdOrderHeaderViewModel p = new ProdOrderHeaderViewModel();
            p.DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];
            p.SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
            p.DocDate = DateTime.Now;
            p.DueDate = DateTime.Now;
            p.DocTypeId = id;
            p.CreatedDate = DateTime.Now;

            //Getting Settings
            var settings = new ProdOrderSettingsService(_unitOfWork).GetProdOrderSettingsForDocument(id, p.DivisionId, p.SiteId);

            if (settings == null && UserRoles.Contains("SysAdmin"))
            {
                return RedirectToAction("Create", "ProdOrderSettings", new { id = id }).Warning("Please create job order settings");
            }
            else if (settings == null && !UserRoles.Contains("SysAdmin"))
            {
                return View("~/Views/Shared/InValidSettings.cshtml");
            }

            if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, id, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "Create") == false)
            {
                return View("~/Views/Shared/PermissionDenied.cshtml").Warning("You don't have permission to do this task.");
            }

            PrepareViewBag(id);

            ViewBag.Mode = "Add";
            //p.DocNo = _ProdOrderHeaderService.GetMaxDocNo();
            p.DocNo = new DocumentTypeService(_unitOfWork).FGetNewDocNo("DocNo", ConfigurationManager.AppSettings["DataBaseSchema"] + ".ProdOrderHeaders", p.DocTypeId, p.DocDate, p.DivisionId, p.SiteId);
            return View("Create", p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HeaderPost(ProdOrderHeaderViewModel svm)
        {
            if (svm.DocDate > svm.DueDate)
            {
                ModelState.AddModelError("DueDate", "DueDate cannot be greater than DocDate");
            }

            #region DocTypeTimeLineValidation

            try
            {

                if (svm.ProdOrderHeaderId <= 0)
                    TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(svm), DocumentTimePlanTypeConstants.Create, User.Identity.Name, out ExceptionMsg, out Continue);
                else
                    TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(svm), DocumentTimePlanTypeConstants.Modify, User.Identity.Name, out ExceptionMsg, out Continue);

            }
            catch (Exception ex)
            {
                string message = _exception.HandleException(ex);
                TempData["CSEXC"] += message;
                TimePlanValidation = false;
            }

            if (!TimePlanValidation)
                TempData["CSEXC"] += ExceptionMsg;

            #endregion

            if (ModelState.IsValid && (TimePlanValidation || Continue))
            {

                #region CreateRecord
                if (svm.ProdOrderHeaderId == 0)
                {
                    ProdOrderHeader s = Mapper.Map<ProdOrderHeaderViewModel, ProdOrderHeader>(svm);

                    s.CreatedDate = DateTime.Now;
                    s.ModifiedDate = DateTime.Now;
                    s.CreatedBy = User.Identity.Name;
                    s.ModifiedBy = User.Identity.Name;
                    s.Status = (int)StatusConstants.Drafted;
                    _ProdOrderHeaderService.Create(s);

                    new ProdOrderHeaderStatusService(_unitOfWork).CreateHeaderStatus(s.ProdOrderHeaderId);

                    try
                    {
                        _unitOfWork.Save();
                    }

                    catch (Exception ex)
                    {
                        string message = _exception.HandleException(ex);
                        TempData["CSEXC"] += message;
                        PrepareViewBag(svm.DocTypeId);
                        return View("Create", svm);
                    }


                    LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                    {
                        DocTypeId = s.DocTypeId,
                        DocId = s.ProdOrderHeaderId,
                        ActivityType = (int)ActivityTypeContants.Added,
                        DocNo = s.DocNo,
                        DocDate = s.DocDate,
                        DocStatus = s.Status,
                    }));

                    return RedirectToAction("Modify", new { id = s.ProdOrderHeaderId }).Success("Data saved Successfully");
                }
                #endregion

                #region EditRecord
                else
                {
                    List<LogTypeViewModel> LogList = new List<LogTypeViewModel>();

                    //string tempredirect = (Request["Redirect"].ToString());
                    ProdOrderHeader s = Mapper.Map<ProdOrderHeaderViewModel, ProdOrderHeader>(svm);
                    StringBuilder logstring = new StringBuilder();
                    ProdOrderHeader temp = _ProdOrderHeaderService.Find(s.ProdOrderHeaderId);

                    ProdOrderHeader ExRec = new ProdOrderHeader();
                    ExRec = Mapper.Map<ProdOrderHeader>(temp);

                    int status = temp.Status;

                    if (temp.Status != (int)StatusConstants.Drafted && temp.Status != (int)StatusConstants.Import)
                        temp.Status = (int)StatusConstants.Modified;

                    temp.DocTypeId = s.DocTypeId;
                    temp.DocDate = s.DocDate;
                    temp.DocNo = s.DocNo;
                    temp.Remark = s.Remark;
                    temp.DueDate = s.DueDate;
                    temp.ModifiedDate = DateTime.Now;
                    temp.ModifiedBy = User.Identity.Name;
                    _ProdOrderHeaderService.Update(temp);

                    LogList.Add(new LogTypeViewModel
                    {
                        ExObj = ExRec,
                        Obj = temp,
                    });
                    XElement Modifications = new ModificationsCheckService().CheckChanges(LogList);
                    try
                    {
                        _unitOfWork.Save();
                    }

                    catch (Exception ex)
                    {
                        string message = _exception.HandleException(ex);
                        TempData["CSEXC"] += message;
                        PrepareViewBag(svm.DocTypeId);
                        ViewBag.Mode = "Edit";
                        return View("Create", svm);
                    }

                    LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                    {
                        DocTypeId = s.DocTypeId,
                        DocId = s.ProdOrderHeaderId,
                        ActivityType = (int)ActivityTypeContants.Modified,
                        DocNo = s.DocNo,
                        xEModifications = Modifications,
                        DocDate = s.DocDate,
                        DocStatus = s.Status,
                    }));

                    return RedirectToAction("Index", new { id = temp.DocTypeId, IndexType = "" }).Success("Data saved successfully");
                }

                #endregion
            }
            PrepareViewBag(svm.DocTypeId);
            ViewBag.Mode = "Add";
            return View("Create", svm);
        }

        [HttpGet]
        public ActionResult Modify(int id, string IndexType)
        {
            ProdOrderHeader header = _ProdOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Drafted)
                return Edit(id, IndexType);
            else
                return HttpNotFound();
        }

        [HttpGet]
        public ActionResult ModifyAfter_Submit(int id, string IndexType)
        {
            ProdOrderHeader header = _ProdOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Submitted || header.Status == (int)StatusConstants.Modified || header.Status == (int)StatusConstants.ModificationSubmitted)
                return Edit(id, IndexType);
            else
                return HttpNotFound();
        }

        // GET: /ProdOrderHeader/Edit/5
        private ActionResult Edit(int id, string IndexType)
        {
            ViewBag.IndexStatus = IndexType;

            ProdOrderHeaderViewModel s = _ProdOrderHeaderService.GetProdOrderHeader(id);

            if (s == null)
            {
                return HttpNotFound();
            }

            if (s.Status != (int)StatusConstants.Drafted)
                if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, s.DocTypeId, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "Edit") == false)
                    return RedirectToAction("DetailInformation", new { id = id, IndexType = IndexType }).Warning("You don't have permission to do this task.");

            #region DocTypeTimeLineValidation
            try
            {

                TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(s), DocumentTimePlanTypeConstants.Modify, User.Identity.Name, out ExceptionMsg, out Continue);

            }
            catch (Exception ex)
            {
                string message = _exception.HandleException(ex);
                TempData["CSEXC"] += message;
                TimePlanValidation = false;
            }

            if (!TimePlanValidation)
                TempData["CSEXC"] += ExceptionMsg;
            #endregion

            if ((!TimePlanValidation && !Continue))
            {
                return RedirectToAction("DetailInformation", new { id = id, IndexType = IndexType });
            }

            //Getting Settings
            var settings = new ProdOrderSettingsService(_unitOfWork).GetProdOrderSettingsForDocument(s.DocTypeId, s.DivisionId, s.SiteId);
            if (settings == null && UserRoles.Contains("SysAdmin"))
            {
                return RedirectToAction("Create", "ProdOrderSettings", new { id = s.DocTypeId }).Warning("Please create Prod Order settings");
            }
            else if (settings == null && !UserRoles.Contains("SysAdmin"))
            {
                return View("~/Views/Shared/InValidSettings.cshtml");
            }

            PrepareViewBag(s.DocTypeId);
            ViewBag.Mode = "Edit";

            if (!(System.Web.HttpContext.Current.Request.UrlReferrer.PathAndQuery).Contains("Create"))
                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = s.DocTypeId,
                    DocId = s.ProdOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Detail,
                    DocNo = s.DocNo,
                    DocDate = s.DocDate,
                    DocStatus = s.Status,
                }));

            return View("Create", s);
        }

        [HttpGet]
        public ActionResult DetailInformation(int id, string IndexType)
        {
            return RedirectToAction("Detail", new { id = id, transactionType = "detail", IndexType = IndexType });
        }


        [Authorize]
        public ActionResult Detail(int id, string transactionType, string IndexType)
        {

            ViewBag.transactionType = transactionType;
            ViewBag.IndexStatus = IndexType;

            ProdOrderHeaderViewModel s = _ProdOrderHeaderService.GetProdOrderHeader(id);
            PrepareViewBag(s.DocTypeId);
            if (s == null)
            {
                return HttpNotFound();
            }

            if (String.IsNullOrEmpty(transactionType) || transactionType == "detail")
                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = s.DocTypeId,
                    DocId = s.ProdOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Detail,
                    DocNo = s.DocNo,
                    DocDate = s.DocDate,
                    DocStatus = s.Status,
                }));


            return View("Create", s);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProdOrderHeader header = _ProdOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Drafted || header.Status == (int)StatusConstants.Import)
                return Remove(id);
            else
                return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteAfter_Submit(int id)
        {
            ProdOrderHeader header = _ProdOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Submitted || header.Status == (int)StatusConstants.Modified)
                return Remove(id);
            else
                return HttpNotFound();
        }

        // GET: /PurchaseOrderHeader/Delete/5

        private ActionResult Remove(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdOrderHeaderViewModel ProdOrderHeader = _ProdOrderHeaderService.GetProdOrderHeader(id);
            if (ProdOrderHeader == null)
            {
                return HttpNotFound();
            }

            if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, ProdOrderHeader.DocTypeId, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "Remove") == false)
            {
                return PartialView("~/Views/Shared/PermissionDenied_Modal.cshtml").Warning("You don't have permission to do this task.");
            }

            #region DocTypeTimeLineValidation
            try
            {
                TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(ProdOrderHeader), DocumentTimePlanTypeConstants.Delete, User.Identity.Name, out ExceptionMsg, out Continue);
                TempData["CSEXC"] += ExceptionMsg;
            }
            catch (Exception ex)
            {
                string message = _exception.HandleException(ex);
                TempData["CSEXC"] += message;
                TimePlanValidation = false;
            }

            if (!TimePlanValidation && !Continue)
            {
                return PartialView("AjaxError");
            }
            #endregion

            ReasonViewModel rvm = new ReasonViewModel()
            {
                id = id,
            };
            return PartialView("_Reason", rvm);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReasonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                List<LogTypeViewModel> LogList = new List<LogTypeViewModel>();

                //string temp = (Request["Redirect"].ToString());
                //first find the Purchase Order Object based on the ID. (sience this object need to marked to be deleted IE. ObjectState.Deleted)
                var ProdOrderHeader = _ProdOrderHeaderService.Find(vm.id);
                int status = ProdOrderHeader.Status;

                LogList.Add(new LogTypeViewModel
                {
                    ExObj = ProdOrderHeader,
                });


                //Then find all the Purchase Order Header Line associated with the above ProductType.
                var ProdOrderLine = new ProdOrderLineService(_unitOfWork).GetProdOrderLineListForIndex(vm.id);



                //Mark ObjectState.Delete to all the Purchase Order Lines. 
                foreach (var item in ProdOrderLine)
                {
                    LogList.Add(new LogTypeViewModel
                    {
                        ExObj = item,
                    });

                    new ProdOrderLineStatusService(_unitOfWork).Delete(item.ProdOrderLineId);

                    new ProdOrderLineService(_unitOfWork).Delete(item.ProdOrderLineId);
                }
            

                new ProdOrderHeaderStatusService(_unitOfWork).Delete(ProdOrderHeader.ProdOrderHeaderId);

                // Now delete the Purhcase Order Header
                new ProdOrderHeaderService(_unitOfWork).Delete(vm.id);


                XElement Modifications = new ModificationsCheckService().CheckChanges(LogList);
                //Commit the DB
                try
                {
                    _unitOfWork.Save();
                }

                catch (Exception ex)
                {
                    string message = _exception.HandleException(ex);
                    TempData["CSEXC"] += message;
                    return PartialView("_Reason", vm);
                }

                //Logging Activity

                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = ProdOrderHeader.DocTypeId,
                    DocId = ProdOrderHeader.ProdOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Deleted,
                    UserRemark = vm.Reason,
                    DocNo = ProdOrderHeader.DocNo,
                    xEModifications = Modifications,
                    DocDate = ProdOrderHeader.DocDate,
                    DocStatus = ProdOrderHeader.Status,
                }));

                return Json(new { success = true });
            }
            return PartialView("_Reason", vm);
        }



        public ActionResult Submit(int id, string IndexType, string TransactionType)
        {
            ProdOrderHeader s = context.ProdOrderHeader.Find(id);
            if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, s.DocTypeId, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "Submit") == false)
            {
                return View("~/Views/Shared/PermissionDenied.cshtml").Warning("You don't have permission to do this task.");
            }

            #region DocTypeTimeLineValidation

            
            try
            {
                TimePlanValidation = Submitvalidation(id, out ExceptionMsg);
                TempData["CSEXC"] += ExceptionMsg;
            }
            catch (Exception ex)
            {
                string message = _exception.HandleException(ex);
                TempData["CSEXC"] += message;
                TimePlanValidation = false;
            }
            try
            {
                TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(s), DocumentTimePlanTypeConstants.Submit, User.Identity.Name, out ExceptionMsg, out Continue);
                TempData["CSEXC"] += ExceptionMsg;
            }
            catch (Exception ex)
            {
                string message = _exception.HandleException(ex);
                TempData["CSEXC"] += message;
                TimePlanValidation = false;
            }

            if (!TimePlanValidation && !Continue)
            {
                return RedirectToAction("Index", new { id = s.DocTypeId, IndexType = IndexType });
            }
            #endregion
            return RedirectToAction("Detail", new { id = id, IndexType = IndexType, transactionType = string.IsNullOrEmpty(TransactionType) ? "submit" : TransactionType });
        }


        [HttpPost, ActionName("Detail")]
        [MultipleButton(Name = "Command", Argument = "Submit")]
        public ActionResult Submitted(int Id, string IndexType, string UserRemark, string IsContinue)
        {
            ProdOrderHeader pd = new ProdOrderHeaderService(_unitOfWork).Find(Id);

            if (ModelState.IsValid)
            {
                if (User.Identity.Name == pd.ModifiedBy || UserRoles.Contains("Admin"))
                {

                    pd.Status = (int)StatusConstants.Submitted;
                    pd.ReviewBy = null;
                    _ProdOrderHeaderService.Update(pd);

                    _unitOfWork.Save();

                    LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                    {
                        DocTypeId = pd.DocTypeId,
                        DocId = pd.ProdOrderHeaderId,
                        ActivityType = (int)ActivityTypeContants.Submitted,
                        UserRemark = UserRemark,
                        DocNo = pd.DocNo,
                        DocDate = pd.DocDate,
                        DocStatus = pd.Status,
                    }));

                    //SendEmail_PODrafted(Id);

                    return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Success("Record Submitted successfully.");
                }
                else
                    return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Warning("Record can be submitted by user " + pd.ModifiedBy + " only.");
            }

            return View();
        }



        public ActionResult Review(int id, string IndexType, string TransactionType)
        {
            return RedirectToAction("Detail", new { id = id, IndexType = IndexType, transactionType = string.IsNullOrEmpty(TransactionType) ? "review" : TransactionType });
        }


        [HttpPost, ActionName("Detail")]
        [MultipleButton(Name = "Command", Argument = "Review")]
        public ActionResult Reviewed(int Id, string IndexType, string UserRemark, string IsContinue)
        {
            ProdOrderHeader pd = new ProdOrderHeaderService(_unitOfWork).Find(Id);

            if (ModelState.IsValid)
            {

                pd.ReviewCount = (pd.ReviewCount ?? 0) + 1;
                pd.ReviewBy += User.Identity.Name + ", ";

                _ProdOrderHeaderService.Update(pd);

                _unitOfWork.Save();

                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = pd.DocTypeId,
                    DocId = pd.ProdOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Reviewed,
                    UserRemark = UserRemark,
                    DocNo = pd.DocNo,
                    DocDate = pd.DocDate,
                    DocStatus = pd.Status,
                }));

                //SendEmail_POApproved(Id);

                return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Success("Record reviewed successfully.");
            }

            return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Warning("Error in reviewing.");
        }

        public int PendingToSubmitCount(int id)
        {
            return (_ProdOrderHeaderService.GetProdOrderHeaderListPendingToSubmit(id, User.Identity.Name)).Count();
        }

        public int PendingToReviewCount(int id)
        {
            return (_ProdOrderHeaderService.GetProdOrderHeaderListPendingToReview(id, User.Identity.Name)).Count();
        }

        protected override void Dispose(bool disposing)
        {
            if (!string.IsNullOrEmpty((string)TempData["CSEXC"]))
            {
                CookieGenerator.CreateNotificationCookie(NotificationTypeConstants.Danger, (string)TempData["CSEXC"]);
                TempData.Remove("CSEXC");
            }
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GeneratePrints(string Ids, int DocTypeId)
        {

            if (!string.IsNullOrEmpty(Ids))
            {
                int SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
                int DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];

                var Settings = new ProdOrderSettingsService(_unitOfWork).GetProdOrderSettingsForDocument(DocTypeId, DivisionId, SiteId);

                if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, DocTypeId, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "GeneratePrints") == false)
                {
                    return View("~/Views/Shared/PermissionDenied.cshtml").Warning("You don't have permission to do this task.");
                }

                try
                {

                    List<byte[]> PdfStream = new List<byte[]>();
                    foreach (var item in Ids.Split(',').Select(Int32.Parse))
                    {
                        DirectReportPrint drp = new DirectReportPrint();
                        var pd = context.ProdOrderHeader.Find(item);

                        LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                        {
                            DocTypeId = pd.DocTypeId,
                            DocId = pd.ProdOrderHeaderId,
                            ActivityType = (int)ActivityTypeContants.Print,
                            DocNo = pd.DocNo,
                            DocDate = pd.DocDate,
                            DocStatus = pd.Status,
                        }));

                        byte[] Pdf;

                        if (pd.Status == (int)StatusConstants.Drafted || pd.Status == (int)StatusConstants.Import || pd.Status == (int)StatusConstants.Modified)
                        {
                            if (Settings.SqlProcDocumentPrint == null || Settings.SqlProcDocumentPrint == "")
                            {
                                ProdOrderHeaderRDL cr = new ProdOrderHeaderRDL();
                                drp.CreateRDLFile("Std_ProdOrder_Print", cr.Create_Std_ProdOrder_Print());
                                List<ListofQuery> QueryList = new List<ListofQuery>();
                                QueryList = DocumentPrintData(item);
                                Pdf = drp.DocumentPrint_New(QueryList, User.Identity.Name);
                            }
                            else
                                Pdf = drp.DirectDocumentPrint(Settings.SqlProcDocumentPrint, User.Identity.Name, item);
                            PdfStream.Add(Pdf);
                        }
                        else if (pd.Status == (int)StatusConstants.Submitted || pd.Status == (int)StatusConstants.ModificationSubmitted)
                        {
                            if (Settings.SqlProcDocumentPrint == null || Settings.SqlProcDocumentPrint == "")
                            {
                                ProdOrderHeaderRDL cr = new ProdOrderHeaderRDL();
                                drp.CreateRDLFile("Std_ProdOrder_Print", cr.Create_Std_ProdOrder_Print());
                                List<ListofQuery> QueryList = new List<ListofQuery>();
                                QueryList = DocumentPrintData(item);
                                Pdf = drp.DocumentPrint_New(QueryList, User.Identity.Name);
                            }
                            else
                                Pdf = drp.DirectDocumentPrint(Settings.SqlProcDocumentPrint, User.Identity.Name, item);
                            PdfStream.Add(Pdf);
                        }
                        else
                        {
                            if (Settings.SqlProcDocumentPrint == null || Settings.SqlProcDocumentPrint == "")
                            {
                                ProdOrderHeaderRDL cr = new ProdOrderHeaderRDL();
                                drp.CreateRDLFile("Std_ProdOrder_Print", cr.Create_Std_ProdOrder_Print());
                                List<ListofQuery> QueryList = new List<ListofQuery>();
                                QueryList = DocumentPrintData(item);
                                Pdf = drp.DocumentPrint_New(QueryList, User.Identity.Name);
                            }
                            else
                                Pdf = drp.DirectDocumentPrint(Settings.SqlProcDocumentPrint, User.Identity.Name, item);
                            PdfStream.Add(Pdf);
                        }

                    }

                    PdfMerger pm = new PdfMerger();

                    byte[] Merge = pm.MergeFiles(PdfStream);

                    if (Merge != null)
                        return File(Merge, "application/pdf");

                }

                catch (Exception ex)
                {
                    string message = _exception.HandleException(ex);
                    return Json(new { success = "Error", data = message }, JsonRequestBehavior.AllowGet);
                }


                return Json(new { success = "Success" }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { success = "Error", data = "No Records Selected." }, JsonRequestBehavior.AllowGet);

        }

        private List<ListofQuery> DocumentPrintData(int item)
        {
            List<ListofQuery> DocumentPrintData = new List<ListofQuery>();
            String QueryMain;
            QueryMain = @"
SELECT H.ProdOrderHeaderId,H.DocTypeId,H.DocNo,DocIdCaption + ' No' AS DocIdCaption,
      H.SiteId,H.DivisionId,H.DocDate,DTS.DocIdCaption + ' Date' AS DocIdCaptionDate, format(H.DueDate, 'dd/MMM/yy') AS DueDate, DocIdCaption+'Due Date' AS DocIdCaptionDueDate, 	
       H.Remark,DT.DocumentTypeShortName,H.ModifiedBy + ' ' + Replace(replace(convert(NVARCHAR, H.ModifiedDate, 106), ' ', '/'), '/20', '/') + substring(convert(NVARCHAR, H.ModifiedDate), 13, 7) AS ModifiedBy,
               H.ModifiedDate,(CASE WHEN Isnull(H.Status, 0)= 0 OR Isnull(H.Status, 0)= 8 THEN 0 ELSE 1 END)  AS Status,
               DTS.ContraDocTypeCaption, NULL   ProductUidName, MH.DocNo ReferenceNo, NULL AS LotNo,
	(CASE WHEN SPR.[Party GST NO]
        IS NULL THEN 'Yes' ELSE 'No' END ) AS ReverseCharge,
VDC.CompanyName,
    P.Name AS PartyName, DTS.PartyCaption AS  PartyCaption, P.Suffix AS PartySuffix,	
    isnull(PA.Address,'')+' '+isnull(C.CityName,'')+','+isnull(PA.ZipCode,'')+(CASE WHEN isnull(CS.StateName,'') <> isnull(S.StateName,'') AND SPR.[Party GST NO] IS NOT NULL THEN ',State : '+isnull(S.StateName,'')+(CASE WHEN S.StateCode IS NULL THEN '' ELSE ', Code : '+S.StateCode END)    ELSE '' END ) AS PartyAddress,
    isnull(S.StateName, '') AS PartyStateName, isnull(S.StateCode, '') AS PartyStateCode,

       P.Mobile AS PartyMobileNo,	SPR.*,

    DTS.SignatoryMiddleCaption,DTS.SignatoryRightCaption,
	--Line Table
    PD.ProductName,DTS.ProductCaption,U.UnitName,U.DecimalPlaces,DTS.DealQtyCaption,
    L.Qty, 
          D1.Dimension1Name,DTS.Dimension1Caption,D2.Dimension2Name,DTS.Dimension2Caption,D3.Dimension3Name,DTS.Dimension3Caption,D4.Dimension4Name,DTS.Dimension4Caption,
   (CASE WHEN DTS.PrintSpecification >0 THEN L.Specification ELSE '' END)  AS Specification, DTS.SpecificationCaption,DTS.SignatoryleftCaption,L.Remark AS LineRemark,
    (SELECT TOP 1 SalesTaxProductCodeCaption FROM web.SiteDivisionSettings WHERE H.DocDate BETWEEN StartDate AND IsNull(EndDate, getdate()) AND SiteId = H.SiteId AND DivisionId = H.DivisionId)  AS SalesTaxProductCodeCaption,
       (CASE WHEN DTS.PrintProductGroup > 0 THEN isnull(PG.ProductGroupName, '') ELSE '' END)+(CASE WHEN DTS.PrintProductdescription >0 THEN isnull(','+PD.Productdescription,'') ELSE '' END) AS ProductGroupName,
         DTS.ProductGroupCaption,  
   DTS.ProductUidCaption,
NULL  AS SubReportProcList,
     (CASE WHEN Isnull(H.Status, 0) = 0 OR Isnull(H.Status, 0) = 8 THEN 'Provisional ' + isnull(DT.PrintTitle, DT.DocumentTypeName) ELSE isnull(DT.PrintTitle, DT.DocumentTypeName) END) AS ReportTitle,
          	'Std_ProdOrder_Print.rdl' AS ReportName
FROM Web.ProdOrderHeaders H WITH (Nolock)
LEFT JOIN Web.ProdOrderLines L WITH (Nolock) ON L.ProdOrderHeaderId = H.ProdOrderHeaderId
LEFT JOIN web.DocumentTypes DT WITH(Nolock) ON DT.DocumentTypeId=H.DocTypeId
LEFT JOIN Web._DocumentTypeSettings DTS WITH (Nolock) ON DTS.DocumentTypeId=DT.DocumentTypeId
LEFT JOIN Web.ProdOrderSettings  JOS WITH (Nolock) ON JOS.DocTypeId=DT.DocumentTypeId AND JOS.SiteId= H.SiteId AND JOS.DivisionId= H.DivisionId
LEFT JOIN web.ViewDivisionCompany VDC WITH (Nolock) ON VDC.DivisionId=H.DivisionId
LEFT JOIN web.MaterialPlanLines ML ON ML.MaterialplanLineId =L.MaterialplanLineId
LEFT JOIN web.MaterialPlanHeaders MH ON MH.MaterialplanHeaderId = ML.MaterialplanHeaderId
LEFT JOIN Web.Sites SI WITH (Nolock) ON SI.SiteId=H.SiteId
LEFT JOIN Web.Divisions DIV WITH (Nolock) ON DIV.DivisionId=H.DivisionId
LEFT JOIN Web.Companies Com ON Com.CompanyId = DIV.CompanyId
LEFT JOIN Web.Cities CC WITH (Nolock) ON CC.CityId=Com.CityId
LEFT JOIN Web.States CS WITH (Nolock) ON CS.StateId=CC.StateId
LEFT JOIN Web.People P WITH (Nolock) ON P.PersonID=H.BuyerId
LEFT JOIN(SELECT* FROM Web.PersonAddresses WITH (nolock) WHERE AddressType IS NULL) PA ON PA.PersonId = P.PersonID
LEFT JOIN Web.Cities C WITH (nolock) ON C.CityId = PA.CityId
LEFT JOIN Web.States S WITH (Nolock) ON S.StateId=C.StateId
LEFT JOIN web.Products PD WITH (Nolock) ON PD.ProductId=L.ProductId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId=PD.ProductGroupid
LEFT JOIN Web.Dimension1 D1 WITH(Nolock) ON D1.Dimension1Id=L.Dimension1Id
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Dimension2Id=L.Dimension2Id
LEFT JOIN web.Dimension3 D3 WITH (Nolock) ON D3.Dimension3Id=L.Dimension3Id
LEFT JOIN Web.Dimension4 D4 WITH (nolock) ON D4.Dimension4Id=L.Dimension4Id
LEFT JOIN web.Units U WITH (Nolock) ON U.UnitId=PD.UnitId
LEFT JOIN Web.Std_PersonRegistrations SPR WITH (Nolock) ON SPR.CustomerId=H.BuyerId 
WHERE H.ProdOrderHeaderId=  " + item + @" 
ORDER BY L.ProdOrderLineId";



            ListofQuery QryMain = new ListofQuery();
            QryMain.Query = QueryMain;
            QryMain.QueryName = nameof(QueryMain);
            DocumentPrintData.Add(QryMain);


            return DocumentPrintData;

        }

        public ActionResult GetCustomPerson(string searchTerm, int pageSize, int pageNum, int filter)//DocTypeId
        {
            var Query = _ProdOrderHeaderService.GetCustomPerson(filter, searchTerm);
            var temp = Query.Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToList();

            var count = Query.Count();

            ComboBoxPagedResult Data = new ComboBoxPagedResult();
            Data.Results = temp;
            Data.Total = count;

            return new JsonpResult
            {
                Data = Data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        #region submitValidation
        public bool Submitvalidation(int id, out string Msg)
        {
            Msg = "";
            int ProdOrdLine = (new ProdOrderLineService(_unitOfWork).GetProdOrderLineListForIndex(id)).Count();
            if (ProdOrdLine == 0)
            {
                Msg = "Add Line Record. <br />";
            }
            else
            {
                Msg = "";
            }
            return (string.IsNullOrEmpty(Msg));
        }

        #endregion submitValidation

    }
}
