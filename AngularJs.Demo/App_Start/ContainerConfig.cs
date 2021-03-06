﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Demo.Provider.Provider;
using Demo.Data.Contexts;
using Demo.Data.Respositories;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace AngularJs.Demo.App_Start
{
    public class ContainerConfig
    {
        public static IContainer Container { get; set; }
        public static void RegisterComponets()
        {
            var builder = new ContainerBuilder();
            //Context
            builder.RegisterType<MusicStoreContext>().As<IMusicStoreContext>().InstancePerRequest();

            //Repositories
            builder.RegisterType<AlbumRespository>().As<IAlbumRespository>().InstancePerRequest();
            builder.RegisterType<GenreRespository>().As<IGenreRespository>().InstancePerRequest();
            builder.RegisterType<OrderRespository>().As<IOrderRespository>().InstancePerRequest();
            builder.RegisterType<RegionDDLRespository>().As<IRegionDDLRespository>().InstancePerRequest();

            //Provider
            builder.RegisterType<AlbumProvider>().As<IAlbumProvider>().InstancePerRequest();
            builder.RegisterType<GenreProvider>().As<IGenreProvider>().InstancePerRequest();
            builder.RegisterType<OrderProvider>().As<IOrderProvider>().InstancePerRequest();
            builder.RegisterType<ddlProvider>().As<IddlProvider>().InstancePerRequest();
            //other
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder the Container
            var config = GlobalConfiguration.Configuration;
            var container = builder.Build();

            var dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);


            //Define Dependency injector for Web API
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}