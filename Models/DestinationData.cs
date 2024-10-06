using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Models
{
    internal class DestinationData
    {
        [JsonPropertyName("destination")]
        public required string Destination { get; set; }
    }
}
