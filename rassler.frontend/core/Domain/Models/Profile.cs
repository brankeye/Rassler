using System;
using System.Linq;
using System.Runtime.Serialization;
using rassler.frontend.core.Domain.Interfaces;
using Realms;
using Xamarin.Realm.Service.Attributes;

namespace rassler.frontend.core.Domain.Models
{
    [DataContract]
    public class Profile : RealmObject, ILocalEntity
    {
        [PrimaryKey, AutoIncrement]
        public long LocalId { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public long ContactInfoId { get; set; }

        [DataMember]
        public long StandingId { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public long SchoolId { get; set; }

        public User User { get; set; }

        public School School { get; set; }

        public Standing Standing { get; set; }

        [Backlink(nameof(Rank.Profile))]
        public IQueryable<Rank> Ranks { get; }

        [Backlink(nameof(Payment.Profile))]
        public IQueryable<Payment> Payments { get; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
