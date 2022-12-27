using System;
using System.Text;
using AdoDapperBLL.Configurations;
using AdoDapperBLL.Grpc;
using AdoDapperBLL.Protos;
using AdoDapperBLL.Services.Abstract;
using AdoDapperBLL.Services.Concrete;
using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Connection.Concrete;
using AdoDapperDAL.Repositories.Abstract;
using AdoDapperDAL.Repositories.Concrete;
using AdoDapperDAL.UnitOfWork.Abstract;
using AdoDapperDAL.UnitOfWork.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdoDapperAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddGrpcReflection();
            
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( options => 
            {  
                options.SaveToken = true;  
                options.RequireHttpsMetadata = false;  
                options.TokenValidationParameters = new TokenValidationParameters()  
                {  
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                    ClockSkew = TimeSpan.Zero, 
                };  
            });
            
            services.AddGrpcClient<Products.ProductsClient>((_, options) =>
            {
                options.Address = new Uri(Configuration["urls:grpcProducts"]);
            });

            services.AddTransient<IPurchaseOrderProductRepository, PurchaseOrderProductRepository>();
            services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddTransient<IWarehouseProductRepository, WarehouseProductRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();
            services.AddTransient<IWarehouseService, WarehouseService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddRazorPages();

            services.AddControllers();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(options => options
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcReflectionService();
                endpoints.MapGrpcService<WarehousesService>();
                endpoints.MapControllers();
            });
        }
    }
}
