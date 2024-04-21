using System.Formats.Asn1;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Buffers.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;
using System.Xml.Linq;
using FluentValidation;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Serialization;

namespace abstractests.Models
{
    public abstract class baseRecord
    {
        public string name { get; set; }

    }
    public class record   : baseRecord
    {
    }

    public class ARecord : baseRecord
    {
        public string ip4address { get; set; }
    }

    public class AAARecord : baseRecord
    {
        public string ip4address { get; set; }
        public string ip6address { get; set; }

    }

    public class RecordSetBase
    {
        [JsonPropertyName("Name")]
        public string name { get; set; }
        [JsonPropertyName("Type")]
        public type type { get; set; }
        [JsonPropertyName("Records")]
        public IEnumerable<baseRecord> records { get; set; }
    }
    public enum type
    {
        UNRECOGNIZED = -1,
        A  = 0,
        AAA = 1
    }
  


}
   

