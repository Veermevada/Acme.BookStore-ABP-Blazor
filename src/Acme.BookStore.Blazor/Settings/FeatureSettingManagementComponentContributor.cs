using System.Threading.Tasks;
using Acme.BookStore.Blazor.Components.FeatureSettingGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Blazor.Components.FeatureSettingGroup;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.SettingManagement.Blazor;

namespace Acme.BookStore.Blazor.Settings;

public class FeatureSettingManagementComponentContributor : ISettingComponentContributor
{
    public virtual async Task ConfigureAsync(SettingComponentCreationContext context)
    {
        if (!await CheckPermissionsInternalAsync(context))
        {
            return;
        }

        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpFeatureManagementResource>>();
        context.Groups.Add(
            new SettingComponentGroup(
                "Volo.Abp.Feature",
                l["Permission:FeatureManagement"],
                typeof(CustomFeatureSettingManagementComponent)
            )
        );
    }

    public virtual async Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context)
    {
        return await CheckPermissionsInternalAsync(context);
    }

    protected virtual async Task<bool> CheckPermissionsInternalAsync(SettingComponentCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

        return await authorizationService.IsGrantedAsync(FeatureManagementPermissions.ManageHostFeatures);
    }
}