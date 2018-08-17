using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Core.Common;
using Model.Models;
using Data.Models;
using Service;
using Jobs.Helpers;
using Data.Infrastructure;
using Presentation.ViewModels;
using AutoMapper;
using Presentation;
using System.Text;
using Model.ViewModel;
using System.Configuration;
using System.Xml.Linq;
using Model.ViewModels;
using Reports.Controllers;
using Reports.Reports;

namespace Jobs.Controllers
{
    [Authorize]
    public class SaleDeliveryOrderHeaderController : System.Web.Mvc.Controller
    {

        private ApplicationDbContext context = new ApplicationDbContext();
        private bool EventException = false;

        List<string> UserRoles = new List<string>();
        ActiivtyLogViewModel LogVm = new ActiivtyLogViewModel();

        bool TimePlanValidation = true;
        string ExceptionMsg = "";
        bool Continue = true;

        ISaleDeliveryOrderHeaderService _SaleDeliveryOrderHeaderService;
        IUnitOfWork _unitOfWork;
        IExceptionHandlingService _exception;
        public SaleDeliveryOrderHeaderController(ISaleDeliveryOrderHeaderService PurchaseOrderHeaderService, IActivityLogService ActivityLogService, IUnitOfWork unitOfWork, IExceptionHandlingService exec)
        {
            _SaleDeliveryOrderHeaderService = PurchaseOrderHeaderService;
            _unitOfWork = unitOfWork;
            _exception = exec;

            UserRoles = (List<string>)System.Web.HttpContext.Current.Session["Roles"];

            //Log Initialization
            LogVm.SessionId = 0;
            LogVm.ControllerName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");
            LogVm.ActionName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");
            LogVm.User = System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.Name;
        }

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

        // GET: /SaleDeliveryOrderHeader/

        public ActionResult Index(int id, string IndexType)//DocumentTypeId
        {
            if (IndexType == "PTS")
            {
                return RedirectToAction("Index_PendingToSubmit", new { id });
            }
            else if (IndexType == "PTR")
            {
                return RedirectToAction("Index_PendingToReview", new { id });
            }
            IQueryable<SaleDeliveryOrderHeaderIndexViewModel> p = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeaderList(id, User.Identity.Name);

            ViewBag.Name = new DocumentTypeService(_unitOfWork).Find(id).DocumentTypeName;
            ViewBag.id = id;
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "All";
            return View(p);
        }
        public ActionResult Index_PendingToSubmit(int id)
        {
            var PendingToSubmit = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeaderListPendingToSubmit(id, User.Identity.Name);

            PrepareViewBag(id);
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "PTS";
            return View("Index", PendingToSubmit);
        }

        public ActionResult Index_PendingToReview(int id)
        {
            var PendingtoReview = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeaderListPendingToReview(id, User.Identity.Name);
            PrepareViewBag(id);
            ViewBag.PendingToSubmit = PendingToSubmitCount(id);
            ViewBag.PendingToReview = PendingToReviewCount(id);
            ViewBag.IndexStatus = "PTR";
            return View("Index", PendingtoReview);
        }

        [HttpGet]
        public ActionResult NextPage(int id, string name)//CurrentHeaderId
        {
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }
        [HttpGet]
        public ActionResult PrevPage(int id, string name)//CurrentHeaderId
        {
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }

        [HttpGet]
        public ActionResult History()
        {
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }


        [HttpGet]
        public ActionResult Email()
        {
            //To Be Implemented
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }        

        [HttpGet]
        public ActionResult Remove()
        {
            //To Be Implemented
            return View("~/Views/Shared/UnderImplementation.cshtml");
        }

        private void PrepareViewBag(int id)
        {

            ViewBag.Name = new DocumentTypeService(_unitOfWork).Find(id).DocumentTypeName;
            ViewBag.id = id;

            ViewBag.ShipMethodList = new ShipMethodService(_unitOfWork).GetShipMethodList().ToList();
            List<SelectListItem> temp = new List<SelectListItem>();
            temp.Add(new SelectListItem { Text = Enum.GetName(typeof(SaleOrderPriority), -10), Value = ((int)(SaleOrderPriority.Low)).ToString() });
            temp.Add(new SelectListItem { Text = Enum.GetName(typeof(SaleOrderPriority), 0), Value = ((int)(SaleOrderPriority.Normal)).ToString() });
            temp.Add(new SelectListItem { Text = Enum.GetName(typeof(SaleOrderPriority), 10), Value = ((int)(SaleOrderPriority.High)).ToString() });

            ViewBag.PriorityList = new SelectList(temp, "Value", "Text");

        }

