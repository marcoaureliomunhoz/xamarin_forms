using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

using clipb1.Services;
using clipb1.Droid.Services;

[assembly: Dependency(typeof(ClipboardService_Droid))]

namespace clipb1.Droid.Services
{
    public class ClipboardService_Droid : IClipboardService
    {
        public void SetText(string text)
        {
            var clipboardManager = (ClipboardManager)Android.App.Application.Context.GetSystemService(Context.ClipboardService);

            ClipData clipData = ClipData.NewPlainText("title", text);

            clipboardManager.PrimaryClip = clipData;
        }
    }
}