using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour
{
    

    //method that calls our native plugin.
    public void CallNativePlugin()
    {
        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.xcalliber.plugin.HelloWorld");

        // Setup the parameters we want to send to our native plugin.              
        object[] parameters = new object[2];
        parameters[0] = unityActivity;
        parameters[1] = "This is an call to native android!";

        // Call PrintString in bridge, with our parameters.
        bridge.Call("PrintString", parameters);
    }

    public void SayHello()
    {
        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.xcalliber.plugin.HelloWorld");

        // Call PrintString in bridge, with our parameters.
        bridge.Call("hello");

        Debug.Log(bridge.Get<string>("str"));
    }

    public void Share()
    {
        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.xcalliber.plugin.HelloWorld");

        var args = new object[1];
        args[0] = unityActivity;

        // Call PrintString in bridge, with our parameters.
        bridge.Call("Share3",args);

    }


}
