using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.frontend.core.Domain.Models;
using Xamarin.Realm.Service;

namespace rassler.frontend.core.Domain.Services.Realms
{
    public class UsersRealm : RealmService<User>
    {
    }
}
