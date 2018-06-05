﻿using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Infrastructure;
using Model.Models;

using Core.Common;
using System;
using Model;
using System.Threading.Tasks;
using Data.Models;
using Model.ViewModel;
using System.Data.Entity.SqlServer;
using Model.ViewModels;

namespace Service
{
    public interface ISaleInvoiceReturnHeaderService : IDisposable
    {
        SaleInvoiceReturnHeader Create(SaleInvoiceReturnHeader pt);
        void Delete(int id);
        void Delete(SaleInvoiceReturnHeader pt);
        SaleInvoiceReturnHeader Find(string Name);
        SaleInvoiceReturnHeader Find(int id);
        
        IEnumerable<SaleInvoiceReturnHeader> GetPagedList(int pageNumber, int pageSize, out int totalRecords);
        void Update(SaleInvoiceReturnHeader pt);
        SaleInvoiceReturnHeader Add(SaleInvoiceReturnHeader pt);
        SaleInvoiceReturnHeaderViewModel GetSaleInvoiceReturnHeader(int id);//HeadeRId
        IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnHeaderList(int id, string Uname);
        IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnPendingToSubmit(int id, string Uname);
        IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnPendingToReview(int id, string Uname);
        Task<IEquatable<SaleInvoiceReturnHeader>> GetAsync();
        Task<SaleInvoiceReturnHeader> FindAsync(int id);
        int NextId(int id);
        int PrevId(int id);
        string GetMaxDocNo();
        IQueryable<ComboBoxResult> GetCustomPerson(int Id, string term);
        string GetNarration(int SaleInvoiceReturnHeaderId);
    }

    public class SaleInvoiceReturnHeaderService : ISaleInvoiceReturnHeaderService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWorkForService _unitOfWork;
        private readonly Repository<SaleInvoiceReturnHeader> _SaleInvoiceReturnHeaderRepository;
        RepositoryQuery<SaleInvoiceReturnHeader> SaleInvoiceReturnHeaderRepository;
        public SaleInvoiceReturnHeaderService(IUnitOfWorkForService unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _SaleInvoiceReturnHeaderRepository = new Repository<SaleInvoiceReturnHeader>(db);
            SaleInvoiceReturnHeaderRepository = new RepositoryQuery<SaleInvoiceReturnHeader>(_SaleInvoiceReturnHeaderRepository);
        }

        public SaleInvoiceReturnHeader Find(string Name)
        {
            return SaleInvoiceReturnHeaderRepository.Get().Where(i => i.DocNo == Name).FirstOrDefault();
        }


        public SaleInvoiceReturnHeader Find(int id)
        {
            return _unitOfWork.Repository<SaleInvoiceReturnHeader>().Find(id);
        }       

        public SaleInvoiceReturnHeader Create(SaleInvoiceReturnHeader pt)
        {
            pt.ObjectState = ObjectState.Added;
            _unitOfWork.Repository<SaleInvoiceReturnHeader>().Insert(pt);
            return pt;
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<SaleInvoiceReturnHeader>().Delete(id);
        }

        public void Delete(SaleInvoiceReturnHeader pt)
        {
            _unitOfWork.Repository<SaleInvoiceReturnHeader>().Delete(pt);
        }

        public void Update(SaleInvoiceReturnHeader pt)
        {
            pt.ObjectState = ObjectState.Modified;
            _unitOfWork.Repository<SaleInvoiceReturnHeader>().Update(pt);
        }

