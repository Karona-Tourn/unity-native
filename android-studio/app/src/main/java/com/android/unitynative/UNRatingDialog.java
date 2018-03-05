package com.android.unitynative;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.text.TextUtils;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

import java.util.Date;

public class UNRatingDialog extends UnityNativeBase {

    private static final String PREF_NAME = "rating";
    private static final String PREF_DENIED_RATE = "denied-rate";
    private static final String PREF_ALREADY_RATED = "already-rated";

    private SharedPreferences preferences = null;
    private CharSequence packageName = "";
    private CharSequence title = "";
    private CharSequence message = "";

    public UNRatingDialog (String packageName) {
        this.packageName = packageName;
        preferences = getCurrentActivity().getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);
    }

    /**
     * Rate now
     */
    private void rateNow() {
        Log.d("DEBUG", getCurrentActivity().getPackageName());
//        Intent intent = new Intent(Intent.ACTION_VIEW);
//        intent.setData(Uri.parse("market://details?id=" + packageName));
//        getCurrentActivity().startActivity(intent);
    }

    private void denyRate() {
        SharedPreferences.Editor editor = getCurrentActivity().getPreferences(Context.MODE_PRIVATE).edit();
        editor.putBoolean(PREF_DENIED_RATE, true);
        editor.commit();
    }

    private void rateLater() {

    }

    public boolean canShowNow() {
        if (preferences.getBoolean(PREF_ALREADY_RATED, false)) {
            return false;
        }

        if (preferences.getBoolean(PREF_DENIED_RATE, false)) {
            return false;
        }

        return false;
    }

    public void setTitle(CharSequence title) {
        this.title= title;
    }

    public void setMessage(CharSequence message) {
        this.message = message;
    }

    private void show() {

        if (TextUtils.isEmpty(packageName)) {
            Log.e("ERROR", "Package name cannot be empty.");
            return;
        }

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                AlertDialog.Builder builder = new AlertDialog.Builder(getCurrentActivity().getApplicationContext());
                builder.setTitle(title);
                builder.setMessage(message);
                builder.setPositiveButton("RATE NOW", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        rateNow();
                    }
                });
                builder.setNegativeButton("NO, THANKS", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        denyRate();
                    }
                });
                builder.setNeutralButton("LATER", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        rateLater();
                    }
                });
                builder.show();
            }
        });

    }

}
