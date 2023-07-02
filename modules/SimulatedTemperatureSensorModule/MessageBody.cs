// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace SimulatedFlowSensorModule
{
    public class MessageBody
    {
        [JsonProperty("InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty("machine")]
        public Machine Machine { get; set; }
        [JsonProperty("ambient")]
        public Ambient Ambient { get; set; }
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }
    }

    [JsonObject("machine")]
    public class Machine
    {
        [JsonProperty("Flow")]
        public double Flow { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
    }

    [JsonObject("ambient")]
    public class Ambient
    {
        [JsonProperty("Flow")]
        public double Flow { get; set; }
        [JsonProperty("Rate")]
        public int Rate { get; set; }
    }
}
