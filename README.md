# jhalbrecht fork
This is a fork of Oren Novotny sample .net Standard Xamarin forms sample. Read his article and git the sample. His sample; _Works on my machine_ 

I've added MqttTest.Data from the Xamarin hermes project and a .net standard console app using that data to subscibe a client to an mqtt server.

* The console app works. It connects, subscribes and displays data from a test topic
* The Xamarin.Forms throws errors.

I modified the XamFormsSample to consume the MqttTest.Data

This is currently to demonstrate errors encountered attempting to use Xamarin hermes mqtt in a Xamarin.Forms project.

## Msbuild
I used the following commands to build the solution. Afterwards I was able to debug out of visual studio in both the Androi and UWP apps! Much joy! I wonder if there is a way to successfully do the builds from vs? So much to learn, so little time ehh? :-)
* msbuild /t:restore XamFormsSample.sln
* msbuild /t:build /p:Configuration=Release XamFormsSample.sln


# Oren Novotny original README.md
This is a sample solution showing how to use Xamarin Forms with .NET Standard class libraries. Full blog post explaining this repo here: https://oren.codes/2017/04/23/using-xamarin-forms-with-net-standard-vs-2017-edition/
