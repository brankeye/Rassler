using System;
using System.Runtime.Serialization;
using rassler.frontend.core.Domain.Interfaces;
using Realms;
using Xamarin.Realm.Service.Attributes;

namespace rassler.frontend.core.Domain.Models
{
    [DataContract]
    public class Rank : RealmObject, ILocalEntity
    {
        [PrimaryKey, AutoIncrement]
        public long LocalId { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public DateTimeOffset AchievementDate { get; set; }

        [DataMember]
        public long ProfileId { get; set; }

        public Profile Profile { get; set; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
