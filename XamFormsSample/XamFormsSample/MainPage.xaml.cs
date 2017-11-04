using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttTest.Data.Services;
using Xamarin.Forms;

namespace XamFormsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MqttDataServices dataServices = new MqttDataServices();
            dataServices.Connect();
        }
    }
}
