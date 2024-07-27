using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Tenant
{
    public class TenantReposisotry : ITenantRepository
    {
        private readonly ApiContext _context;
        private readonly UserManager<User> _userManager;


        public TenantReposisotry(ApiContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }


        private async Task<bool> CheckUserIsAlreadyExist(User user)
        {
            var _user = await _userManager.FindByEmailAsync(user.Email);
            if (_user is not null)
            {
                return true;
            }
            _user = await _userManager.FindByEmailAsync(user.UserName);
            if (_user is not null)
            {
               
                return true;
            }
            return false;

            

        }
        public async Task<Tenants> AddAsync(Tenants tenant, User user, Branch branch,Company company)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Add tenant
                var addedTenant = _context.Tenants.Add(tenant).Entity;
                await _context.SaveChangesAsync();

                //Add user 

                //add company

                company.TenantId = addedTenant.Id;
                company.Id = new Guid();
                
                company.LogoUrl = "";
                company.Name = company.Name;
                company.Email = company.Email;
                company.ContactNo = company.ContactNo;
                var addedCompany = _context.Company.Add(company).Entity;
                
                await _context.SaveChangesAsync();

                // add branch 
                branch.TenantId = addedTenant.Id;
                branch.CompanyId = addedCompany.Id;
                branch.Address = branch.Address;
                branch.Name = branch.Name;
                branch.ContactNo = branch.ContactNo;
                var addedBranch  = _context.Branches.Add(branch).Entity;
                addedCompany.TenantId = addedTenant.Id;
                await _context.SaveChangesAsync();

                user.TenantId = addedTenant.Id;
                user.BranchId = addedBranch.Id;

                //if ( await CheckUserIsAlreadyExist(user)== true)
                // {
                //     await transaction.RollbackAsync();
                //     throw new Exception("User is Already Exist !");
                // };
                var addedUser = await  _userManager.CreateAsync(user, user.PasswordHash);
                

                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();


                return (addedTenant);
            }
            catch(Exception ex)
            {
                // Rollback transaction
                await transaction.RollbackAsync();
                throw new Exception(ex.StackTrace);
            }

           
        }

        public async Task<IEnumerable<Tenants>> GetAllAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task<Tenants> GetAsync(Guid tenantId)
        {
            return await _context.Tenants
                .Where(x => x.Id == tenantId)
                .SingleOrDefaultAsync();
        }

        public Task<Tenants> Update(Tenants employee)
        {
            throw new NotImplementedException();
        }
    }
}
