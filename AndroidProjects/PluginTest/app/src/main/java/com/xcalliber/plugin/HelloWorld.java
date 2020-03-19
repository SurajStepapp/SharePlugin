package com.xcalliber.plugin;

import android.app.Application;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Handler;
import android.widget.Toast;
import android.util.Log;
import android.os.Looper; //extend android application.

import static android.content.ContentValues.TAG;

public class HelloWorld extends Application {
    // our native method, which will be called from Unity3D
    public void PrintString( final Context ctx, final String message )
    {
        Log.i(TAG, "PrintString:hiiiiii ");
        //create / show an android toast, with message and short duration.
        new Handler(Looper.getMainLooper()).post(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(ctx, message, Toast.LENGTH_SHORT).show();
            }
        });
    }

    public String str = "";
    public void hello()
    {
        Log.i(TAG, "hello:oooooooo ");
        str = "hiiiiiiiii";
    }

    public void Share(Context context) {
        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.putExtra(Intent.EXTRA_TEXT, "This is my text to send.");
        intent.setType("text/plain");
        Log.i(TAG, "Share:shareeeee");
        context.startActivity(intent);
    }

    public void Share2(Context context)
    {
        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.putExtra(Intent.EXTRA_TEXT, "This is my text to send.");
        intent.setType("text/plain");
        Log.i(TAG, "Share2:Readyyyyyyy ");
        PendingIntent pendingIntent = PendingIntent.getActivity(context, 1, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        try {
            // Perform the operation associated with our pendingIntent
            Log.i(TAG, "Share2:sendddddddd ");
            pendingIntent.send();
        } catch (PendingIntent.CanceledException e) {
            Log.i(TAG, "Share2:failllllllllll ");
            e.printStackTrace();
        }
    }

    public void Share3(Context context, String mgs, String title)
    {
        Intent receiver = new Intent(context, MyReceiver.class);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(context, 0, receiver, PendingIntent.FLAG_UPDATE_CURRENT);

        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.putExtra(Intent.EXTRA_TEXT, mgs);
        intent.setType("text/plain");

        context.startActivity(Intent.createChooser(intent
                , title
                , pendingIntent.getIntentSender()));


    }
}
