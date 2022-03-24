using Microsoft.AspNetCore.Builder;

namespace WalletApi.Middlewares
{
    public static class ConfigureSwagger
    {
        public static void InitialSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WalletApi v1");
                c.InjectStylesheet("/css/swagger-dark-theme.css");
            });

        }
    }
}
