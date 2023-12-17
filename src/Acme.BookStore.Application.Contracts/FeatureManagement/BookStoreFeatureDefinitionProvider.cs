using Acme.BookStore.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Features;
using Volo.Abp.Localization; 
using Volo.Abp.Validation.StringValues;

namespace Acme.BookStore.FeatureManagement;

public class BookStoreFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
        var myFeature = context.AddGroup("MyFeature");

        myFeature.AddFeature(
            "MyFeature.TwoFactor",
            defaultValue: "false",
            displayName: LocalizableString.Create<BookStoreResource>("Two Factor Enabled"),
            valueType: new ToggleStringValueType()
        );
    }
}

