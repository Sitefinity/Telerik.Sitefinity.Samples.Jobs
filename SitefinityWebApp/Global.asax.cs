using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Jobs;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
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
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initializing += new EventHandler<Telerik.Sitefinity.Data.ExecutingEventArgs>(Bootstrapper_Initializing);
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(Bootstrapper_Initialized);
        }

        protected void Bootstrapper_Initializing(object sender, Telerik.Sitefinity.Data.ExecutingEventArgs args)
        {
            if (args.CommandName == "RegisterRoutes")
            {
                SampleUtilities.RegisterModule<JobsModule>("Jobs", "This module presents showcases how to create a jobs module that allows users to submit jobs applications.");
            }
        }

        protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
        {
            if (args.CommandName == "Bootstrapped")
            {
                SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSampleWorker);
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

                JobApplicationUpload jobApplicationUpload = new JobApplicationUpload();
                SampleUtilities.AddControlToPage(new Guid(JobApplicationPageId), jobApplicationUpload, "Content", "UploadJobsWidget");
            }

            //create admin
            SampleUtilities.CreateUsersAndRoles();
            //SampleUtilities.FrontEndAuthenticate();
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