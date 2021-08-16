using MoodApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoodApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SadBtn_Clicked(object sender, EventArgs e)
        {
            ShowMessage(sender);
        }

        private void FrustratedBtn_Clicked(object sender, EventArgs e)
        {
            ShowMessage(sender);
        }

        private void BoredBtn_Clicked(object sender, EventArgs e)
        {
            ShowMessage(sender);
        }

        private void AngryBtn_Clicked(object sender, EventArgs e)
        {
            ShowMessage(sender);
        }

        private void HappyBtn_Clicked(object sender, EventArgs e)
        {
            ShowMessage(sender);
        }

        private async void ShowMessage(object sender)
        {
            var button = (Button)sender;
            string category = button.ClassId;
            Mood moodresult = ReturnMood(category);
            await DisplayAlert(moodresult.title, moodresult.message, "OK");

        }


        private Mood ReturnMood(string name)
        {
            string jsonFileName = "messages.json";
            MoodList moodList = new MoodList();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");

            using StreamReader reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();

            moodList = JsonConvert.DeserializeObject<MoodList>(jsonString);



            var result = moodList.moods.Where(m => m.mood.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if(result == null)
            {
                return new Mood
                {
                    title = "Be guidy", 
                    message = "life is good, though sometimes it does not look like it"
                };
            }

            Random random = new Random();

            int idx = random.Next(result.Count);
            
            if(idx == result.Count)
            {
                idx = result.Count - 1;
            }
            return result[idx];

        }

      
      
    }
}
