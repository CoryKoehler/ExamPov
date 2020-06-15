using System;
using Autofac;
using EventFlow;
using EventFlow.Autofac.Extensions;
using EventFlow.Extensions;
using EventFlow.MongoDB.Extensions;
using Newtonsoft.Json;

namespace ExamPovApi
{
    public static class StartupExtensions
    {
        public static ContainerBuilder AddEventFlow(this ContainerBuilder containerBuilder,
                string mongoDbUri, string mongoDbName)
        {
            var container = EventFlowOptions.New
                .UseAutofacContainerBuilder(containerBuilder)
                .Configure(c => c.IsAsynchronousSubscribersEnabled = true)
                .ConfigureMongoDb(mongoDbUri, mongoDbName)
                .UseMongoDbEventStore()
                .UseMongoDbSnapshotStore()
                .ConfigureJson(options => options.Configure(settings =>
                {
                    settings.TypeNameHandling = TypeNameHandling.Auto;
                    settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                }))
                .AddDefaults(typeof(Program).Assembly)
                .ConfigureOptimisticConcurrentcyRetry(20, TimeSpan.FromMilliseconds(1));

            return containerBuilder;
        }
    }
}
