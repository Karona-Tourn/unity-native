package com.android.unitynative;

import android.app.Activity;

import com.android.unitynative.Util.StringUtil;
import com.unity3d.player.UnityPlayer;

public class UnityNativeBase {

    protected Activity getCurrentActivity(){

        return UnityPlayer.currentActivity;

    }

    protected void sendMessage(String gameObject, String method, String value){

        if(StringUtil.isNullOrEmpty(gameObject) || StringUtil.isNullOrEmpty(method))
            return;

        UnityPlayer.UnitySendMessage(gameObject, method, value);

    }

}
