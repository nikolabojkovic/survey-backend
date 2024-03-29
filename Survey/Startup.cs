﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Application.Analytics.Strategy;
using Survey.Application.Interfaces;
using Survey.Application.Strategy;
using Survey.Domain.Survey;
using Survey.Extensions;
using Survey.Persistence;
using System.Reflection;

namespace Survey
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // stragety registration

            services.AddScoped<IQuestionStrategy, QuestionStrategy>();
            services.AddScoped<IQuestionType, CheckBoxesQuestion>();
            services.AddScoped<IQuestionType, ShortQuestion>();
            services.AddScoped<IQuestionType, RadioButtonsQuestion>();

            services.AddScoped<IQuestionResponseStrategy, QuestionResponseStrategy>();
            services.AddScoped<IQuestionResponseType, CheckBoxQuestionResponse>();
            services.AddScoped<IQuestionResponseType, TextQuestionResponse>();
            services.AddScoped<IQuestionResponseType, RadioButtonQuestionResponse>();

            services.AddScoped<IAnalyticsStrategy, AnalyticsStrategy>();
            services.AddScoped<IAnalyticsType, ShortQuestionAnalytics>();
            services.AddScoped<IAnalyticsType, SingleChoiceQuestionAnalytics>();
            services.AddScoped<IAnalyticsType, MultipleChoiceQuestionAnalytics>();

            // register mapper
            Mapper.Initialize(cfg =>
                cfg.AddMaps(new Assembly[] {
                    Assembly.Load("Survey.Domain"),
                    Assembly.Load("Survey.Application")
                }));

            services.AddMediatR(new Assembly[] {
                    Assembly.Load("Survey.Application")
                });

            services.AddSwagger();
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
            services.AddDbContext<ISurveyDbContext, SurveyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataConnectionString"), x => x.MigrationsAssembly("Survey.Persistence")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseSwaggerDocumentation();

            // app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
