using System;
using System.Linq;
using System.Runtime.Serialization;
using rassler.frontend.core.Domain.Interfaces;
using Realms;
using Xamarin.Realm.Service.Attributes;

namespace rassler.frontend.core.Domain.Models
{
    [DataContract]
    public class User : RealmObject, ILocalEntity
    {
        [PrimaryKey, AutoIncrement]
        public long LocalId { get; set; }

        [DataMember]
        public long Id { get; set; }

        [Indexed]
        [DataMember]
        public string Username { get; set; }

        [Backlink(nameof(Profile.User))]
        public IQueryable<Profile> Profiles { get; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
