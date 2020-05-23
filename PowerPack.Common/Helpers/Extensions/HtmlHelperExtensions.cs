using System;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using PowerPack.Common.Localization;
using PowerPack.Common.ViewModels;
using System.Data.SqlClient;
using System.Configuration;
using PowerPack.Common.CustomAttributes;
using PowerPack.Models;


namespace PowerPack.Common.Helpers.Extensions
{
    public static class HtmlHelperExtensions
    {
        #region BreadCrumb
        public static MvcHtmlString BreadCrumb(this HtmlHelper helper, IEnumerable<ModuleStructure> currentPageStructure)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul class=\"clearfix breadcrumbs\">");
            int itemIndex = 1;
            foreach (ModuleStructure page in currentPageStructure)
            {
                string activeCssClass = (currentPageStructure.LastOrDefault() == page) ? " class=\"active\"" : string.Empty;
                if (itemIndex > currentPageStructure.Count()-1)
                {
                    // Do not add links for other items as it may open error page
                    page.ModuleUrl = string.Empty;
                }
                string linkTitle = string.IsNullOrWhiteSpace(page.ModuleUrl)
                    ? page.ModuleName
                    : string.Format("<a  href=\"{0}\">{1} </a>", page.ModuleUrl, page.ModuleName);

                sb.Append(string.Format("<li{0}>{1}</li>", activeCssClass, linkTitle));
                itemIndex++;
            }
            sb.Append("</ul>");

