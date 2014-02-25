using System;
using System.Collections.Generic;
using System.Linq;
using Jobs.Model;
using Jobs.Services.Data;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.GenericContent;

namespace Jobs.Services
{
    public class JobsBackendService : ContentServiceBase<JobApplication, JobApplicationViewModel, JobsManager>
    {
        public override IQueryable<JobApplication> GetChildContentItems(Guid parentId, string providerName)
        {
            throw new NotSupportedException();
        }

        public override JobApplication GetContentItem(Guid id, string providerName)
        {
            return this.GetManager(providerName).GetJobApplication(id);
        }

        public override IQueryable<JobApplication> GetContentItems(string providerName)
        {
            return this.GetManager(providerName).GetJobApplications();
        }

        public override JobsManager GetManager(string providerName)
        {
            return JobsManager.GetManager(providerName);
        }

        public override JobApplication GetParentContentItem(Guid id, string providerName)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable<JobApplicationViewModel> GetViewModelList(IEnumerable<JobApplication> contentList, ContentDataProviderBase dataProvider)
        {
            var viewModelList = new List<JobApplicationViewModel>();
            foreach (var product in contentList)
                viewModelList.Add(new JobApplicationViewModel(product, dataProvider));
            return viewModelList;
        }
    }
}
