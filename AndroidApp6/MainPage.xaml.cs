using Plugin.LocalNotification;

namespace AndroidApp6
{
    public partial class MainPage : ContentPage
    {
        List<task> tasks = new List<task>();

        public MainPage()
        {
            InitializeComponent();
            ViewReload();
            PickerReload();
        }

        public void Addbt(object sender, EventArgs e)
        {
            try
            {
                tasks = App.Db.GetAll();
                string[] date = TaskDate.Text.Split('.');
                DateTime notifytime = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), Convert.ToInt32(date[5]));

                if (tasks.Count > 0)
                {
                    App.Db.Save(new task { id = 1 + tasks[tasks.Count - 1].id, name = TaskName.Text, description = TaskText.Text, time = notifytime.ToString() });
                }
                else
                {
                    App.Db.Save(new task { id = 1, name = TaskName.Text, description = TaskText.Text, time = notifytime.ToString() });
                }
                ViewReload();
                PickerReload();

                var request = new NotificationRequest
                {
                    NotificationId = tasks.Count,
                    Title = TaskName.Text,
                    Description = TaskText.Text,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = notifytime,
                        NotifyRepeatInterval = TimeSpan.FromDays(1)
                    }
                };
                LocalNotificationCenter.Current.Show(request);
                TaskName.Text = "";
                TaskText.Text = "";
                TaskDate.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message.ToString(), "ОK");
            }
        }

        public void Deletebt(object sender, EventArgs e)
        {
            try
            {
                App.Db.DeleteById(Convert.ToInt32(TaskPicker.SelectedItem.ToString()));
                ViewReload();
                PickerReload();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message.ToString(), "ОK");
            }
        }

        public void ViewReload()
        {
            tasks = App.Db.GetAll();
            tasklist.ItemsSource = tasks;
        }

        public void PickerReload()
        {
            int[] ids = new int[tasks.Count];
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = tasks[i].id;
            }
            TaskPicker.ItemsSource = ids;
        }
    }
}