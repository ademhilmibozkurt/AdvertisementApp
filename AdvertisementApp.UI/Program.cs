using AdvertisementApp.Business.DependencyResolvers.Microsoft;

public class Program
{   
    // static error
    public static IConfiguration Configuration { get; set; }
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDependencies(Configuration);

        var app = builder.Build();

        app.Run();
    }
}