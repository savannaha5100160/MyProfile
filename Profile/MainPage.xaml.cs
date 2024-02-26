using System;
using System.IO;
using System.Text.Json;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
namespace Profile
{
    public partial class MainPage : ContentPage
    {
        private const string ProfileFileName = "profile.json";

        public MainPage()
        {
            InitializeComponent();
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (File.Exists(ProfileFileName))
            {
                var json = File.ReadAllText(ProfileFileName);
                var profile = JsonSerializer.Deserialize<Profile>(json);
                NameEntry.Text = profile.Name;
                SurnameEntry.Text = profile.Surname;
                EmailEntry.Text = profile.Email;
                BioEditor.Text = profile.Bio;
            }
        }
        private void OnSaveClicked(object sender, EventArgs e)
        {
            var profile = new Profile
            {
                Name = NameEntry.Text,
                Surname = SurnameEntry.Text,
                Email = EmailEntry.Text,
                Bio = BioEditor.Text
            };

            var json = JsonSerializer.Serialize(profile);

            
            var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(localFolder, ProfileFileName);

            File.WriteAllText(filePath, json);
        }
    }
    
    public class Profile
    {
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
    }
}























































        
    


