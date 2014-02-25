using Jobs.Data;
using Jobs.Resources;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;

namespace Jobs.Configuration
{
    public class JobsConfig : ContentModuleConfigBase
    {
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(this.Providers)
            {
                Name = "OpenAccessDataProvider",
                Description = "A provider that stores jobs data in a database using OpenAccess ORM.",
                ProviderType = typeof(OpenAccessJobsDataProvider)
            });
        }

        protected override void InitializeDefaultViews(ConfigElementDictionary<string, ContentViewControlElement> contentViewControls)
        {
            contentViewControls.Add(JobsDefinitions.DefineJobsBackendContentView(contentViewControls));
        }
    }
}