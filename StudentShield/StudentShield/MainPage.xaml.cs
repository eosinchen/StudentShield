using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace StudentShield
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnbtnWarningClick(object sender, EventArgs args)
        {
            await DisplayAlert("Title", "嚇阻鈴聲", "是", "否");
        }

        async void OnbtnMessageClick(object sender, EventArgs args)
        {
            await DisplayAlert("Title", "訊息通報", "是", "否");
        }

        async void OnbtnTelephoneClick(object sender, EventArgs args)
        {
            // await DisplayAlert("Title", "電話通報", "是", "否");
            var call = CrossMessaging.Current.PhoneDialer;

            if (call.CanMakePhoneCall)
                call.MakePhoneCall("12345678");
        }

        async void OnbtnRecordClick(object sender, EventArgs args)
        {
            // await DisplayAlert("Title", "蒐證紀錄", "是", "否");
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                // PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                ImageSource.FromStream(() => { return photo.GetStream(); });
        }

    }
}
