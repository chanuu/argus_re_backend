using Argus.Platform.Core.Common;
using Argus.Platform.Core.Features;
using Argus.Platform.Core.JobEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Features
{
 public class FeatureRepository : IFeatureRepository
    {
        private readonly ApiContext _context;

        public FeatureRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Feature Add(Feature feature)
        {
            return _context.Features.Add(feature).Entity;
        }


        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            return await _context.Features.ToListAsync();
        }

        public async Task<Feature> GetAsync(Guid featureId)
        {
            return await _context.Features.SingleOrDefaultAsync();
        }

        public async Task<Feature> Update(Feature feature)
        {
            _context.Features.Update(feature);

            await _context.SaveChangesAsync();

            return feature;
        }
    }
}
