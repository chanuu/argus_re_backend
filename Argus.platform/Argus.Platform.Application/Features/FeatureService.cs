using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Features
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureReposirory;
        public FeatureService(IFeatureRepository featureReposirory)
        {
            _featureReposirory = featureReposirory;
        }

        public async Task<IEnumerable<Feature>> GetAllFeaturesAsync()
        {
            return await _featureReposirory.GetAllAsync();
        }


        public async Task<Feature> GetFeatureAsync(Guid featureId)
        {
            return await _featureReposirory.GetAsync(featureId);
        }

        public async Task<Feature> AddFeatureAsync(Feature feature)
        {
            // You may perform any necessary business logic validation here 
            var _feature = _featureReposirory.Add(feature);
            await _featureReposirory.UnitOfWork.SaveChangesAsync();
            return _feature;
        }

        public async Task<Feature> UpdateFeatureAsync(Feature feature)
        {

            var _feature = await _featureReposirory.Update(feature);
            await _featureReposirory.UnitOfWork.SaveChangesAsync();
            return _feature;
        }

    }
}
