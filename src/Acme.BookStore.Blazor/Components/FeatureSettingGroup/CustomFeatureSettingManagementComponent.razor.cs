using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.FeatureManagement.Blazor.Components.FeatureSettingGroup;
using Volo.Abp.FeatureManagement.Blazor.Components;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.Features;

namespace Acme.BookStore.Blazor.Components.FeatureSettingGroup
{
    public partial class CustomFeatureSettingManagementComponent : AbpComponentBase
    {
        [Inject]
        protected PermissionChecker PermissionChecker { get; set; }

        protected CustomFeatureManagementModal FeatureManagementModalRef;

        protected CustomFeatureSettingViewModel Settings;

        public CustomFeatureSettingManagementComponent()
        {
            LocalizationResource = typeof(AbpFeatureManagementResource);
        }

        protected async override Task OnInitializedAsync()
        {
            Settings = new CustomFeatureSettingViewModel
            {
                HasManageHostFeaturesPermission = await AuthorizationService.IsGrantedAsync(FeatureManagementPermissions.ManageHostFeatures)
            };
        }

        protected virtual async Task OnManageHostFeaturesClicked()
        {
            await FeatureManagementModalRef.OpenAsync(TenantFeatureValueProvider.ProviderName);
        }
    }
}
