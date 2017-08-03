using  Prism.Events;
using SMM.Contract.Model;

namespace SMM.Configuration.Events
{
    public class OnDatabaseProviderSelectionChangedEvent : PubSubEvent<DatabaseProviders>
    {
    }
}
