using Argus.Platform.Core.Common;
using Argus.Platform.Core.JobEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Features
{
    public interface IFeatureRepository : IRepository<Feature>, ITransientService
    {
        Feature Add(Feature feature);
        Task<IEnumerable<Feature>> GetAllAsync();
        Task<Feature> GetAsync(Guid featureId);
        Task<Feature> Update(Feature feature);
    }
}
