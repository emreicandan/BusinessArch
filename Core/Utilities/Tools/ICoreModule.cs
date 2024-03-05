using System;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Tools;

public interface ICoreModule
{
    public void Load(IServiceCollection services);
}

