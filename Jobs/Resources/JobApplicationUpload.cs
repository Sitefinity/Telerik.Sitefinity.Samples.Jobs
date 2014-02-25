using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;

namespace Jobs.PublicControls
{
    /// <summary>
    /// A control which provides job application upload capabilities.
    /// </summary>
    [RequireScriptManager]
    public class JobApplicationUpload : SimpleView
    {
        #region Fields

        /// <summary>
        /// Default template name.
        /// </summary>
        private string layoutTemplateName = "Jobs.Resources.Views.JobApplicationUpload.ascx";

        #endregion

        /// <summary>
        /// Gets the name of the embedded layout template.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// Override this property to change the embedded template to be used with the dialog
        /// </remarks>
        protected override string LayoutTemplateName
        {
            get
            {
                return this.layoutTemplateName;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                ////Use div wrapper tag to make easier common styling. This will surround the layout template with a div tag.
                return HtmlTextWriterTag.Div;
            }
        }

        /// <summary>
        /// Gets the RadUpload control which handles the file uploads on the web page.
        /// </summary>
        /// <value>A Telerik RadUpload control from the control template.</value>
        protected virtual RadUpload RadUpload1
        {
            get
            {
                return this.Container.GetControl<RadUpload>("RadUpload1", true);
            }
        }

        /// <summary>
        /// Gets the phone number provided by the user.
        /// </summary>
        /// <value>Phone number as a string.</value>
        protected virtual string Phone
        {
            get
            {
                return this.Container.GetControl<TextBox>("Phone", true).Text;
            }
        }

        /// <summary>
        /// Gets the first name provided by the user.
        /// </summary>
        /// <value>The first name.</value>
        protected virtual string FirstName
        {
            get
            {
                return this.Container.GetControl<TextBox>("FirstName", true).Text;
            }
        }

        /// <summary>
        /// Gets the last name provided by the user.
        /// </summary>
        /// <value>The last name.</value>
        protected virtual string LastName
        {
            get
            {
                return this.Container.GetControl<TextBox>("LastName", true).Text;
            }
        }

        /// <summary>
        /// Gets RadComboBox containing the referral information provided by the user.
        /// </summary>
        /// <value>An instance of a Telerik RadComboBox control from the control template.</value>
        protected RadComboBox HowDidYouHear
        {
            get
            {
                return this.Container.GetControl<RadComboBox>("HowDidYouHear", true);
            }
        }

        /// <summary>
        /// Gets Message control used for displaying feedback about the process.
        /// </summary>
        /// <value>A Message control from the control tempalte.</value>
        protected Message Message
        {
            get
            {
                return this.Container.GetControl<Message>("message", true);
            }
        }

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="controlContainer">The control container.</param>
        protected override void InitializeControls(GenericContainer controlContainer)
        {
            controlContainer.GetControl<Button>("SubmitButton", true).Click += new EventHandler(this.JobApplicationUpload_Click);
        }

        /// <summary>
        /// Handles the Click event of the JobApplicationUpload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void JobApplicationUpload_Click(object sender, EventArgs e)
        {
            if (this.RadUpload1.InvalidFiles.Count > 0)
            {
                this.Message.ShowNegativeMessage("Allowed filetypes are " + String.Join(", ", this.RadUpload1.AllowedFileExtensions));
                return;
            }

            if (this.RadUpload1.UploadedFiles.Count < 1)
            {
                this.Message.ShowNegativeMessage("Select a file to upload");
                return;
            }

            JobsModule module = new JobsModule();
            try
            {
                module.UploadApplication(this.FirstName, this.LastName, this.Phone, this.HowDidYouHear.SelectedItem.Text, this.RadUpload1.UploadedFiles[0]);
            }
            catch (Exception exc)
            {
                this.Message.ShowNegativeMessage(exc.Message);
                return;
            }

            this.Message.ShowPositiveMessage("Your application was uploaded successfully");

            // clear the input
            foreach (TextBox txt in this.Container.GetControls<TextBox>().Values)
            {
                txt.Text = String.Empty;
            }
        }
    }
}
