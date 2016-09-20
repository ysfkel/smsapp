using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using MySmsSender.ServiceInterface;
using ServiceStack.Razor;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using DomainModel.Repository;
using DomainModel;
using ServiceStack.OrmLite.SqlServer;

namespace MySmsSender
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("MySmsSender", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            this.Plugins.Add(new RazorFormat());


            this.Config.AllowRouteContentTypeExtensions = false;

            //       var allowedOrigins = _appSettings.GetList("AllowedOrigins") ?? new[] {"*"};   //<add key="AllowedOrigins" value="http://localhost,http://locahost:3000"/>
            //appHost.Plugins.Add(new PostmanFeature());
            //appHost.Plugins.Add(new CorsFeature(
            //    allowOriginWhitelist: allowedOrigins,
            //    allowedMethods: "GET, POST, PUT, DELETE, OPTIONS",
            //    allowCredentials: true,
            //    allowedHeaders: "Authorization, Content-Type"));  //Access-Control-Allow-Headers, X-Requested-With, Accept, 
            this.Plugins.Add(new PostmanFeature());
            this.Plugins.Add(new CorsFeature(

                allowOriginWhitelist: new[] { "*" },
                     allowedMethods: "GET, POST, PUT, DELETE, OPTIONS",
            allowCredentials: true,
            allowedHeaders: "Authorization, Content-Type"
                ));
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            // Add our IDbConnectionFactory to the container, this will
            // allow all of our services to share a single connection factory
            container.Register<IDbConnectionFactory>
                (new OrmLiteConnectionFactory
                    (Properties.Settings.Default.ConnectionString,
                    SqlServerOrmLiteDialectProvider.Instance));

            container.RegisterAutoWiredAs<GenericRepository<SMS>, IGenericRepository<SMS>>();


            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                // We’re just creating a single table, but you could add
                // as many as you need.  Also note the “overwrite: false” parameter,
                // this will only create the table if it doesn’t already exist.
                // db.CreateTable<Person>(overwrite: false);
                db.CreateTable<Country>(overwrite: false);
                db.CreateTable<SMS>(overwrite: false);
            }

        }
    }
}