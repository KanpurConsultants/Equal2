using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using Model.Models;
using Data.Models;
using System.Collections;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Jobs.Constants.DocumentType;
using Jobs.Constants.DocumentCategory;
using Jobs.Constants.Menu;
using Jobs.Constants.Module;
using Jobs.Constants.SubModule;
using Jobs.Constants.DocumentNature;
using Jobs.Constants.Site;
using Jobs.Constants.Division;
using Jobs.Constants.Company;
using Jobs.Constants.Godown;
using Jobs.Constants.Country;
using Jobs.Constants.State;
using Jobs.Constants.City;
using Jobs.Constants.CompanySetting;
using Jobs.Constants.LedgerAccountGroup;
using Jobs.Constants.LedgerAccount;
using Jobs.Constants.ChargeType;
using Jobs.Constants.Charge;
using Jobs.Constants.Unit;
using Jobs.Constants.Currency;
using Jobs.Constants.ChargeGroupSetting;
using Jobs.Constants.ChargeGroupPerson;
using Jobs.Constants.TdsGroup;
using Jobs.Constants.TdsCategory;
using Jobs.Constants.TdsRate;
using Jobs.Constants.ChargeGroupProduct;
using Jobs.Constants.Department;
using Jobs.Constants.Designation;
using Jobs.Constants.ShipMethod;
using Jobs.Constants.Calculation;
using Jobs.Constants.CalculationFooter;
using Jobs.Constants.CalculationProduct;
using Jobs.Constants.PersonContactType;
using Jobs.Constants.Process;
using Jobs.Constants.DeliveryTerms;
using Jobs.Constants.ProductNature;
using Jobs.Constants.ProductType;
using Jobs.Constants.ActivityTypes;
using Jobs.Constants.PersonSetting;
using Jobs.Constants.ControllerAction;
using Jobs.Constants.UnitConversionFor;
using Jobs.Constants.ProductSizeTypes;
using Jobs.Constants.ProductDesign;
using Jobs.Constants.ProductShape;
using Jobs.Constants.ProductGroup;

namespace Data.Models
{
    public class InitializeTables
    {
        string mQry = "";
        ApplicationDbContext db = new ApplicationDbContext();
        public UserManager<IdentityUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }

