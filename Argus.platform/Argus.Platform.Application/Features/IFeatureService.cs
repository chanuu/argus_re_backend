using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Features
{
    public interface IFeatureService : ITransientService
    {
        Task<IEnumerable<Feature>> GetAllFeaturesAsync();
        Task<Feature> GetFeatureAsync(Guid featureId);
        Task<Feature> AddFeatureAsync(Feature feature);
        Task<Feature> UpdateFeatureAsync(Feature feature );
    }
}
