using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using MqttTest.Data.Model;

namespace MqttTest.Data.ViewModel
{
    public class MainViewModel //: ViewModelBase
    {
        public MainViewModel()
        {
            MqttMessages = new ObservableCollection<MqttMessage>();
            MqttMessages.Add(new MqttMessage {Topic = "topical", Payload = "payup"});
        }
           
        public ObservableCollection<MqttMessage> MqttMessages { get; }
    }
}
