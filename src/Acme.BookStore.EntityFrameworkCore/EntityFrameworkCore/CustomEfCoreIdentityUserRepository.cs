using Acme.BookStore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore;

[ExposeServices(typeof(ICustomIdentityUserRepository), IncludeDefaults = true)]
public class CustomEfCoreIdentityUserRepository : EfCoreIdentityUserRepository, ICustomIdentityUserRepository
{
    public CustomEfCoreIdentityUserRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider)
        : base(dbContextProvider)
    {

    }

    public virtual async Task<List<IdentityUser>> GetListByTenantId(Guid Id, CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();

        var List = await dbContext.Users.Where(w => w.TenantId == Id).ToListAsync(GetCancellationToken(cancellationToken));

        return List;
    }
}