        public InitializeTables()
        {
        }
        public void InsertData()
        {
            InsertActivityTypes();
            InsertDocumentNature();
            InsertDocumentCategories();
            InsertDocumentTypes();
            InsertControllerActions();
            InsertModules();
            InsertSubModules();
            InsertMenus();
            InsertCountry();
            InsertState();
            InsertCity();
            InsertSite();
            InsertCompany();
            InsertCompanySetting();
            InsertDivision();
            InsertGodown();
            InsertLedgerAccountGroup();
            InsertLedgerAccount();
            InsertUnit();
            InsertUnitConversionFor();
            InsertCurrency();
            InsertProcess();
            InsertTdsGroup();
            InsertTdsCategory();
            InsertTdsRate();
            InsertDepartment();
            InsertDesignation();
            InsertShipMethod();
            InsertDeliveryTerms();
            InsertPersonContactType();
            InsertProductNature();
            InsertProductShape();
            InsertProductType();
            InsertProductGroup();
            InsertChargeType();
            InsertCharge();
            InsertChargeGroupPerson();
            InsertChargeGroupProduct();
            InsertChargeGroupSetting();
            InsertCalculation();
            InsertCalculationProduct();
            InsertCalculationFooter();
            InsertPersonSetting();
            InitializeUserTables(db);
            InitializePersonTables(db);

            //Only For Carpet Industry
            InsertProductSizeTypes();
            InsertProductDesign();

            InitializeSettingsTables(db);
            InitializeProcedure(db);
            InitializeFunction(db);
            InitializeSqlViews(db);
        }
        public void InsertActivityTypes()
        {
            try
            {
                Type ActivityTypesConstantsType = typeof(ActivityTypesConstants);

                System.Type[] ChildClassCollection = ActivityTypesConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ActivityTypeId = (int)ChildClass.GetField("ActivityTypeId").GetRawConstantValue();
                    if (db.ActivityType.Find(ActivityTypeId) == null)
                    {
                        ActivityType ActivityType = new ActivityType();
                        ActivityType.ActivityTypeId  = (int)ChildClass.GetField("ActivityTypeId").GetRawConstantValue();
                        ActivityType.ActivityTypeName = (string)ChildClass.GetField("ActivityTypeName").GetRawConstantValue();
                        ActivityType.CreatedBy = "System";
                        ActivityType.ModifiedBy = "System";
                        ActivityType.CreatedDate = System.DateTime.Now;
                        ActivityType.ModifiedDate = System.DateTime.Now;
                        ActivityType.ObjectState = Model.ObjectState.Added;
                        db.ActivityType.Add(ActivityType);
                    }
                    else
                    {
                        ActivityType ActivityType = db.ActivityType.Find(ActivityTypeId);
                        ActivityType.ActivityTypeName = (string)ChildClass.GetField("ActivityTypeName").GetRawConstantValue();
                        ActivityType.ModifiedBy = "System";
                        ActivityType.ModifiedDate = System.DateTime.Now;
                        ActivityType.ObjectState = Model.ObjectState.Modified;
                        db.ActivityType.Add(ActivityType);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductSizeTypes()
        {
            try
            {
                Type ProductSizeTypesConstantsType = typeof(ProductSizeTypesConstants);

                System.Type[] ChildClassCollection = ProductSizeTypesConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductSizeTypeId = (int)ChildClass.GetField("ProductSizeTypeId").GetRawConstantValue();
                    if (db.ProductSizeType.Find(ProductSizeTypeId) == null)
                    {
                        ProductSizeType ProductSizeType = new ProductSizeType();
                        ProductSizeType.ProductSizeTypeId = (int)ChildClass.GetField("ProductSizeTypeId").GetRawConstantValue();
                        ProductSizeType.ProductSizeTypeName = (string)ChildClass.GetField("ProductSizeTypeName").GetRawConstantValue();
                        ProductSizeType.CreatedBy = "System";
                        ProductSizeType.ModifiedBy = "System";
                        ProductSizeType.CreatedDate = System.DateTime.Now;
                        ProductSizeType.ModifiedDate = System.DateTime.Now;
                        ProductSizeType.ObjectState = Model.ObjectState.Added;
                        db.ProductSizeType.Add(ProductSizeType);
                    }
                    else
                    {
                        ProductSizeType ProductSizeType = db.ProductSizeType.Find(ProductSizeTypeId);
                        ProductSizeType.ProductSizeTypeName = (string)ChildClass.GetField("ProductSizeTypeName").GetRawConstantValue();
                        ProductSizeType.ModifiedBy = "System";
                        ProductSizeType.ModifiedDate = System.DateTime.Now;
                        ProductSizeType.ObjectState = Model.ObjectState.Modified;
                        db.ProductSizeType.Add(ProductSizeType);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductDesign()
        {
            try
            {
                Type ProductDesignConstantsType = typeof(ProductDesignConstants);

                System.Type[] ChildClassCollection = ProductDesignConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductDesignId = (int)ChildClass.GetField("ProductDesignId").GetRawConstantValue();
                    if (db.ProductDesigns.Find(ProductDesignId) == null)
                    {
                        ProductDesign ProductDesign = new ProductDesign();
                        ProductDesign.ProductDesignId = (int)ChildClass.GetField("ProductDesignId").GetRawConstantValue();
                        ProductDesign.ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                        ProductDesign.ProductDesignName = (string)ChildClass.GetField("ProductDesignName").GetRawConstantValue();
                        ProductDesign.CreatedBy = "System";
                        ProductDesign.ModifiedBy = "System";
                        ProductDesign.CreatedDate = System.DateTime.Now;
                        ProductDesign.ModifiedDate = System.DateTime.Now;
                        ProductDesign.ObjectState = Model.ObjectState.Added;
                        db.ProductDesigns.Add(ProductDesign);
                    }
                    else
                    {
                        ProductDesign ProductDesign = db.ProductDesigns.Find(ProductDesignId);
                        ProductDesign.ProductDesignName = (string)ChildClass.GetField("ProductDesignName").GetRawConstantValue();
                        ProductDesign.ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                        ProductDesign.ModifiedBy = "System";
                        ProductDesign.ModifiedDate = System.DateTime.Now;
                        ProductDesign.ObjectState = Model.ObjectState.Modified;
                        db.ProductDesigns.Add(ProductDesign);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDocumentNature()
        {
            try
            {
                Type DocumentNatureConstantsType = typeof(DocumentNatureConstants);

                System.Type[] ChildClassCollection = DocumentNatureConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DocumentNatureId = (int)ChildClass.GetField("DocumentNatureId").GetRawConstantValue();
                    if (db.DocumentNature.Find(DocumentNatureId) == null)
                    {
                        DocumentNature DocumentNature = new DocumentNature();
                        DocumentNature.DocumentNatureId = (int)ChildClass.GetField("DocumentNatureId").GetRawConstantValue();
                        DocumentNature.DocumentNatureName = (string)ChildClass.GetField("DocumentNatureName").GetRawConstantValue();
                        DocumentNature.IsActive = true;
                        DocumentNature.IsSystemDefine = true;
                        DocumentNature.ObjectState = Model.ObjectState.Added;
                        db.DocumentNature.Add(DocumentNature);
                    }
                    else
                    {
                        DocumentNature DocumentNature = db.DocumentNature.Find(DocumentNatureId);
                        DocumentNature.DocumentNatureName = (string)ChildClass.GetField("DocumentNatureName").GetRawConstantValue();
                        DocumentNature.IsActive = true;
                        DocumentNature.IsSystemDefine = true;
                        DocumentNature.ObjectState = Model.ObjectState.Modified;
                        db.DocumentNature.Add(DocumentNature);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDocumentCategories()
        {
            try
            {
                Type DocumentCategoryConstantsType = typeof(DocumentCategoryConstants);

                System.Type[] ChildClassCollection = DocumentCategoryConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DocumentCategoryId = (int)ChildClass.GetField("DocumentCategoryId").GetRawConstantValue();
                    if (db.DocumentCategory.Find(DocumentCategoryId) == null)
                    {
                        DocumentCategory DocumentCategory = new DocumentCategory();
                        DocumentCategory.DocumentCategoryId = (int)ChildClass.GetField("DocumentCategoryId").GetRawConstantValue();
                        DocumentCategory.DocumentCategoryName = (string)ChildClass.GetField("DocumentCategoryName").GetRawConstantValue();
                        DocumentCategory.IsActive = true;
                        DocumentCategory.IsSystemDefine = true;
                        DocumentCategory.ObjectState = Model.ObjectState.Added;
                        db.DocumentCategory.Add(DocumentCategory);
                    }
                    else
                    {
                        DocumentCategory DocumentCategory = db.DocumentCategory.Find(DocumentCategoryId);
                        DocumentCategory.DocumentCategoryName = (string)ChildClass.GetField("DocumentCategoryName").GetRawConstantValue();
                        DocumentCategory.IsActive = true;
                        DocumentCategory.IsSystemDefine = true;
                        DocumentCategory.ObjectState = Model.ObjectState.Modified;
                        db.DocumentCategory.Add(DocumentCategory);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDocumentTypes()
        {
            try
            {
                Type DocumentTypeConstantsType = typeof(DocumentTypeConstants);

                System.Type[] ChildClassCollection = DocumentTypeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DocumentTypeId = (int)ChildClass.GetField("DocumentTypeId").GetRawConstantValue();

                    if (db.DocumentType.Find(DocumentTypeId) == null)
                    {
                        DocumentType DocumentType = new DocumentType();
                        DocumentType.DocumentTypeId = (int)ChildClass.GetField("DocumentTypeId").GetRawConstantValue();
                        DocumentType.DocumentTypeShortName = (string)ChildClass.GetField("DocumentTypeShortName").GetRawConstantValue();
                        DocumentType.DocumentTypeName = (string)ChildClass.GetField("DocumentTypeName").GetRawConstantValue();
                        DocumentType.DocumentCategoryId = (int)ChildClass.GetField("DocumentCategoryId").GetRawConstantValue();
                        DocumentType.DocumentNatureId = (int)ChildClass.GetField("DocumentNatureId").GetRawConstantValue();
                        DocumentType.Nature = (string)ChildClass.GetField("Nature").GetRawConstantValue();
                        DocumentType.PrintTitle = (string)ChildClass.GetField("PrintTitle").GetRawConstantValue();
                        DocumentType.IsActive = true;
                        DocumentType.IsSystemDefine = true;
                        DocumentType.CreatedBy = "System";
                        DocumentType.ModifiedBy = "System";
                        DocumentType.CreatedDate = System.DateTime.Now;
                        DocumentType.ModifiedDate = System.DateTime.Now;
                        DocumentType.ObjectState = Model.ObjectState.Added;
                        db.DocumentType.Add(DocumentType);
                    }
                    else
                    {
                        DocumentType DocumentType = db.DocumentType.Find(DocumentTypeId);
                        DocumentType.DocumentTypeShortName = (string)ChildClass.GetField("DocumentTypeShortName").GetRawConstantValue();
                        DocumentType.DocumentTypeName = (string)ChildClass.GetField("DocumentTypeName").GetRawConstantValue();
                        DocumentType.DocumentCategoryId = (int)ChildClass.GetField("DocumentCategoryId").GetRawConstantValue();
                        DocumentType.DocumentNatureId = (int)ChildClass.GetField("DocumentNatureId").GetRawConstantValue();
                        DocumentType.Nature = (string)ChildClass.GetField("Nature").GetRawConstantValue();
                        DocumentType.PrintTitle = (string)ChildClass.GetField("PrintTitle").GetRawConstantValue();
                        DocumentType.IsActive = true;
                        DocumentType.IsSystemDefine = true;
                        DocumentType.ModifiedBy = "System";
                        DocumentType.ModifiedDate = System.DateTime.Now;
                        DocumentType.ObjectState = Model.ObjectState.Modified;
                        db.DocumentType.Add(DocumentType);
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertControllerActions()
        {
            try
            {
                Type ControllerActionConstantsType = typeof(ControllerActionConstants);

                System.Type[] ChildClassCollection = ControllerActionConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ControllerActionId = (int)ChildClass.GetField("ControllerActionId").GetRawConstantValue();

                    if (db.ControllerAction.Find(ControllerActionId) == null)
                    {
                        ControllerAction ControllerAction = new ControllerAction();
                        ControllerAction.ControllerActionId = (int)ChildClass.GetField("ControllerActionId").GetRawConstantValue();
                        ControllerAction.ControllerName = (string)ChildClass.GetField("ControllerName").GetRawConstantValue();
                        ControllerAction.ActionName = (string)ChildClass.GetField("ActionName").GetRawConstantValue();
                        ControllerAction.CreatedBy = "System";
                        ControllerAction.ModifiedBy = "System";
                        ControllerAction.CreatedDate = System.DateTime.Now;
                        ControllerAction.ModifiedDate = System.DateTime.Now;
                        ControllerAction.ObjectState = Model.ObjectState.Added;
                        db.ControllerAction.Add(ControllerAction);
                    }
                    else
                    {
                        ControllerAction ControllerAction = db.ControllerAction.Find(ControllerActionId);
                        ControllerAction.ControllerName = (string)ChildClass.GetField("ControllerName").GetRawConstantValue();
                        ControllerAction.ActionName = (string)ChildClass.GetField("ActionName").GetRawConstantValue();
                        ControllerAction.ModifiedBy = "System";
                        ControllerAction.ModifiedDate = System.DateTime.Now;
                        ControllerAction.ObjectState = Model.ObjectState.Modified;
                        db.ControllerAction.Add(ControllerAction);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertModules()
        {
            try
            {
                Type ModuleConstantsType = typeof(ModuleConstants);

                System.Type[] ChildClassCollection = ModuleConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ModuleId = (int)ChildClass.GetField("ModuleId").GetRawConstantValue();

                    if (db.MenuModule.Find(ModuleId) == null)
                    {
                        MenuModule Module = new MenuModule();
                        Module.ModuleId = (int)ChildClass.GetField("ModuleId").GetRawConstantValue();
                        Module.ModuleName = (string)ChildClass.GetField("ModuleName").GetRawConstantValue();
                        Module.Srl = (int)ChildClass.GetField("Srl").GetRawConstantValue();
                        Module.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        Module.IsActive = true;
                        Module.CreatedBy = "System";
                        Module.ModifiedBy = "System";
                        Module.CreatedDate = System.DateTime.Now;
                        Module.ModifiedDate = System.DateTime.Now;
                        Module.ObjectState = Model.ObjectState.Added;
                        db.MenuModule.Add(Module);
                    }
                    else
                    {
                        MenuModule Module = db.MenuModule.Find(ModuleId);
                        Module.ModuleName = (string)ChildClass.GetField("ModuleName").GetRawConstantValue();
                        Module.Srl = (int)ChildClass.GetField("Srl").GetRawConstantValue();
                        Module.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        Module.IsActive = true;
                        Module.ModifiedBy = "System";
                        Module.ModifiedDate = System.DateTime.Now;
                        Module.ObjectState = Model.ObjectState.Modified;
                        db.MenuModule.Add(Module);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertSubModules()
        {
            try
            {
                Type SubModuleConstantsType = typeof(SubModuleConstants);

                System.Type[] ChildClassCollection = SubModuleConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int SubModuleId = (int)ChildClass.GetField("SubModuleId").GetRawConstantValue();

                    if (db.MenuSubModule.Find(SubModuleId) == null)
                    {
                        MenuSubModule SubModule = new MenuSubModule();
                        SubModule.SubModuleId = (int)ChildClass.GetField("SubModuleId").GetRawConstantValue();
                        SubModule.SubModuleName = (string)ChildClass.GetField("SubModuleName").GetRawConstantValue();
                        SubModule.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        SubModule.CreatedBy = "System";
                        SubModule.ModifiedBy = "System";
                        SubModule.CreatedDate = System.DateTime.Now;
                        SubModule.ModifiedDate = System.DateTime.Now;
                        SubModule.ObjectState = Model.ObjectState.Added;
                        db.MenuSubModule.Add(SubModule);
                    }
                    else
                    {
                        MenuSubModule SubModule = db.MenuSubModule.Find(SubModuleId);
                        SubModule.SubModuleName = (string)ChildClass.GetField("SubModuleName").GetRawConstantValue();
                        SubModule.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        SubModule.ModifiedBy = "System";
                        SubModule.ModifiedDate = System.DateTime.Now;
                        SubModule.ObjectState = Model.ObjectState.Modified;
                        db.MenuSubModule.Add(SubModule);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertMenus()
        {
            try
            {
                Type MenuConstantsType = typeof(MenuConstants);

                System.Type[] ChildClassCollection = MenuConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int MenuId = (int)ChildClass.GetField("MenuId").GetRawConstantValue();

                    if (db.Menu.Find(MenuId) == null)
                    {
                        Menu Menu = new Menu();
                        Menu.MenuId = (int)ChildClass.GetField("MenuId").GetRawConstantValue();
                        Menu.MenuName = (string)ChildClass.GetField("MenuName").GetRawConstantValue();
                        Menu.Srl = (string)ChildClass.GetField("Srl").GetRawConstantValue();
                        Menu.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        Menu.Description = (string)ChildClass.GetField("Description").GetRawConstantValue();
                        Menu.ModuleId = (int)ChildClass.GetField("ModuleId").GetRawConstantValue();
                        Menu.SubModuleId = (int)ChildClass.GetField("SubModuleId").GetRawConstantValue();
                        Menu.ControllerName = (string)ChildClass.GetField("ControllerName").GetRawConstantValue();
                        Menu.ActionName = (string)ChildClass.GetField("ActionName").GetRawConstantValue();
                        Menu.RouteId = (string)ChildClass.GetField("RouteId").GetValue("RouteId");
                        Menu.URL = (string)ChildClass.GetField("URL").GetRawConstantValue();
                        Menu.IsVisible = (bool)ChildClass.GetField("IsVisible").GetRawConstantValue();
                        Menu.AreaName = (string)ChildClass.GetField("AreaName").GetRawConstantValue();
                        Menu.CreatedBy = "System";
                        Menu.ModifiedBy = "System";
                        Menu.CreatedDate = System.DateTime.Now;
                        Menu.ModifiedDate = System.DateTime.Now;
                        Menu.ObjectState = Model.ObjectState.Added;
                        db.Menu.Add(Menu);
                    }
                    else
                    {
                        Menu Menu = db.Menu.Find(MenuId);
                        Menu.MenuName = (string)ChildClass.GetField("MenuName").GetRawConstantValue();
                        Menu.Srl = (string)ChildClass.GetField("Srl").GetRawConstantValue();
                        Menu.IconName = (string)ChildClass.GetField("IconName").GetRawConstantValue();
                        Menu.Description = (string)ChildClass.GetField("Description").GetRawConstantValue();
                        Menu.ModuleId = (int)ChildClass.GetField("ModuleId").GetRawConstantValue();
                        Menu.SubModuleId = (int)ChildClass.GetField("SubModuleId").GetRawConstantValue();
                        Menu.ControllerName = (string)ChildClass.GetField("ControllerName").GetRawConstantValue();
                        Menu.ActionName = (string)ChildClass.GetField("ActionName").GetRawConstantValue();
                        Menu.RouteId = (string)ChildClass.GetField("RouteId").GetValue("RouteId");
                        Menu.URL = (string)ChildClass.GetField("URL").GetRawConstantValue();
                        Menu.IsVisible = (bool)ChildClass.GetField("IsVisible").GetRawConstantValue();
                        Menu.AreaName = (string)ChildClass.GetField("AreaName").GetRawConstantValue();
                        Menu.ModifiedBy = "System";
                        Menu.ModifiedDate = System.DateTime.Now;
                        Menu.ObjectState = Model.ObjectState.Modified;
                        db.Menu.Add(Menu);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCountry()
        {
            try
            {
                Type CountryConstantsType = typeof(CountryConstants);

                System.Type[] ChildClassCollection = CountryConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CountryId = (int)ChildClass.GetField("CountryId").GetRawConstantValue();
                    if (db.Country.Find(CountryId) == null)
                    {
                        Country Country = new Country();
                        Country.CountryId = (int)ChildClass.GetField("CountryId").GetRawConstantValue();
                        Country.CountryName = (string)ChildClass.GetField("CountryName").GetRawConstantValue();
                        Country.IsActive = true;
                        Country.CreatedBy = "System";
                        Country.ModifiedBy = "System";
                        Country.CreatedDate = System.DateTime.Now;
                        Country.ModifiedDate = System.DateTime.Now;
                        Country.ObjectState = Model.ObjectState.Added;
                        db.Country.Add(Country);
                    }
                    else
                    {
                        Country Country = db.Country.Find(CountryId);
                        Country.CountryName = (string)ChildClass.GetField("CountryName").GetRawConstantValue();
                        Country.IsActive = true;
                        Country.ModifiedBy = "System";
                        Country.ModifiedDate = System.DateTime.Now;
                        Country.ObjectState = Model.ObjectState.Modified;
                        db.Country.Add(Country);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertState()
        {
            try
            {
                Type StateConstantsType = typeof(StateConstants);

                System.Type[] ChildClassCollection = StateConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int StateId = (int)ChildClass.GetField("StateId").GetRawConstantValue();
                    if (db.State.Find(StateId) == null)
                    {
                        State State = new State();
                        State.StateId = (int)ChildClass.GetField("StateId").GetRawConstantValue();
                        State.StateCode = (string)ChildClass.GetField("StateCode").GetRawConstantValue();
                        State.StateName = (string)ChildClass.GetField("StateName").GetRawConstantValue();
                        State.CountryId = (int)ChildClass.GetField("CountryId").GetRawConstantValue();
                        State.IsActive = true;
                        State.CreatedBy = "System";
                        State.ModifiedBy = "System";
                        State.CreatedDate = System.DateTime.Now;
                        State.ModifiedDate = System.DateTime.Now;
                        State.ObjectState = Model.ObjectState.Added;
                        db.State.Add(State);
                    }
                    else
                    {
                        State State = db.State.Find(StateId);
                        State.StateName = (string)ChildClass.GetField("StateName").GetRawConstantValue();
                        State.StateCode = (string)ChildClass.GetField("StateCode").GetRawConstantValue();
                        State.CountryId = (int)ChildClass.GetField("CountryId").GetRawConstantValue();
                        State.IsActive = true;
                        State.ModifiedBy = "System";
                        State.ModifiedDate = System.DateTime.Now;
                        State.ObjectState = Model.ObjectState.Modified;
                        db.State.Add(State);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCity()
        {
            try
            {
                Type CityConstantsType = typeof(CityConstants);

                System.Type[] ChildClassCollection = CityConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CityId = (int)ChildClass.GetField("CityId").GetRawConstantValue();
                    if (db.City.Find(CityId) == null)
                    {
                        City City = new City();
                        City.CityId = (int)ChildClass.GetField("CityId").GetRawConstantValue();
                        City.CityName = (string)ChildClass.GetField("CityName").GetRawConstantValue();
                        City.StateId = (int)ChildClass.GetField("StateId").GetRawConstantValue();
                        City.IsActive = true;
                        City.CreatedBy = "System";
                        City.ModifiedBy = "System";
                        City.CreatedDate = System.DateTime.Now;
                        City.ModifiedDate = System.DateTime.Now;
                        City.ObjectState = Model.ObjectState.Added;
                        db.City.Add(City);
                    }
                    else
                    {
                        City City = db.City.Find(CityId);
                        City.CityName = (string)ChildClass.GetField("CityName").GetRawConstantValue();
                        City.StateId = (int)ChildClass.GetField("StateId").GetRawConstantValue();
                        City.IsActive = true;
                        City.ModifiedBy = "System";
                        City.ModifiedDate = System.DateTime.Now;
                        City.ObjectState = Model.ObjectState.Modified;
                        db.City.Add(City);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertSite()
        {
            try
            {
                Type SiteConstantsType = typeof(SiteConstants);

                System.Type[] ChildClassCollection = SiteConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int SiteId = (int)ChildClass.GetField("SiteId").GetRawConstantValue();
                    if (db.Site.Find(SiteId) == null)
                    {
                        Site Site = new Site();
                        Site.SiteId = (int)ChildClass.GetField("SiteId").GetRawConstantValue();
                        Site.SiteName = (string)ChildClass.GetField("SiteName").GetRawConstantValue();
                        Site.SiteCode = (string)ChildClass.GetField("SiteCode").GetRawConstantValue();
                        Site.CityId = (int)ChildClass.GetField("CityId").GetRawConstantValue();
                        Site.IsActive = true;
                        Site.IsSystemDefine = true;
                        Site.CreatedBy = "System";
                        Site.ModifiedBy = "System";
                        Site.CreatedDate = System.DateTime.Now;
                        Site.ModifiedDate = System.DateTime.Now;
                        Site.ObjectState = Model.ObjectState.Added;
                        db.Site.Add(Site);
                    }
                    else
                    {
                        Site Site = db.Site.Find(SiteId);
                        Site.SiteName = (string)ChildClass.GetField("SiteName").GetRawConstantValue();
                        Site.SiteCode = (string)ChildClass.GetField("SiteCode").GetRawConstantValue();
                        Site.CityId = (int)ChildClass.GetField("CityId").GetRawConstantValue();
                        Site.IsActive = true;
                        Site.IsSystemDefine = true;
                        Site.ModifiedBy = "System";
                        Site.ModifiedDate = System.DateTime.Now;
                        Site.ObjectState = Model.ObjectState.Modified;
                        db.Site.Add(Site);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCompany()
        {
            try
            {
                Type CompanyConstantsType = typeof(CompanyConstants);

                System.Type[] ChildClassCollection = CompanyConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CompanyId = (int)ChildClass.GetField("CompanyId").GetRawConstantValue();
                    if (db.Company.Find(CompanyId) == null)
                    {
                        Company Company = new Company();
                        Company.CompanyId = (int)ChildClass.GetField("CompanyId").GetRawConstantValue();
                        Company.CompanyName = (string)ChildClass.GetField("CompanyName").GetRawConstantValue();
                        Company.CreatedBy = "System";
                        Company.ModifiedBy = "System";
                        Company.CreatedDate = System.DateTime.Now;
                        Company.ModifiedDate = System.DateTime.Now;
                        Company.ObjectState = Model.ObjectState.Added;
                        db.Company.Add(Company);
                    }
                    else
                    {
                        Company Company = db.Company.Find(CompanyId);
                        Company.CompanyName = (string)ChildClass.GetField("CompanyName").GetRawConstantValue();
                        Company.ModifiedBy = "System";
                        Company.ModifiedDate = System.DateTime.Now;
                        Company.ObjectState = Model.ObjectState.Modified;
                        db.Company.Add(Company);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCompanySetting()
        {
            try
            {
                Type CompanySettingConstantsType = typeof(CompanySettingConstants);

                System.Type[] ChildClassCollection = CompanySettingConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CompanySettingId = (int)ChildClass.GetField("CompanySettingsId").GetRawConstantValue();
                    if (db.CompanySettings.Find(CompanySettingId) == null)
                    {
                        CompanySettings CompanySetting = new CompanySettings();
                        CompanySetting.CompanyId = (int)ChildClass.GetField("CompanyId").GetRawConstantValue();
                        CompanySetting.isVisibleMessage = (bool)ChildClass.GetField("isVisibleMessage").GetRawConstantValue();
                        CompanySetting.isVisibleTask = (bool)ChildClass.GetField("isVisibleTask").GetRawConstantValue();
                        CompanySetting.isVisibleNotification = (bool)ChildClass.GetField("isVisibleNotification").GetRawConstantValue();
                        CompanySetting.isVisibleGodownSelection = (bool)ChildClass.GetField("isVisibleGodownSelection").GetRawConstantValue();
                        CompanySetting.isVisibleCompanyName = (bool)ChildClass.GetField("isVisibleCompanyName").GetRawConstantValue();
                        CompanySetting.SiteCaption = (string)ChildClass.GetField("SiteCaption").GetRawConstantValue();
                        CompanySetting.DivisionCaption = (string)ChildClass.GetField("DivisionCaption").GetRawConstantValue();
                        CompanySetting.GodownCaption = (string)ChildClass.GetField("GodownCaption").GetRawConstantValue();
                        CompanySetting.CreatedBy = "System";
                        CompanySetting.ModifiedBy = "System";
                        CompanySetting.CreatedDate = System.DateTime.Now;
                        CompanySetting.ModifiedDate = System.DateTime.Now;
                        CompanySetting.ObjectState = Model.ObjectState.Added;
                        db.CompanySettings.Add(CompanySetting);
                    }
                    else
                    {
                        CompanySettings CompanySetting = db.CompanySettings.Find(CompanySettingId);
                        CompanySetting.isVisibleMessage = (bool)ChildClass.GetField("isVisibleMessage").GetRawConstantValue();
                        CompanySetting.isVisibleTask = (bool)ChildClass.GetField("isVisibleTask").GetRawConstantValue();
                        CompanySetting.isVisibleNotification = (bool)ChildClass.GetField("isVisibleNotification").GetRawConstantValue();
                        CompanySetting.isVisibleGodownSelection = (bool)ChildClass.GetField("isVisibleGodownSelection").GetRawConstantValue();
                        CompanySetting.isVisibleCompanyName = (bool)ChildClass.GetField("isVisibleCompanyName").GetRawConstantValue();
                        CompanySetting.SiteCaption = (string)ChildClass.GetField("SiteCaption").GetRawConstantValue();
                        CompanySetting.DivisionCaption = (string)ChildClass.GetField("DivisionCaption").GetRawConstantValue();
                        CompanySetting.GodownCaption = (string)ChildClass.GetField("GodownCaption").GetRawConstantValue();
                        CompanySetting.ModifiedBy = "System";
                        CompanySetting.ModifiedDate = System.DateTime.Now;
                        CompanySetting.ObjectState = Model.ObjectState.Modified;
                        db.CompanySettings.Add(CompanySetting);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDivision()
        {
            try
            {
                Type DivisionConstantsType = typeof(DivisionConstants);

                System.Type[] ChildClassCollection = DivisionConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DivisionId = (int)ChildClass.GetField("DivisionId").GetRawConstantValue();
                    if (db.Divisions.Find(DivisionId) == null)
                    {
                        Division Division = new Division();
                        Division.DivisionId = (int)ChildClass.GetField("DivisionId").GetRawConstantValue();
                        Division.DivisionName = (string)ChildClass.GetField("DivisionName").GetRawConstantValue();
                        Division.CompanyId = (int)ChildClass.GetField("CompanyId").GetRawConstantValue();
                        Division.IsActive = true;
                        Division.IsSystemDefine = true;
                        Division.CreatedBy = "System";
                        Division.ModifiedBy = "System";
                        Division.CreatedDate = System.DateTime.Now;
                        Division.ModifiedDate = System.DateTime.Now;
                        Division.ObjectState = Model.ObjectState.Added;
                        db.Divisions.Add(Division);
                    }
                    else
                    {
                        Division Division = db.Divisions.Find(DivisionId);
                        Division.DivisionName = (string)ChildClass.GetField("DivisionName").GetRawConstantValue();
                        Division.CompanyId = (int)ChildClass.GetField("CompanyId").GetRawConstantValue();
                        Division.IsActive = true;
                        Division.IsSystemDefine = true;
                        Division.ModifiedBy = "System";
                        Division.ModifiedDate = System.DateTime.Now;
                        Division.ObjectState = Model.ObjectState.Modified;
                        db.Divisions.Add(Division);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertGodown()
        {
            try
            {
                Type GodownConstantsType = typeof(GodownConstants);

                System.Type[] ChildClassCollection = GodownConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int GodownId = (int)ChildClass.GetField("GodownId").GetRawConstantValue();
                    if (db.Godown.Find(GodownId) == null)
                    {
                        Godown Godown = new Godown();
                        Godown.GodownId = (int)ChildClass.GetField("GodownId").GetRawConstantValue();
                        Godown.GodownName = (string)ChildClass.GetField("GodownName").GetRawConstantValue();
                        Godown.SiteId = (int)ChildClass.GetField("SiteId").GetRawConstantValue();
                        Godown.IsActive = true;
                        Godown.CreatedBy = "System";
                        Godown.ModifiedBy = "System";
                        Godown.CreatedDate = System.DateTime.Now;
                        Godown.ModifiedDate = System.DateTime.Now;
                        Godown.ObjectState = Model.ObjectState.Added;
                        db.Godown.Add(Godown);
                    }
                    else
                    {
                        Godown Godown = db.Godown.Find(GodownId);
                        Godown.GodownName = (string)ChildClass.GetField("GodownName").GetRawConstantValue();
                        Godown.SiteId = (int)ChildClass.GetField("SiteId").GetRawConstantValue();
                        Godown.IsActive = true;
                        Godown.ModifiedBy = "System";
                        Godown.ModifiedDate = System.DateTime.Now;
                        Godown.ObjectState = Model.ObjectState.Modified;
                        db.Godown.Add(Godown);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertLedgerAccountGroup()
        {
            try
            {
                Type LedgerAccountGroupConstantsType = typeof(LedgerAccountGroupConstants);

                System.Type[] ChildClassCollection = LedgerAccountGroupConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                    if (db.LedgerAccountGroup.Find(LedgerAccountGroupId) == null)
                    {
                        LedgerAccountGroup LedgerAccountGroup = new LedgerAccountGroup();
                        LedgerAccountGroup.LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                        LedgerAccountGroup.LedgerAccountGroupName = (string)ChildClass.GetField("LedgerAccountGroupName").GetRawConstantValue();
                        LedgerAccountGroup.LedgerAccountType = (string)ChildClass.GetField("LedgerAccountType").GetRawConstantValue();
                        LedgerAccountGroup.LedgerAccountNature = (string)ChildClass.GetField("LedgerAccountNature").GetRawConstantValue();
                        LedgerAccountGroup.IsActive = true;
                        LedgerAccountGroup.IsSystemDefine = true;
                        LedgerAccountGroup.CreatedBy = "System";
                        LedgerAccountGroup.ModifiedBy = "System";
                        LedgerAccountGroup.CreatedDate = System.DateTime.Now;
                        LedgerAccountGroup.ModifiedDate = System.DateTime.Now;
                        LedgerAccountGroup.ObjectState = Model.ObjectState.Added;
                        db.LedgerAccountGroup.Add(LedgerAccountGroup);
                    }
                    else
                    {
                        LedgerAccountGroup LedgerAccountGroup = db.LedgerAccountGroup.Find(LedgerAccountGroupId);
                        LedgerAccountGroup.LedgerAccountGroupName = (string)ChildClass.GetField("LedgerAccountGroupName").GetRawConstantValue();
                        LedgerAccountGroup.LedgerAccountType = (string)ChildClass.GetField("LedgerAccountType").GetRawConstantValue();
                        LedgerAccountGroup.LedgerAccountNature = (string)ChildClass.GetField("LedgerAccountNature").GetRawConstantValue();
                        LedgerAccountGroup.IsActive = true;
                        LedgerAccountGroup.IsSystemDefine = true;
                        LedgerAccountGroup.ModifiedBy = "System";
                        LedgerAccountGroup.ModifiedDate = System.DateTime.Now;
                        LedgerAccountGroup.ObjectState = Model.ObjectState.Modified;
                        db.LedgerAccountGroup.Add(LedgerAccountGroup);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertLedgerAccount()
        {
            try
            {
                Type LedgerAccountConstantsType = typeof(LedgerAccountConstants);

                System.Type[] ChildClassCollection = LedgerAccountConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int LedgerAccountId = (int)ChildClass.GetField("LedgerAccountId").GetRawConstantValue();
                    if (db.LedgerAccount.Find(LedgerAccountId) == null)
                    {
                        LedgerAccount LedgerAccount = new LedgerAccount();
                        LedgerAccount.LedgerAccountId = (int)ChildClass.GetField("LedgerAccountId").GetRawConstantValue();
                        LedgerAccount.LedgerAccountName = (string)ChildClass.GetField("LedgerAccountName").GetRawConstantValue();
                        LedgerAccount.LedgerAccountSuffix = (string)ChildClass.GetField("LedgerAccountSuffix").GetRawConstantValue();
                        LedgerAccount.LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                        LedgerAccount.IsActive = true;
                        LedgerAccount.IsSystemDefine = true;
                        LedgerAccount.CreatedBy = "System";
                        LedgerAccount.ModifiedBy = "System";
                        LedgerAccount.CreatedDate = System.DateTime.Now;
                        LedgerAccount.ModifiedDate = System.DateTime.Now;
                        LedgerAccount.ObjectState = Model.ObjectState.Added;
                        db.LedgerAccount.Add(LedgerAccount);
                    }
                    else
                    {
                        LedgerAccount LedgerAccount = db.LedgerAccount.Find(LedgerAccountId);
                        LedgerAccount.LedgerAccountName = (string)ChildClass.GetField("LedgerAccountName").GetRawConstantValue();
                        LedgerAccount.LedgerAccountSuffix = (string)ChildClass.GetField("LedgerAccountSuffix").GetRawConstantValue();
                        LedgerAccount.LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                        LedgerAccount.IsActive = true;
                        LedgerAccount.IsSystemDefine = true;
                        LedgerAccount.ModifiedBy = "System";
                        LedgerAccount.ModifiedDate = System.DateTime.Now;
                        LedgerAccount.ObjectState = Model.ObjectState.Modified;
                        db.LedgerAccount.Add(LedgerAccount);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertUnit()
        {
            try
            {
                Type UnitConstantsType = typeof(UnitConstants);

                System.Type[] ChildClassCollection = UnitConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    string UnitId = (string)ChildClass.GetField("UnitId").GetRawConstantValue();
                    if (db.Units.Find(UnitId) == null)
                    {
                        Unit Unit = new Unit();
                        Unit.UnitId = (string)ChildClass.GetField("UnitId").GetRawConstantValue();
                        Unit.UnitName = (string)ChildClass.GetField("UnitName").GetRawConstantValue();
                        Unit.Symbol = (string)ChildClass.GetField("Symbol").GetRawConstantValue();
                        Unit.FractionName = (string)ChildClass.GetField("FractionName").GetRawConstantValue();
                        Unit.FractionUnits = (int)ChildClass.GetField("FractionUnits").GetRawConstantValue();
                        Unit.FractionSymbol = (string)ChildClass.GetField("FractionSymbol").GetRawConstantValue();
                        Unit.DecimalPlaces = (byte)ChildClass.GetField("DecimalPlaces").GetRawConstantValue();
                        Unit.DimensionUnitId = (string)ChildClass.GetField("DimensionUnitId").GetRawConstantValue();
                        Unit.IsActive = true;
                        Unit.CreatedBy = "System";
                        Unit.ModifiedBy = "System";
                        Unit.CreatedDate = System.DateTime.Now;
                        Unit.ModifiedDate = System.DateTime.Now;
                        Unit.ObjectState = Model.ObjectState.Added;
                        db.Units.Add(Unit);
                    }
                    else
                    {
                        Unit Unit = db.Units.Find(UnitId);
                        Unit.UnitName = (string)ChildClass.GetField("UnitName").GetRawConstantValue();
                        Unit.Symbol = (string)ChildClass.GetField("Symbol").GetRawConstantValue();
                        Unit.FractionName = (string)ChildClass.GetField("FractionName").GetRawConstantValue();
                        Unit.FractionUnits = (int)ChildClass.GetField("FractionUnits").GetRawConstantValue();
                        Unit.FractionSymbol = (string)ChildClass.GetField("FractionSymbol").GetRawConstantValue();
                        Unit.DecimalPlaces = (byte)ChildClass.GetField("DecimalPlaces").GetRawConstantValue();
                        Unit.DimensionUnitId = (string)ChildClass.GetField("DimensionUnitId").GetRawConstantValue();
                        Unit.IsActive = true;
                        Unit.ModifiedBy = "System";
                        Unit.ModifiedDate = System.DateTime.Now;
                        Unit.ObjectState = Model.ObjectState.Modified;
                        db.Units.Add(Unit);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCurrency()
        {
            try
            {
                Type CurrencyConstantsType = typeof(CurrencyConstants);

                System.Type[] ChildClassCollection = CurrencyConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ID = (int)ChildClass.GetField("ID").GetRawConstantValue();
                    if (db.Currency.Find(ID) == null)
                    {
                        Currency Currency = new Currency();
                        Currency.ID = (int)ChildClass.GetField("ID").GetRawConstantValue();
                        Currency.Name = (string)ChildClass.GetField("Name").GetRawConstantValue();
                        Currency.Symbol = (string)ChildClass.GetField("Symbol").GetRawConstantValue();
                        Currency.IsActive = true;
                        Currency.CreatedBy = "System";
                        Currency.ModifiedBy = "System";
                        Currency.CreatedDate = System.DateTime.Now;
                        Currency.ModifiedDate = System.DateTime.Now;
                        Currency.ObjectState = Model.ObjectState.Added;
                        db.Currency.Add(Currency);
                    }
                    else
                    {
                        Currency Currency = db.Currency.Find(ID);
                        Currency.Name = (string)ChildClass.GetField("Name").GetRawConstantValue();
                        Currency.Symbol = (string)ChildClass.GetField("Symbol").GetRawConstantValue();
                        Currency.IsActive = true;
                        Currency.ModifiedBy = "System";
                        Currency.ModifiedDate = System.DateTime.Now;
                        Currency.ObjectState = Model.ObjectState.Modified;
                        db.Currency.Add(Currency);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProcess()
        {
            try
            {
                Type ProcessConstantsType = typeof(ProcessConstants);

                System.Type[] ChildClassCollection = ProcessConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProcessId = (int)ChildClass.GetField("ProcessId").GetRawConstantValue();
                    if (db.Process.Find(ProcessId) == null)
                    {
                        Process Process = new Process();
                        Process.ProcessId = (int)ChildClass.GetField("ProcessId").GetRawConstantValue();
                        Process.ProcessCode = (string)ChildClass.GetField("ProcessCode").GetRawConstantValue();
                        Process.ProcessName = (string)ChildClass.GetField("ProcessName").GetRawConstantValue();
                        Process.AccountId = (int)ChildClass.GetField("AccountId").GetRawConstantValue();
                        Process.IsActive = true;
                        Process.IsSystemDefine = true;
                        Process.CreatedBy = "System";
                        Process.ModifiedBy = "System";
                        Process.CreatedDate = System.DateTime.Now;
                        Process.ModifiedDate = System.DateTime.Now;
                        Process.ObjectState = Model.ObjectState.Added;
                        db.Process.Add(Process);
                    }
                    else
                    {
                        Process Process = db.Process.Find(ProcessId);
                        Process.ProcessCode = (string)ChildClass.GetField("ProcessCode").GetRawConstantValue();
                        Process.ProcessName = (string)ChildClass.GetField("ProcessName").GetRawConstantValue();
                        Process.AccountId = (int)ChildClass.GetField("AccountId").GetRawConstantValue();
                        Process.IsActive = true;
                        Process.IsSystemDefine = true;
                        Process.ModifiedBy = "System";
                        Process.ModifiedDate = System.DateTime.Now;
                        Process.ObjectState = Model.ObjectState.Modified;
                        db.Process.Add(Process);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertTdsGroup()
        {
            try
            {
                Type TdsGroupConstantsType = typeof(TdsGroupConstants);

                System.Type[] ChildClassCollection = TdsGroupConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int TdsGroupId = (int)ChildClass.GetField("TdsGroupId").GetRawConstantValue();
                    if (db.TdsGroup.Find(TdsGroupId) == null)
                    {
                        TdsGroup TdsGroup = new TdsGroup();
                        TdsGroup.TdsGroupId = (int)ChildClass.GetField("TdsGroupId").GetRawConstantValue();
                        TdsGroup.TdsGroupName = (string)ChildClass.GetField("TdsGroupName").GetRawConstantValue();
                        TdsGroup.CreatedBy = "System";
                        TdsGroup.ModifiedBy = "System";
                        TdsGroup.CreatedDate = System.DateTime.Now;
                        TdsGroup.ModifiedDate = System.DateTime.Now;
                        TdsGroup.ObjectState = Model.ObjectState.Added;
                        db.TdsGroup.Add(TdsGroup);
                    }
                    else
                    {
                        TdsGroup TdsGroup = db.TdsGroup.Find(TdsGroupId);
                        TdsGroup.TdsGroupName = (string)ChildClass.GetField("TdsGroupName").GetRawConstantValue();
                        TdsGroup.ModifiedBy = "System";
                        TdsGroup.ModifiedDate = System.DateTime.Now;
                        TdsGroup.ObjectState = Model.ObjectState.Modified;
                        db.TdsGroup.Add(TdsGroup);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertTdsCategory()
        {
            try
            {
                Type TdsCategoryConstantsType = typeof(TdsCategoryConstants);

                System.Type[] ChildClassCollection = TdsCategoryConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int TdsCategoryId = (int)ChildClass.GetField("TdsCategoryId").GetRawConstantValue();
                    if (db.TdsCategory.Find(TdsCategoryId) == null)
                    {
                        TdsCategory TdsCategory = new TdsCategory();
                        TdsCategory.TdsCategoryId = (int)ChildClass.GetField("TdsCategoryId").GetRawConstantValue();
                        TdsCategory.TdsCategoryName = (string)ChildClass.GetField("TdsCategoryName").GetRawConstantValue();
                        TdsCategory.CreatedBy = "System";
                        TdsCategory.ModifiedBy = "System";
                        TdsCategory.CreatedDate = System.DateTime.Now;
                        TdsCategory.ModifiedDate = System.DateTime.Now;
                        TdsCategory.ObjectState = Model.ObjectState.Added;
                        db.TdsCategory.Add(TdsCategory);
                    }
                    else
                    {
                        TdsCategory TdsCategory = db.TdsCategory.Find(TdsCategoryId);
                        TdsCategory.TdsCategoryName = (string)ChildClass.GetField("TdsCategoryName").GetRawConstantValue();
                        TdsCategory.ModifiedBy = "System";
                        TdsCategory.ModifiedDate = System.DateTime.Now;
                        TdsCategory.ObjectState = Model.ObjectState.Modified;
                        db.TdsCategory.Add(TdsCategory);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertTdsRate()
        {
            try
            {
                Type TdsRateConstantsType = typeof(TdsRateConstants);

                System.Type[] ChildClassCollection = TdsRateConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int TdsRateId = (int)ChildClass.GetField("TdsRateId").GetRawConstantValue();
                    if (db.TdsRate.Find(TdsRateId) == null)
                    {
                        TdsRate TdsRate = new TdsRate();
                        TdsRate.TdsRateId = (int)ChildClass.GetField("TdsRateId").GetRawConstantValue();
                        TdsRate.TdsCategoryId = (int)ChildClass.GetField("TdsCategoryId").GetRawConstantValue();
                        TdsRate.TdsGroupId = (int)ChildClass.GetField("TdsGroupId").GetRawConstantValue();
                        TdsRate.Percentage = Convert.ToDecimal(ChildClass.GetField("Percentage").GetRawConstantValue());
                        TdsRate.CreatedBy = "System";
                        TdsRate.ModifiedBy = "System";
                        TdsRate.CreatedDate = System.DateTime.Now;
                        TdsRate.ModifiedDate = System.DateTime.Now;
                        TdsRate.ObjectState = Model.ObjectState.Added;
                        db.TdsRate.Add(TdsRate);
                    }
                    else
                    {
                        TdsRate TdsRate = db.TdsRate.Find(TdsRateId);
                        TdsRate.TdsCategoryId = (int)ChildClass.GetField("TdsCategoryId").GetRawConstantValue();
                        TdsRate.TdsGroupId = (int)ChildClass.GetField("TdsGroupId").GetRawConstantValue();
                        TdsRate.Percentage = (Decimal)ChildClass.GetField("Percentage").GetRawConstantValue();
                        TdsRate.ModifiedBy = "System";
                        TdsRate.ModifiedDate = System.DateTime.Now;
                        TdsRate.ObjectState = Model.ObjectState.Modified;
                        db.TdsRate.Add(TdsRate);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDepartment()
        {
            try
            {
                Type DepartmentConstantsType = typeof(DepartmentConstants);

                System.Type[] ChildClassCollection = DepartmentConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DepartmentId = (int)ChildClass.GetField("DepartmentId").GetRawConstantValue();
                    if (db.Department.Find(DepartmentId) == null)
                    {
                        Department Department = new Department();
                        Department.DepartmentId = (int)ChildClass.GetField("DepartmentId").GetRawConstantValue();
                        Department.DepartmentName = (string)ChildClass.GetField("DepartmentName").GetRawConstantValue();
                        Department.CreatedBy = "System";
                        Department.ModifiedBy = "System";
                        Department.CreatedDate = System.DateTime.Now;
                        Department.ModifiedDate = System.DateTime.Now;
                        Department.ObjectState = Model.ObjectState.Added;
                        db.Department.Add(Department);
                    }
                    else
                    {
                        Department Department = db.Department.Find(DepartmentId);
                        Department.DepartmentName = (string)ChildClass.GetField("DepartmentName").GetRawConstantValue();
                        Department.ModifiedBy = "System";
                        Department.ModifiedDate = System.DateTime.Now;
                        Department.ObjectState = Model.ObjectState.Modified;
                        db.Department.Add(Department);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDesignation()
        {
            try
            {
                Type DesignationConstantsType = typeof(DesignationConstants);

                System.Type[] ChildClassCollection = DesignationConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DesignationId = (int)ChildClass.GetField("DesignationId").GetRawConstantValue();
                    if (db.Designation.Find(DesignationId) == null)
                    {
                        Designation Designation = new Designation();
                        Designation.DesignationId = (int)ChildClass.GetField("DesignationId").GetRawConstantValue();
                        Designation.DesignationName = (string)ChildClass.GetField("DesignationName").GetRawConstantValue();
                        Designation.CreatedBy = "System";
                        Designation.ModifiedBy = "System";
                        Designation.CreatedDate = System.DateTime.Now;
                        Designation.ModifiedDate = System.DateTime.Now;
                        Designation.ObjectState = Model.ObjectState.Added;
                        db.Designation.Add(Designation);
                    }
                    else
                    {
                        Designation Designation = db.Designation.Find(DesignationId);
                        Designation.DesignationName = (string)ChildClass.GetField("DesignationName").GetRawConstantValue();
                        Designation.ModifiedBy = "System";
                        Designation.ModifiedDate = System.DateTime.Now;
                        Designation.ObjectState = Model.ObjectState.Modified;
                        db.Designation.Add(Designation);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertUnitConversionFor()
        {
            try
            {
                Type UnitConversionForConstantsType = typeof(UnitConversionForConstants);

                System.Type[] ChildClassCollection = UnitConversionForConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    byte UnitConversionForId = (byte)ChildClass.GetField("UnitconversionForId").GetRawConstantValue();
                    if (db.UnitConversonFor.Find(UnitConversionForId) == null)
                    {
                        UnitConversionFor UnitConversionFor = new UnitConversionFor();
                        UnitConversionFor.UnitconversionForId = (byte)ChildClass.GetField("UnitconversionForId").GetRawConstantValue();
                        UnitConversionFor.UnitconversionForName = (string)ChildClass.GetField("UnitconversionForName").GetRawConstantValue();
                        UnitConversionFor.ObjectState = Model.ObjectState.Added;
                        db.UnitConversonFor.Add(UnitConversionFor);
                    }
                    else
                    {
                        UnitConversionFor UnitConversionFor = db.UnitConversonFor.Find(UnitConversionForId);
                        UnitConversionFor.UnitconversionForName = (string)ChildClass.GetField("UnitconversionForName").GetRawConstantValue();
                        UnitConversionFor.ObjectState = Model.ObjectState.Modified;
                        db.UnitConversonFor.Add(UnitConversionFor);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertShipMethod()
        {
            try
            {
                Type ShipMethodConstantsType = typeof(ShipMethodConstants);

                System.Type[] ChildClassCollection = ShipMethodConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ShipMethodId = (int)ChildClass.GetField("ShipMethodId").GetRawConstantValue();
                    if (db.ShipMethod.Find(ShipMethodId) == null)
                    {
                        ShipMethod ShipMethod = new ShipMethod();
                        ShipMethod.ShipMethodId = (int)ChildClass.GetField("ShipMethodId").GetRawConstantValue();
                        ShipMethod.ShipMethodName = (string)ChildClass.GetField("ShipMethodName").GetRawConstantValue();
                        ShipMethod.CreatedBy = "System";
                        ShipMethod.ModifiedBy = "System";
                        ShipMethod.CreatedDate = System.DateTime.Now;
                        ShipMethod.ModifiedDate = System.DateTime.Now;
                        ShipMethod.ObjectState = Model.ObjectState.Added;
                        db.ShipMethod.Add(ShipMethod);
                    }
                    else
                    {
                        ShipMethod ShipMethod = db.ShipMethod.Find(ShipMethodId);
                        ShipMethod.ShipMethodName = (string)ChildClass.GetField("ShipMethodName").GetRawConstantValue();
                        ShipMethod.ModifiedBy = "System";
                        ShipMethod.ModifiedDate = System.DateTime.Now;
                        ShipMethod.ObjectState = Model.ObjectState.Modified;
                        db.ShipMethod.Add(ShipMethod);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertDeliveryTerms()
        {
            try
            {
                Type DeliveryTermsConstantsType = typeof(DeliveryTermsConstants);

                System.Type[] ChildClassCollection = DeliveryTermsConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int DeliveryTermsId = (int)ChildClass.GetField("DeliveryTermsId").GetRawConstantValue();
                    if (db.DeliveryTerms.Find(DeliveryTermsId) == null)
                    {
                        DeliveryTerms DeliveryTerms = new DeliveryTerms();
                        DeliveryTerms.DeliveryTermsId = (int)ChildClass.GetField("DeliveryTermsId").GetRawConstantValue();
                        DeliveryTerms.DeliveryTermsName = (string)ChildClass.GetField("DeliveryTermsName").GetRawConstantValue();
                        DeliveryTerms.PrintingDescription = (string)ChildClass.GetField("PrintingDescription").GetRawConstantValue();
                        DeliveryTerms.CreatedBy = "System";
                        DeliveryTerms.ModifiedBy = "System";
                        DeliveryTerms.CreatedDate = System.DateTime.Now;
                        DeliveryTerms.ModifiedDate = System.DateTime.Now;
                        DeliveryTerms.ObjectState = Model.ObjectState.Added;
                        db.DeliveryTerms.Add(DeliveryTerms);
                    }
                    else
                    {
                        DeliveryTerms DeliveryTerms = db.DeliveryTerms.Find(DeliveryTermsId);
                        DeliveryTerms.DeliveryTermsName = (string)ChildClass.GetField("DeliveryTermsName").GetRawConstantValue();
                        DeliveryTerms.PrintingDescription = (string)ChildClass.GetField("PrintingDescription").GetRawConstantValue();
                        DeliveryTerms.ModifiedBy = "System";
                        DeliveryTerms.ModifiedDate = System.DateTime.Now;
                        DeliveryTerms.ObjectState = Model.ObjectState.Modified;
                        db.DeliveryTerms.Add(DeliveryTerms);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertPersonContactType()
        {
            try
            {
                Type PersonContactTypeConstantsType = typeof(PersonContactTypeConstants);

                System.Type[] ChildClassCollection = PersonContactTypeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int PersonContactTypeId = (int)ChildClass.GetField("PersonContactTypeId").GetRawConstantValue();
                    if (db.PersonContactType.Find(PersonContactTypeId) == null)
                    {
                        PersonContactType PersonContactType = new PersonContactType();
                        PersonContactType.PersonContactTypeId = (int)ChildClass.GetField("PersonContactTypeId").GetRawConstantValue();
                        PersonContactType.PersonContactTypeName = (string)ChildClass.GetField("PersonContactTypeName").GetRawConstantValue();
                        PersonContactType.CreatedBy = "System";
                        PersonContactType.ModifiedBy = "System";
                        PersonContactType.CreatedDate = System.DateTime.Now;
                        PersonContactType.ModifiedDate = System.DateTime.Now;
                        PersonContactType.ObjectState = Model.ObjectState.Added;
                        db.PersonContactType.Add(PersonContactType);
                    }
                    else
                    {
                        PersonContactType PersonContactType = db.PersonContactType.Find(PersonContactTypeId);
                        PersonContactType.PersonContactTypeName = (string)ChildClass.GetField("PersonContactTypeName").GetRawConstantValue();
                        PersonContactType.ModifiedBy = "System";
                        PersonContactType.ModifiedDate = System.DateTime.Now;
                        PersonContactType.ObjectState = Model.ObjectState.Modified;
                        db.PersonContactType.Add(PersonContactType);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductNature()
        {
            try
            {
                Type ProductNatureConstantsType = typeof(ProductNatureConstants);

                System.Type[] ChildClassCollection = ProductNatureConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductNatureId = (int)ChildClass.GetField("ProductNatureId").GetRawConstantValue();
                    if (db.ProductNature.Find(ProductNatureId) == null)
                    {
                        ProductNature ProductNature = new ProductNature();
                        ProductNature.ProductNatureId = (int)ChildClass.GetField("ProductNatureId").GetRawConstantValue();
                        ProductNature.ProductNatureName = (string)ChildClass.GetField("ProductNatureName").GetRawConstantValue();
                        ProductNature.IsActive = true;
                        ProductNature.IsSystemDefine = true;
                        ProductNature.CreatedBy = "System";
                        ProductNature.ModifiedBy = "System";
                        ProductNature.CreatedDate = System.DateTime.Now;
                        ProductNature.ModifiedDate = System.DateTime.Now;
                        ProductNature.ObjectState = Model.ObjectState.Added;
                        db.ProductNature.Add(ProductNature);
                    }
                    else
                    {
                        ProductNature ProductNature = db.ProductNature.Find(ProductNatureId);
                        ProductNature.ProductNatureName = (string)ChildClass.GetField("ProductNatureName").GetRawConstantValue();
                        ProductNature.IsActive = true;
                        ProductNature.IsSystemDefine = true;
                        ProductNature.ModifiedBy = "System";
                        ProductNature.ModifiedDate = System.DateTime.Now;
                        ProductNature.ObjectState = Model.ObjectState.Modified;
                        db.ProductNature.Add(ProductNature);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductShape()
        {
            try
            {
                Type ProductShapeConstantsType = typeof(ProductShapeConstants);

                System.Type[] ChildClassCollection = ProductShapeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductShapeId = (int)ChildClass.GetField("ProductShapeId").GetRawConstantValue();
                    if (db.ProductShape.Find(ProductShapeId) == null)
                    {
                        ProductShape ProductShape = new ProductShape();
                        ProductShape.ProductShapeId = (int)ChildClass.GetField("ProductShapeId").GetRawConstantValue();
                        ProductShape.ProductShapeName = (string)ChildClass.GetField("ProductShapeName").GetRawConstantValue();
                        ProductShape.IsActive = true;
                        ProductShape.IsSystemDefine = true;
                        ProductShape.CreatedBy = "System";
                        ProductShape.ModifiedBy = "System";
                        ProductShape.CreatedDate = System.DateTime.Now;
                        ProductShape.ModifiedDate = System.DateTime.Now;
                        ProductShape.ObjectState = Model.ObjectState.Added;
                        db.ProductShape.Add(ProductShape);
                    }
                    else
                    {
                        ProductShape ProductShape = db.ProductShape.Find(ProductShapeId);
                        ProductShape.ProductShapeName = (string)ChildClass.GetField("ProductShapeName").GetRawConstantValue();
                        ProductShape.IsActive = true;
                        ProductShape.IsSystemDefine = true;
                        ProductShape.ModifiedBy = "System";
                        ProductShape.ModifiedDate = System.DateTime.Now;
                        ProductShape.ObjectState = Model.ObjectState.Modified;
                        db.ProductShape.Add(ProductShape);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductType()
        {
            try
            {
                Type ProductTypeConstantsType = typeof(ProductTypeConstants);

                System.Type[] ChildClassCollection = ProductTypeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                    if (db.ProductTypes.Find(ProductTypeId) == null)
                    {
                        ProductType ProductType = new ProductType();
                        ProductType.ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                        ProductType.ProductNatureId = (int)ChildClass.GetField("ProductNatureId").GetRawConstantValue();
                        ProductType.ProductTypeName = (string)ChildClass.GetField("ProductTypeName").GetRawConstantValue();
                        ProductType.IsActive = true;
                        ProductType.IsSystemDefine = true;
                        ProductType.CreatedBy = "System";
                        ProductType.ModifiedBy = "System";
                        ProductType.CreatedDate = System.DateTime.Now;
                        ProductType.ModifiedDate = System.DateTime.Now;
                        ProductType.ObjectState = Model.ObjectState.Added;
                        db.ProductTypes.Add(ProductType);
                    }
                    else
                    {
                        ProductType ProductType = db.ProductTypes.Find(ProductTypeId);
                        ProductType.ProductNatureId = (int)ChildClass.GetField("ProductNatureId").GetRawConstantValue();
                        ProductType.ProductTypeName = (string)ChildClass.GetField("ProductTypeName").GetRawConstantValue();
                        ProductType.IsActive = true;
                        ProductType.IsSystemDefine = true;
                        ProductType.ModifiedBy = "System";
                        ProductType.ModifiedDate = System.DateTime.Now;
                        ProductType.ObjectState = Model.ObjectState.Modified;
                        db.ProductTypes.Add(ProductType);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertProductGroup()
        {
            try
            {
                Type ProductGroupConstantsType = typeof(ProductGroupConstants);

                System.Type[] ChildClassCollection = ProductGroupConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ProductGroupId = (int)ChildClass.GetField("ProductGroupId").GetRawConstantValue();
                    if (db.ProductGroups.Find(ProductGroupId) == null)
                    {
                        ProductGroup ProductGroup = new ProductGroup();
                        ProductGroup.ProductGroupId = (int)ChildClass.GetField("ProductGroupId").GetRawConstantValue();
                        ProductGroup.ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                        ProductGroup.ProductGroupName = (string)ChildClass.GetField("ProductGroupName").GetRawConstantValue();
                        ProductGroup.IsActive = true;
                        ProductGroup.IsSystemDefine = true;
                        ProductGroup.CreatedBy = "System";
                        ProductGroup.ModifiedBy = "System";
                        ProductGroup.CreatedDate = System.DateTime.Now;
                        ProductGroup.ModifiedDate = System.DateTime.Now;
                        ProductGroup.ObjectState = Model.ObjectState.Added;
                        db.ProductGroups.Add(ProductGroup);
                    }
                    else
                    {
                        ProductGroup ProductGroup = db.ProductGroups.Find(ProductGroupId);
                        ProductGroup.ProductTypeId = (int)ChildClass.GetField("ProductTypeId").GetRawConstantValue();
                        ProductGroup.ProductGroupName = (string)ChildClass.GetField("ProductGroupName").GetRawConstantValue();
                        ProductGroup.IsActive = true;
                        ProductGroup.IsSystemDefine = true;
                        ProductGroup.ModifiedBy = "System";
                        ProductGroup.ModifiedDate = System.DateTime.Now;
                        ProductGroup.ObjectState = Model.ObjectState.Modified;
                        db.ProductGroups.Add(ProductGroup);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertChargeType()
        {
            try
            {
                Type ChargeTypeConstantsType = typeof(ChargeTypeConstants);

                System.Type[] ChildClassCollection = ChargeTypeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ChargeTypeId = (int)ChildClass.GetField("ChargeTypeId").GetRawConstantValue();
                    if (db.ChargeType.Find(ChargeTypeId) == null)
                    {
                        ChargeType ChargeType = new ChargeType();
                        ChargeType.ChargeTypeId = (int)ChildClass.GetField("ChargeTypeId").GetRawConstantValue();
                        ChargeType.ChargeTypeName = (string)ChildClass.GetField("ChargeTypeName").GetRawConstantValue();
                        ChargeType.IsActive = true;
                        ChargeType.IsSystemDefine = true;
                        ChargeType.CreatedBy = "System";
                        ChargeType.ModifiedBy = "System";
                        ChargeType.CreatedDate = System.DateTime.Now;
                        ChargeType.ModifiedDate = System.DateTime.Now;
                        ChargeType.ObjectState = Model.ObjectState.Added;
                        db.ChargeType.Add(ChargeType);
                    }
                    else
                    {
                        ChargeType ChargeType = db.ChargeType.Find(ChargeTypeId);
                        ChargeType.ChargeTypeName = (string)ChildClass.GetField("ChargeTypeName").GetRawConstantValue();
                        ChargeType.IsActive = true;
                        ChargeType.IsSystemDefine = true;
                        ChargeType.ModifiedBy = "System";
                        ChargeType.ModifiedDate = System.DateTime.Now;
                        ChargeType.ObjectState = Model.ObjectState.Modified;
                        db.ChargeType.Add(ChargeType);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCharge()
        {
            try
            {
                Type ChargeConstantsType = typeof(ChargeConstants);

                System.Type[] ChildClassCollection = ChargeConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ChargeId = (int)ChildClass.GetField("ChargeId").GetRawConstantValue();
                    if (db.Charge.Find(ChargeId) == null)
                    {
                        Charge Charge = new Charge();
                        Charge.ChargeId = (int)ChildClass.GetField("ChargeId").GetRawConstantValue();
                        Charge.ChargeName = (string)ChildClass.GetField("ChargeName").GetRawConstantValue();
                        Charge.ChargeCode = (string)ChildClass.GetField("ChargeCode").GetRawConstantValue();
                        Charge.IsActive = true;
                        Charge.CreatedBy = "System";
                        Charge.ModifiedBy = "System";
                        Charge.CreatedDate = System.DateTime.Now;
                        Charge.ModifiedDate = System.DateTime.Now;
                        Charge.ObjectState = Model.ObjectState.Added;
                        db.Charge.Add(Charge);
                    }
                    else
                    {
                        Charge Charge = db.Charge.Find(ChargeId);
                        Charge.ChargeName = (string)ChildClass.GetField("ChargeName").GetRawConstantValue();
                        Charge.ChargeCode = (string)ChildClass.GetField("ChargeCode").GetRawConstantValue();
                        Charge.IsActive = true;
                        Charge.ModifiedBy = "System";
                        Charge.ModifiedDate = System.DateTime.Now;
                        Charge.ObjectState = Model.ObjectState.Modified;
                        db.Charge.Add(Charge);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertChargeGroupPerson()
        {
            try
            {
                Type ChargeGroupPersonConstantsType = typeof(ChargeGroupPersonConstants);

                System.Type[] ChildClassCollection = ChargeGroupPersonConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ChargeGroupPersonId = (int)ChildClass.GetField("ChargeGroupPersonId").GetRawConstantValue();
                    if (db.ChargeGroupPerson.Find(ChargeGroupPersonId) == null)
                    {
                        ChargeGroupPerson ChargeGroupPerson = new ChargeGroupPerson();
                        ChargeGroupPerson.ChargeGroupPersonId = (int)ChildClass.GetField("ChargeGroupPersonId").GetRawConstantValue();
                        ChargeGroupPerson.ChargeGroupPersonName = (string)ChildClass.GetField("ChargeGroupPersonName").GetRawConstantValue();
                        ChargeGroupPerson.IsActive = true;
                        ChargeGroupPerson.CreatedBy = "System";
                        ChargeGroupPerson.ModifiedBy = "System";
                        ChargeGroupPerson.CreatedDate = System.DateTime.Now;
                        ChargeGroupPerson.ModifiedDate = System.DateTime.Now;
                        ChargeGroupPerson.ObjectState = Model.ObjectState.Added;
                        db.ChargeGroupPerson.Add(ChargeGroupPerson);
                    }
                    else
                    {
                        ChargeGroupPerson ChargeGroupPerson = db.ChargeGroupPerson.Find(ChargeGroupPersonId);
                        ChargeGroupPerson.ChargeGroupPersonName = (string)ChildClass.GetField("ChargeGroupPersonName").GetRawConstantValue();
                        ChargeGroupPerson.IsActive = true;
                        ChargeGroupPerson.ModifiedBy = "System";
                        ChargeGroupPerson.ModifiedDate = System.DateTime.Now;
                        ChargeGroupPerson.ObjectState = Model.ObjectState.Modified;
                        db.ChargeGroupPerson.Add(ChargeGroupPerson);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertChargeGroupProduct()
        {
            try
            {
                Type ChargeGroupProductConstantsType = typeof(ChargeGroupProductConstants);

                System.Type[] ChildClassCollection = ChargeGroupProductConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ChargeGroupProductId = (int)ChildClass.GetField("ChargeGroupProductId").GetRawConstantValue();
                    if (db.ChargeGroupProduct.Find(ChargeGroupProductId) == null)
                    {
                        ChargeGroupProduct ChargeGroupProduct = new ChargeGroupProduct();
                        ChargeGroupProduct.ChargeGroupProductId = (int)ChildClass.GetField("ChargeGroupProductId").GetRawConstantValue();
                        ChargeGroupProduct.ChargeGroupProductName = (string)ChildClass.GetField("ChargeGroupProductName").GetRawConstantValue();
                        ChargeGroupProduct.IsActive = true;
                        ChargeGroupProduct.CreatedBy = "System";
                        ChargeGroupProduct.ModifiedBy = "System";
                        ChargeGroupProduct.CreatedDate = System.DateTime.Now;
                        ChargeGroupProduct.ModifiedDate = System.DateTime.Now;
                        ChargeGroupProduct.ObjectState = Model.ObjectState.Added;
                        db.ChargeGroupProduct.Add(ChargeGroupProduct);
                    }
                    else
                    {
                        ChargeGroupProduct ChargeGroupProduct = db.ChargeGroupProduct.Find(ChargeGroupProductId);
                        ChargeGroupProduct.ChargeGroupProductName = (string)ChildClass.GetField("ChargeGroupProductName").GetRawConstantValue();
                        ChargeGroupProduct.IsActive = true;
                        ChargeGroupProduct.ModifiedBy = "System";
                        ChargeGroupProduct.ModifiedDate = System.DateTime.Now;
                        ChargeGroupProduct.ObjectState = Model.ObjectState.Modified;
                        db.ChargeGroupProduct.Add(ChargeGroupProduct);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertChargeGroupSetting()
        {
            try
            {
                Type ChargeGroupSettingConstantsType = typeof(ChargeGroupSettingConstants);

                System.Type[] ChildClassCollection = ChargeGroupSettingConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int ChargeGroupSettingId = (int)ChildClass.GetField("ChargeGroupSettingId").GetRawConstantValue();
                    if (db.ChargeGroupSettings.Find(ChargeGroupSettingId) == null)
                    {
                        ChargeGroupSettings ChargeGroupSetting = new ChargeGroupSettings();
                        ChargeGroupSetting.ChargeGroupSettingsId = (int)ChildClass.GetField("ChargeGroupSettingId").GetRawConstantValue();
                        ChargeGroupSetting.ProcessId = (int)ChildClass.GetField("ProcessId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeTypeId = (int)ChildClass.GetField("ChargeTypeId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeGroupPersonId = (int)ChildClass.GetField("ChargeGroupPersonId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeGroupProductId = (int)ChildClass.GetField("ChargeGroupProductId").GetRawConstantValue();
                        ChargeGroupSetting.ChargePer = Convert.ToDecimal(ChildClass.GetField("ChargePer").GetRawConstantValue());
                        ChargeGroupSetting.ChargeLedgerAccountId = (int?)ChildClass.GetField("ChargeLedgerAccountId").GetValue("ChargeLedgerAccountId");
                        ChargeGroupSetting.CreatedBy = "System";
                        ChargeGroupSetting.ModifiedBy = "System";
                        ChargeGroupSetting.CreatedDate = System.DateTime.Now;
                        ChargeGroupSetting.ModifiedDate = System.DateTime.Now;
                        ChargeGroupSetting.ObjectState = Model.ObjectState.Added;
                        db.ChargeGroupSettings.Add(ChargeGroupSetting);
                    }
                    else
                    {
                        ChargeGroupSettings ChargeGroupSetting = db.ChargeGroupSettings.Find(ChargeGroupSettingId);
                        ChargeGroupSetting.ProcessId = (int)ChildClass.GetField("ProcessId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeTypeId = (int)ChildClass.GetField("ChargeTypeId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeGroupPersonId = (int)ChildClass.GetField("ChargeGroupPersonId").GetRawConstantValue();
                        ChargeGroupSetting.ChargeGroupProductId = (int)ChildClass.GetField("ChargeGroupProductId").GetRawConstantValue();
                        ChargeGroupSetting.ChargePer = Convert.ToDecimal(ChildClass.GetField("ChargePer").GetRawConstantValue());
                        ChargeGroupSetting.ChargeLedgerAccountId = (int?)ChildClass.GetField("ChargeLedgerAccountId").GetValue("ChargeLedgerAccountId");
                        ChargeGroupSetting.ModifiedBy = "System";
                        ChargeGroupSetting.ModifiedDate = System.DateTime.Now;
                        ChargeGroupSetting.ObjectState = Model.ObjectState.Modified;
                        db.ChargeGroupSettings.Add(ChargeGroupSetting);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCalculation()
        {
            try
            {
                Type CalculationConstantsType = typeof(CalculationConstants);

                System.Type[] ChildClassCollection = CalculationConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CalculationId = (int)ChildClass.GetField("CalculationId").GetRawConstantValue();
                    if (db.Calculation.Find(CalculationId) == null)
                    {
                        Calculation Calculation = new Calculation();
                        Calculation.CalculationId = (int)ChildClass.GetField("CalculationId").GetRawConstantValue();
                        Calculation.CalculationName = (string)ChildClass.GetField("CalculationName").GetRawConstantValue();
                        Calculation.IsActive = true;
                        Calculation.CreatedBy = "System";
                        Calculation.ModifiedBy = "System";
                        Calculation.CreatedDate = System.DateTime.Now;
                        Calculation.ModifiedDate = System.DateTime.Now;
                        Calculation.ObjectState = Model.ObjectState.Added;
                        db.Calculation.Add(Calculation);
                    }
                    else
                    {
                        Calculation Calculation = db.Calculation.Find(CalculationId);
                        Calculation.CalculationName = (string)ChildClass.GetField("CalculationName").GetRawConstantValue();
                        Calculation.IsActive = true;
                        Calculation.ModifiedBy = "System";
                        Calculation.ModifiedDate = System.DateTime.Now;
                        Calculation.ObjectState = Model.ObjectState.Modified;
                        db.Calculation.Add(Calculation);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCalculationProduct()
        {
            try
            {
                Type CalculationProductConstantsType = typeof(CalculationProductConstants);

                System.Type[] ChildClassCollection = CalculationProductConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CalculationProductId = (int)ChildClass.GetField("CalculationProductId").GetRawConstantValue();

                    if (db.CalculationProduct.Find(CalculationProductId) == null)
                    {
                        CalculationProduct CalculationProduct = new CalculationProduct();
                        CalculationProduct.CalculationProductId = (int)ChildClass.GetField("CalculationProductId").GetRawConstantValue();
                        CalculationProduct.CalculationId = (int)ChildClass.GetField("CalculationId").GetValue("CalculationId");
                        CalculationProduct.Sr = (int)ChildClass.GetField("Sr").GetValue("Sr");
                        CalculationProduct.ChargeId = (int)ChildClass.GetField("ChargeId").GetValue("ChargeId");
                        CalculationProduct.AddDeduct = (byte?)ChildClass.GetField("AddDeduct").GetValue("AddDeduct");
                        CalculationProduct.AffectCost = (bool)ChildClass.GetField("AffectCost").GetValue("AffectCost");
                        CalculationProduct.ChargeTypeId = (int?)ChildClass.GetField("ChargeTypeId").GetValue("ChargeTypeId");
                        CalculationProduct.CalculateOnId = (int?)ChildClass.GetField("CalculateOnId").GetValue("CalculateOnId");
                        CalculationProduct.RateType = (byte)ChildClass.GetField("RateType").GetValue("RateType");
                        CalculationProduct.IncludedInBase = (bool)ChildClass.GetField("IncludedInBase").GetValue("IncludedInBase");
                        CalculationProduct.ParentChargeId = (int?)ChildClass.GetField("ParentChargeId").GetValue("ParentChargeId");
                        CalculationProduct.IsVisible = (bool)ChildClass.GetField("IsVisible").GetValue("IsVisible");
                        CalculationProduct.IsActive = (bool)ChildClass.GetField("IsActive").GetValue("IsActive");
                        CalculationProduct.IncludedCharges = (string)ChildClass.GetField("IncludedCharges").GetValue("IncludedCharges");
                        CalculationProduct.IncludedChargesCalculation = (string)ChildClass.GetField("IncludedChargesCalculation").GetValue("IncludedChargesCalculation");
                        CalculationProduct.CreatedBy = "System";
                        CalculationProduct.ModifiedBy = "System";
                        CalculationProduct.CreatedDate = System.DateTime.Now;
                        CalculationProduct.ModifiedDate = System.DateTime.Now;
                        CalculationProduct.ObjectState = Model.ObjectState.Added;
                        db.CalculationProduct.Add(CalculationProduct);
                    }
                    else
                    {
                        CalculationProduct CalculationProduct = db.CalculationProduct.Find(CalculationProductId);
                        CalculationProduct.CalculationId = (int)ChildClass.GetField("CalculationId").GetValue("CalculationId");
                        CalculationProduct.Sr = (int)ChildClass.GetField("Sr").GetValue("Sr");
                        CalculationProduct.ChargeId = (int)ChildClass.GetField("ChargeId").GetValue("ChargeId");
                        CalculationProduct.AddDeduct = (byte?)ChildClass.GetField("AddDeduct").GetValue("AddDeduct");
                        CalculationProduct.AffectCost = (bool)ChildClass.GetField("AffectCost").GetValue("AffectCost");
                        CalculationProduct.ChargeTypeId = (int?)ChildClass.GetField("ChargeTypeId").GetValue("ChargeTypeId");
                        CalculationProduct.CalculateOnId = (int?)ChildClass.GetField("CalculateOnId").GetValue("CalculateOnId");
                        CalculationProduct.RateType = (byte)ChildClass.GetField("RateType").GetValue("RateType");
                        CalculationProduct.IncludedInBase = (bool)ChildClass.GetField("IncludedInBase").GetValue("IncludedInBase");
                        CalculationProduct.ParentChargeId = (int?)ChildClass.GetField("ParentChargeId").GetValue("ParentChargeId");
                        CalculationProduct.IsVisible = (bool)ChildClass.GetField("IsVisible").GetValue("IsVisible");
                        CalculationProduct.IsActive = (bool)ChildClass.GetField("IsActive").GetValue("IsActive");
                        CalculationProduct.IncludedCharges = (string)ChildClass.GetField("IncludedCharges").GetValue("IncludedCharges");
                        CalculationProduct.IncludedChargesCalculation = (string)ChildClass.GetField("IncludedChargesCalculation").GetValue("IncludedChargesCalculation");
                        CalculationProduct.ModifiedBy = "System";
                        CalculationProduct.ModifiedDate = System.DateTime.Now;
                        CalculationProduct.ObjectState = Model.ObjectState.Modified;
                        db.CalculationProduct.Add(CalculationProduct);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertCalculationFooter()
        {
            try
            {
                Type CalculationFooterConstantsType = typeof(CalculationFooterConstants);

                System.Type[] ChildClassCollection = CalculationFooterConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int CalculationFooterLineId = (int)ChildClass.GetField("CalculationFooterLineId").GetRawConstantValue();

                    if (db.CalculationFooter.Find(CalculationFooterLineId) == null)
                    {
                        CalculationFooter CalculationFooter = new CalculationFooter();
                        CalculationFooter.CalculationFooterLineId = (int)ChildClass.GetField("CalculationFooterLineId").GetRawConstantValue();
                        CalculationFooter.CalculationId = (int)ChildClass.GetField("CalculationId").GetValue("CalculationId");
                        CalculationFooter.Sr = (int)ChildClass.GetField("Sr").GetValue("Sr");
                        CalculationFooter.ChargeId = (int)ChildClass.GetField("ChargeId").GetValue("ChargeId");
                        CalculationFooter.AddDeduct = (byte?)ChildClass.GetField("AddDeduct").GetValue("AddDeduct");
                        CalculationFooter.AffectCost = (bool)ChildClass.GetField("AffectCost").GetValue("AffectCost");
                        CalculationFooter.ChargeTypeId = (int?)ChildClass.GetField("ChargeTypeId").GetValue("ChargeTypeId");
                        CalculationFooter.CalculateOnId = (int?)ChildClass.GetField("CalculateOnId").GetValue("CalculateOnId");
                        CalculationFooter.ProductChargeId = (int?)ChildClass.GetField("ProductChargeId").GetValue("ProductChargeId");
                        CalculationFooter.RateType = (byte)ChildClass.GetField("RateType").GetValue("RateType");
                        CalculationFooter.IncludedInBase = (bool)ChildClass.GetField("IncludedInBase").GetValue("IncludedInBase");
                        CalculationFooter.ParentChargeId = (int?)ChildClass.GetField("ParentChargeId").GetValue("ParentChargeId");
                        CalculationFooter.IsVisible = (bool)ChildClass.GetField("IsVisible").GetValue("IsVisible");
                        CalculationFooter.IsActive = (bool)ChildClass.GetField("IsActive").GetValue("IsActive");
                        CalculationFooter.IncludedCharges = (string)ChildClass.GetField("IncludedCharges").GetValue("IncludedCharges");
                        CalculationFooter.IncludedChargesCalculation = (string)ChildClass.GetField("IncludedChargesCalculation").GetValue("IncludedChargesCalculation");
                        CalculationFooter.CreatedBy = "System";
                        CalculationFooter.ModifiedBy = "System";
                        CalculationFooter.CreatedDate = System.DateTime.Now;
                        CalculationFooter.ModifiedDate = System.DateTime.Now;
                        CalculationFooter.ObjectState = Model.ObjectState.Added;
                        db.CalculationFooter.Add(CalculationFooter);
                    }
                    else
                    {
                        CalculationFooter CalculationFooter = db.CalculationFooter.Find(CalculationFooterLineId);
                        CalculationFooter.CalculationId = (int)ChildClass.GetField("CalculationId").GetValue("CalculationId");
                        CalculationFooter.Sr = (int)ChildClass.GetField("Sr").GetValue("Sr");
                        CalculationFooter.ChargeId = (int)ChildClass.GetField("ChargeId").GetValue("ChargeId");
                        CalculationFooter.AddDeduct = (byte?)ChildClass.GetField("AddDeduct").GetValue("AddDeduct");
                        CalculationFooter.AffectCost = (bool)ChildClass.GetField("AffectCost").GetValue("AffectCost");
                        CalculationFooter.ChargeTypeId = (int?)ChildClass.GetField("ChargeTypeId").GetValue("ChargeTypeId");
                        CalculationFooter.CalculateOnId = (int?)ChildClass.GetField("CalculateOnId").GetValue("CalculateOnId");
                        CalculationFooter.ProductChargeId = (int?)ChildClass.GetField("ProductChargeId").GetValue("ProductChargeId");
                        CalculationFooter.RateType = (byte)ChildClass.GetField("RateType").GetValue("RateType");
                        CalculationFooter.IncludedInBase = (bool)ChildClass.GetField("IncludedInBase").GetValue("IncludedInBase");
                        CalculationFooter.ParentChargeId = (int?)ChildClass.GetField("ParentChargeId").GetValue("ParentChargeId");
                        CalculationFooter.IsVisible = (bool)ChildClass.GetField("IsVisible").GetValue("IsVisible");
                        CalculationFooter.IsActive = (bool)ChildClass.GetField("IsActive").GetValue("IsActive");
                        CalculationFooter.IncludedCharges = (string)ChildClass.GetField("IncludedCharges").GetValue("IncludedCharges");
                        CalculationFooter.IncludedChargesCalculation = (string)ChildClass.GetField("IncludedChargesCalculation").GetValue("IncludedChargesCalculation");
                        CalculationFooter.ModifiedBy = "System";
                        CalculationFooter.ModifiedDate = System.DateTime.Now;
                        CalculationFooter.ObjectState = Model.ObjectState.Modified;
                        db.CalculationFooter.Add(CalculationFooter);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public void InsertPersonSetting()
        {
            try
            {
                Type PersonSettingConstantsType = typeof(PersonSettingConstants);

                System.Type[] ChildClassCollection = PersonSettingConstantsType.GetNestedTypes();

                foreach (System.Type ChildClass in ChildClassCollection)
                {
                    int PersonSettingId = (int)ChildClass.GetField("PersonSettingsId").GetRawConstantValue();
                    if (db.PersonSettings.Find(PersonSettingId) == null)
                    {
                        PersonSettings PersonSettings = new PersonSettings();
                        PersonSettings.PersonSettingsId = (int)ChildClass.GetField("PersonSettingsId").GetRawConstantValue();
                        PersonSettings.DocTypeId = (int)ChildClass.GetField("DocTypeId").GetRawConstantValue();
                        PersonSettings.DefaultProcessId = (int)ChildClass.GetField("DefaultProcessId").GetRawConstantValue();
                        PersonSettings.LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                        PersonSettings.isVisibleAddress = (Boolean)ChildClass.GetField("isVisibleAddress").GetRawConstantValue();
                        PersonSettings.isVisibleCity = (Boolean)ChildClass.GetField("isVisibleCity").GetRawConstantValue();
                        PersonSettings.CreatedBy = "System";
                        PersonSettings.ModifiedBy = "System";
                        PersonSettings.CreatedDate = System.DateTime.Now;
                        PersonSettings.ModifiedDate = System.DateTime.Now;
                        PersonSettings.ObjectState = Model.ObjectState.Added;
                        db.PersonSettings.Add(PersonSettings);
                    }
                    else
                    {
                        PersonSettings PersonSettings = db.PersonSettings.Find(PersonSettingId);
                        PersonSettings.DocTypeId = (int)ChildClass.GetField("DocTypeId").GetRawConstantValue();
                        PersonSettings.LedgerAccountGroupId = (int)ChildClass.GetField("LedgerAccountGroupId").GetRawConstantValue();
                        PersonSettings.DefaultProcessId = (int)ChildClass.GetField("DefaultProcessId").GetRawConstantValue();
                        PersonSettings.isVisibleAddress = (Boolean)ChildClass.GetField("isVisibleAddress").GetRawConstantValue();
                        PersonSettings.isVisibleCity = (Boolean)ChildClass.GetField("isVisibleCity").GetRawConstantValue();
                        PersonSettings.ModifiedBy = "System";
                        PersonSettings.ModifiedDate = System.DateTime.Now;
                        PersonSettings.ObjectState = Model.ObjectState.Modified;
                        db.PersonSettings.Add(PersonSettings);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void InitializeUserTables(ApplicationDbContext db)
        {
            string mQry = "";

            mQry = " INSERT INTO Web.AspNetRoles (Id, Name) VALUES ('302b9430-498e-46e8-8ead-9e92867b7c9f', 'Admin') ";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = " INSERT INTO Web.Users (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName, Discriminator) " +
                    " VALUES ('99bddeed-49d4-45fd-8f2c-df57c78434dd', 'meet2arpit@rediffmail.com', 1, 'AIrF0x9YIMRYD8NbDwddsu59QH2AojxsDKdH3yxRYT180EEJqSrnTmWjF1fgxnSZ8g==', '432a52e7-c4f9-4ef5-81cf-7fdc75c7d964', NULL, 0, 0, NULL, 0, 1, 'admin', NULL, NULL, '1') ";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = @"INSERT INTO Web.UserRoles (UserId, RoleId, SiteId, DivisionId,  ExpiryDate, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
                    VALUES ('99bddeed-49d4-45fd-8f2c-df57c78434dd', '302b9430-498e-46e8-8ead-9e92867b7c9f', 
                    " + SiteConstants.MainSite.SiteId + @",
                    " + DivisionConstants.MainDivision.DivisionId + @",
                    NULL, 'Admin', getdate(), 'Admin', getdate()) ";
            db.Database.ExecuteSqlCommand(mQry);
        }
        private void InitializePersonTables(ApplicationDbContext db)
        {
            string mQry = "";

            mQry = "INSERT INTO Web.People (DocTypeId, Name, Suffix, Code, IsActive, IsSisterConcern, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(" + DocumentTypeConstants.Customer.DocumentTypeId + ", 'Customer', '00000721', '00000721', 1, 0, 'Admin', 'Admin', getdate(), getdate()) ";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.BusinessEntities (PersonID, IsSisterConcern, DivisionIds, SiteIds) " +
                    " SELECT P.PersonID, 0, '|"+ DivisionConstants.MainDivision.DivisionId.ToString()  + "|','|" + SiteConstants.MainSite.SiteId.ToString() + "|' " +
                    " FROM web.People P WITH(nolock) " +
                    " WHERE P.Name = 'Customer' AND P.DocTypeId =  " + DocumentTypeConstants.Customer.DocumentTypeId + "";
            db.Database.ExecuteSqlCommand(mQry);


            mQry = "INSERT INTO Web.LedgerAccounts (LedgerAccountId, LedgerAccountName, LedgerAccountSuffix, PersonId, LedgerAccountGroupId, IsActive, IsSystemDefine, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " SELECT (SELECT Max(G.LedgerAccountId) FROM web.LedgerAccounts G WITH (Nolock) ) +1 AS LedgerAccountId, P.Name AS LedgerAccountName, P.Suffix AS LedgerAccountSuffix, P.PersonID, " + LedgerAccountGroupConstants.SundryDebtors.LedgerAccountGroupId + ", 1, 1, 'Admin', 'Admin', getdate(), getdate() " +
                    " FROM web.People P WITH(nolock) " +
                    " WHERE P.Name = 'Customer' AND P.DocTypeId =  " + DocumentTypeConstants.Customer.DocumentTypeId + "";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.PersonAddresses (PersonId, CityId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    "SELECT P.PersonID, " + CityConstants.Kanpur.CityId + ", 'Admin', 'Admin', getdate(), getdate() " +
                    " FROM web.People P WITH(nolock) " +
                    " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.PersonRoles (PersonId, RoleDocTypeId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                "SELECT P.PersonID,  " + DocumentTypeConstants.Customer.DocumentTypeId + ", 'Admin', 'Admin', getdate(), getdate() " +
                " FROM web.People P WITH(nolock) " +
                " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
            db.Database.ExecuteSqlCommand(mQry);


           mQry= "INSERT INTO Web.PersonProcesses(PersonId, ProcessId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                "SELECT P.PersonID,  " + ProcessConstants.Sale.ProcessId + ", 'Admin', 'Admin', getdate(), getdate() " +
                " FROM web.People P WITH(nolock) " +
                " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
            db.Database.ExecuteSqlCommand(mQry);

        }


        private void InitializeSettingsTables(ApplicationDbContext db)
        {
            string mQry = "";
            mQry = "INSERT INTO Web.SaleEnquirySettings(SaleEnquirySettingsId,  isVisibleCurrency, isVisibleShipMethod, isVisibleDealUnit, UnitConversionForId, ProcessId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate,  filterPersonRoles) " +
                    " VALUES(1, 1, 1, 1, " + UnitConversionForConstants.Standard.UnitconversionForId + ", " + ProcessConstants.Sale.ProcessId + ", 'Admin', 'Admin', getdate(), getdate(), '" + DocumentTypeConstants.Customer.DocumentTypeId.ToString () + "')";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.ProductBuyerSettings (ProductBuyerSettingsId,BuyerSpecificationDisplayName, BuyerSpecification1DisplayName, BuyerSpecification2DisplayName, BuyerSpecification3DisplayName, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(1, 'BuyerSpecification', 'BuyerSpecification1', 'BuyerSpecification2', 'BuyerSpecification3', 'Admin', 'Admin', getdate(), getdate())";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.CarpetSkuSettings (CarpetSkuSettingsId,isVisibleProductDesign, isVisibleProductStyle, isVisibleProductManufacturer, isVisibleProductDesignPattern, isVisibleContent, isVisibleOriginCountry, isVisibleInvoiceGroup, isVisibleDrawbackTarrif, isVisibleStandardCost, isVisibleStandardWeight, isVisibleSupplierDetail, isVisibleSample, isVisibleCounterNo, isVisibleTags, isVisibleDivision, isVisibleColour, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, OMSId, ProductDesignId, OriginCountryId, AddColourInProductName, isVisibleProductionRemark, isVisibleGrossWeight, UnitConversions, isVisibleMapScale, isVisibleCBM, isVisibleTraceType, isVisibleMapType, isVisibleStencilSize, PerimeterSizeTypeId, NameBaseOnSize, isVisibleSalesTaxProductCode, SalesTaxProductCodeCaption) " +
                    " VALUES(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'Admin', 'Admin', Getdate(), Getdate(), NULL, " + ProductDesignConstants.NA.ProductDesignId + ", 1, 1, 0, 1, 'MT2', NULL, NULL, NULL, NULL, NULL, " + ProductSizeTypesConstants.Standard.ProductSizeTypeId + ", 'ManufacturingSizeName', NULL, NULL)";
            db.Database.ExecuteSqlCommand(mQry);


            mQry = "INSERT INTO Web.ProductTypeSettings (ProductTypeSettingsId, ProductTypeId, UnitId, isShowMappedDimension1, isShowUnMappedDimension1, isApplicableDimension1, Dimension1Caption, isShowMappedDimension2, isShowUnMappedDimension2, isApplicableDimension2, Dimension2Caption, isShowMappedDimension3, isShowUnMappedDimension3, isApplicableDimension3, Dimension3Caption, isShowMappedDimension4, isShowUnMappedDimension4, isApplicableDimension4, Dimension4Caption, isVisibleProductDescription, isVisibleProductSpecification, isVisibleProductCategory, isVisibleSalesTaxGroup, isVisibleSaleRate, isVisibleStandardCost, isVisibleTags, isVisibleMinimumOrderQty, isVisibleReOrderLevel, isVisibleGodownId, isVisibleBinLocationId, isVisibleProfitMargin, isVisibleCarryingCost, isVisibleLotManagement, isVisibleConsumptionDetail, isVisibleProductProcessDetail, isVisibleDefaultDimension1, isVisibleDefaultDimension2, isVisibleDefaultDimension3, isVisibleDefaultDimension4, isVisibleDiscontinueDate, isVisibleSalesTaxProductCode, IndexFilterParameter, ProductNameCaption, ProductCodeCaption, ProductDescriptionCaption, ProductSpecificationCaption, ProductGroupCaption, ProductCategoryCaption, SalesTaxProductCodeCaption, SqlProcProductCode, ImportMenuId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(1, " + ProductTypeConstants.Rug.ProductTypeId + ", 'Pcs', 0, 0, 1, 'Colour', 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Admin', 'Admin', Getdate(), Getdate())";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = "INSERT INTO Web.ProductTypeSettings (ProductTypeSettingsId, ProductTypeId, UnitId, isShowMappedDimension1, isShowUnMappedDimension1, isApplicableDimension1, Dimension1Caption, isShowMappedDimension2, isShowUnMappedDimension2, isApplicableDimension2, Dimension2Caption, isShowMappedDimension3, isShowUnMappedDimension3, isApplicableDimension3, Dimension3Caption, isShowMappedDimension4, isShowUnMappedDimension4, isApplicableDimension4, Dimension4Caption, isVisibleProductDescription, isVisibleProductSpecification, isVisibleProductCategory, isVisibleSalesTaxGroup, isVisibleSaleRate, isVisibleStandardCost, isVisibleTags, isVisibleMinimumOrderQty, isVisibleReOrderLevel, isVisibleGodownId, isVisibleBinLocationId, isVisibleProfitMargin, isVisibleCarryingCost, isVisibleLotManagement, isVisibleConsumptionDetail, isVisibleProductProcessDetail, isVisibleDefaultDimension1, isVisibleDefaultDimension2, isVisibleDefaultDimension3, isVisibleDefaultDimension4, isVisibleDiscontinueDate, isVisibleSalesTaxProductCode, IndexFilterParameter, ProductNameCaption, ProductCodeCaption, ProductDescriptionCaption, ProductSpecificationCaption, ProductGroupCaption, ProductCategoryCaption, SalesTaxProductCodeCaption, SqlProcProductCode, ImportMenuId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(2, " + ProductTypeConstants.Yarn.ProductTypeId + ", 'KG', 0, 0, 1, 'Shade', 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Admin', 'Admin', Getdate(), Getdate())";
            db.Database.ExecuteSqlCommand(mQry);

        }

        private void InitializeProcedure(ApplicationDbContext db)
        {
            string mQry = "";
            mQry = @"CREATE PROCEDURE[Web].[GetNewDocNo]
        @FieldName VARCHAR(50), @TableName VARCHAR(50),@DocTypeId INT, @DocDate SMALLDATETIME, @DivisionId INT, @SiteId INT --,@NewDocNo nVarChar(50) OUTPUT
    AS
BEGIN
    DECLARE @StartDate SMALLDATETIME
    DECLARE @EndDate SMALLDATETIME
    DECLARE @Ref_Prefix VARCHAR(10)
    DECLARE @Ref_PadLength INT

    DECLARE @IsNumberingCategoryWise BIT
    DECLARE @DocCategoryId INT
    DECLARE @IsNumberingSiteWise BIT
    DECLARE @IsNumberingDivisionWise BIT

    SELECT @IsNumberingCategoryWise=IsNumberingDocCategoryWise, @IsNumberingSiteWise=IsNumberingSiteWise , @IsNumberingDivisionWise=IsNumberingDivisionWise
    FROM web.DocumentTypeSettings WHERE DocumentTypeId = @DocTypeId

    SET @DocCategoryId =(SELECT DocumentCategoryId  FROM web.DocumentTypes WHERE DocumentTypeId = @DocTypeId)


    SET @Ref_PadLength = 5
    IF(@DocDate >= '01/Apr/2018' AND @DocDate <= '31/Mar/2019 23:59:59' )
    BEGIN
        SET @StartDate = '01/Apr/2018'
		SET @EndDate = '31/Mar/2019 23:59:59'
        SET @Ref_Prefix = '18-'
    END
    ELSE IF(@DocDate >= '01/Apr/2017' AND @DocDate <= '31/Mar/2018 23:59:59' )
    BEGIN
        SET @StartDate = '01/Apr/2017'
		--SET @EndDate = '31/Mar/2018 23:59:59'
        SET @EndDate = '31/Mar/2018'
        SET @Ref_Prefix = '17-'
    END
    ELSE IF(@DocDate >= '01/Apr/2016' AND @DocDate <= '31/Mar/2017 23:59:59' )
    BEGIN
        SET @StartDate = '01/Apr/2016'
		SET @EndDate = '31/Mar/2017 23:59:59'
        SET @Ref_Prefix = '16-'
    END
    ELSE IF(@DocDate >= '01/Apr/2015' AND @DocDate <= '31/Mar/2016 23:59:59' )
    BEGIN
        SET @StartDate = '01/Apr/2015'
		SET @EndDate = '31/Mar/2016 23:59:59'
        SET @Ref_Prefix = '15-'
    END
    ELSE IF(@DocDate >= '01/Apr/2014' AND @DocDate <= '31/Mar/2015' )
    BEGIN
        SET @StartDate = '01/Apr/2014'
		SET @EndDate = '31/Mar/2015'
        SET @Ref_Prefix = '14-'
    END
       ELSE IF(@DocDate >= '01/Apr/2013' AND @DocDate <= '31/Mar/2014' )
    BEGIN
        SET @StartDate = '01/Apr/2013'
		SET @EndDate = '31/Mar/2014'
        SET @Ref_Prefix = '13-'
    END
       ELSE IF(@DocDate >= '01/Apr/2012' AND @DocDate <= '31/Mar/2013' )
    BEGIN
        SET @StartDate = '01/Apr/2012'
		SET @EndDate = '31/Mar/2013'
        SET @Ref_Prefix = '12-'
    END
       ELSE IF(@DocDate >= '01/Apr/2011' AND @DocDate <= '31/Mar/2012' )
    BEGIN
        SET @StartDate = '01/Apr/2011'
		SET @EndDate = '31/Mar/2012'
        SET @Ref_Prefix = '11-'
    END
       ELSE IF(@DocDate >= '01/Apr/2010' AND @DocDate <= '31/Mar/2011' )
    BEGIN
        SET @StartDate = '01/Apr/2010'
		SET @EndDate = '31/Mar/2011'
        SET @Ref_Prefix = '10-'
    END


    DECLARE @Sql VARCHAR(2000)

    IF @IsNumberingCategoryWise = 1
    BEGIN
           IF(@IsNumberingSiteWise= 0 AND @IsNumberingDivisionWise = 0)
        BEGIN
        SET @sql = N' 
	    SELECT ''' + @Ref_Prefix +  ''' + 
        RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric, Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
        From ' + @TableName +' H With(NoLock)
        LEFT JOIN Web.DocumentTypes DT With(NoLock)  on DT.DocumentTypeId =H.DocTypeId
       WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocumentCategoryId = ' + Convert(nvarchar ,@DocCategoryId) +'
        And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	    END
        ELSE
        BEGIN
        SET @sql = N' 
	    SELECT ''' + @Ref_Prefix +  ''' + 
        RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric, Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
        From ' + @TableName +' H With(NoLock)
        LEFT JOIN Web.DocumentTypes DT With(NoLock)  on DT.DocumentTypeId =H.DocTypeId
       WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocumentCategoryId = ' + Convert(nvarchar ,@DocCategoryId) +' And DivisionId = ' + Convert(nvarchar ,@DivisionId) +'
        And SiteId = ' + Convert(nvarchar ,@SiteId) +'
        And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	    END
    END
    ELSE
       BEGIN
        SET @sql = N' 
        SELECT ''' + @Ref_Prefix +  ''' + 
        RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric, Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
        From ' + @TableName +' With(NoLock)
        WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocTypeId = ' + Convert(nvarchar ,@DocTypeId) +' And DivisionId = ' + Convert(nvarchar ,@DivisionId) +'
        And SiteId = ' + Convert(nvarchar ,@SiteId) +'
        And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	END

    Exec(@sql)
    PRINT @sql
	
	--SET @NewDocNo = @Ref_Prefix + RIGHT('000' + IsNull(@NewDocNo, ''), 4)
    --Return @NewDocNo
	--PRINT @NewDocNo
END";
            db.Database.ExecuteSqlCommand(mQry);



            mQry = @"CREATE  PROCEDURE Web.sp_GetCustomCarpetSkuName (@ProductGroupName VARCHAR(50), @StandardSizeName VARCHAR(50), @ColourName VARCHAR(50))
                    AS
                    SELECT Replace(@ProductGroupName, '-', '') + '-' + @StandardSizeName + '-' + @ColourName AS ProductName";
            db.Database.ExecuteSqlCommand(mQry);

            mQry = @"CREATE  PROCEDURE Web.sp_GetUnitConversionForSize (@SizeId INT, @ToUnitId NVARCHAR(3), @Attribute NVARCHAR(20) = NULL)
AS 

DECLARE @ToQty DECIMAL(18,4) = 0
DECLARE @ProductShape NVARCHAR(10)
DECLARE @UnitId NVARCHAR(10)

SELECT @ProductShape = Ps.ProductShapeName, @UnitId=S.UnitId 
FROM Web.Sizes S
LEFT JOIN Web.ProductShapes Ps ON S.ProductShapeId = Ps.ProductShapeId
WHERE SizeId = @SizeId


IF (@ToUnitId = 'MT2')
BEGIN
IF (@UnitId = 'MET')
	BEGIN
	SELECT @ToQty=(S.Length+S.LengthFraction/100)* (S.Width +S.WidthFraction/100)
	FROM Web.Sizes S
	WHERE SizeId = @SizeId
	END 
ELSE 
	BEGIN 
	DECLARE @LengthCms DECIMAL(18,4) = 0
	DECLARE @WidthCms DECIMAL(18,4) = 0
	
	SELECT @LengthCms = IsNull(F.Cms,0)
	FROM Web.Sizes S
	LEFT JOIN Web.FeetConversionToCms F ON S.Length = F.Feet AND S.LengthFraction = F.Inch
	WHERE SizeId = @SizeId
	AND F.FeetConversionToCmsId IS NOT NULL
	
	SELECT @WidthCms = IsNull(F.Cms,0)
	FROM Web.Sizes S
	LEFT JOIN Web.FeetConversionToCms F ON S.Width = F.Feet AND S.WidthFraction = F.Inch
	WHERE SizeId = @SizeId
	AND F.FeetConversionToCmsId IS NOT NULL
	
	
	SET @ToQty =(@LengthCms * @WidthCms)/10000
	END 
END

IF (@ToUnitId = 'FT')
BEGIN
IF (@UnitId = 'MET')
	BEGIN
	
	
		
DECLARE @SCL DECIMAL(18,5) 
DECLARE @SCW DECIMAL(18,5) 

DECLARE @SLF DECIMAL(18,5) 
DECLARE @SLI DECIMAL(18,5) 
DECLARE @SWF DECIMAL(18,5) 
DECLARE @SWI DECIMAL(18,5) 



SELECT @SCL=0.393701*(S.Length*100+S.LengthFraction), @SCW=0.393701*(S.Width*100 +S.WidthFraction)
FROM Web.Sizes S
WHERE SizeId = @SizeId
	

SET @SLF=round(convert(INT,@SCL)/12,0)
SET @SWF=round(convert(INT,@SCW)/12,0)
SET @SLI=round(@SCL%12,0)
SET @SWI=round(@SCW%12,0)



		IF (@ProductShape = 'Rectangle')
		BEGIN
			IF (@Attribute = 'Length')
			BEGIN
				SELECT @ToQty = Round((@SLF + (@SLI / 12)) * 2,3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
			
			IF (@Attribute = 'Width')
			BEGIN
				SELECT @ToQty = Round((@SWF + (@SWI / 12)) * 2,3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
			
			IF (@Attribute = 'Length + Width')
			BEGIN
				SELECT @ToQty = Round(((@SLF + (@SLI / 12)) * 2) + ((@SWF + (@SWI / 12)) * 2),3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
		END
		ELSE
		BEGIN
			SELECT @ToQty = Floor((@SLF + (@SLI / 12)) * 3.14)
			FROM Web.Sizes S
			WHERE SizeId = @SizeId
		END 
		
	END 
ELSE 
		BEGIN 
		IF (@ProductShape = 'Rectangle')
		BEGIN
			IF (@Attribute = 'Length')
			BEGIN
				SELECT @ToQty = Round((S.Length + (S.LengthFraction / 12)) * 2,3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
			
			IF (@Attribute = 'Width')
			BEGIN
				SELECT @ToQty = Round((S.Width + (S.WidthFraction / 12)) * 2,3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
			
			IF (@Attribute = 'Length + Width')
			BEGIN
				SELECT @ToQty = Round(((S.Length + (S.LengthFraction / 12)) * 2) + ((S.Width + (S.WidthFraction / 12)) * 2),3)
				FROM Web.Sizes S
				WHERE SizeId = @SizeId
			END 
		END
		ELSE
		BEGIN
			SELECT @ToQty = Floor((S.Length + (S.LengthFraction / 12)) * 3.14)
			FROM Web.Sizes S
			WHERE SizeId = @SizeId
		END 
	END 
END 

SELECT @ToQty AS ToQty;";

            db.Database.ExecuteSqlCommand(mQry);

            mQry = @"CREATE  Procedure Web.sp_GetFirstProductForColourWayAndSize (@ProductDesignId INT, @StandardSizeID INT)
AS 

DECLARE @ProductGruopName NVARCHAR(200)
DECLARE @SizeName NVARCHAR(200)

SELECT @ProductGruopName = Replace(ProductGroupName,'-','')
FROM Web.ProductGroups
WHERE ProductGroupId  IN (
	SELECT Min(Pg.ProductGroupId)
	FROM Web.FinishedProduct F 
	LEFT JOIN Web.Products P ON F.ProductId = P.ProductId
	LEFT JOIN Web.ProductGroups Pg ON P.ProductGroupId = Pg.ProductGroupId
	WHERE F.ProductDesignId = @ProductDesignId
)

SELECT @SizeName = Replace(Replace(Replace(Replace(S.SizeName,'`',''),'""',''),'X',''),' ','')  + 
IsNull(Ps.ProductShapeShortName, '')
FROM Web.Sizes S
LEFT JOIN Web.ProductShapes Ps ON S.ProductShapeId = Ps.ProductShapeId
WHERE S.SizeId = @StandardSizeID



DECLARE @StencilSizeID INT

SELECT @StencilSizeID = StencilSizeID
FROM Web.ViewRugSize
WHERE ProductId IN
(
    SELECT Min(F.ProductId)
    FROM Web.FinishedProduct F
    LEFT JOIN Web.ViewRugSize Vrs ON F.ProductId = Vrs.ProductId
    WHERE F.ProductDesignId = @ProductDesignId AND Vrs.StandardSizeID = @StandardSizeID
)

SELECT @ProductGruopName +'-' + @SizeName AS ProductName, @StandardSizeID AS StandardSizeID, @StencilSizeID AS StencilSizeID ";
 db.Database.ExecuteSqlCommand(mQry);


        }

        private void InitializeFunction(ApplicationDbContext db)
        {
            string mQry = @"CREATE FUNCTION[Web].[FuncConvertSqFeetToSqYard](@SqFeets DECIMAL(18,4))  
RETURNS @Results TABLE(SqYard DECIMAL(18,4))  AS BEGIN  DECLARE @MyInt INT
DECLARE @MyFrcation Decimal(18,4)  DECLARE @TempSqYard Decimal(18,4)
 SET @TempSqYard = @SqFeets * 0.111111111  SET @MyInt = Convert(INT, @TempSqYard)  SET @MyFrcation = @TempSqYard - @MyInt  If(@MyFrcation* 16) > 1      begin SET @MyFrcation = @MyFrcation* 16     SET @MyFrcation = convert(INT, @MyFrcation)     SET @MyFrcation = @MyFrcation / 16     end Else IF @MyInt > 0       BEGIN SET @MyFrcation = 0      END SET @SqFeets = @MyInt + @MyFrcation INSERT INTO @Results(SqYard) VALUES(@SqFeets)  RETURN END";
            db.Database.ExecuteSqlCommand(mQry);


        }

        private void InitializeSqlViews(ApplicationDbContext db)
        {
            string mqry = "";
            mqry = @"IF OBJECT_ID('Web.ViewRugSize') IS NOT NULL
   DROP VIEW Web.ViewRugSize


CREATE VIEW[Web].[ViewRugSize]
        AS
SELECT P.ProductId, 
SS.SizeId AS StandardSizeID, SS.SizeName + IsNull(SSS.ProductShapeShortName,'') AS StandardSizeName, SS.Area AS StandardSizeArea,  
SM.SizeId AS ManufaturingSizeID, SM.SizeName + IsNull(SSS.ProductShapeShortName,'') AS ManufaturingSizeName, SM.Area AS ManufaturingSizeArea,
SF.SizeId AS FinishingSizeID,SF.SizeName + IsNull(SSS.ProductShapeShortName,'') AS FinishingSizeName, SF.Area AS FinishingSizeArea   ,
ST.SizeId AS StencilSizeID,ST.SizeName + IsNull(SSS.ProductShapeShortName,'') AS StencilSizeName, ST.Area AS StencilSizeArea  ,
SP.SizeId AS MapSizeID,SP.SizeName + IsNull(SSS.ProductShapeShortName,'') AS MapSizeName, SP.Area AS MapSizeArea
FROM Web.Products P
LEFT JOIN(
    SELECT PSS.ProductId, PSS.SizeId
    FROM Web.ProductSizes PSS
    WHERE PSS.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Standard')
) AS PSS ON P.ProductId = PSS.ProductId
LEFT JOIN (     
    SELECT PSM.ProductId, PSM.SizeId
    FROM Web.ProductSizes PSM
    WHERE PSM.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Manufaturing Size')
) AS PSM ON P.ProductId = PSM.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Finishing Size')
) AS PSF ON P.ProductId = PSF.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Stencil')
) AS PST ON P.ProductId = PST.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Map')
) AS PSP ON P.ProductId = PSP.ProductId
LEFT JOIN Web.Sizes SS ON SS.SizeId = PSS.SizeId
LEFT JOIN Web.ProductShapes SSS ON SS.ProductShapeId = SSS.ProductShapeId
LEFT JOIN Web.Sizes SM ON SM.SizeId = PSM.SizeId
LEFT JOIN Web.ProductShapes SSM ON SM.ProductShapeId = SSM.ProductShapeId
LEFT JOIN Web.Sizes SF ON SF.SizeId = PSF.SizeId
LEFT JOIN Web.ProductShapes SSF ON SF.ProductShapeId = SSF.ProductShapeId
LEFT JOIN Web.Sizes ST ON ST.SizeId = PST.SizeId
LEFT JOIN Web.ProductShapes SST ON ST.ProductShapeId = SST.ProductShapeId
LEFT JOIN Web.Sizes SP ON SP.SizeId = PSP.SizeId
LEFT JOIN Web.ProductShapes SSP ON SP.ProductShapeId = SSP.ProductShapeId";

            db.Database.ExecuteSqlCommand(mQry);

        }

    }
}