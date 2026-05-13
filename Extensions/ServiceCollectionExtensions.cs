using IQeSign.TicketBai.Configuration;
using IQeSign.TicketBai.Http;
using IQeSign.TicketBai.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IQeSign.TicketBai.Extensions;

/// <summary>
/// Extensiones de <see cref="IServiceCollection"/> para registrar los servicios de IQ eSign TicketBAI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registra los servicios de IQ eSign TicketBAI en el contenedor de dependencias.
    /// </summary>
    /// <param name="services">La colección de servicios de la aplicación.</param>
    /// <param name="configure">Acción para configurar las opciones del cliente.</param>
    /// <returns>La colección de servicios para encadenar llamadas.</returns>
    /// <example>
    /// <code>
    /// // En Program.cs / Startup.cs:
    /// builder.Services.AddIQeSignTicketBai(options =>
    /// {
    ///     options.CredentialGuid = builder.Configuration["IQeSignTicketBai:CredentialGuid"]!;
    ///     options.Environment = IQeSignEnvironment.Production;
    /// });
    ///
    /// // O bien usando appsettings.json con sección "IQeSignTicketBai":
    /// builder.Services.AddIQeSignTicketBai(
    ///     builder.Configuration.GetSection(IQeSignOptions.SectionName));
    /// </code>
    /// </example>
    public static IServiceCollection AddIQeSignTicketBai(
        this IServiceCollection services,
        Action<IQeSignOptions> configure)
    {
        services.Configure(configure);
        RegisterServices(services);
        return services;
    }

    /// <summary>
    /// Registra los servicios de IQ eSign TicketBAI usando una sección de configuración.
    /// </summary>
    /// <param name="services">La colección de servicios de la aplicación.</param>
    /// <param name="configuration">Sección de configuración que contiene las opciones de <see cref="IQeSignOptions"/>.</param>
    /// <returns>La colección de servicios para encadenar llamadas.</returns>
    public static IServiceCollection AddIQeSignTicketBai(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        services.Configure<IQeSignOptions>(configuration);
        RegisterServices(services);
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        // Registrar los dos clientes HTTP nombrados (uno por entorno)
        services
            .AddHttpClient(HttpClientNames.Production, (sp, client) =>
            {
                client.BaseAddress = new Uri("https://iqesignapi.azurewebsites.net");
                ConfigureTimeout(client, sp);
            });

        services
            .AddHttpClient(HttpClientNames.Staging, (sp, client) =>
            {
                client.BaseAddress = new Uri("https://iqesignapistaging.azurewebsites.net");
                ConfigureTimeout(client, sp);
            });

        // Cliente HTTP interno (singleton para reutilizar el token cacheado)
        services.AddSingleton<IQeSignHttpClient>();

        // Servicios públicos
        services.AddTransient<ICertificateService, CertificateService>();
        services.AddTransient<ITicketBaiService, TicketBaiService>();
        services.AddTransient<ITicketBaiReceivedService, TicketBaiReceivedService>();
    }

    private static void ConfigureTimeout(System.Net.Http.HttpClient client, IServiceProvider sp)
    {
        var options = sp.GetRequiredService<IOptions<IQeSignOptions>>().Value;
        client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
    }
}
