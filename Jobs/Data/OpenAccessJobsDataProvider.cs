using System;
using System.Linq;
using System.Reflection;
using Jobs.Model;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using Telerik.Sitefinity.Security;

namespace Jobs.Data
{
    [ContentProviderDecorator(typeof(OpenAccessContentDecorator))]
    public class OpenAccessJobsDataProvider : JobsDataProviderBase, IOpenAccessDataProvider
    {
        public Database Database
        {
            get;
            set;
        }

        public bool UseImplicitTransactions
        {
            get { return true; }
        }

        public override JobApplication CreateJobApplication()
        {
            return this.CreateJobApplication(Guid.NewGuid());
        }

        /// <summary>
        /// Creates the job application.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override JobApplication CreateJobApplication(Guid id)
        {
            var dateValue = DateTime.UtcNow;

            var item = new JobApplication()
            {
                Id = id,
                ApplicationName = this.ApplicationName,
                Owner = SecurityManager.GetCurrentUserId(),
                DateCreated = dateValue,
                PublicationDate = dateValue
            };

            ((IDataItem)item).Provider = this;

            if (id != Guid.Empty)
            {
                this.GetContext().Add(item);
            }

            return item;
        }

        /// <summary>
        /// Gets the job applications.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<JobApplication> GetJobApplications()
        {
            var appName = this.ApplicationName;

            var query =
                SitefinityQuery
                .Get<JobApplication>(this, MethodBase.GetCurrentMethod())
                .Where(b => b.ApplicationName == appName);

            return query;
        }

        /// <summary>
        /// Gets the job application.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override JobApplication GetJobApplication(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("id");

            var item = this.GetContext().GetItemById<JobApplication>(id.ToString());
            ((IDataItem)item).Provider = this;
            return item;
        }

        /// <summary>
        /// Deletes the job application.
        /// </summary>
        /// <param name="application">The application.</param>
        public override void DeleteJobApplication(JobApplication application)
        {
            var context = this.GetContext();
            if (context != null)
            {
                context.Remove(application);
            }
        }

        /// <summary>
        /// Gets the transaction concurrency.
        /// </summary>
        /// <value>The transaction concurrency.</value>
        public TransactionMode TransactionConcurrency
        {
            get
            {
                return TransactionMode.PESSIMISTIC_EXPLICIT;
            }
        }

        /// <summary>
        /// Gets or sets the OpenAccess context. Alternative to Database.
        /// </summary>
        /// <value>The context.</value>
        public OpenAccessProviderContext Context 
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the meta data source.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
        {
            return new JobsFluentMetadataSource(context);
        } 
    }
}