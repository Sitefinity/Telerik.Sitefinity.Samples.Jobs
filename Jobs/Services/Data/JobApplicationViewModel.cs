using Jobs.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.GenericContent;

namespace Jobs.Services.Data
{
    public class JobApplicationViewModel : ContentViewModelBase
    {
        public JobApplicationViewModel()
            : base()
        {
        }

        public JobApplicationViewModel(JobApplication contentItem, ContentDataProviderBase provider)
            : base(contentItem, provider)
        {
            this.Phone = contentItem.Phone;
            this.FirstName = contentItem.FirstName;
            this.LastName = contentItem.LastName;
            this.Text = contentItem.Text;
            this.Referral = contentItem.Referral;
        }

        public string Phone
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string Referral
        {
            get;
            set;
        }

        protected override Content GetLive()
        {
            return this.provider.GetLiveBase<JobApplication>((JobApplication)this.ContentItem);
        }

        protected override Content GetTemp()
        {
            return this.provider.GetTempBase<JobApplication>((JobApplication)this.ContentItem);
        }
    }
}
