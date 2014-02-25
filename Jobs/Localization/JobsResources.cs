using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace Jobs.Localization
{
    [ObjectInfo(typeof(JobsResources), Title = "JobsResourcesTitle", Description = "JobsResourcesDescription")]
    public class JobsResources : Resource
    {
        public JobsResources()
        { }

        public JobsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        { }

        [ResourceEntry("JobsViewTitle",
            Value = "Jobs",
            Description = "The title of the Jobs module.",
            LastModified = "2011/05/09")]
        public string JobsViewTitle
        {
            get { return this["JobsViewTitle"]; }
        }

        [ResourceEntry("PermissionsForApplications",
            Value = "Permissions",
            Description = "phrase: Permissions for applications",
            LastModified = "2011/05/17")]
        public string PermissionsForApplications
        {
            get { return this["PermissionsForApplications"]; }
        }

        [ResourceEntry("BackToItems",
                Value = "Back to Applications",
                Description = "The text of the back to applications link",
                LastModified = "2011/05/17")]
        public string BackToItems
        {
            get
            {
                return this["BackToItems"];
            }
        }

        [ResourceEntry("lTitle",
            Value = "First name",
            Description = "phrase: First name",
            LastModified = "2010/12/09")]
        public string lTitle
        {
            get { return this["lTitle"]; }
        }

        [ResourceEntry("FirstNameCannotBeEmpty",
            Value = "First name cannot be empty",
            Description = "phrase: First name cannot be empty",
            LastModified = "2011/05/17")]
        public string FirstNameCannotBeEmpty
        {
            get { return this["FirstNameCannotBeEmpty"]; }
        }

        [ResourceEntry("LastNameCannotBeEmpty",
            Value = "Last name cannot be empty",
            Description = "phrase: Last name cannot be empty",
            LastModified = "2011/05/17")]
        public string LastNameCannotBeEmpty
        {
            get { return this["LastNameCannotBeEmpty"]; }
        }

        [ResourceEntry("PhoneNumberCannotBeEmpty",
            Value = "Phone number cannot be empty",
            Description = "phrase: Phone number cannot be empty",
            LastModified = "2011/05/17")]
        public string PhoneNumberCannotBeEmpty
        {
            get { return this["PhoneNumberCannotBeEmpty"]; }
        }

        [ResourceEntry("InvalidPhoneNumber",
            Value = "Invalid phone number",
            Description = "phrase: Invalid phone number",
            LastModified = "2011/05/17")]
        public string InvalidPhoneNumber
        {
            get { return this["InvalidPhoneNumber"]; }
        }

        [ResourceEntry("MotivationalTextCannotBeEmpty",
            Value = "Motivational text cannot be empty",
            Description = "phrase: Motivational text cannot be empty",
            LastModified = "2011/05/17")]
        public string MotivationalTextCannotBeEmpty
        {
            get { return this["MotivationalTextCannotBeEmpty"]; }
        }

        [ResourceEntry("ReferrerCannotBeEmpty",
            Value = "Referrer cannot be empty",
            Description = "phrase: Referrer cannot be empty",
            LastModified = "2011/05/17")]
        public string ReferrerCannotBeEmpty
        {
            get { return this["ReferrerCannotBeEmpty"]; }
        }

        [ResourceEntry("EditItem",
            Value = "Edit an application",
            Description = "The title of the edit item dialog",
            LastModified = "2011/05/17")]
        public string EditItem
        {
            get { return this["EditItem"]; }
        }

        [ResourceEntry("Content",
            Value = "Content",
            Description = "word: Content",
            LastModified = "2010/01/28")]
        public string Content
        {
            get
            {
                return this["Content"];
            }
        }

        [ResourceEntry("VersionComparison",
            Value = "version comparison",
            Description = "word: Jobs",
            LastModified = "2011/02/09")]
        public string VersionComparison
        {
            get { return this["VersionComparison"]; }
        }

        [ResourceEntry("CreateNewItem",
            Value = "Create an application item",
            Description = "The title of the create new item dialog",
            LastModified = "2010/07/26")]
        public string CreateNewItem
        {
            get { return this["CreateNewItem"]; }
        }

        [ResourceEntry("Edit",
            Value = "<strong>Edit...</strong>",
            Description = "word",
            LastModified = "2010/01/29")]
        public string Edit
        {
            get
            {
                return this["Edit"];
            }
        }

        [ResourceEntry("JobsResourcesTitle",
                       Value = "JobsResources",
                       Description = "The title of this class.",
                       LastModified = "2009/04/30")]
        public string JobsResourcesTitle
        {
            get
            {
                return this["JobsResourcesTitle"];
            }
        }

        [ResourceEntry("JobsResourcesDescription",
                       Value = "Contains localizable resources for Jobs module labels.",
                       Description = "The description of this class.",
                       LastModified = "2009/04/30")]
        public string JobsResourcesDescription
        {
            get
            {
                return this["JobsResourcesDescription"];
            }
        }

        [ResourceEntry("JobsResourcesTitlePlural",
            Value = "JobsResources",
            Description = "The title plural of this class.",
            LastModified = "2009/04/30")]
        public string JobsResourcesTitlePlural
        {
            get
            {
                return this["JobsResourcesTitlePlural"];
            }
        }

        [ResourceEntry("JobApplicationsUploadTitle",
            Value = "Job Application Form",
            Description = "The title of the JobApplicationUploadWidget.",
            LastModified = "2010/04/30")]
        public string JobApplicationsUploadTitle
        {
            get
            {
                return this["JobApplicationsUploadTitle"];
            }
        }

        [ResourceEntry("JobApplicationsUploadDescription",
            Value = "A widget for job application submissions.",
            Description = "The description of the JobApplicationUploadWidget.",
            LastModified = "2010/04/30")]
        public string JobApplicationsUploadDescription
        {
            get
            {
                return this["JobApplicationsUploadDescription"];
            }
        }

        [ResourceEntry("FirstName",
            Value = "First name")]
        public string FirstName
        {
            get
            {
                return this["FirstName"];
            }
        }

        [ResourceEntry("FirstNameRequired",
            Value = "First name required")]
        public string FirstNameRequired
        {
            get
            {
                return this["FirstNameRequired"];
            }
        }

        [ResourceEntry("LastName",
            Value = "Last name")]
        public string LastName
        {
            get
            {
                return this["LastName"];
            }
        }

        [ResourceEntry("LastNameRequired",
            Value = "Last name required")]
        public string LastNameRequired
        {
            get
            {
                return this["LastNameRequired"];
            }
        }

        [ResourceEntry("PhoneNumber",
            Value = "Phone number")]
        public string PhoneNumber
        {
            get
            {
                return this["PhoneNumber"];
            }
        }

        [ResourceEntry("PhoneNumberRequired",
           Value = "Phone number required")]
        public string PhoneNumberRequired
        {
            get
            {
                return this["PhoneNumberRequired"];
            }
        }

        [ResourceEntry("HowDidYouHear",
            Value = "How did you hear about us?")]
        public string HowDidYouHear
        {
            get
            {
                return this["HowDidYouHear"];
            }
        }

        [ResourceEntry("InternetAd",
           Value = "Internet Ad")]
        public string InternetAd
        {
            get
            {
                return this["InternetAd"];
            }
        }

        [ResourceEntry("MobilePhoneAd",
            Value = "Mobile Phone Ad")]
        public string MobilePhoneAd
        {
            get
            {
                return this["MobilePhoneAd"];
            }
        }

        [ResourceEntry("SocialNetwork",
            Value = "Social Network")]
        public string SocialNetwork
        {
            get
            {
                return this["SocialNetwork"];
            }
        }

        [ResourceEntry("TelevisionAd",
            Value = "Television Ad")]
        public string TelevisionAd
        {
            get
            {
                return this["TelevisionAd"];
            }
        }

        [ResourceEntry("WebLink",
            Value = "Web Link")]
        public string WebLink
        {
            get
            {
                return this["WebLink"];
            }
        }

        [ResourceEntry("WebSearch",
            Value = "Web Search")]
        public string WebSearch
        {
            get
            {
                return this["WebSearch"];
            }
        }

        [ResourceEntry("MagazineAd",
            Value = "Magazine Ad")]
        public string MagazineAd
        {
            get
            {
                return this["MagazineAd"];
            }
        }

        [ResourceEntry("Other",
            Value = "Other")]
        public string Other
        {
            get
            {
                return this["Other"];
            }
        }

        [ResourceEntry("AttachYourDocuments",
            Value = "Attach your documents")]
        public string AttachYourDocuments
        {
            get
            {
                return this["AttachYourDocuments"];
            }
        }

        [ResourceEntry("MotivationalText",
            Value = "Motivational text")]
        public string MotivationalText
        {
            get
            {
                return this["MotivationalText"];
            }
        }

        [ResourceEntry("MotivationalTextOptional",
            Value = "Motivational text <strong>(optional)</strong>")]
        public string MotivationalTextOptional
        {
            get
            {
                return this["MotivationalTextOptional"];
            }
        }

        [ResourceEntry("Submit",
            Value = "Submit")]
        public string Submit
        {
            get
            {
                return this["Submit"];
            }
        }

        [ResourceEntry("SubmissionDate",
            Value = "Submission date")]
        public string SubmissionDate
        {
            get
            {
                return this["SubmissionDate"];
            }
        }

        [ResourceEntry("Referrer",
            Value = "Referrer")]
        public string Referrer
        {
            get
            {
                return this["Referrer"];
            }
        }

        [ResourceEntry("DownloadAttachments",
            Value = "Download attachments")]
        public string DownloadAttachments
        {
            get
            {
                return this["DownloadAttachments"];
            }
        }

        [ResourceEntry("DeleteThisJobApplication",
            Value = "Delete this job application?")]
        public string DeleteThisJobApplication
        {
            get
            {
                return this["DeleteThisJobApplication"];
            }
        }

        [ResourceEntry("Delete",
            Value = "Delete")]
        public string Delete
        {
            get
            {
                return this["Delete"];
            }
        }

        [ResourceEntry("SaveChanges",
            Value = "Save changes")]
        public string SaveChanges
        {
            get
            {
                return this["SaveChanges"];
            }
        }

        [ResourceEntry("MoreActions",
            Value = "More actions")]
        public string MoreActions
        {
            get
            {
                return this["MoreActions"];
            }
        }

        [ResourceEntry("ClickToAddSummary",
            Value = "Click to add summary",
            Description = "phrase: Click to add summary",
            LastModified = "2010/12/09")]
        public string ClickToAddSummary
        {
            get { return this["ClickToAddSummary"]; }
        }

        [ResourceEntry("TextFieldMaximumLength",
            Value = "Maximum allowed length is 40",
            Description = "phrase: Maximum length of the field is 40",
            LastModified = "2012/02/16")]
        public string TextFieldMaximumLength
        {
            get { return this["TextFieldMaximumLength"]; }
        }

        [ResourceEntry("TextAreaMaximumLength",
            Value = "Maximum allowed length of the text is 200",
            Description = "phrase: Maximum allowed length of the text is 200",
            LastModified = "2012/02/16")]
        public string TextAreaMaximumLength
        {
            get { return this["TextAreaMaximumLength"]; }
        }

        /// <summary>
        /// Messsage: JobsTitle
        /// </summary>
        /// <value>Title for the Jobs module.</value>
        [ResourceEntry(
            "JobsTitle",
            Value = "Jobs",
            Description = "Title for the Jobs module.",
            LastModified = "2012/07/20")
        ]
        public string JobsTitle
        {

            get { return this["JobsTitle"]; }
        }

        /// <summary>
        /// Messsage: JobsTitle
        /// </summary>
        /// <value>Title for the Jobs module.</value>
        [ResourceEntry(
            "JobsHtmlTitle",
            Value = "Jobs",
            Description = "Html Title for the Jobs module.",
            LastModified = "2012/07/20")
        ]
        public string JobsHtmlTitle
        {

            get { return this["JobsHtmlTitle"]; }
        }

        /// <summary>
        /// Messsage: Jobs
        /// </summary>
        /// <value>Jobs URL name.</value>
        [ResourceEntry(
            "JobsUrlName",
            Value = "Jobs",
            Description = "Jobs URL.",
            LastModified = "2012/07/20")
        ]
        public string JobsUrlName
        {

            get { return this["JobsUrlName"]; }
        }

        //
        /// <summary>
        /// Messsage: Jobs
        /// </summary>
        /// <value>Jobs Description.</value>
        [ResourceEntry(
            "JobsDescription",
            Value = "JobsDescription",
            Description = "Jobs",
            LastModified = "2012/07/20")
        ]
        public string JobsDescription
        {

            get { return this["JobsDescription"]; }
        }

        /// <summary>
        /// Messsage: Jobs
        /// </summary>
        /// <value>Title of the Jobs page group.</value>
        [ResourceEntry(
            "PageGroupNodeTitle",
            Value = "Jobs",
            Description = "Title of the Jobs page group.",
            LastModified = "2012/07/20")
        ]
        public string PageGroupNodeTitle
        {

            get { return this["PageGroupNodeTitle"]; }
        }

        /// <summary>
        /// Messsage: This is the page group that contains all pages for the Jobs module.
        /// </summary>
        /// <value>Jobs Page Group Description</value>
        [ResourceEntry(
            "PageGroupNodeDescription",
            Value = "This is the page group that contains all pages for the Jobs module.",
            Description = "Jobs Page Group Description",
            LastModified = "2012/07/20")
        ]
        public string PageGroupNodeDescription
        {

            get { return this["PageGroupNodeDescription"]; }
        }
        
        /// <summary>
        /// Messsage: Jobs upload widget title.
        /// </summary>
        /// <value>Title of the Jobs upload widget.</value>
        [ResourceEntry(
            "UploadJobsWidgetTitle",
            Value = "Jobs upload",
            Description = "Title of the Jobs upload widget.",
            LastModified = "2012/07/20")
        ]
        public string UploadJobsWidgetTitle
        {

            get { return this["UploadJobsWidgetTitle"]; }
        }

        /// <summary>
        /// Messsage: Jobs upload widget description.
        /// </summary>
        /// <value>Title of the Jobs upload widget.n</value>
        [ResourceEntry(
            "UploadJobsWidgetDescription",
            Value = "Upload jobs.",
            Description = "Description of the Jobs upload widget.",
            LastModified = "2012/07/20")
        ]
        public string UploadJobsWidgetDescription
        {

            get { return this["UploadJobsWidgetDescription"]; }
        }
    }
}