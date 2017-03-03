﻿using System;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
{
    [DataContract]
    public class Class : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Day { get; set; }

        [DataMember]
        public DateTimeOffset StartTime { get; set; }

        [DataMember]
        public DateTimeOffset EndTime { get; set; }

        [DataMember]
        public long SchoolId { get; set; }
    }
}
