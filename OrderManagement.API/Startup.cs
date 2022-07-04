using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OrderManagement.API.Infrastructure.Mapper;
using OrderManagement.API.Middlewares;
using OrderManagement.API.Repository;
using OrderManagement.API.Repository.Implementation;
using OrderManagement.API.Repository.Interfaces;
using OrderManagement.API.Services.Implementation;
using OrderManagement.API.Services.Interfaces;

namespace OrderManagement.API
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
            services.AddDbContext<ApplicationDBContext>(options =>
                                   options.UseSqlServer(Configuration.GetSection("AppConfig:ConnectionStrings").Value),ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(ResponseProfile));
            services.AddAutoMapper(typeof(RequestProfile));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<IProductIndexService,ProductIndexService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagement.API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseJsonExceptionHandler(loggerFactory);

            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderManagement.API v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