        // GET: /SaleDeliveryOrderHeader/Create

        public ActionResult Create(int id)
        {

            SaleDeliveryOrderHeaderViewModel p = new SaleDeliveryOrderHeaderViewModel();

            p.DocDate = DateTime.Now.Date;
            p.DueDate = DateTime.Now.Date;
            p.DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];
            p.SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
            p.CreatedDate = DateTime.Now;

            //Getting Settings
            var settings = new SaleDeliveryOrderSettingsService(_unitOfWork).GetSaleDeliveryOrderSettingsForDocument(id, p.DivisionId, p.SiteId);

            if (settings == null && UserRoles.Contains("SysAdmin"))
            {
                return RedirectToAction("Create", "SaleDeliveryOrderSettings", new { id = id }).Warning("Please create SaleDeliveryOrder settings");
            }
            else if (settings == null && !UserRoles.Contains("SysAdmin"))
            {
                return View("~/Views/Shared/InValidSettings.cshtml");
            }

            if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, id, settings.ProcessId, this.ControllerContext.RouteData.Values["controller"].ToString(), "Create") == false)
            {
                return View("~/Views/Shared/PermissionDenied.cshtml").Warning("You don't have permission to do this task.");
            }

            p.SaleDeliveryOrderSettings = Mapper.Map<SaleDeliveryOrderSettings, SaleDeliveryOrderSettingsViewModel>(settings);
            PrepareViewBag(id);
            p.DocTypeId = id;
            ViewBag.Mode = "Add";
            p.DocNo = new DocumentTypeService(_unitOfWork).FGetNewDocNo("DocNo", ConfigurationManager.AppSettings["DataBaseSchema"] + ".SaleDeliveryOrderHeaders", p.DocTypeId, p.DocDate, p.DivisionId, p.SiteId);
            return View("Create", p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HeaderPost(SaleDeliveryOrderHeaderViewModel svm)
        {
            if (svm.DocDate > svm.DueDate)
            {
                ModelState.AddModelError("DueDate", "DueDate cannot be greater than DocDate");
            }

            #region DocTypeTimeLineValidation

            try
            {

                if (svm.SaleDeliveryOrderHeaderId <= 0)
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
                if (svm.SaleDeliveryOrderHeaderId <= 0)
                {
                    SaleDeliveryOrderHeader s = Mapper.Map<SaleDeliveryOrderHeaderViewModel, SaleDeliveryOrderHeader>(svm);

                    s.CreatedDate = DateTime.Now;
                    s.ModifiedDate = DateTime.Now;
                    s.CreatedBy = User.Identity.Name;
                    s.ModifiedBy = User.Identity.Name;
                    s.Status = (int)StatusConstants.Drafted;
                    _SaleDeliveryOrderHeaderService.Create(s);

                    try
                    {
                        _unitOfWork.Save();
                    }

                    catch (Exception ex)
                    {
                        string message = _exception.HandleException(ex);
                        TempData["CSEXC"] += message;
                        PrepareViewBag(svm.DocTypeId);
                        ViewBag.Mode = "Add";
                        return View("Create", svm);
                    }

                    LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                    {
                        DocTypeId = s.DocTypeId,
                        DocId = s.SaleDeliveryOrderHeaderId,
                        ActivityType = (int)ActivityTypeContants.Added,
                        DocNo = s.DocNo,
                        DocDate = s.DocDate,
                        DocStatus = s.Status,
                    }));

                    return RedirectToAction("Modify", new { id = s.SaleDeliveryOrderHeaderId }).Success("Data saved Successfully");
                } 
                #endregion

                #region EditRecord
                else
                {
                    //string tempredirect = (Request["Redirect"].ToString());
                    List<LogTypeViewModel> LogList = new List<LogTypeViewModel>();

                    SaleDeliveryOrderHeader s = Mapper.Map<SaleDeliveryOrderHeaderViewModel, SaleDeliveryOrderHeader>(svm);
                    StringBuilder logstring = new StringBuilder();
                    SaleDeliveryOrderHeader temp = _SaleDeliveryOrderHeaderService.Find(s.SaleDeliveryOrderHeaderId);

                    SaleDeliveryOrderHeader ExRec = new SaleDeliveryOrderHeader();
                    ExRec = Mapper.Map<SaleDeliveryOrderHeader>(temp);

                    int status = temp.Status;

                    if (temp.Status != (int)StatusConstants.Drafted && temp.Status != (int)StatusConstants.Import)
                        temp.Status = (int)StatusConstants.Modified;

                    temp.DocDate = s.DocDate;
                    temp.DocNo = s.DocNo;
                    temp.Priority = s.Priority;
                    temp.ShipMethodId = s.ShipMethodId;
                    temp.ShipAddress = s.ShipAddress;
                    temp.Remark = s.Remark;
                    temp.DueDate = s.DueDate;
                    temp.ModifiedDate = DateTime.Now;
                    temp.ModifiedBy = User.Identity.Name;
                    _SaleDeliveryOrderHeaderService.Update(temp);

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
                        DocTypeId = temp.DocTypeId,
                        DocId = temp.SaleDeliveryOrderHeaderId,
                        ActivityType = (int)ActivityTypeContants.Modified,
                        DocNo = temp.DocNo,
                        xEModifications = Modifications,
                        DocDate = temp.DocDate,
                        DocStatus = temp.Status,
                    }));

                    return RedirectToAction("Index", new { id = svm.DocTypeId }).Success("Data saved successfully");
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
            SaleDeliveryOrderHeader header = _SaleDeliveryOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Drafted || header.Status == (int)StatusConstants.Import)
                return Edit(id, IndexType);
            else
                return HttpNotFound();
        }

        [HttpGet]
        public ActionResult ModifyAfter_Submit(int id, string IndexType)
        {
            SaleDeliveryOrderHeader header = _SaleDeliveryOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Submitted || header.Status == (int)StatusConstants.Modified || header.Status == (int)StatusConstants.ModificationSubmitted)
                return Edit(id, IndexType);
            else
                return HttpNotFound();
        }

        // GET: /SaleDeliveryOrderHeader/Edit/5
        private ActionResult Edit(int id, string IndexType)
        {
            ViewBag.IndexStatus = IndexType;

            SaleDeliveryOrderHeader s = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeader(id);

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
            //Job Order Settings
            var settings = new SaleDeliveryOrderSettingsService(_unitOfWork).GetSaleDeliveryOrderSettingsForDocument(s.DocTypeId, s.DivisionId, s.SiteId);

            if (settings == null && UserRoles.Contains("SysAdmin"))
            {
                return RedirectToAction("Create", "SaleDeliveryOrderSettings", new { id = s.DocTypeId }).Warning("Please create SaleDeliveryOrder settings");
            }
            else if (settings == null && !UserRoles.Contains("SysAdmin"))
            {
                return View("~/Views/Shared/InValidSettings.cshtml");
            }

            SaleDeliveryOrderHeaderViewModel svm = Mapper.Map<SaleDeliveryOrderHeader, SaleDeliveryOrderHeaderViewModel>(s);
            svm.SaleDeliveryOrderSettings = Mapper.Map<SaleDeliveryOrderSettings, SaleDeliveryOrderSettingsViewModel>(settings);

            PrepareViewBag(s.DocTypeId);
            ViewBag.Mode = "Edit";

            if (!(System.Web.HttpContext.Current.Request.UrlReferrer.PathAndQuery).Contains("Create"))
                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = s.DocTypeId,
                    DocId = s.SaleDeliveryOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Detail,
                    DocNo = s.DocNo,
                    DocDate = s.DocDate,
                    DocStatus = s.Status,
                }));

            return View("Create", svm);
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

            SaleDeliveryOrderHeader s = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeader(id);

            if (s == null)
            {
                return HttpNotFound();
            }

            //Job Order Settings
            var settings = new SaleDeliveryOrderSettingsService(_unitOfWork).GetSaleDeliveryOrderSettingsForDocument(s.DocTypeId, s.DivisionId, s.SiteId);

            if (settings == null)
            {
                return RedirectToAction("Create", "SaleDeliveryOrderSettings", new { id = s.DocTypeId }).Warning("Please create SaleDeliveryOrder settings");
            }

            SaleDeliveryOrderHeaderViewModel svm = Mapper.Map<SaleDeliveryOrderHeader, SaleDeliveryOrderHeaderViewModel>(s);
            svm.SaleDeliveryOrderSettings = Mapper.Map<SaleDeliveryOrderSettings, SaleDeliveryOrderSettingsViewModel>(settings);

            PrepareViewBag(svm.DocTypeId);

            if (String.IsNullOrEmpty(transactionType) || transactionType == "detail")
                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = s.DocTypeId,
                    DocId = s.SaleDeliveryOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Detail,
                    DocNo = s.DocNo,
                    DocDate = s.DocDate,
                    DocStatus = s.Status,
                }));

           
            return View("Create", svm);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            SaleDeliveryOrderHeader header = _SaleDeliveryOrderHeaderService.Find(id);
            if (header.Status == (int)StatusConstants.Drafted || header.Status == (int)StatusConstants.Import)
                return Remove(id);
            else
                return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteAfter_Submit(int id)
        {
            SaleDeliveryOrderHeader header = _SaleDeliveryOrderHeaderService.Find(id);
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
            var SaleDeliveryOrderHeader = _SaleDeliveryOrderHeaderService.Find(id);

            if (SaleDeliveryOrderHeader == null)
            {
                return HttpNotFound();
            }

            if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, SaleDeliveryOrderHeader.DocTypeId, null, this.ControllerContext.RouteData.Values["controller"].ToString(), "Remove") == false)
            {
                return PartialView("~/Views/Shared/PermissionDenied_Modal.cshtml").Warning("You don't have permission to do this task.");
            }

            #region DocTypeTimeLineValidation
            try
            {
                TimePlanValidation = DocumentValidation.ValidateDocument(Mapper.Map<DocumentUniqueId>(SaleDeliveryOrderHeader), DocumentTimePlanTypeConstants.Delete, User.Identity.Name, out ExceptionMsg, out Continue);
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
                var SaleDeliveryOrderHeader = _SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeader(vm.id);

                LogList.Add(new LogTypeViewModel
                {
                    ExObj = SaleDeliveryOrderHeader,
                });

                //Then find all the Purchase Order Header Line associated with the above ProductType.
                var SaleDeliveryOrderLine = new SaleDeliveryOrderLineService(_unitOfWork).GetSaleDeliveryOrderLineList(vm.id);

                //Mark ObjectState.Delete to all the Purchase Order Lines. 
                foreach (var item in SaleDeliveryOrderLine)
                {

                    LogList.Add(new LogTypeViewModel
                    {
                        ExObj = item,
                    });
                    new SaleDeliveryOrderLineService(_unitOfWork).Delete(item.SaleDeliveryOrderLineId);
                }

                // Now delete the Purhcase Order Header
                new SaleDeliveryOrderHeaderService(_unitOfWork).Delete(vm.id);
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

                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = SaleDeliveryOrderHeader.DocTypeId,
                    DocId = SaleDeliveryOrderHeader.SaleDeliveryOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Deleted,
                    UserRemark = vm.Reason,
                    DocNo = SaleDeliveryOrderHeader.DocNo,
                    xEModifications = Modifications,
                    DocDate = SaleDeliveryOrderHeader.DocDate,
                    DocStatus = SaleDeliveryOrderHeader.Status,
                }));

                return Json(new { success = true });
            }
            return PartialView("_Reason", vm);
        }



        public ActionResult Submit(int id, string IndexType, string TransactionType)
        {
            SaleDeliveryOrderHeader s = context.SaleDeliveryOrderHeader.Find(id);
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
            SaleDeliveryOrderHeader pd = new SaleDeliveryOrderHeaderService(_unitOfWork).Find(Id);

            if (ModelState.IsValid)
            {
                if (User.Identity.Name == pd.ModifiedBy || UserRoles.Contains("Admin"))
                {
                    int ActivityType;


                    pd.Status = (int)StatusConstants.Submitted;
                    ActivityType = (int)ActivityTypeContants.Submitted;

                    pd.ReviewBy = null;

                    _SaleDeliveryOrderHeaderService.Update(pd);

                    _unitOfWork.Save();

                    LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                    {
                        DocTypeId = pd.DocTypeId,
                        DocId = pd.SaleDeliveryOrderHeaderId,
                        ActivityType = ActivityType,
                        UserRemark = UserRemark,
                        DocNo = pd.DocNo,
                        DocDate = pd.DocDate,
                        DocStatus = pd.Status,
                    }));

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
            SaleDeliveryOrderHeader pd = new SaleDeliveryOrderHeaderService(_unitOfWork).Find(Id);
            if (ModelState.IsValid)
            {

                pd.ReviewCount = (pd.ReviewCount ?? 0) + 1;
                pd.ReviewBy += User.Identity.Name + ", ";

                _SaleDeliveryOrderHeaderService.Update(pd);

                _unitOfWork.Save();

                LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                {
                    DocTypeId = pd.DocTypeId,
                    DocId = pd.SaleDeliveryOrderHeaderId,
                    ActivityType = (int)ActivityTypeContants.Reviewed,
                    UserRemark = UserRemark,
                    DocNo = pd.DocNo,
                    DocDate = pd.DocDate,
                    DocStatus = pd.Status,
                }));

                return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Success("Record reviewed successfully.");
            }

            return RedirectToAction("Index", new { id = pd.DocTypeId, IndexType = IndexType }).Warning("Error in reviewing.");
        }

        public int PendingToSubmitCount(int id)
        {
            return (_SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeaderListPendingToSubmit(id, User.Identity.Name)).Count();
        }

        public int PendingToReviewCount(int id)
        {
            return (_SaleDeliveryOrderHeaderService.GetSaleDeliveryOrderHeaderListPendingToReview(id, User.Identity.Name)).Count();
        }

        public ActionResult Import(int id)//Document Type Id
        {
            //ControllerAction ca = new ControllerActionService(_unitOfWork).Find(id);
            SaleDeliveryOrderHeaderViewModel vm = new SaleDeliveryOrderHeaderViewModel();

            vm.DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];
            vm.SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];

            var settings = new SaleDeliveryOrderSettingsService(_unitOfWork).GetSaleDeliveryOrderSettingsForDocument(id, vm.DivisionId, vm.SiteId);

            if (settings != null)
            {
                if (settings.ImportMenuId != null)
                {
                    MenuViewModel menuviewmodel = new MenuService(_unitOfWork).GetMenu((int)settings.ImportMenuId);

                    if (menuviewmodel == null)
                    {
                        return View("~/Views/Shared/UnderImplementation.cshtml");
                    }
                    else if (!string.IsNullOrEmpty(menuviewmodel.URL))
                    {
                        return Redirect(System.Configuration.ConfigurationManager.AppSettings[menuviewmodel.URL] + "/" + menuviewmodel.ControllerName + "/" + menuviewmodel.ActionName + "/" + id + "?MenuId=" + menuviewmodel.MenuId);
                    }
                    else
                    {
                        return RedirectToAction(menuviewmodel.ActionName, menuviewmodel.ControllerName, new { MenuId = menuviewmodel.MenuId, id = id });
                    }
                }
            }
            return RedirectToAction("Index", new { id = id });
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

        public ActionResult Print(int id)
        {
            String query = "Web.ProcSaleDeliveryOrderPrint ";
            return Redirect((string)System.Configuration.ConfigurationManager.AppSettings["JobsDomain"] + "/Report_DocumentPrint/DocumentPrint/?DocumentId=" + id + "&queryString=" + query);
        }

        public ActionResult GeneratePrints(string Ids, int DocTypeId)
        {

            if (!string.IsNullOrEmpty(Ids))
            {
                int SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
                int DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];

                var Settings = new SaleDeliveryOrderSettingsService(_unitOfWork).GetSaleDeliveryOrderSettingsForDocument(DocTypeId, DivisionId, SiteId);

                if (new RolePermissionService(_unitOfWork).IsActionAllowed(UserRoles, DocTypeId, Settings.ProcessId, this.ControllerContext.RouteData.Values["controller"].ToString(), "GeneratePrints") == false)
                {
                    return View("~/Views/Shared/PermissionDenied.cshtml").Warning("You don't have permission to do this task.");
                }

                try
                {

                    List<byte[]> PdfStream = new List<byte[]>();
                    foreach (var item in Ids.Split(',').Select(Int32.Parse))
                    {

                        DirectReportPrint drp = new DirectReportPrint();

                        var pd = context.SaleDeliveryOrderHeader.Find(item);

                        LogActivity.LogActivityDetail(LogVm.Map(new ActiivtyLogViewModel
                        {
                            DocTypeId = pd.DocTypeId,
                            DocId = pd.SaleDeliveryOrderHeaderId,
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
                                SaleDeliveryOrderHeaderRDL cr = new SaleDeliveryOrderHeaderRDL();
                                drp.CreateRDLFile("Std_SaleDeliveryOrder_Print", cr.Create_Std_SaleDeliveryOrder_Print());
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
                            if (Settings.SqlProcDocumentPrint_AfterSubmit == null || Settings.SqlProcDocumentPrint_AfterSubmit == "")
                            {
                                SaleDeliveryOrderHeaderRDL cr = new SaleDeliveryOrderHeaderRDL();
                                drp.CreateRDLFile("Std_SaleDeliveryOrder_Print", cr.Create_Std_SaleDeliveryOrder_Print());
                                List<ListofQuery> QueryList = new List<ListofQuery>();
                                QueryList = DocumentPrintData(item);
                                Pdf = drp.DocumentPrint_New(QueryList, User.Identity.Name);
                            }
                            else
                                Pdf = drp.DirectDocumentPrint(Settings.SqlProcDocumentPrint_AfterSubmit, User.Identity.Name, item);

                            PdfStream.Add(Pdf);
                        }
                        else
                        {
                            if (Settings.SqlProcDocumentPrint_AfterApprove == null || Settings.SqlProcDocumentPrint_AfterApprove == "")
                            {
                                SaleDeliveryOrderHeaderRDL cr = new SaleDeliveryOrderHeaderRDL();
                                drp.CreateRDLFile("Std_SaleDeliveryOrder_Print", cr.Create_Std_SaleDeliveryOrder_Print());
                                List<ListofQuery> QueryList = new List<ListofQuery>();
                                QueryList = DocumentPrintData(item);
                                Pdf = drp.DocumentPrint_New(QueryList, User.Identity.Name);
                            }
                            else
                                Pdf = drp.DirectDocumentPrint(Settings.SqlProcDocumentPrint_AfterApprove, User.Identity.Name, item);
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
            QueryMain = @"SELECT H.SaleDeliveryOrderHeaderId,H.DocTypeId,H.DocNo,DocIdCaption + ' No' AS DocIdCaption,
      H.SiteId,H.DivisionId,H.DocDate,DTS.DocIdCaption + ' Date' AS DocIdCaptionDate, format(L.DueDate, 'dd/MMM/yy') AS DueDate, DocIdCaption+'Due Date' AS DocIdCaptionDueDate, 	
       H.Remark,DT.DocumentTypeShortName,H.ModifiedBy + ' ' + Replace(replace(convert(NVARCHAR, H.ModifiedDate, 106), ' ', '/'), '/20', '/') + substring(convert(NVARCHAR, H.ModifiedDate), 13, 7) AS ModifiedBy,
               H.ModifiedDate,(CASE WHEN Isnull(H.Status, 0)= 0 OR Isnull(H.Status, 0)= 8 THEN 0 ELSE 1 END)  AS Status,
              DTS.ContraDocTypeCaption, NULL   ProductUidName, SOH.DocNo ReferenceNo, NULL AS LotNo,
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
   (CASE WHEN DTS.PrintSpecification >0 THEN SOL.Specification ELSE '' END)  AS Specification, DTS.SpecificationCaption,DTS.SignatoryleftCaption,L.Remark AS LineRemark,
    (SELECT TOP 1 SalesTaxProductCodeCaption FROM web.SiteDivisionSettings WHERE H.DocDate BETWEEN StartDate AND IsNull(EndDate, getdate()) AND SiteId = H.SiteId AND DivisionId = H.DivisionId)  AS SalesTaxProductCodeCaption,
       (CASE WHEN DTS.PrintProductGroup > 0 THEN isnull(PG.ProductGroupName, '') ELSE '' END)+(CASE WHEN DTS.PrintProductdescription >0 THEN isnull(','+PD.Productdescription,'') ELSE '' END) AS ProductGroupName,
         DTS.ProductGroupCaption,  
   DTS.ProductUidCaption,
NULL  AS SubReportProcList,
     (CASE WHEN Isnull(H.Status, 0) = 0 OR Isnull(H.Status, 0) = 8 THEN 'Provisional ' + isnull(DT.PrintTitle, DT.DocumentTypeName) ELSE isnull(DT.PrintTitle, DT.DocumentTypeName) END) AS ReportTitle,
          	'Std_SaleDeliveryOrder_Print.rdl' AS ReportName
FROM Web.SaleDeliveryOrderHeaders H WITH (Nolock)
LEFT JOIN Web.SaleDeliveryOrderLines L WITH (Nolock) ON L.SaleDeliveryOrderHeaderId = H.SaleDeliveryOrderHeaderId
LEFT JOIN web.DocumentTypes DT WITH(Nolock) ON DT.DocumentTypeId=H.DocTypeId
LEFT JOIN Web._DocumentTypeSettings DTS WITH (Nolock) ON DTS.DocumentTypeId=DT.DocumentTypeId
LEFT JOIN Web.SaleDeliveryOrderSettings  JOS WITH (Nolock) ON JOS.DocTypeId=DT.DocumentTypeId AND JOS.SiteId= H.SiteId AND JOS.DivisionId= H.DivisionId
LEFT JOIN web.ViewDivisionCompany VDC WITH (Nolock) ON VDC.DivisionId=H.DivisionId
LEFT JOIN Web.Sites SI WITH (Nolock) ON SI.SiteId=H.SiteId
LEFT JOIN Web.Divisions DIV WITH (Nolock) ON DIV.DivisionId=H.DivisionId
LEFT JOIN Web.Companies Com ON Com.CompanyId = DIV.CompanyId
LEFT JOIN Web.Cities CC WITH (Nolock) ON CC.CityId=Com.CityId
LEFT JOIN Web.States CS WITH (Nolock) ON CS.StateId=CC.StateId
LEFT JOIN Web.People P WITH (Nolock) ON P.PersonID=H.BuyerId
LEFT JOIN(SELECT* FROM Web.PersonAddresses WITH (nolock) WHERE AddressType IS NULL) PA ON PA.PersonId = P.PersonID
LEFT JOIN Web.Cities C WITH (nolock) ON C.CityId = PA.CityId
LEFT JOIN Web.States S WITH (Nolock) ON S.StateId=C.StateId
LEFT JOIN Web.SaleOrderLines SOL ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH ON SOH.SaleOrderHeaderId = SOL.SaleOrderHeaderId
LEFT JOIN web.Products PD WITH (Nolock) ON PD.ProductId=SOL.ProductId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId=PD.ProductGroupid
LEFT JOIN Web.Dimension1 D1 WITH(Nolock) ON D1.Dimension1Id=SOL.Dimension1Id
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Dimension2Id=SOL.Dimension2Id
LEFT JOIN web.Dimension3 D3 WITH (Nolock) ON D3.Dimension3Id=SOL.Dimension3Id
LEFT JOIN Web.Dimension4 D4 WITH (nolock) ON D4.Dimension4Id=SOL.Dimension4Id
LEFT JOIN web.Units U WITH (Nolock) ON U.UnitId=PD.UnitId
LEFT JOIN Web.Std_PersonRegistrations SPR WITH (Nolock) ON SPR.CustomerId=H.BuyerId 
WHERE H.SaleDeliveryOrderHeaderId= " + item + @" 
ORDER BY L.SaleDeliveryOrderLineId";



            ListofQuery QryMain = new ListofQuery();
            QryMain.Query = QueryMain;
            QryMain.QueryName = nameof(QueryMain);
            DocumentPrintData.Add(QryMain);


            return DocumentPrintData;

        }

        public ActionResult GetCustomPerson(string searchTerm, int pageSize, int pageNum, int filter)//DocTypeId
        {
            var Query = _SaleDeliveryOrderHeaderService.GetCustomPerson(filter, searchTerm);
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
            int SaleOrderQtyAmd = (new SaleDeliveryOrderLineService(_unitOfWork).GetSaleDeliveryOrderLineList(id)).Count();
            if (SaleOrderQtyAmd == 0)
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


    }
}
