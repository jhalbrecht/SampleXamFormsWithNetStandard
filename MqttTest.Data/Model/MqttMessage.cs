using System;
using System.Collections.Generic;
using System.Text;

namespace MqttTest.Data.Model
{
    public class MqttMessage
    {
        public string Topic { get; set; }
        public string Payload { get; set; }
    }
}
