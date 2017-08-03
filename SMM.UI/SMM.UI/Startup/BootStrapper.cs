using  Autofac;
using Prism.Events;
using SMM.Services.QualGroups;
using SMM.UI.ViewModels;
using SMM.UI.ViewModels.QualGroups;
using SMM.UI.Views;

namespace SMM.UI.Startup
{
    public class BootStrapper
    {
        public IContainer BootStarp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<SMMHome>().AsSelf();
            builder.RegisterType<SMMHomeViewModel>().AsSelf();
            builder.RegisterType<QualifierGroupViewModel>()
                .As<IQualifierGroupViewModel>();
            builder.RegisterType<QualGroupNavigationDataProvider>()
                .As<IQualGroupNavigationDataProvider>();
            builder.RegisterType<QualifierGroupDataServiceInMemory>()
                .As<IQualifierGroupDataService>();

            return builder.Build();
        }
    }
}
