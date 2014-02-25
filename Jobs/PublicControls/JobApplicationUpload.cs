using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace Jobs.PublicControls
{
    [RequireScriptManager]
    public class JobApplicationUpload : SimpleView
    {
        #region Control References

        protected virtual string Phone
        {
            get
            {
                return this.Container.GetControl<TextBox>("Phone", true).Text;
            }
            set
            {
                this.Container.GetControl<TextBox>("Phone", true).Text = value;
            }
        }

        protected virtual string FirstName
        {
            get
            {
                return this.Container.GetControl<TextBox>("FirstName", true).Text;
            }
            set
            {
                this.Container.GetControl<TextBox>("FirstName", true).Text = value;
            }
        }

        protected virtual string LastName
        {
            get
            {
                return this.Container.GetControl<TextBox>("LastName", true).Text;
            }
            set
            {
                this.Container.GetControl<TextBox>("LastName", true).Text = value;
            }
        }

        protected virtual string MotivationalText
        {
            get
            {
                return this.Container.GetControl<TextBox>("MotivationalText", true).Text;
            }
            set
            {
                this.Container.GetControl<TextBox>("MotivationalText", true).Text = value;
            }
        }

        protected RadComboBox HowDidYouHear
        {
            get
            {
                return this.Container.GetControl<RadComboBox>("HowDidYouHear", true);
            }
        }

        protected Message Message
        {
            get
            {
                return this.Container.GetControl<Message>("message", true);
            }
        }

        #endregion

        #region Overriden Members

        public override string LayoutTemplatePath
        {
            get
            {
                var path = JobsModule.JobsVirtualPath + layoutTemplateName;
                return path;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        protected override string LayoutTemplateName
        {
            get
            {
                return null;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //Use the div wrapper tag to make common styling easier. This will surround the layout template with a div tag.
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void InitializeControls(GenericContainer controlContainer)
        {
            var validationGroup = "JobsWidget_" + this.ClientID;
            foreach (var validatorId in this.validatorIDs)
            {
                var validator = this.Container.GetControl<System.Web.UI.WebControls.BaseValidator>(validatorId, true);
                validator.ValidationGroup = validationGroup;
            }
            var submitButton = controlContainer.GetControl<Button>("SubmitButton", true);
            submitButton.Click += new EventHandler(JobApplicationUpload_Click);
            submitButton.ValidationGroup = validationGroup;
        }

        #endregion

        #region Private Members

        private const string layoutTemplateName = "Jobs.Resources.Views.JobApplicationUpload.ascx";
        private void JobApplicationUpload_Click(object sender, EventArgs e)
        {
            var manager = new JobsManager();
            var application = manager.CreateJobApplication();

            application.FirstName = this.FirstName;
            application.LastName = this.LastName;
            application.Phone = this.Phone;
            application.Referral = this.HowDidYouHear.SelectedValue;
            application.Text = this.MotivationalText;

            manager.SaveChanges();

            Message.ShowPositiveMessage("Your application was submitted successfully");

            // Reset form values
            this.FirstName = "";
            this.LastName = "";
            this.Phone = "";
            this.MotivationalText = "";
            this.Container.GetControl<RadComboBox>("HowDidYouHear", true).SelectedIndex = 0;
        }
        private List<string> validatorIDs = new List<string>()
        {
            "FirstNameRequiredValidator", "LastNameRequiredValidator", "PhoneRequiredValidator", "MotivationalRequiredValidator",
            "FirstNameRegularExpressionValidator", "LastNameRegularExpressionValidator", "PhoneRegularExpressionValidator", "MotivationalTextRegularExpressionValidator"
        };

        #endregion
    }
}
