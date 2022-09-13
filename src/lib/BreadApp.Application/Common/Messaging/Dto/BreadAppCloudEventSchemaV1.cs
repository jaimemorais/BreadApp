using Newtonsoft.Json;
using System;
using System.Globalization;

namespace BreadApp.Application.Common.Messaging.Dto
{
    public class BreadAppCloudEventSchemaV1<T> where T : class
    {
        [JsonProperty("specversion")]
        public string CloudEventSpecVersion => "1.0";

        [JsonProperty("type")]
        public string EventType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("id")]
        public string EventId => Guid.NewGuid().ToString();

        [JsonProperty("time")]
        public string Time => DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

        [JsonProperty("subject")]
        public string Subject { get; set; }



        [JsonProperty("data")]
        public T Data { get; set; }

    }
}
