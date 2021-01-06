using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Services;
using Infra;
using Infra.IRepositories;
using Infra.Repositories;
using Infra.Repositories.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MainContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aprendizagem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            //services.SetupServicesDependencies();
            //services.SetupRepositoriesDependencies();
            services.AddControllers();
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );



            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IDeliveryManService, DeliveryManService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISnackService, SnackService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ICommentRestaurantService, CommentRestaurantService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISnackRepository, SnackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ICommentRestaurantRepository, CommentRestaurantRepository>();
            services.AddScoped<IOrder_SnackRepository, Order_SnackRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetRequiredService<MainContext>();

                context
                    .Database
                    .Migrate();
            }

            app.UseCors(x => x.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
