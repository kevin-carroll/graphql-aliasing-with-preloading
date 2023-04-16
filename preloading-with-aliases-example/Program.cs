namespace preloading_with_aliases_example
{
    using GraphQL.AspNet.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGraphQL();

            var app = builder.Build();

            app.UseGraphQL();

            app.Run();
        }
    }
}