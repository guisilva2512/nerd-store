using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Bus;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection service) 
        {
            // Domain Bus Mediator
            service.AddScoped<IMediatRHandler, MediatRHandler>();

            // Catalogo
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IProdutoAppService, ProdutoAppService>();
            service.AddScoped<IEstoqueService, EstoqueService>();
            service.AddScoped<CatalogoContext>();

            // MediatR
            service.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
        }
    }
}
