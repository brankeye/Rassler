using System;
using System.Runtime.Serialization;
using rassler.frontend.core.Domain.Interfaces;
using Realms;
using Xamarin.Realm.Service.Attributes;

namespace rassler.frontend.core.Domain.Models
{
    [DataContract]
    public class ContactInfo : RealmObject, ILocalEntity
    {
        [PrimaryKey, AutoIncrement]
        public long LocalId { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        public Profile Profile { get; set; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
