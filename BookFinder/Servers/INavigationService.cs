using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Servers
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }

        void GoBack();

        void NavigateTo(string pagekey);

        void NavigateTo(string pagekey, string parameter);
    }
}
