package com.android.unitynative;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.text.TextUtils;
import android.util.Log;

import java.util.Date;

public class UNRatingDialog extends UnityNativeBase {

    public interface ConditionTrigger {
        boolean canShow();
    }

    private static final String PREF_NAME = "pref-rating";
    private static final String KEY_NEVER_RATE = "never-rate";
    private static final String KEY_RATED = "rated";
    private static final String KEY_TRY_TIMES = "try-times";
    private static final String KEY_FIRST_DATE = "first-date";

    private SharedPreferences preferences = null;
    private CharSequence packageName = "";
    private CharSequence title = "";
    private CharSequence message = "";
    private ConditionTrigger condition = null;
    private int maxTryTimes = 0;

    public UNRatingDialog(String packageName, int maxTryTimes) {
        this.packageName = packageName;
        this.maxTryTimes = maxTryTimes;
        preferences = getCurrentActivity().getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);
    }

    public void setConditionTrigger(ConditionTrigger condition) {
        this.condition = condition;
    }

    public void reset() {
        preferences.edit()
                .putBoolean(KEY_NEVER_RATE, false)
                .putBoolean(KEY_RATED, false)
                .putInt(KEY_TRY_TIMES, 1)
                .putLong(KEY_FIRST_DATE, new Date().getTime())
                .apply();
    }

    /**
     * Rate now
     */
    private void rateNow() {
        Intent intent = new Intent(Intent.ACTION_VIEW);
        intent.setData(Uri.parse("market://details?id=" + packageName));
        getCurrentActivity().startActivity(intent);
        preferences.edit().putBoolean(KEY_RATED, true).apply();
    }

    private void neverRate() {
        preferences.edit().putBoolean(KEY_NEVER_RATE, true).apply();
    }

    private void rateLater() {
        preferences.edit()
                .putInt(KEY_TRY_TIMES, 1)
                .putLong(KEY_FIRST_DATE, new Date().getTime())
                .apply();
    }

    private boolean canShow() {
        if (preferences.getBoolean(KEY_RATED, false)) return false;
        if (preferences.getBoolean(KEY_NEVER_RATE, false)) return false;

        int tryTimes = preferences.getInt(KEY_TRY_TIMES, 1);
        if (tryTimes > maxTryTimes) return true;
        else preferences.edit().putInt(KEY_TRY_TIMES, tryTimes + 1).apply();

        long firstDate = preferences.getLong(KEY_FIRST_DATE, new Date().getTime());
        if ((new Date().getTime() - firstDate) > (1000 * 60 * 60 * 24)) return true;

        return false;
    }

    public void setTitle(CharSequence title) {
        this.title = title;
    }

    public void setMessage(CharSequence message) {
        this.message = message;
    }

    public void showIfNeeded() {
        if (condition != null) {
            if (condition.canShow()) show();
        } else {
            if (canShow()) show();
        }
    }

    public void show() {

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
                        neverRate();
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
