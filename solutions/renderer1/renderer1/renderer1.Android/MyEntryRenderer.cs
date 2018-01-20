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
using Xamarin.Forms.Platform.Android;

using renderer1;
using renderer1.Droid;

[ assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer)) ]

namespace renderer1.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetTextColor(global::Android.Graphics.Color.Blue);
                Control.SetBackgroundColor(global::Android.Graphics.Color.Yellow);
            }
        }
    }
}