using IPS.ContentManagementSystem.Application.Contracts.Infrastructure;
using IPS.ContentManagementSystem.Application.Model.Mail;
using IPS.ContentManagementSystem.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            service.AddTransient<IEmailService, EmailService>();

            return service;
        }
    }
}
