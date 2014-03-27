using System.Runtime.Serialization;
using Telerik.OpenAccess;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;

namespace Jobs.Model
{
    [DataContract(Namespace = "http://sitefinity.com/samples/jobsmodule", Name = "JobApplication")] 
    [ManagerType("Jobs.JobsManager, Jobs")]
    [Persistent(IdentityField = "contentId")]
    public class JobApplication : Content
    {
        public override bool SupportsContentLifecycle
        {
            get
            {
                return false;
            }
        }

        [DataMember]
        [FieldAlias("phone")]
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        [DataMember]
        [FieldAlias("firstName")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        [DataMember]
        [FieldAlias("lastName")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        [DataMember]
        [FieldAlias("text")]
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        [DataMember]
        [FieldAlias("referral")]
        public string Referral
        {
            get
            {
                return this.referral;
            }
            set
            {
                this.referral = value;
            }
        }

        private string referral;
        private string text;
        private string phone;
        private string firstName;
        private string lastName;
    }
}