// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Microsoft.AspNetCore.Mvc.DataAnnotations.Internal
{
    /// <summary>
    /// An implementation of <see cref="IClientModelValidatorProvider"/> which provides client validators
    /// for specific numeric types.
    /// </summary>
    public class NumericClientModelValidatorProvider : IClientModelValidatorProvider
    {
        /// <inheritdoc />
        public void GetValidators(ClientValidatorProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var typeToValidate = context.ModelMetadata.UnderlyingOrModelType;

            // Check only the numeric types for which we set type='text'.
            if (typeToValidate == typeof(float) ||
                typeToValidate == typeof(double) ||
                typeToValidate == typeof(decimal))
            {
                for (var i = 0; i < context.Results.Count; i++)
                {
                    var validator = context.Results[i].Validator;
                    if (validator != null && validator is NumericClientModelValidator)
                    {
                        // A validator is already present. No need to add one.
                        return;
                    }
                }

                context.Results.Add(new ClientValidatorItem
                {
                    Validator = new NumericClientModelValidator(),
                    IsReusable = true
                });
            }
        }
    }
}
