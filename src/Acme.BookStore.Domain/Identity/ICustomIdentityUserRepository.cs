using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Acme.BookStore.Identity;

public interface ICustomIdentityUserRepository : IRepository<IdentityUser, Guid>
{
    Task<List<IdentityUser>> GetListByTenantId(Guid Id, CancellationToken cancellationToken = default);
}
