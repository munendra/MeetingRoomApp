using AutoMapper;
using FluentValidation.AspNetCore;
using MeetingApp.Api.Middleware;
using MeetingApp.Domain.Context;
using MeetingApp.Dto.Validations;
using MeetingApp.Logic.Contract;
using MeetingApp.Logic.Implementation;
using MeetingApp.Mapper;
using MeetingApp.Repository.Contracts;
using MeetingApp.Repository.Implementations;
using MeetingApp.Service.Contract;
using MeetingApp.Service.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MeetingApp.Api
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            HostingEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);


            services.AddDbContext<MeetingAppDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();

            services.AddTransient<IMeetingRoomBookingLogic, MeetingRoomBookingLogic>();
            services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            services.AddTransient<IRoomLogic, RoomLogic>();

            services.AddTransient<IMeetingRoomBookingService, MeetingRoomBookingService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IBookingValidation, BookingValidation>();

            services
               .AddMvc(options =>
                   {

                       options.Filters.Add(new ProducesAttribute("application/json"));
                       options.Filters.Add(typeof(ValidateModelStateAttribute));
                   }
                )
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookingValidator>());
            services.AddAutoMapper(typeof(RoomMapper));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/error/{0}");
            }
            app.UseStaticFiles();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvcWithDefaultRoute();
        }
    }
}
