package com.android.unitynative;

import android.app.Activity;

import com.unity3d.player.UnityPlayer;

public class UnityNativeBase {

    protected Activity getCurrentActivity(){

        return UnityPlayer.currentActivity;

    }

}
