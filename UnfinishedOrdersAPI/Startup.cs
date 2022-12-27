using AutoMapper;
using Common;
using Common.Events.OrderEvents;
using MassTransit;
using RabbitMQ.Client;
using Redis.OM;
using UnfinishedOrdersAPI.Configurations;
using UnfinishedOrdersAPI.Entities;
using UnfinishedOrdersAPI.Repositories.Abstract;
using UnfinishedOrdersAPI.Repositories.Concrete;

namespace UnfinishedOrdersAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Redis Configuration
            var redisProvider = new RedisConnectionProvider(Configuration["CacheSettings:ConnectionString"]);
            services.AddSingleton(redisProvider);
            redisProvider.Connection.CreateIndex(typeof(UnfinishedSalesOrder));

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Password(Configuration["EventBusSettings:Password"]);
                        h.Username(Configuration["EventBusSettings:Username"]);
                    });

                    cfg.Message<FinishedSalesOrderEvent>(e =>
                        e.SetEntityName(EventBusConstants.TopicExchange)); // name of the primary exchange
                    cfg.Publish<FinishedSalesOrderEvent>(e =>
                        e.ExchangeType = ExchangeType.Topic); // primary exchange type
                    cfg.Send<FinishedSalesOrderEvent>(e => { e.UseRoutingKeyFormatter(_ => "order."); });
                });
            });

            services.AddTransient<IUnfinishedSalesOrderRepository, UnfinishedSalesOrderRepository>();

            var mapperConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new AutoMapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpContextAccessor();

            services.AddHttpContextAccessor();

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

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}