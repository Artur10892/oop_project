using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch_Application;

public static class DependencyInjection
{
    public static void AddApplicationMediatR(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}