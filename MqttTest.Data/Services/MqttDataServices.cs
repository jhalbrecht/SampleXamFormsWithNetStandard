using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mqtt;
using System.Text;
using MqttTest.Data.Model;
using Xamarin.Forms;

namespace MqttTest.Data.Services
{
    public class MqttDataServices
    {
        const string topic = "test/chat/message";
        const string host = "192.168.1.222";

        public void Connect()
        {
            try
            {
                var config = new MqttConfiguration { Port = 1883 };
                var client = MqttClient.CreateAsync(host, config).Result;
                var clientId = "XamarinClient";
                client.ConnectAsync(new MqttClientCredentials(clientId)).Wait();
                client.SubscribeAsync(topic, MqttQualityOfService.AtLeastOnce).Wait();
                client.MessageStream.Subscribe(message =>
                {
                    var data = Encoding.UTF8.GetString(message.Payload);
                    Debug.WriteLine($"Message Received; {data}");
                    var msg = new MqttMessage
                    {
                        Topic = message.Topic,
                        Payload = data
                    };
                    //MessagingCenter.Send<XamFormsSample.ViewModels.MainPageViewModel>(this, "Hi");
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine("_________________ Begin e _________________");
                Debug.WriteLine(e);
                Debug.WriteLine("_________________ End e _________________");
            }
        }
    }
}
