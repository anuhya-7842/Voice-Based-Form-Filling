using System.Threading.Tasks;

namespace VoiceFormApp;

public interface ISpeechToTextService
{
    // Starts speech recognition and returns the recognized text
    Task<string> ListenAsync();

    // Stops the current speech recognition session
    void StopListening();
}