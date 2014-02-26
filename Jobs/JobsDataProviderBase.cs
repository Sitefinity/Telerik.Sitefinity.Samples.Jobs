using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jobs.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.GenericContent;

namespace Jobs
{
    public abstract class JobsDataProviderBase : ContentDataProviderBase
    {
        public override string RootKey
        {
            get
            {
                return "JobsDataProvider";
            }
        }

        public abstract JobApplication CreateJobApplication();

        public abstract JobApplication CreateJobApplication(Guid id);

        public abstract IQueryable<JobApplication> GetJobApplications();

        public abstract JobApplication GetJobApplication(Guid id);

        public abstract void DeleteJobApplication(JobApplication application);

        public override object CreateItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobApplication))
                return this.CreateJobApplication(id);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override object GetItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobApplication))
                return this.GetJobApplication(id);

            return base.GetItem(itemType, id);
        }

        public override void DeleteItem(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var itemType = item.GetType();

            if (itemType == typeof(JobApplication))
            {
                this.DeleteJobApplication((JobApplication)item);
                return;
            }

            throw GetInvalidItemTypeException(item.GetType(), this.GetKnownTypes());
        }

        public override IEnumerable GetItems(Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobApplication))
                return SetExpressions(this.GetJobApplications(), filterExpression, orderExpression, skip, take, ref totalCount);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override Type[] GetKnownTypes()
        {
            return new[] { typeof(JobApplication) };
        }

        public override Type GetParentTypeFor(Type contentType)
        {
            return null;
        }

        public override IEnumerable GetItemsByTaxon(Guid taxonId, bool isSingleTaxon, string propertyName, Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
        {
            return null;
        }

        public override Type GetUrlTypeFor(Type itemType)
        {
            return null;
        }
    }
}