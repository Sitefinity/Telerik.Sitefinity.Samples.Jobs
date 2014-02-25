using System;
using Jobs.Configuration;
using Jobs.Localization;
using Jobs.PublicControls;
using Jobs.Resources;
using Jobs.Services;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Fluent.Modules;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Jobs
{
    public class JobsModule : ContentModuleBase
    {
        public const string ModuleName = "Jobs";

        public override Type[] Managers
        {
            get
            {
                return new[] { typeof(JobsManager) };
            }
        }

        public override Guid LandingPageId
        {
            get
            {
                return JobsModule.JobsModuleLandingPage;
            }
        }

        public Guid SubPageId
        {
            get
            {
                return JobsModule.JobsPageGroupID;
            }
        }

        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);
            Config.RegisterSection<JobsConfig>();
            Res.RegisterResource<JobsResources>();

            ObjectFactory.RegisterWebService(typeof(JobsBackendService), "Sitefinity/Services/Content/Jobs.svc");
            TypeResolutionService.RegisterAssembly(typeof(JobsModule).Assembly.GetName());
        }

        public override void Install(SiteInitializer initializer)
        {
            base.Install(initializer);
            this.InstallCustomVirtualPaths(initializer);
        }

        private void InstallCustomVirtualPaths(SiteInitializer initialzer)
        {
            var virtualPathConfig = initialzer.Context.GetConfig<VirtualPathSettingsConfig>();
            ConfigManager.Executed += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(ConfigManager_Executed);
            var jobsModuleVirtualPathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
            {
                VirtualPath = JobsModule.JobsVirtualPath + "*",
                ResolverName = "EmbeddedResourceResolver",
                ResourceLocation = "Jobs"
            };
            if (!virtualPathConfig.VirtualPaths.ContainsKey(JobsModule.JobsVirtualPath + "*"))
                virtualPathConfig.VirtualPaths.Add(jobsModuleVirtualPathConfig);
        }

        private void ConfigManager_Executed(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
        {
            if (args.CommandName == "SaveSection")
            {
                var section = args.CommandArguments as VirtualPathSettingsConfig;
                if (section != null)
                {
                    // Reset the Virtual path manager, whenever the section of the VirtualPathSettingsConfig is saved.
                    // This is needed so that the prefixes for templates in our module assembly are taken into account.
                    VirtualPathManager.Reset();
                }
            }
        }

        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        { }

        protected override ConfigSection GetModuleConfig()
        {
            return Config.Get<JobsConfig>();
        }

        protected override void InstallPages(SiteInitializer initializer)
        {
            initializer.Installer
                .CreateModuleGroupPage(JobsModule.JobsPageGroupID, JobsModule.ModuleName)
                .PlaceUnder(CommonNode.TypesOfContent)
                .LocalizeUsing<JobsResources>()
                .SetTitleLocalized("JobsTitle")
                .SetUrlNameLocalized("PageGroupNodeTitle")
                .SetDescriptionLocalized("PageGroupNodeDescription")
                .AddChildPage(JobsModule.JobsModuleLandingPage, JobsModule.ModuleName)
                    .LocalizeUsing<JobsResources>()
                    .SetTitleLocalized("JobsTitle")
                    .SetHtmlTitleLocalized("JobsTitle")
                    .SetUrlName("JobsUrlName")
                    .SetDescriptionLocalized("JobsDescription")
                    .AddContentView(b=>
                        {
                            b.ControlDefinitionName = JobsDefinitions.BackendDefinitionName;
                            b.ID = JobsModule.JobsBackendContentViewControlId;
                        })
                    .Done();
        }

        protected override void InstallTaxonomies(SiteInitializer initializer)
        { }


        protected override void InstallConfiguration(SiteInitializer initializer)
        {
            initializer.Installer
                .PageToolbox()
                    .LoadOrAddSection("Samples")
                        .LoadOrAddWidget<JobApplicationUpload>("NewsView")
                            .SetTitle("UploadJobsWidgetTitle")
                            .SetDescription("UploadJobsWidgetDescription")
                            .LocalizeUsing<JobsResources>()
                            .Done()
                        .Done()
                    .Done();
        }

        public static readonly Guid JobsPageGroupID = new Guid("13FA3CB0-6F00-4DFB-A534-28EA60252A16");
        public static readonly Guid JobsModuleLandingPage = new Guid("A52C36E1-3D29-4F39-BB8D-BB1F064E556A");
        public static string JobsVirtualPath = "~/SFJobs/";

        /// <summary>
        /// The id of the jobs backed content view control.
        /// </summary>
        public const string JobsBackendContentViewControlId = "jobsCntView";
    }
}
