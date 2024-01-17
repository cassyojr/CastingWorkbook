using CastingWorkbook.Repository.Context;

namespace CastingWorkbook.Api.Infrastructure;

public static class ContextInfrastructure
{
    public static IApplicationBuilder CreateInMemoryDb(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<CastingWorkbookContext>();
            dbContext.Database.EnsureCreated();
        }

        return app;
    }
}
