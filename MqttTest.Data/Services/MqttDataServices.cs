using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mqtt;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using MqttTest.Data.Model;
using Xamarin.Forms;

namespace MqttTest.Data.Services
{
    public class MqttDataServices
    {
        //  mosquitto_pub -h test.mosquitto.org -t test/xamarin/hermes/mqtt/chat/message -m "howdy from mosquitto_pub"
        //  mosquitto_sub -h test.mosquitto.org -t "test/xamarin/hermes/mqtt/chat/message"
        const string topic = "test/xamarin/hermes/mqtt/chat/message";
        const string host = "test.mosquitto.org";

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

                    // TODO get nuget fixed....
                    Messenger.Default.Send<MqttMessage>(msg);
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
