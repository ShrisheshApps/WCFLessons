﻿using System.Runtime.Serialization;

namespace ServiceLibrary
{
    [DataContract]
    public class OpenStudent: Student
    {
        [DataMember]
        public int Hours { get; set; }
        [DataMember]
        public int HourlyRate { get; set; }
    }
}