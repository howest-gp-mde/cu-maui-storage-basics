using AVFoundation;
using ObjCRuntime;
using UIKit;

namespace Mde.Storage.StorageBasics
{
    public class Program
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));

            // On iOS, the MediaElement's playback audio is muted by default when the user has toggled the Hardware Silent Switch to off.
            // This code bypasses the iOS Silent Watch for Maui Community Toolkit MediaElement
            // see docs: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement
            AVAudioSession.SharedInstance().SetActive(true);
            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);

        }
    }
}
