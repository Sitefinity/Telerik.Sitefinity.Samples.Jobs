using System;
using System.Web.UI;
using Jobs.Localization;
using Jobs.Model;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Config;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Enums;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Widgets;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Detail;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Master;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Master.Config;
using Telerik.Sitefinity.Web.UI.Extenders.Config;
using Telerik.Sitefinity.Web.UI.Fields.Config;
using Telerik.Sitefinity.Web.UI.Fields.Enums;
using Telerik.Sitefinity.Web.UI.Validation.Config;

namespace Jobs.Resources
{
    public class JobsDefinitions
    {
        public const string BackendDefinitionName = "JobsBackend";
        public const string BackendEditViewName = "JobsBackendEdit";
        public const string ModuleName = "Jobs";
        public const string BackendListViewName = "JobsBackendList";

        public const string EditCommandName = "edit";
        public const string DeleteCommandName = "delete";

        /// <summary>
        /// Defines the jobs backend content view.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        public static ContentViewControlElement DefineJobsBackendContentView(ConfigElement parent)
        {
            // define content view control
            var backendContentView = new ContentViewControlElement(parent)
            {
                ControlDefinitionName = BackendDefinitionName,
                ContentType = typeof(JobApplication)
            };

            // define views
            var jobsGridView = new MasterGridViewElement(backendContentView.ViewsConfig)
            {
                ViewName = JobsDefinitions.BackendListViewName,
                ViewType = typeof(MasterGridView),
                AllowPaging = true,
                DisplayMode = FieldDisplayMode.Read,
                ItemsPerPage = 50,
                ResourceClassId = typeof(JobsResources).Name,
                Title = "JobsViewTitle",
                WebServiceBaseUrl = "~/Sitefinity/Services/Content/Jobs.svc/",
            };

            // define columns
            var gridMode = new GridViewModeElement(jobsGridView.ViewModesConfig)
            {
                Name = "Grid",
            };
            jobsGridView.ViewModesConfig.Add(gridMode);

            DataColumnElement firstNameColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "FirstName",
                HeaderText = Res.Get<JobsResources>().FirstName,
                ClientTemplate = "<span>{{FirstName}}</span>",
                HeaderCssClass = "sfRegular",
                ItemCssClass = "sfRegular"
            };
            gridMode.ColumnsConfig.Add(firstNameColumn);

            DataColumnElement lastNameColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "LastName",
                HeaderText = Res.Get<JobsResources>().LastName,
                ClientTemplate = "<span>{{LastName}}</span>",
                HeaderCssClass = "sfRegular",
                ItemCssClass = "sfRegular"
            };
            gridMode.ColumnsConfig.Add(lastNameColumn);

