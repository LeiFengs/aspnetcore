// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.ObjectModel;
using Microsoft.Extensions.Primitives;

namespace Microsoft.AspNetCore.Components.Endpoints;

internal sealed class HttpContextFormDataProvider
{
    private string? _name;
    private IReadOnlyDictionary<string, StringValues>? _entries;

    public string? Name => _name;

    public IReadOnlyDictionary<string, StringValues> Entries => _entries ?? ReadOnlyDictionary<string, StringValues>.Empty;

    public bool IsFormDataAvailable => Name != null;

    public void SetFormData(string name, IReadOnlyDictionary<string, StringValues> form)
    {
        _name = name;
        _entries = form;
    }
}
