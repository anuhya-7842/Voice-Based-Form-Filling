using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Microsoft.Maui.ApplicationModel;
namespace VoiceFormApp;

public partial class MainPage : ContentPage
{
    private readonly ISpeechToTextService _speechService;
    private bool _isListening;

    public MainPage(ISpeechToTextService speechService)
    {
        InitializeComponent();
        _speechService = speechService;
    }

    private async void OnStartVoiceClicked(object sender, EventArgs e)
    {
        if (_isListening)
            return;

        _isListening = true;

        StatusLabel.Text = "Listening...";

        while (_isListening)
        {
            try
            {
                string speech = await _speechService.ListenAsync();

                if (!_isListening)
                    break;

                if (!string.IsNullOrWhiteSpace(speech))
                {
                    await ProcessVoiceCommand(speech);
                }
            }
            catch
            {
                // Ignore recognition errors and continue listening
            }

            await Task.Delay(300);
        }

        StatusLabel.Text = "Voice Assistant Stopped";
    }


    private async Task ProcessVoiceCommand(string speech)
    {
        speech = speech.Trim();

        StatusLabel.Text = "Recognized: " + speech;

        string lower = speech.ToLower();

        if (lower.StartsWith("name "))
        {
            NameEntry.Text = speech.Substring(5).Trim();
            return;
        }

        if (lower.StartsWith("email "))
        {
            EmailEntry.Text = speech.Substring(6).Trim();
            return;
        }

        if (lower.StartsWith("phone number "))
        {
            PhoneEntry.Text = speech.Substring(13).Trim();
            return;
        }

        if (lower.StartsWith("phone "))
        {
            PhoneEntry.Text = speech.Substring(6).Trim();
            return;
        }

        if (lower.StartsWith("gender "))
        {
            string gender = speech.Substring(7).Trim().ToLower();

            if (gender.Contains("female"))
                GenderPicker.SelectedIndex = 1;
            else if (gender.Contains("male"))
                GenderPicker.SelectedIndex = 0;
            else
                GenderPicker.SelectedIndex = 2;

            return;
        }

        if (lower.StartsWith("address "))
        {
            AddressEditor.Text = speech.Substring(8).Trim();
            return;
        }

        if (lower == "submit")
        {
            OnSubmitClicked(this, EventArgs.Empty);
            return;
        }

        if (lower == "stop")
        {
            OnStopVoiceClicked(this, EventArgs.Empty);
            return;
        }
    }

    private void OnStopVoiceClicked(object sender, EventArgs e)
    {
        _isListening = false;

        _speechService.StopListening();

        StatusLabel.Text = "Voice Assistant Stopped";
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        string name = string.IsNullOrWhiteSpace(NameEntry.Text)
            ? "Not Provided"
            : NameEntry.Text;

        string email = string.IsNullOrWhiteSpace(EmailEntry.Text)
            ? "Not Provided"
            : EmailEntry.Text;

        string phone = string.IsNullOrWhiteSpace(PhoneEntry.Text)
            ? "Not Provided"
            : PhoneEntry.Text;

        string gender = GenderPicker.SelectedItem == null
            ? "Not Selected"
            : GenderPicker.SelectedItem.ToString()!;

        string address = string.IsNullOrWhiteSpace(AddressEditor.Text)
            ? "Not Provided"
            : AddressEditor.Text;

        bool confirm = await DisplayAlertAsync(
            "Confirm Submission",
            $"Please check your details before submitting.\n\n" +
            $"Name : {name}\n\n" +
            $"Email : {email}\n\n" +
            $"Phone : {phone}\n\n" +
            $"Gender : {gender}\n\n" +
            $"Address : {address}\n\n" +
            "Do you want to submit?",
            "Yes",
            "No");

        if (!confirm)
            return;

        await DisplayAlertAsync(
            "Success",
            "Registration Submitted Successfully.",
            "OK");
    }
}