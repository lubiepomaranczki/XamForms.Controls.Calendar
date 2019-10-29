## Calendar Control Plugin for Xamarin.Forms
A simple Calendar control for your Xamarin.Forms projects

This is a fork repository of [a nuget made by RebeccaXam](https://github.com/rebeccaXam/XamForms.Controls.Calendar/). 

#### Setup
* Available on NuGet: https://www.nuget.org/packages/XamForms.Enhanced.Calendar/  [![NuGet](https://img.shields.io/nuget/v/XamForms.Enhanced.Calendar.svg?label=NuGet)](https://www.nuget.org/packages/XamForms.Enhanced.Calendar/)
* Install into your PCL project and Client projects.

<p align="center">
  <img src="https://raw.githubusercontent.com/rebeccaXam/XamForms.Controls.Calendar/master/images/iOS.png" height="200"/>
  <img src="https://raw.githubusercontent.com/rebeccaXam/XamForms.Controls.Calendar/master/images/Android.png" height="200"/>
  <img src="https://raw.githubusercontent.com/rebeccaXam/XamForms.Controls.Calendar/master/images/BackgroundPatternDroid.png" height="200"/>
  <img src="https://raw.githubusercontent.com/rebeccaXam/XamForms.Controls.Calendar/master/images/BackgroundpatterniOS.png" height="200"/>
</p>

In your iOS, Android projects call:

```
Xamarin.Forms.Init();//platform specific init
XamForms.Controls.<PLATFORM>.Calendar.Init();
```

You must do this AFTER you call Xamarin.Forms.Init();

**IMPORTANT:** If you are having problems like: [When Changing Months, the days do not update properly](https://github.com/rebeccaXam/XamForms.Controls.Calendar/issues/2) in, try adding this to your projects AssemblyInfo.cs:
```
[assembly:Xamarin.Forms.Platform.<Platform>.ExportRenderer(typeof(XamForms.Controls.CalendarButton), typeof(XamForms.Controls.<Platform>.CalendarButtonRenderer))]
```

#### Usage
There is a playground project in the solution. Please take a look there.

#### Contributors
* [rebeccaXam](https://github.com/rebeccaXam)
* [lubiepomaranczki](https://github.com/lubiepomaranczki)

#### License
https://github.com/lubiepomaranczki/XamForms.Controls.Calendar/blob/develop/LICENSE