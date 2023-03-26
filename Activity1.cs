using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Xamarin.Essentials.Platform;

namespace MyPassword
{
    [Activity(Label = "Activity1", MainLauncher = true)]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.layout1);
            Android.Content.Intent i = new Android.Content.Intent(this, typeof(MainActivity));
            EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            string nom = et1.Text;
            Button b1 = FindViewById<Button>(Resource.Id.button1);
            //b1.Click += delegate
            //{
               // i.PutExtra("Nom", et1.ToString());
               // i.PutExtra("Complexite", 8);
                //StartActivity(i);
            //};
            Button b2 = FindViewById<Button>(Resource.Id.button2);
            b2.Click += delegate
            {

                i.PutExtra("Nom", et1.Text.ToString());
                i.PutExtra("Complexite", 9);
                StartActivity(i);
            };
            Button b3 = FindViewById<Button>(Resource.Id.button3);
            //b3.Click += delegate
            //{
                
            //    i.PutExtra("Nom", et1.ToString());
             //   i.PutExtra("Complexite", 10);
              
             //   StartActivity(i);
            //};
            
        }


       
    }
}