            DataColumnElement phoneColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "Phone",
                HeaderText = Res.Get<JobsResources>().PhoneNumber,
                ClientTemplate = "<span>{{Phone}}</span>",
                HeaderCssClass = "sfRegular",
                ItemCssClass = "sfRegular"
            };
            gridMode.ColumnsConfig.Add(phoneColumn);

            DataColumnElement refferalColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "Refferal",
                HeaderText = Res.Get<JobsResources>().Referrer,
                ClientTemplate = "<span>{{Referral}}</span>",
                HeaderCssClass = "sfRegular",
                ItemCssClass = "sfRegular"
            };
            gridMode.ColumnsConfig.Add(refferalColumn);

            ActionMenuColumnElement actionsColumn = new ActionMenuColumnElement(gridMode.ColumnsConfig)
            {
                Name = "Actions",
                HeaderText = Res.Get<Labels>().Actions,
                HeaderCssClass = "sfMoreActions",
                ItemCssClass = "sfMoreActions"
            };
            FillActionMenuItems(actionsColumn.MenuItems, actionsColumn, typeof(JobsResources).Name);
            gridMode.ColumnsConfig.Add(actionsColumn);

            DataColumnElement authorColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "Author",
                HeaderText = Res.Get<Labels>().Author,
                ClientTemplate = "<span>{{Author}}</span>",
                HeaderCssClass = "sfRegular",
                ItemCssClass = "sfRegular"
            };
            gridMode.ColumnsConfig.Add(authorColumn);

            DataColumnElement dateColumn = new DataColumnElement(gridMode.ColumnsConfig)
            {
                Name = "Date",
                HeaderText = Res.Get<Labels>().Date,
                ClientTemplate = "<span>{{ (DateCreated) ? DateCreated.sitefinityLocaleFormat('dd MMM, yyyy hh:mm:ss'): '-' }}</span>",
                HeaderCssClass = "sfDate",
                ItemCssClass = "sfDate"
            };
            gridMode.ColumnsConfig.Add(dateColumn);

            backendContentView.ViewsConfig.Add(jobsGridView);

            var parameters = string.Concat(
                "?ControlDefinitionName=",
                JobsDefinitions.BackendDefinitionName,
                "&ViewName=",
                JobsDefinitions.BackendEditViewName);
            DialogElement editDialogElement = DefinitionsHelper.CreateDialogElement(
                jobsGridView.DialogsConfig,
                DefinitionsHelper.EditCommandName,
                "ContentViewEditDialog",
                parameters);
            jobsGridView.DialogsConfig.Add(editDialogElement);

            var jobsEditDetailView = new DetailFormViewElement(backendContentView.ViewsConfig)
            {
                Title = "EditItem",
                ViewName = JobsDefinitions.BackendEditViewName,
                ViewType = typeof(DetailFormView),
                ShowSections = true,
                DisplayMode = FieldDisplayMode.Write,
                ShowTopToolbar = true,
                ResourceClassId = typeof(JobsResources).Name,
                WebServiceBaseUrl = "~/Sitefinity/Services/Content/Jobs.svc/",
                IsToRenderTranslationView = false,
                UseWorkflow = false
            };

            backendContentView.ViewsConfig.Add(jobsEditDetailView);

            JobsDefinitions.CreateBackendSections(jobsEditDetailView, FieldDisplayMode.Write);
            JobsDefinitions.CreateBackendFormToolbar(jobsEditDetailView, typeof(JobsResources).Name, false);

            return backendContentView;
        }

        private static void CreateBackendFormToolbar(DetailFormViewElement detailView, string resourceClassId, bool isCreateMode)
        {
            JobsDefinitions.CreateBackendFormToolbar(detailView, resourceClassId, isCreateMode, "ThisItem", true);
        }

        private static void CreateBackendFormToolbar(DetailFormViewElement detailView, string resourceClassId, bool isCreateMode, string itemName, bool showPreview, string backToItems = "BackToItems")
        {
            var toolbarSectionElement = new WidgetBarSectionElement(detailView.Toolbar.Sections)
            {
                Name = "BackendForm",
                WrapperTagKey = HtmlTextWriterTag.Div,
                CssClass = "sfWorkflowMenuWrp"
            };

            // Create 
            toolbarSectionElement.Items.Add(new CommandWidgetElement(toolbarSectionElement.Items)
            {
                Name = "SaveChangesWidgetElement",
                ButtonType = CommandButtonType.Save,
                CommandName = DefinitionsHelper.SaveCommandName,
                Text = (isCreateMode) ? String.Concat("Create", itemName) : "SaveChanges",
                ResourceClassId = resourceClassId,
                WrapperTagKey = HtmlTextWriterTag.Span,
                WidgetType = typeof(CommandWidget)
            });

            if (!isCreateMode)
            {
                var actionsMenuWidget = new ActionMenuWidgetElement(toolbarSectionElement.Items)
                {
                    Name = "moreActions",
                    Text = "MoreActions",
                    ResourceClassId = resourceClassId,
                    WrapperTagKey = HtmlTextWriterTag.Div,
                    WidgetType = typeof(ActionMenuWidget),
                    CssClass = "sfInlineBlock sfAlignMiddle"
                };

                actionsMenuWidget.MenuItems.Add(new CommandWidgetElement(actionsMenuWidget.MenuItems)
                {
                    Name = DeleteCommandName,
                    Text = "DeleteThisJobApplication",
                    CommandName = DefinitionsHelper.DeleteCommandName,
                    ResourceClassId = resourceClassId,
                    WidgetType = typeof(CommandWidget),
                    CssClass = "sfDeleteItm"
                });

                toolbarSectionElement.Items.Add(actionsMenuWidget);
            }

            // Cancel
            toolbarSectionElement.Items.Add(new CommandWidgetElement(toolbarSectionElement.Items)
            {
                Name = "CancelWidgetElement",
                ButtonType = CommandButtonType.Cancel,
                CommandName = DefinitionsHelper.CancelCommandName,
                Text = backToItems,
                ResourceClassId = resourceClassId,
                WrapperTagKey = HtmlTextWriterTag.Span,
                WidgetType = typeof(CommandWidget)
            });

            detailView.Toolbar.Sections.Add(toolbarSectionElement);
        }

        private static void CreateBackendSections(DetailFormViewElement detailView, FieldDisplayMode displayMode)
        {
            var mainSection = new ContentViewSectionElement(detailView.Sections)
            {
                Name = "MainSection",
                CssClass = "sfFirstForm"
            };

            var firstNameField = new TextFieldDefinitionElement(mainSection.Fields)
            {
                ID = "firstNameFieldControl",
                DataFieldName = "FirstName",
                DisplayMode = displayMode,
                Title = "FirstName",
                CssClass = "sfTitleField",
                ResourceClassId = typeof(JobsResources).Name,
                WrapperTag = HtmlTextWriterTag.Li,
            };
            firstNameField.ValidatorConfig = new ValidatorDefinitionElement(firstNameField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = Res.Get<JobsResources>().FirstNameCannotBeEmpty,
                MaxLength = 40,
                MaxLengthViolationMessage = Res.Get<JobsResources>().TextFieldMaximumLength
            };
            mainSection.Fields.Add(firstNameField);

            var lastNameField = new TextFieldDefinitionElement(mainSection.Fields)
            {
                ID = "lastNameFieldControl",
                DataFieldName = "LastName",
                DisplayMode = displayMode,
                Title = "LastName",
                CssClass = "sfTitleField",
                ResourceClassId = typeof(JobsResources).Name,
                WrapperTag = HtmlTextWriterTag.Li,
            };
            lastNameField.ValidatorConfig = new ValidatorDefinitionElement(lastNameField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = Res.Get<JobsResources>().LastNameCannotBeEmpty,
                MaxLength = 40,
                MaxLengthViolationMessage = Res.Get<JobsResources>().TextFieldMaximumLength
            };
            mainSection.Fields.Add(lastNameField);

            var phoneNumberField = new TextFieldDefinitionElement(mainSection.Fields)
            {
                ID = "phoneNumberFieldControl",
                DataFieldName = "Phone",
                DisplayMode = displayMode,
                Title = "PhoneNumber",
                CssClass = "sfTitleField",
                ResourceClassId = typeof(JobsResources).Name,
                WrapperTag = HtmlTextWriterTag.Li,
            };
            phoneNumberField.ValidatorConfig = new ValidatorDefinitionElement(phoneNumberField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = Res.Get<JobsResources>().PhoneNumberCannotBeEmpty,
                RegularExpression = "^[0-9]+[.]*[0-9]*$",
                RegularExpressionViolationMessage = Res.Get<JobsResources>().InvalidPhoneNumber,
                MaxLength = 40,
                MaxLengthViolationMessage = Res.Get<JobsResources>().TextFieldMaximumLength
            };
            mainSection.Fields.Add(phoneNumberField);

            var textField = new TextFieldDefinitionElement(mainSection.Fields)
            {
                ID = "motivationalTextFieldControl",
                DataFieldName = "Text",
                DisplayMode = displayMode,
                Title = "MotivationalText",
                CssClass = "sfTitleField",
                WrapperTag = HtmlTextWriterTag.Li,
                ResourceClassId = typeof(JobsResources).Name,
                Rows = 5
            };
            textField.ExpandableDefinitionConfig = new ExpandableControlElement(textField)
            {
                Expanded = false,
                ExpandText = Res.Get<JobsResources>().ClickToAddSummary
            };
            textField.ValidatorConfig = new ValidatorDefinitionElement(textField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = Res.Get<JobsResources>().MotivationalTextCannotBeEmpty,
                MaxLength = 200,
                MaxLengthViolationMessage = Res.Get<JobsResources>().TextAreaMaximumLength
            };
            mainSection.Fields.Add(textField);

            var referrer = new ChoiceFieldElement(mainSection.Fields)
            {
                RenderChoiceAs = Telerik.Sitefinity.Web.UI.Fields.Enums.RenderChoicesAs.DropDown,
                ID = "referrerChoices",
                DataFieldName = "Referral",
                DisplayMode = displayMode,
                Title = "HowDidYouHear",
                CssClass = "sfTitleField",
                WrapperTag = HtmlTextWriterTag.Li,
                ResourceClassId = typeof(JobsResources).Name,

            };

            var internetAdField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().InternetAd,
                Value = Res.Get<JobsResources>().InternetAd,
            };
            referrer.ChoicesConfig.Add(internetAdField);

            var mobilePhoneAdField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().MobilePhoneAd,
                Value = Res.Get<JobsResources>().MobilePhoneAd,
            };
            referrer.ChoicesConfig.Add(mobilePhoneAdField);

            var socialNetworkField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().SocialNetwork,
                Value = Res.Get<JobsResources>().SocialNetwork,
            };
            referrer.ChoicesConfig.Add(socialNetworkField);

            var televisionAdField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().TelevisionAd,
                Value = Res.Get<JobsResources>().TelevisionAd,
            };
            referrer.ChoicesConfig.Add(televisionAdField);

            var webLinkField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().WebLink,
                Value = Res.Get<JobsResources>().WebLink,
            };
            referrer.ChoicesConfig.Add(webLinkField);

            var webSearchField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().WebSearch,
                Value = Res.Get<JobsResources>().WebSearch,
            };
            referrer.ChoicesConfig.Add(webSearchField);

            var magazineAdField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().MagazineAd,
                Value = Res.Get<JobsResources>().MagazineAd,
            };
            referrer.ChoicesConfig.Add(magazineAdField);

            var otherField = new ChoiceElement(referrer.ChoicesConfig)
            {
                Text = Res.Get<JobsResources>().Other,
                Value = Res.Get<JobsResources>().Other,
            };
            referrer.ChoicesConfig.Add(otherField);

            mainSection.Fields.Add(referrer);
            detailView.Sections.Add(mainSection);
        }

        public static void FillActionMenuItems(ConfigElementList<WidgetElement> menuItems, ConfigElement parent, string resourceClassId)
        {
            menuItems.Add(
                CreateActionMenuCommand(menuItems, "Delete", HtmlTextWriterTag.Li, DeleteCommandName, "Delete", resourceClassId, "sfDeleteItm"));
            menuItems.Add(
                CreateActionMenuSeparator(menuItems, "Separator", HtmlTextWriterTag.Li, "sfSeparator", "Edit", resourceClassId));
            menuItems.Add(
                CreateActionMenuCommand(menuItems, "Content", HtmlTextWriterTag.Li, EditCommandName, "Content", resourceClassId));
        }

        public static CommandWidgetElement CreateActionMenuCommand(
            ConfigElement parent,
            string name,
            HtmlTextWriterTag wrapperTagKey,
            string commandName,
            string text,
            string resourceClassId,
            string cssClass)
        {
            var commandWidgetElement = DefinitionsHelper.CreateActionMenuCommand(parent, name, wrapperTagKey, commandName, text, resourceClassId);
            commandWidgetElement.CssClass = cssClass;
            return commandWidgetElement;
        }

        public static CommandWidgetElement CreateActionMenuCommand(
            ConfigElement parent,
            string name,
            HtmlTextWriterTag wrapperTagKey,
            string commandName,
            string text,
            string resourceClassId)
        {
            return new CommandWidgetElement(parent)
            {
                Name = name,
                WrapperTagKey = wrapperTagKey,
                CommandName = commandName,
                Text = text,
                ResourceClassId = resourceClassId,
                WidgetType = typeof(CommandWidget)
            };
        }

        public static WidgetElement CreateActionMenuSeparator(
            ConfigElement parent,
            string name,
            HtmlTextWriterTag WrapperTagKey,
            string cssClass,
            string text,
            string resourceClassId)
        {
            return new LiteralWidgetElement(parent)
            {
                Name = name,
                WrapperTagKey = WrapperTagKey,
                CssClass = cssClass,
                Text = text,
                ResourceClassId = resourceClassId,
                WidgetType = typeof(LiteralWidget),
                IsSeparator = true
            };
        }
    }
}