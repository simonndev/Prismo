using Prism.Events;
using Prismo.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Presentation.Events
{
    public class FetchModuleNavigationItemsEvent : PubSubEvent<IEnumerable<NavigationItemModel>>
    {
    }
}
