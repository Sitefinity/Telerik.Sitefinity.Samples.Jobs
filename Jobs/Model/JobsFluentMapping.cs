using System.Collections.Generic;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;

namespace Jobs.Model
{
    public class JobsFluentMapping : OpenAccessFluentMappingBase
    {
        public JobsFluentMapping(IDatabaseMappingContext context)
            : base(context)
        {
        }

        public override IList<MappingConfiguration> GetMapping()
        {
            var mappings = new List<MappingConfiguration>();
            MapItem(mappings);
            return mappings;
        }

        private void MapItem(IList<MappingConfiguration> mappings)
        {
            var itemMapping = new MappingConfiguration<JobApplication>();
            itemMapping.HasProperty(p => p.Id).IsIdentity();
            itemMapping.MapType(p => new { }).ToTable("sfex_jobapplications");
            itemMapping.HasProperty(p => p.Phone);
            itemMapping.HasProperty(p => p.FirstName);
            itemMapping.HasProperty(p => p.LastName);
            itemMapping.HasProperty(p => p.Text);
            itemMapping.HasProperty(p => p.Referral);
            mappings.Add(itemMapping);
        }
    }
}
