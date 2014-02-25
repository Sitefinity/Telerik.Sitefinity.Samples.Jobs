using System.Collections.Generic;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;

namespace Jobs.Model
{
    public class JobsFluentMetadataSource : ContentBaseMetadataSource
    {
        public JobsFluentMetadataSource()
            : base(null)
        {}

        public JobsFluentMetadataSource(IDatabaseMappingContext context)
            : base (context)
        {}

        protected override IList<IOpenAccessFluentMapping> BuildCustomMappings()
        {
            var sitefinityMappings = new List<IOpenAccessFluentMapping>();
            sitefinityMappings.Add(new Telerik.Sitefinity.Model.CommonFluentMapping(this.Context) { });
            sitefinityMappings.Add(new Telerik.Sitefinity.Model.ContentBaseFluentMapping(this.Context) { });
            sitefinityMappings.Add(new JobsFluentMapping(this.Context));
            return sitefinityMappings;
        }
    }
}
