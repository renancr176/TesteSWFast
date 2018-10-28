using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.Services;
using TesteSWFast.IO.Core.Bus;
using TesteSWFast.IO.Core.Events;
using TesteSWFast.IO.Core.Notifications;
using TesteSWFast.IO.Domain.Categories.Commands;
using TesteSWFast.IO.Domain.Categories.Events;
using TesteSWFast.IO.Domain.Categories.Repository;
using TesteSWFast.IO.Domain.Interfaces;
using TesteSWFast.IO.Domain.Products.Commands;
using TesteSWFast.IO.Domain.Products.Events;
using TesteSWFast.IO.Domain.Products.Repository;
using TesteSWFast.IO.Infra.CrossCutting.AspNetFilters;
using TesteSWFast.IO.Infra.CrossCutting.Bus;
using TesteSWFast.IO.Infra.CrossCutting.Identity.Models;
using TesteSWFast.IO.Infra.CrossCutting.Identity.Services;
using TesteSWFast.IO.Infra.Data.Context;
using TesteSWFast.IO.Infra.Data.Repository;
using TesteSWFast.IO.Infra.Data.UoW;

namespace TesteSWFast.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            #endregion

            #region ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion

            #region Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();
            #endregion

            #region Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
            #endregion

            #region Domain - Commands
            services.AddScoped<IHandler<CategoryInsertCommand>, CategoryCommandHandler>();
            services.AddScoped<IHandler<CategoryUpdateCommand>, CategoryCommandHandler>();
            services.AddScoped<IHandler<CategoryDeleteCommand>, CategoryCommandHandler>();

            services.AddScoped<IHandler<ProductInsertCommand>, ProductCommandHandler>();
            services.AddScoped<IHandler<ProductUpdateCommand>, ProductCommandHandler>();
            services.AddScoped<IHandler<ProductDeleteCommand>, ProductCommandHandler>();
            #endregion

            #region Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<CategoryInsertedEvent>, CategoryEventHandler>();
            services.AddScoped<IHandler<CategoryUpdatedEvent>, CategoryEventHandler>();
            services.AddScoped<IHandler<CategoryDeletedEvent>, CategoryEventHandler>();

            services.AddScoped<IHandler<ProductInsertedEvent>, ProductEventHandler>();
            services.AddScoped<IHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<IHandler<ProductDeletedEvent>, ProductEventHandler>();
            #endregion

            #region Infra - Data
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion
        }
    }
}
