using Android.App;
using Android.Widget;
using Android.OS;
using System;
using WRC.App.Message;

namespace App.Message
{
    [Activity(Label = "Notificação", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button buttonAdd;
        public int IdNotify = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            BindComponents();
        }

        private void BindComponents()
        {
            buttonAdd = FindViewById<Button>(Resource.Id.ButtonAddMessage);
            buttonAdd.Text = GetString(Resource.String.app_Button_Add);
            buttonAdd.Click += ButtonAddMessage_Click;
        }

        private void ButtonAddMessage_Click(object sender, EventArgs e)
        {
            var text = FindViewById<EditText>(Resource.Id.editText1).Text;
            StartNotification(text);
        }

        public void StartNotification(String mensagem)
        {           
                var notificationManager = this.GetSystemService(NotificationService) as NotificationManager;

                var builder = new Notification.Builder(Application.Context)
                    .SetCategory(Notification.CategorySystem)
                    .SetContentTitle(GetString(Resource.String.app_name))
                    .SetContentText(mensagem)
                    .SetDefaults(NotificationDefaults.Sound);
                    //.SetSmallIcon(Resource.Drawable.icon);

                var notification = builder.Build();
                notification.Flags = NotificationFlags.AutoCancel;
                notification.Flags = NotificationFlags.ShowLights;
                notification.Flags = NotificationFlags.OngoingEvent;
                notificationManager?.Notify(IdNotify++, notification);
        }
    }
}