        public IEnumerable<SaleInvoiceReturnHeader> GetPagedList(int pageNumber, int pageSize, out int totalRecords)
        {
            var so = _unitOfWork.Repository<SaleInvoiceReturnHeader>()
                .Query()
                .OrderBy(q => q.OrderBy(c => c.DocNo))
                .GetPage(pageNumber, pageSize, out totalRecords);

            return so;
        }
        public SaleInvoiceReturnHeaderViewModel GetSaleInvoiceReturnHeader(int id)
        {
            return (from H in db.SaleInvoiceReturnHeader
                    where H.SaleInvoiceReturnHeaderId == id
                    select new SaleInvoiceReturnHeaderViewModel
                    {
                        SaleInvoiceReturnHeaderId = H.SaleInvoiceReturnHeaderId,
                        DivisionId = H.DivisionId,
                        DocNo = H.DocNo,
                        DocDate = H.DocDate,
                        DocTypeId = H.DocTypeId,
                        Remark = H.Remark,
                        SiteId = H.SiteId,
                        SaleDispatchReturnHeaderId=H.SaleDispatchReturnHeaderId,
                        Status = H.Status,
                        BuyerId = H.BuyerId,  
                        GodownId = H.SaleDispatchReturnHeader.GodownId,
                        SalesTaxGroupPersonId = H.SalesTaxGroupPersonId,
                        //SalesTaxGroupId=H.SalesTaxGroupId,
                        Nature = H.Nature,
                        //CurrencyId=H.CurrencyId,
                        ReasonId=H.ReasonId,
                        ModifiedBy=H.ModifiedBy,
                        CreatedDate=H.CreatedDate,
                    }).FirstOrDefault();
        }
        public IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnHeaderList(int id, string Uname)
        {
            var DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];
            var SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
            List<string> UserRoles = (List<string>)System.Web.HttpContext.Current.Session["Roles"];



            var SaleInvoiceList = (from L in db.SaleInvoiceReturnLine
                                   where L.SaleInvoiceReturnHeader.SiteId == SiteId && L.SaleInvoiceReturnHeader.DivisionId == DivisionId && L.SaleInvoiceReturnHeader.DocTypeId == id
                                   group new { L } by new { L.SaleInvoiceReturnHeaderId } into Result
                                   select new
                                   {
                                       SaleInvoiceReturnHeaderId = Result.Key.SaleInvoiceReturnHeaderId,
                                       SaleInvoiceDocNo = Result.Max(i => i.L.SaleInvoiceLine.SaleInvoiceHeader.DocNo)
                                   });


