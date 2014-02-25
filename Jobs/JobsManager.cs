using System;
using System.Linq;
using Jobs.Configuration;
using Jobs.Model;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.GenericContent;

namespace Jobs
{
    public class JobsManager : ContentManagerBase<JobsDataProviderBase>, IContentLifecycleManager<JobApplication>
    {
        public JobsManager()
            : this(null)
        {
        }

        public JobsManager(string providerName)
            : base(providerName)
        {
        }

        public JobsManager(string providerName, string transactionName)
            : base(providerName, transactionName)
        {
        }

        public override string ModuleName
        {
            get { return JobsModule.ModuleName; }
        }

        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get { return Config.Get<JobsConfig>().Providers; }
        }

        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get { return () => Config.Get<JobsConfig>().DefaultProvider; }
        }

        public static JobsManager GetManager()
        {
            return ManagerBase<JobsDataProviderBase>.GetManager<JobsManager>();
        }

        public static JobsManager GetManager(string providerName)
        {
            return ManagerBase<JobsDataProviderBase>.GetManager<JobsManager>(providerName);
        }

        public static JobsManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<JobsDataProviderBase>.GetManager<JobsManager>(providerName, transactionName);
        }

        public virtual JobApplication CreateJobApplication()
        {
            return this.Provider.CreateJobApplication();
        }

        public virtual JobApplication CreateJobApplication(Guid id)
        {
            return this.Provider.CreateJobApplication(id);
        }

        public virtual IQueryable<JobApplication> GetJobApplications()
        {
            return this.Provider.GetJobApplications();
        }

        public virtual JobApplication GetJobApplication(Guid id)
        {
            return this.Provider.GetJobApplication(id);
        }

        public virtual void DeleteJobApplication(JobApplication application)
        {
            this.Provider.DeleteJobApplication(application);
        }

        public override IQueryable<TItem> GetItems<TItem>()
        {
            if (typeof(JobApplication).IsAssignableFrom(typeof(TItem)))
                return this.GetJobApplications() as IQueryable<TItem>;
            if (typeof(TItem) == typeof(Comment))
                return null;
            throw new NotSupportedException();
        }

        public JobApplication CheckIn(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public JobApplication CheckOut(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public void Copy(JobApplication source, JobApplication destination)
        {
            throw new NotImplementedException();
        }

        public JobApplication Edit(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public Guid GetCheckedOutBy(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public JobApplication GetLive(JobApplication cnt)
        {
            throw new NotImplementedException();
        }

        public JobApplication GetMaster(JobApplication cnt)
        {
            throw new NotImplementedException();
        }

        public JobApplication GetTemp(JobApplication cnt)
        {
            throw new NotImplementedException();
        }

        public bool IsCheckedOut(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public bool IsCheckedOutBy(JobApplication item, Guid userId)
        {
            throw new NotImplementedException();
        }

        public JobApplication Publish(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public JobApplication Schedule(JobApplication item, DateTime publicationDate, DateTime? expirationDate)
        {
            throw new NotImplementedException();
        }

        public JobApplication Unpublish(JobApplication item)
        {
            throw new NotImplementedException();
        }

        public Content CheckIn(Content item)
        {
            throw new NotImplementedException();
        }

        public Content CheckOut(Content item)
        {
            throw new NotImplementedException();
        }

        public void Copy(Content source, Content destination)
        {
            throw new NotImplementedException();
        }

        public Content Edit(Content item)
        {
            throw new NotImplementedException();
        }

        public Guid GetCheckedOutBy(Content item)
        {
            throw new NotImplementedException();
        }

        public Content GetLive(Content cnt)
        {
            throw new NotImplementedException();
        }

        public Content GetMaster(Content cnt)
        {
            throw new NotImplementedException();
        }

        public Content GetTemp(Content cnt)
        {
            throw new NotImplementedException();
        }

        public bool IsCheckedOut(Content item)
        {
            throw new NotImplementedException();
        }

        public bool IsCheckedOutBy(Content item, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Content Publish(Content item)
        {
            throw new NotImplementedException();
        }

        public Content Schedule(Content item, DateTime publicationDate, DateTime? expirationDate)
        {
            throw new NotImplementedException();
        }

        public Content Unpublish(Content item)
        {
            throw new NotImplementedException();
        }
    }
}