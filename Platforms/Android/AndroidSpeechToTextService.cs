using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;

namespace VoiceFormApp.Platforms.Android;

public class AndroidSpeechToTextService : Java.Lang.Object,
    ISpeechToTextService,
    IRecognitionListener
{
    private SpeechRecognizer? _speechRecognizer;
    private Intent? _speechIntent;
    private TaskCompletionSource<string>? _taskCompletionSource;

    public Task<string> ListenAsync()
    {
        _taskCompletionSource = new TaskCompletionSource<string>();

        var context = Microsoft.Maui.ApplicationModel.Platform.AppContext;

        if (!SpeechRecognizer.IsRecognitionAvailable(context))
        {
            _taskCompletionSource.SetException(
                new Exception("Speech Recognition is not available on this device."));
            return _taskCompletionSource.Task;
        }

        _speechRecognizer = SpeechRecognizer.CreateSpeechRecognizer(context);
        _speechRecognizer.SetRecognitionListener(this);

        _speechIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);

        _speechIntent.PutExtra(
            RecognizerIntent.ExtraLanguageModel,
            RecognizerIntent.LanguageModelFreeForm);

        _speechIntent.PutExtra(
            RecognizerIntent.ExtraLanguage,
            Java.Util.Locale.Default);

        _speechIntent.PutExtra(
            RecognizerIntent.ExtraPrompt,
            "Speak now...");

        _speechRecognizer.StartListening(_speechIntent);

        return _taskCompletionSource.Task;
    }

    public void StopListening()
    {
        if (_speechRecognizer != null)
        {
            _speechRecognizer.StopListening();
            _speechRecognizer.Cancel();
            _speechRecognizer.Destroy();
            _speechRecognizer.Dispose();
            _speechRecognizer = null;
        }
    }

    public void OnResults(Bundle? results)
    {
        var matches = results?.GetStringArrayList(
            SpeechRecognizer.ResultsRecognition);

        if (matches != null && matches.Count > 0)
        {
            _taskCompletionSource?.TrySetResult(matches[0]);
        }
        else
        {
            _taskCompletionSource?.TrySetResult(string.Empty);
        }

        StopListening();
    }

    public void OnError([GeneratedEnum] SpeechRecognizerError error)
    {
        _taskCompletionSource?.TrySetResult(string.Empty);

        StopListening();
    }

    public void OnReadyForSpeech(Bundle? @params)
    {
    }

    public void OnBeginningOfSpeech()
    {
    }

    public void OnRmsChanged(float rmsdB)
    {
    }

    public void OnBufferReceived(byte[]? buffer)
    {
    }

    public void OnEndOfSpeech()
    {
    }

    public void OnPartialResults(Bundle? partialResults)
    {
    }

    public void OnEvent(int eventType, Bundle? @params)
    {
    }
}