            var pt = (from p in db.SaleInvoiceReturnHeader
                      join t3 in db._Users on p.ModifiedBy equals t3.UserName into table3
                      from tab3 in table3.DefaultIfEmpty()
                      join t in db.DocumentType on p.DocTypeId equals t.DocumentTypeId into table
                      from tab in table.DefaultIfEmpty()
                      join t1 in db.Persons on p.BuyerId equals t1.PersonID into table2
                      from tab2 in table2.DefaultIfEmpty()
                      join Sil in SaleInvoiceList on p.SaleInvoiceReturnHeaderId equals Sil.SaleInvoiceReturnHeaderId into SaleInvoiceListTable
                      from SaleInvoiceListTab in SaleInvoiceListTable.DefaultIfEmpty()
                      orderby p.DocDate descending, p.DocNo descending
                      where p.SiteId == SiteId && p.DivisionId == DivisionId && p.DocTypeId == id 
                      select new SaleInvoiceReturnHeaderViewModel
                      {
                          DocDate = p.DocDate,
                          DocNo = p.DocNo,
                          DocTypeName = tab.DocumentTypeName,
                          SaleInvoiceReturnHeaderId = p.SaleInvoiceReturnHeaderId,
                          Remark = p.Remark,
                          Status = p.Status,
                          BuyerName = tab2.Name,
                          ModifiedBy = p.ModifiedBy,
                          FirstName = tab3.FirstName,
                          ReviewCount = p.ReviewCount,
                          ReviewBy = p.ReviewBy,
                          Reviewed = (SqlFunctions.CharIndex(Uname, p.ReviewBy) > 0),
                          SaleInvoiceDocNo = SaleInvoiceListTab.SaleInvoiceDocNo
                      });
            return pt;
        }

        public SaleInvoiceReturnHeader Add(SaleInvoiceReturnHeader pt)
        {
            _unitOfWork.Repository<SaleInvoiceReturnHeader>().Insert(pt);
            return pt;
        }

        public int NextId(int id)
        {
            int temp = 0;
            if (id != 0)
            {
                temp = (from p in db.SaleInvoiceReturnHeader
                        orderby p.DocDate descending, p.DocNo descending
                        select p.SaleInvoiceReturnHeaderId).AsEnumerable().SkipWhile(p => p != id).Skip(1).FirstOrDefault();
            }
            else
            {
                temp = (from p in db.SaleInvoiceReturnHeader
                        orderby p.DocDate descending, p.DocNo descending
                        select p.SaleInvoiceReturnHeaderId).FirstOrDefault();
            }
            if (temp != 0)
                return temp;
            else
                return id;
        }

        public int PrevId(int id)
        {

            int temp = 0;
            if (id != 0)
            {

                temp = (from p in db.SaleInvoiceReturnHeader
                        orderby p.DocDate descending, p.DocNo descending
                        select p.SaleInvoiceReturnHeaderId).AsEnumerable().TakeWhile(p => p != id).LastOrDefault();
            }
            else
            {
                temp = (from p in db.SaleInvoiceReturnHeader
                        orderby p.DocDate descending, p.DocNo descending
                        select p.SaleInvoiceReturnHeaderId).AsEnumerable().LastOrDefault();
            }
            if (temp != 0)
                return temp;
            else
                return id;
        }

        public string GetMaxDocNo()
        {
            int x;
            var maxVal = _unitOfWork.Repository<SaleInvoiceReturnHeader>().Query().Get().Select(i => i.DocNo).DefaultIfEmpty().ToList().Select(sx => int.TryParse(sx, out x) ? x : 0).Max();
            return (maxVal + 1).ToString();
        }

        public IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnPendingToSubmit(int id, string Uname)
        {

            List<string> UserRoles = (List<string>)System.Web.HttpContext.Current.Session["Roles"];
            var SaleInvoiceReturnHeader = GetSaleInvoiceReturnHeaderList(id, Uname).AsQueryable();

            var PendingToSubmit = from p in SaleInvoiceReturnHeader
                                  where p.Status == (int)StatusConstants.Drafted || p.Status == (int)StatusConstants.Modified && (p.ModifiedBy == Uname || UserRoles.Contains("Admin"))
                                  select p;
            return PendingToSubmit;

        }

        public IQueryable<SaleInvoiceReturnHeaderViewModel> GetSaleInvoiceReturnPendingToReview(int id, string Uname)
        {

            List<string> UserRoles = (List<string>)System.Web.HttpContext.Current.Session["Roles"];
            var SaleInvoiceReturnHeader = GetSaleInvoiceReturnHeaderList(id, Uname).AsQueryable();

            var PendingToReview = from p in SaleInvoiceReturnHeader
                                   where p.Status == (int)StatusConstants.Submitted && (SqlFunctions.CharIndex(Uname, (p.ReviewBy ?? "")) == 0)
                                   select p;
            return PendingToReview;

        }

        public IQueryable<ComboBoxResult> GetCustomPerson(int Id, string term)
        {
            int DocTypeId = Id;
            int SiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
            int DivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];

            var settings = new SaleInvoiceSettingService(_unitOfWork).GetSaleInvoiceSettingForDocument(DocTypeId, DivisionId, SiteId);

            string[] PersonRoles = null;
            if (!string.IsNullOrEmpty(settings.filterPersonRoles)) { PersonRoles = settings.filterPersonRoles.Split(",".ToCharArray()); }
            else { PersonRoles = new string[] { "NA" }; }

            string DivIdStr = "|" + DivisionId.ToString() + "|";
            string SiteIdStr = "|" + SiteId.ToString() + "|";

            var list = (from p in db.Persons
                        join bus in db.BusinessEntity on p.PersonID equals bus.PersonID into BusinessEntityTable
                        from BusinessEntityTab in BusinessEntityTable.DefaultIfEmpty()
                        join pp in db.PersonProcess on p.PersonID equals pp.PersonId into PersonProcessTable
                        from PersonProcessTab in PersonProcessTable.DefaultIfEmpty()
                        join pr in db.PersonRole on p.PersonID equals pr.PersonId into PersonRoleTable
                        from PersonRoleTab in PersonRoleTable.DefaultIfEmpty()
                        where PersonProcessTab.ProcessId == settings.ProcessId
                        && (string.IsNullOrEmpty(term) ? 1 == 1 : (p.Name.ToLower().Contains(term.ToLower()) || p.Code.ToLower().Contains(term.ToLower())))
                        && (string.IsNullOrEmpty(settings.filterPersonRoles) ? 1 == 1 : PersonRoles.Contains(PersonRoleTab.RoleDocTypeId.ToString()))
                        && BusinessEntityTab.DivisionIds.IndexOf(DivIdStr) != -1
                        && BusinessEntityTab.SiteIds.IndexOf(SiteIdStr) != -1
                        && (p.IsActive == null ? 1 == 1 : p.IsActive == true)
                        group new { p } by new { p.PersonID } into Result
                        orderby Result.Max(m => m.p.Name)
                        select new ComboBoxResult
                        {
                            id = Result.Key.PersonID.ToString(),
                            text = Result.Max(m => m.p.Name + ", " + m.p.Suffix + " [" + m.p.Code + "]"),
                        }
              );

            return list;
        }

        public void Dispose()
        {
        }


        public Task<IEquatable<SaleInvoiceReturnHeader>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SaleInvoiceReturnHeader> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public string GetNarration(int SaleInvoiceReturnHeaderId)
        {
            string Narration = "";

            var SaleInvoiceReturnHeader_Data = (from H in db.SaleInvoiceReturnHeader
                                                join L in db.SaleInvoiceReturnLine on H.SaleInvoiceReturnHeaderId equals L.SaleInvoiceReturnHeaderId into SaleInvoiceReturnLineTable
                                                from SaleInvoiceReturnLineTab in SaleInvoiceReturnLineTable.DefaultIfEmpty()
                                                join P in db.Persons on H.BuyerId equals P.PersonID into PersonTable from PersonTab in PersonTable.DefaultIfEmpty()
                                                where H.SaleInvoiceReturnHeaderId == SaleInvoiceReturnHeaderId
                                                select new
                                                {
                                                    DocTypeId = H.DocTypeId,
                                                    SaleToBuyerName = PersonTab.Name,
                                                    InvoiceNo = SaleInvoiceReturnLineTab.SaleInvoiceLine.SaleInvoiceHeader.DocNo,
                                                    ProductName = SaleInvoiceReturnLineTab.SaleInvoiceLine.SaleDispatchLine.PackingLine.Product.ProductName,
                                                    ProductGroupName = SaleInvoiceReturnLineTab.SaleInvoiceLine.SaleDispatchLine.PackingLine.Product.ProductGroup.ProductGroupName,
                                                    ProductUidName = SaleInvoiceReturnLineTab.SaleInvoiceLine.SaleDispatchLine.PackingLine.ProductUid.ProductUidName,
                                                    Qty = SaleInvoiceReturnLineTab.Qty,
                                                    Rate = SaleInvoiceReturnLineTab.Rate,
                                                    Amount = SaleInvoiceReturnLineTab.Amount,
                                                }).FirstOrDefault();

            var SaleInvoiceReturnHeaderCharges_Data = (from Hc in db.SaleInvoiceReturnHeaderCharge
                                                       where Hc.HeaderTableId == SaleInvoiceReturnHeaderId
                                                       && Hc.Charge.ChargeName == "Net Amount"
                                                       select new
                                                       {
                                                           NetAmount = Hc.Amount
                                                       }).FirstOrDefault();



            if (SaleInvoiceReturnHeader_Data != null)
            {
                var Narration_Temp = (from H in db.Narration where H.DocTypeId == SaleInvoiceReturnHeader_Data.DocTypeId select new { Narration = H.NarrationName }).FirstOrDefault();

                if (Narration_Temp != null)
                    Narration = Narration_Temp.Narration.Replace("<CustomerName>", SaleInvoiceReturnHeader_Data.SaleToBuyerName)
                                            .Replace("<InvoiceNo>", SaleInvoiceReturnHeader_Data.InvoiceNo)
                                            .Replace("<ProductName>", SaleInvoiceReturnHeader_Data.ProductName)
                                            .Replace("<ProductGroupName>", SaleInvoiceReturnHeader_Data.ProductGroupName)
                                            .Replace("<ProductUidName>", SaleInvoiceReturnHeader_Data.ProductUidName)
                                            .Replace("<Qty>", SaleInvoiceReturnHeader_Data.Qty.ToString())
                                            .Replace("<Rate>", SaleInvoiceReturnHeader_Data.Rate.ToString())
                                            .Replace("<Amount>", SaleInvoiceReturnHeader_Data.Amount.ToString())
                                            .Replace("<NetAmount>", SaleInvoiceReturnHeaderCharges_Data.NetAmount.ToString());
            }
            return Narration;
        }
    }
}