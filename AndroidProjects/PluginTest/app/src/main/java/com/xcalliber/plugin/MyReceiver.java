package com.xcalliber.plugin;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

import static android.content.ContentValues.TAG;

public class MyReceiver extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        //super.onReceive(context, intent);
        // do something here
        Log.i(TAG, "onReceive:whatsapppppppppppppp");
    }
}
