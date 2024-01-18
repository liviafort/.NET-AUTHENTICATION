//Arquivo crucial para a configuração inicial da aplicação e para definir como ela lida com solicitações e serviços
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        /*
        Essencialmente, esta parte do código está configurando a aplicação para aceitar tokens JWT com determinadas características (emitido por um emissor específico, para uma audiência específica, etc.) e registrando os serviços necessários para lidar com solicitações HTTP usando o padrão MVC.
        */

        public void ConfigureServices(IServiceCollection services)
        {
            var TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = "https://fbi-demo.com",
                ValidAudience = "https://fbi-demo.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ")),
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