            return MvcHtmlString.Create(sb.ToString());
        }
        #endregion

        #region Localized Controls

        public static string ActionButtonsHtmlTemplate
        {
            get
            {
                return "<div class='tbl-actions'>{0}</div>";
            }
        }

        public static MvcHtmlString LocalizedLabel(this HtmlHelper helper, string cssClass, string keyPath)
        {
            object attributes = null;
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                attributes = new { @class = cssClass };
            }
            string required = ResourceManager.GetValidators(keyPath).Contains("required") ? "<span class='text-danger'>*</span>" : "";
            if (string.IsNullOrEmpty(required))
                return LocalizedLabel(helper, keyPath, attributes);

            TagBuilder tagBuilder = new TagBuilder("label");

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tagBuilder.MergeAttribute("class", cssClass);
            }

            tagBuilder.InnerHtml = !string.IsNullOrWhiteSpace(keyPath) ? ResourceManager.GetString(keyPath) + required : string.Empty;
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString LocalizedLabel(this HtmlHelper helper, string keyPath, object attributes)
        {
            string required = ResourceManager.GetValidators(keyPath).Contains("required") ? "*" : "";
            return LabelExtensions.Label(helper, "", ResourceManager.GetString(keyPath) + required, attributes);
        }

        public static MvcHtmlString LocalizedLiteral(this HtmlHelper helper, string keyPath)
        {
            return MvcHtmlString.Create(ResourceManager.GetString(keyPath));
        }

        #region LocalizedLinkButton


        public static MvcHtmlString LocalizedSelectLinkButton(string href, HyperlinkAttributes attributes)
        {
            attributes.DefaultCssClass = "fas fa-angle-double-right btnSelect";
            return LocalizedLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedEditLinkButton(HyperlinkAttributes attributes)
        {
            if (attributes.PagePermission.CanEdit)
            {
                attributes.DefaultCssClass = "fas fa-pencil-alt btnEdit";
                attributes.TitleResourceKey = "Shared.Labels.EditRecord";
                return LocalizedLinkButton(attributes);
            }
            else
            {
                attributes.DefaultCssClass = "fas fa-eye btnEdit";
                attributes.TitleResourceKey = "Shared.Labels.View";
                return LocalizedLinkButton(attributes);
            }
        
        }

        public static MvcHtmlString LocalizedEditLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes, bool isViewMode = false)
        {
           
            attributes.DefaultCssClass = "fas fa-pencil-alt btnEdit";
            attributes.TitleResourceKey = "Shared.Labels.EditRecord";
            return LocalizedEditLinkButton(attributes, isViewMode);
        }

        public static MvcHtmlString LocalizedEditLinkButton(HyperlinkAttributes attributes, bool isViewMode = false)
        {
            if (string.IsNullOrEmpty(attributes.DefaultCssClass)) 
            attributes.DefaultCssClass = "fas fa-pencil-alt btnEdit";
            attributes.TitleResourceKey = "Shared.Labels.EditRecord";
            return LocalizedLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedDeleteLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes)
        {
            return LocalizedDeleteLinkButton(attributes);
        }


        public static MvcHtmlString LocalizedDeleteLinkButton(HyperlinkAttributes attributes)
        {

            attributes.DefaultCssClass = "far fa-trash-alt btnDelete";
            attributes.TitleResourceKey = "Shared.Labels.DeleteRecord";
            return LocalizedLinkButton(attributes);
        }

        #region LocalizedEditDeleteLinkButtons (2 Overloads)

        public static string LocalizedEditDeleteLinkButtons(int itemId, string itemName, bool isViewMode = false)
        {
            return LocalizedEditDeleteLinkButtons(itemId, itemName, string.Empty, isViewMode);
        }

        public static string LocalizedEditDeleteLinkButtons(int itemId, string itemName, string jsObjectName = "", bool isViewMode = false)
        {
            string editButtonCssClass = string.Empty;
            string deleteButtonCssClass = string.Empty;
            var handler = (!string.IsNullOrEmpty(jsObjectName) ? jsObjectName + "." : "");

            return LocalizedLinkButtons(
                               LocalizedEditLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "edit" + itemName + "Popup($(this),'" + itemId + "');",
                                   CssClass = editButtonCssClass
                               }, isViewMode).ToString() + "" +
                               LocalizedDeleteLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "delete" + itemName + "Data($(this)," + itemId + ");",
                                   CssClass = deleteButtonCssClass
                               }).ToString());
        }
        public static string LocalizedEditDeleteLinkButtons(HyperlinkAttributes attributes,int itemId, string itemName, string jsObjectName = "", bool isViewMode = false)
        {
            string editButtonCssClass = string.Empty;
            string deleteButtonCssClass = string.Empty;
            var handler = (!string.IsNullOrEmpty(jsObjectName) ? jsObjectName + "." : "");
            if (!attributes.PagePermission.CanEdit)
            {
                return LocalizedLinkButtons(
                              LocalizedEditLinkButton(new HyperlinkAttributes()
                              {
                                  OnClick = handler + "edit" + itemName + "Popup($(this),'" + itemId + "');",
                                  DefaultCssClass = "fa fa-eye btnView"
                              }, isViewMode).ToString());
            }
            return LocalizedLinkButtons(
                               LocalizedEditLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "edit" + itemName + "Popup($(this),'" + itemId + "');",
                                   CssClass = editButtonCssClass
                               }, isViewMode).ToString() + "" +
                               LocalizedDeleteLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "delete" + itemName + "Data($(this)," + itemId + ");",
                                   CssClass = deleteButtonCssClass
                               }).ToString());
        }
        public static string LocalizedSaveDeleteLinkButtons(int itemId, string itemName, string jsObjectName = "")
        {
            string okButtonCssClass = string.Empty;
            string deleteButtonCssClass = string.Empty;
            var handler = (string.IsNullOrEmpty(jsObjectName) ? jsObjectName + "." : "");

            return LocalizedLinkButtons(
                               LocalizedOkLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "save" + itemName + "($(this),'" + itemId + "');",
                                   CssClass = okButtonCssClass
                               }) + "" +
                               LocalizedDeleteLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = handler + "delete" + itemName + "Data($(this)," + itemId + ");",
                                   CssClass = deleteButtonCssClass
                               }));
        }

        public static string LocalizedDeleteLinkButton(int itemId, string itemName, bool isSmallActionButtons = false)
        {
            string deleteButtonCssClass = string.Empty;
            if (isSmallActionButtons)
            {
                deleteButtonCssClass = "btnDeleteSmall";
            }

            return LocalizedLinkButtons(
                               LocalizedDeleteLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = "delete" + itemName + "(this," + itemId + ");",
                                   CssClass = deleteButtonCssClass
                               }).ToString(), isSmallActionButtons);
        }

        public static MvcHtmlString LocalizedOkLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes)
        {
            return LocalizedOkLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedOkLinkButton(HyperlinkAttributes attributes)
        {
            attributes.DefaultCssClass = "fas fa-check-circle btnOk";
            attributes.TitleResourceKey = "Shared.Buttons.Ok";
            return LocalizedLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedCancelLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes)
        {
            return LocalizedCancelLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedCancelLinkButton(HyperlinkAttributes attributes)
        {
            attributes.DefaultCssClass = "fas fa-undo-alt btnCancel";
            attributes.TitleResourceKey = "Shared.Buttons.Cancel";
            return LocalizedLinkButton(attributes);
        }


        public static MvcHtmlString LocalizedPlusLinkButton(HyperlinkAttributes attributes)
        {
            attributes.DefaultCssClass = "fas fa-plus-circle";
            attributes.TitleResourceKey = "Shared.Labels.PlusRecord";
            return LocalizedLinkButton(attributes);
        }

        public static string LocalizedPlusLinkButton(string itemId, string itemName, bool isSmallActionButtons)
        {
            string plusButtonCssClass = string.Empty;
            if (isSmallActionButtons)
            {
                plusButtonCssClass += "btnPlusSmall";
            }

            return LocalizedLinkButtons(
                               LocalizedPlusLinkButton(new HyperlinkAttributes()
                               {
                                   OnClick = "add" + itemName + "('" + itemId + "');",
                                   CssClass = plusButtonCssClass
                               }).ToString(), isSmallActionButtons);
        }

        public static string LocalizedLinkButtons(string buttonsHtml, bool isSmallActionButtons = false)
        {
            string htmlUlTemplate = "<div class='tbl-actions'>{0}</div>";
            string panelCssClass = "panel-controls";

            if (isSmallActionButtons)
            {
                panelCssClass += "-small";
            }

            return string.Format(htmlUlTemplate, buttonsHtml);
        }

        #endregion
        public static MvcHtmlString LocalizedLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes)
        {
            return LocalizedLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes, bool embedInPanel)
        {
            return LocalizedLinkButton(helper, attributes, embedInPanel, false);
        }

        public static MvcHtmlString LocalizedLinkButton(this HtmlHelper helper, HyperlinkAttributes attributes, bool embedInPanel, bool isSmallActionButtons)
        {
            if (embedInPanel)
            {
                return MvcHtmlString.Create(LocalizedLinkButtons(LocalizedLinkButton(attributes).ToString(), isSmallActionButtons));
            }
            return LocalizedLinkButton(attributes);
        }

        public static MvcHtmlString LocalizedLinkButton(HyperlinkAttributes attributes)
        {
            TagBuilder tagBuilder = new TagBuilder("button");

            // build the input tag.    
            tagBuilder.MergeAttribute("class", "table-action-icon-btn ");

            if (!string.IsNullOrWhiteSpace(attributes.Id))
            {
                tagBuilder.MergeAttribute("id", attributes.Id);
            }
            if (!string.IsNullOrWhiteSpace(attributes.CssClass))
            {
                tagBuilder.MergeAttribute("class", attributes.CssClass);
            }
            if (!string.IsNullOrWhiteSpace(attributes.Title))
            {
                tagBuilder.MergeAttribute("title", attributes.Title);
            }
            if (!string.IsNullOrWhiteSpace(attributes.TitleResourceKey))
            {
                if (attributes.IsTitleFormatted)
                {
                    tagBuilder.MergeAttribute("title", ResourceManager.GetStringFormatted(attributes.TitleResourceKey, attributes.TitleFormatValues));
                }
                else
                {
                    tagBuilder.MergeAttribute("title", ResourceManager.GetString(attributes.TitleResourceKey));
                }
            }

            if (!string.IsNullOrEmpty(attributes.DefaultCssClass))
            {
                tagBuilder.InnerHtml = "<i class='" + attributes.DefaultCssClass + "'></i>";
            }
            else if (!string.IsNullOrEmpty(attributes.InnerIconCssClass))
            {
                tagBuilder.InnerHtml = "<i class='" + attributes.InnerIconCssClass + "'></i>";
            }

            if (!string.IsNullOrWhiteSpace(attributes.OnClick))
            {
                tagBuilder.MergeAttribute("onclick", attributes.OnClick);
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString LocalizedViewLinkButton(string href, HyperlinkAttributes attributes)
        {
            attributes.DefaultCssClass = "fas fa-eye btnView";
            attributes.TitleResourceKey = "Shared.Labels.ViewRecord";
            return LocalizedLinkButton(attributes);
        }
        #endregion

        #region Inputs

        private static MvcHtmlString LocalizedButton(string type, ButtonAttributes attributes)
        {
            TagBuilder tagBuilder = new TagBuilder("button");

            // build the input tag.
            if (!string.IsNullOrWhiteSpace(type))
            {
                tagBuilder.MergeAttribute("type", type);
            }
            if (!string.IsNullOrWhiteSpace(attributes.Id))
            {
                tagBuilder.MergeAttribute("id", attributes.Id);
            }
            if (!string.IsNullOrWhiteSpace(attributes.DefaultCssClass))
            {
                tagBuilder.MergeAttribute("class", attributes.DefaultCssClass);
            }
            if (!string.IsNullOrWhiteSpace(attributes.CssClass))
            {
                //tagBuilder.MergeAttribute("class", attributes.CssClass);
                tagBuilder.AddCssClass(attributes.CssClass);
            }
            tagBuilder.InnerHtml = !string.IsNullOrWhiteSpace(attributes.ResourceKey) ? ResourceManager.GetString(attributes.ResourceKey) : string.Empty;
            if (!string.IsNullOrWhiteSpace(attributes.OnClick))
            {
                tagBuilder.MergeAttribute("onclick", attributes.OnClick);
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString LocalizedSubmitButton(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.DefaultCssClass = "btn btn-info";
            return LocalizedButton(type, attributes);
        }

        public static MvcHtmlString LocalizedPreview(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.ResourceKey = "Shared.Buttons.Preview";
            return LocalizedSubmitButton(helper, type, attributes);
        }

        public static MvcHtmlString LocalizedSave(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.ResourceKey = "Shared.Buttons.Save";
            return LocalizedSubmitButton(helper, type, attributes);
        }

        public static MvcHtmlString LocalizedDelete(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.ResourceKey = "Shared.Buttons.Delete";
            return LocalizedSubmitButton(helper, type, attributes);
        }


        public static MvcHtmlString LocalizedSaveNext(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.ResourceKey = "Shared.Buttons.SaveNext";
            return LocalizedSubmitButton(helper, type, attributes);
        }

        public static MvcHtmlString LocalizedCancel(this HtmlHelper helper, String type, ButtonAttributes attributes)
        {
            attributes.DefaultCssClass = "btn btn-info";
            attributes.ResourceKey = "Shared.Buttons.Cancel";
            return LocalizedButton(type, attributes);
        }

        #endregion

        #endregion

        #region Popover Textbox

        //Usage: someModel.GetMetadata()
        //Gets the metadata for the type someModel.GetType().
        public static ModelMetadata GetMetadata<TModel>(this TModel model)
        {
            var metadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(TModel));
            return metadata;
        }

        //Usage: someModel.GetMetadataForProperty(m => m.SomeProperty)
        //Gets the metadata for the type someModel.SomePropery.GetType().
        public static ModelMetadata GetMetadataForProperty<TModel>(this TModel model, string propertyName)
        {
            return model.GetMetadata().Properties.Single(p => p.PropertyName == propertyName);
        }

        public static Expression<Func<TModel, dynamic>> GetPropertyExpression<TModel>(object model, string propertyName)
        {
            ParameterExpression fieldName = Expression.Parameter(typeof(object), "m");
            Expression fieldExpr = Expression.PropertyOrField(Expression.Constant(model), propertyName);
            return Expression.Lambda<Func<TModel, dynamic>>(fieldExpr, fieldName);
        }

        public static MvcHtmlString LocalizedPopoverTextbox<TModel>(this HtmlHelper<TModel> helper, string popoverTextboxIdPrefix, string labelResourceKey)
        {
            object model = helper.ViewData.Model;
            StringBuilder stringBuilder = new StringBuilder();
            var hiddenFieldStringBuilder = new StringBuilder();
            string otherLanguageCodes = string.Empty;
            string otherLanguageTextboxIds = string.Empty;

            IEnumerable<SystemLanguage> systemLanguages = SystemLanguageHelper.SystemLanguages;
            if (systemLanguages.Any())
            {
                SystemLanguage currentSystemLanguage = LocalizationHelper.CurrentSystemLanguage;
                string defaultLanguageId = currentSystemLanguage.SystemLanguageId.ToString();

                IDictionary<string, object> popoverTextBoxAttributes = new Dictionary<string, object>();
                popoverTextBoxAttributes.Add("class", "form-control");
                var maxLength = ResourceManager.GetMaxLength(labelResourceKey);
                if (!string.IsNullOrEmpty(maxLength)) popoverTextBoxAttributes.Add("maxlength", maxLength);

                if (systemLanguages.Count() > 1)
                {
                    popoverTextBoxAttributes.Add("data-labelname", ResourceManager.GetString(labelResourceKey));
                    popoverTextBoxAttributes.Add("data-input-class", "form-control");
                    popoverTextBoxAttributes.Add("rel", "multilang-textedit-popover");

                    IEnumerable<SystemLanguage> otherLanguages = systemLanguages.Where(
                        i => !i.SystemLanguageCode.Equals(currentSystemLanguage.SystemLanguageCode, StringComparison.OrdinalIgnoreCase));

                    foreach (var item in otherLanguages)
                    {
                        string otherLanguagetextboxId = popoverTextboxIdPrefix + Convert.ToString(item.SystemLanguageId);
                        otherLanguageTextboxIds += "po_" + otherLanguagetextboxId + ",";
                        otherLanguageCodes += item.SystemLanguageCode + ",";

                        var tagHidden = new TagBuilder("input");
                        tagHidden.MergeAttribute("type", "hidden");
                        tagHidden.MergeAttribute("name", otherLanguagetextboxId);
                        tagHidden.MergeAttribute("data-mapped-to", "po_" + otherLanguagetextboxId);
                        tagHidden.MergeAttribute("value", Convert.ToString(model.GetMetadataForProperty(otherLanguagetextboxId).Model));
                        hiddenFieldStringBuilder.Append(tagHidden);
                    }
                }

                popoverTextBoxAttributes.Add("data-otherlang-codes", otherLanguageCodes.TrimEnd(','));
                popoverTextBoxAttributes.Add("data-inputids", otherLanguageTextboxIds.TrimEnd(','));

                //Create a Input Group
                stringBuilder.Append("<div class=\"input-group\">");
                stringBuilder.Append(string.Format("<span class=\"input-group-addon\">{0}</span>", currentSystemLanguage.SystemLanguageCode.ToUpper()));
                var propertyExpression = GetPropertyExpression<TModel>(model, popoverTextboxIdPrefix + defaultLanguageId);
                stringBuilder.Append(InputExtensions.TextBoxFor(helper, propertyExpression, popoverTextBoxAttributes).ToHtmlString());
                stringBuilder.Append("</div>");
                stringBuilder.Append(hiddenFieldStringBuilder);
            }
            else
            {
                throw new ApplicationException("No Language available");
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        public static MvcHtmlString LocalizedLanguageTextbox<TModel>(this HtmlHelper<TModel> helper, string popoverTextboxIdPrefix, string labelResourceKey)
        {
            object model = helper.ViewData.Model;
            StringBuilder stringBuilder = new StringBuilder();
            var hiddenFieldStringBuilder = new StringBuilder();
            string otherLanguageCodes = string.Empty;
            string otherLanguageTextboxIds = string.Empty;

            IEnumerable<SystemLanguage> systemLanguages = SystemLanguageHelper.SystemLanguages;
            if (systemLanguages.Any())
            {
                SystemLanguage currentSystemLanguage = LocalizationHelper.CurrentSystemLanguage;
                string defaultLanguageId = currentSystemLanguage.SystemLanguageId.ToString(); //1
                string xmlPropertyName = popoverTextboxIdPrefix + "Xml";
                string xmlString = Convert.ToString(model.GetType().GetProperty(xmlPropertyName).GetValue(model));

                IDictionary<string, object> popoverTextBoxAttributes = new Dictionary<string, object>();
                popoverTextBoxAttributes.Add("class", "form-control");
                popoverTextBoxAttributes.Add("data-lang-name", popoverTextboxIdPrefix + "_" + defaultLanguageId);
                popoverTextBoxAttributes.Add("data-lang-id", defaultLanguageId);
                popoverTextBoxAttributes.Add("data-xml-field", xmlPropertyName);


                var maxLength = ResourceManager.GetMaxLength(labelResourceKey);
                if (!string.IsNullOrEmpty(maxLength)) popoverTextBoxAttributes.Add("maxlength", maxLength);

                if (systemLanguages.Count() > 1)
                {
                    popoverTextBoxAttributes.Add("data-labelname", ResourceManager.GetString(labelResourceKey));
                    popoverTextBoxAttributes.Add("data-input-class", "form-control");
                    popoverTextBoxAttributes.Add("rel", "multilang-textedit-popover");

                    IEnumerable<SystemLanguage> otherLanguages = systemLanguages.Where(
                        i => !i.SystemLanguageCode.Equals(currentSystemLanguage.SystemLanguageCode, StringComparison.OrdinalIgnoreCase));

                    foreach (var item in otherLanguages)
                    {
                        string otherLanguagetextboxId = popoverTextboxIdPrefix + "_" + Convert.ToString(item.SystemLanguageId);
                        otherLanguageTextboxIds += "po_" + otherLanguagetextboxId + ",";
                        otherLanguageCodes += item.SystemLanguageCode + ",";

                        var tagHidden = new TagBuilder("input");
                        tagHidden.MergeAttribute("type", "hidden");
                        tagHidden.MergeAttribute("name", otherLanguagetextboxId);
                        tagHidden.MergeAttribute("data-mapped-to", "po_" + otherLanguagetextboxId);
                        tagHidden.MergeAttribute("value", CommonHelper.GetXmlAttributeValue(otherLanguagetextboxId, xmlString));
                        tagHidden.MergeAttribute("data-lang-name", otherLanguagetextboxId);
                        tagHidden.MergeAttribute("data-lang-id", Convert.ToString(item.SystemLanguageId));
                        hiddenFieldStringBuilder.Append(tagHidden);
                    }
                }

                popoverTextBoxAttributes.Add("data-otherlang-codes", otherLanguageCodes.TrimEnd(','));
                popoverTextBoxAttributes.Add("data-inputids", otherLanguageTextboxIds.TrimEnd(','));

                //Add popover data attributes               
                popoverTextBoxAttributes.Add("data-html", "true");
                popoverTextBoxAttributes.Add("data-trigger", "manual");
                popoverTextBoxAttributes.Add("data-placement", "bottom");
                popoverTextBoxAttributes.Add("data-container", "body");
                popoverTextBoxAttributes.Add("data-title", ResourceManager.GetString(labelResourceKey));

                //Create a Input Group
                stringBuilder.Append("<div class=\"input-group\">");
                //stringBuilder.Append(string.Format("<span class=\"input-group-addon\">{0}</span>", currentSystemLanguage.SystemLanguageCode.ToUpper()));
                var propertyExpression = GetPropertyExpression<TModel>(model, popoverTextboxIdPrefix);
                stringBuilder.Append(InputExtensions.TextBoxFor(helper, propertyExpression, popoverTextBoxAttributes).ToHtmlString());
                stringBuilder.Append("</div>");
                stringBuilder.Append(hiddenFieldStringBuilder);
            }
            else
            {
                throw new ApplicationException("No Language available");
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }


        public static string GetDisplayName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
        {
            Type type = typeof(TModel);

            MemberExpression memberExpression = (MemberExpression)expression.Body;
            string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);
            return propertyName ?? String.Empty;
        }
        #endregion

        #region Render Scripts/Css
        public static IHtmlString Resource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
            else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };

            return new HtmlString(String.Empty);
        }

        public static IHtmlString RenderResources(this HtmlHelper HtmlHelper, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];

                foreach (var Resource in Resources)
                {
                    if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
                }
            }

            return new HtmlString(String.Empty);
        }
        #endregion
        #region Base controller properties
        public static PagePermission CurrentPagePermission(this HtmlHelper htmlHelper)
        {
            var controller = htmlHelper.ViewContext.Controller as BaseController;
            if (controller == null)
            {
                throw new Exception();
            }
            return BaseController.CurrentPagePermission;
        }
        public static PagePermission InnerPagePermission(this HtmlHelper htmlHelper)
        {
            var controller = htmlHelper.ViewContext.Controller as BaseController;
            if (controller == null)
            {
                throw new Exception();
            }
            return BaseController.InnerPagePermission;
        }
        #endregion
    }
}