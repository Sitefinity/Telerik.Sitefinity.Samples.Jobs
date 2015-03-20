using System;
using Jobs;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Samples.Common;
using Jobs.PublicControls;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
	public class Global : System.Web.HttpApplication
	{
        private const string SamplesThemeName = "SamplesTheme";
        private const string SamplesThemePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Themes/Samples";  

        private const string SamplesTemplateId = "015b4db0-1d4f-4938-afec-5da59749e0e8";
        private const string SamplesTemplateName = "SamplesMasterPage";
        private const string SamplesTemplatePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Master/Samples.master";

        private const string JobApplicationPageId = "2FF33642-8F5C-49DA-8FA6-BCA5307DC846";
        private const string JobApplicationPageName = "JobApplicationSample";

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(Bootstrapper_Initialized);
        }

        protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                SampleUtilities.RegisterModule<JobsModule>("Jobs", "This module presents showcases how to create a jobs module that allows users to submit jobs applications.");
            }
            if ((Bootstrapper.IsDataInitialized) && (e.CommandName == "Bootstrapped"))
            {
                var worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSampleWorker);
                SystemManager.RunWithElevatedPrivilege(worker);
            }
        }        

        private void CreateSampleWorker(object[] args)
        {
            SampleUtilities.CreateUsersAndRoles();
            SampleUtilities.RegisterTheme(SamplesThemeName, SamplesThemePath);
            SampleUtilities.RegisterTemplate(new Guid(SamplesTemplateId), SamplesTemplateName, SamplesTemplateName, SamplesTemplatePath, SamplesThemeName);

            var result = SampleUtilities.CreatePage(new Guid(JobApplicationPageId), JobApplicationPageName, true);

            if (result)
            {
                SampleUtilities.SetTemplateToPage(new Guid(JobApplicationPageId), new Guid(SamplesTemplateId));

                var jobApplicationUpload = new JobApplicationUpload();
                SampleUtilities.AddControlToPage(new Guid(JobApplicationPageId), jobApplicationUpload, "Content", "UploadJobsWidget");
            }
        }

		protected void Application_BeginRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_Error(object sender, EventArgs e) 
		{

		}

		protected void Session_End(object sender, EventArgs e) 
		{

		}

		protected void Application_End(object sender, EventArgs e) 
		{

		}
	}
}