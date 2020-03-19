using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharePlugin : MonoBehaviour
{
    public InputField shareScreenTitle;
    public InputField Message;


    public void ShareButtonClicked()
    {
        Share(Message.text, shareScreenTitle.text);
    }

    public void Share(string mgs, string title)
    {
        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.xcalliber.plugin.HelloWorld");

        var args = new object[3];
        args[0] = unityActivity;
        args[1] = mgs;
        args[2] = title;

        // Call PrintString in bridge, with our parameters.
        bridge.Call("Share3", args);

    }
}
