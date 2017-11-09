using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using MqttTest.Data.Model;
using MqttTest.Data.Services;
using Xamarin.Forms;

namespace XamFormsSample.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            //MessagingCenter.Subscribe<MqttDataServices, string>(this, "Hi", (sender, arg) => {
            //    // do something whenever the "Hi" message is sent
            //    // using the 'arg' parameter which is a string
            //});

            Messenger.Default.Register<MqttMessage>(this, HandleMqttMessage);
        }
        public string Another { get; set; } = "This is from the Main Page View Model";

        public ObservableCollection<MqttMessage> MqttMessages { get; set; } = new ObservableCollection<MqttMessage>();
        private void HandleMqttMessage(MqttMessage obj)
        {
            if (!obj.Payload.Contains("exit"))
            {
                Debug.WriteLine($"In MainPageViewModel HandleMqttMessage, Topic {obj.Topic}, Payload {obj.Payload}");
                Device.BeginInvokeOnMainThread(() =>
                {
                    MqttMessages.Add(obj);
                });
            }
        }
    }
}
