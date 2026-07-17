# Voice-Based Form Filling Using Voice Commands

A .NET MAUI application that enables users to fill a registration form using voice commands. The application uses Android's built-in Speech Recognition API to convert spoken commands into text and automatically populate the corresponding form fields, reducing manual typing and improving accessibility.

---

## Features

- Voice-based form filling
- Continuous speech recognition
- Automatic field detection using voice commands
- Supports partial form completion
- Manual editing of fields after voice input
- Start and Stop voice controls
- Confirmation dialog before final submission
- User-friendly interface
- Android Speech Recognition integration

---

## Voice Commands

The application recognizes commands in the following format:

| Voice Command | Action |
|---------------|--------|
| **Name Anuhya** | Fills the Name field |
| **Email anuhya@gmail.com** | Fills the Email field |
| **Phone Number 9876543210** | Fills the Phone Number field |
| **Gender Female** | Selects Female in the Gender dropdown |
| **Address Hyderabad Telangana** | Fills the Address field |
| **Stop** | Stops voice recognition |

---

## Workflow

1. Open the Registration Form.
2. Click **Start Voice**.
3. Speak commands such as:
   - Name Anuhya
   - Email anuhya@gmail.com
   - Phone Number 9876543210
   - Gender Female
   - Address Hyderabad
4. The application automatically fills the corresponding fields.
5. Users can manually edit any field if needed.
6. Click **Submit**.
7. Review the entered details.
8. Confirm the submission.

---

## Project Structure

```
VoiceFormApp
│
├── Platforms
│   ├── Android
│   │   ├── AndroidSpeechToTextService.cs
│   │   ├── MainActivity.cs
│   │   └── AndroidManifest.xml
│
├── Resources
│
├── MainPage.xaml
├── MainPage.xaml.cs
├── MauiProgram.cs
├── ISpeechToTextService.cs
├── App.xaml
├── AppShell.xaml
└── VoiceFormApp.csproj
```

---

## Technology Stack

- .NET MAUI
- C#
- XAML
- Android SpeechRecognizer API
- Microsoft Visual Studio 2022
- .NET 8
- Dependency Injection (Built-in .NET MAUI)
- Asynchronous Programming (Task-based)
- Android SDK

---

## Development Environment

- IDE: Microsoft Visual Studio 2022
- Framework: .NET MAUI (.NET 8)
- Platform: Android
- Language: C#
- UI Design: XAML
- Speech Recognition: Android SpeechRecognizer API

---

## Architecture

```
User
   │
   ▼
Start Voice
   │
   ▼
Android Speech Recognizer
   │
   ▼
Speech-to-Text Conversion
   │
   ▼
Voice Command Processing
   │
   ▼
Automatic Form Population
   │
   ▼
Review & Submit
```

---

## Key Components

### MainPage.xaml
- Builds the user interface.
- Contains the registration form.
- Provides Start Voice, Stop, and Submit buttons.

### MainPage.xaml.cs
- Handles voice commands.
- Maps recognized speech to the correct form field.
- Displays confirmation before submission.

### ISpeechToTextService.cs
- Defines the speech recognition interface.
- Declares methods for starting and stopping speech recognition.

### AndroidSpeechToTextService.cs
- Implements Android Speech Recognition.
- Converts spoken input into text.
- Returns recognized text asynchronously.

### MauiProgram.cs
- Registers services using Dependency Injection.
- Configures fonts and application startup.

---

## Advantages

- Reduces manual typing effort.
- Faster form completion.
- Improves accessibility.
- Hands-free interaction.
- Simple and intuitive user experience.
- Easily extendable to other forms.

---

## Future Enhancements

- Multilingual voice recognition.
- Offline speech recognition.
- AI-powered voice command understanding.
- Voice confirmation before submission.
- Support for dynamic forms.
- Integration with cloud speech services.
- Real-time partial speech recognition.

---

## Demo

A demo video showcasing the application workflow can be found in the repository or LinkedIn project section.
LinkedIn: https://www.linkedin.com/in/dhathri-anuhya-devarampati-a54946323/

---
