package com.android.unitynative;

import android.widget.Toast;

/**
 * Used to showing a toast message
 */
public class UNToast extends UnityNativeBase {

    private UNToast() {
    }

    /**
     * Alert a toast message
     *
     * @param message        message to be displayed in the toast
     * @param isLongDuration duration of toast lifetime
     */
    private void showInternal(final String message, final boolean isLongDuration) {
        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(getCurrentActivity().getApplicationContext(), message, isLongDuration ? Toast.LENGTH_LONG : Toast.LENGTH_SHORT).show();
            }
        });
    }

    /**
     * Alert a toast message
     *
     * @param message        message to be displayed in the toast
     * @param isLongDuration duration of toast lifetime
     */
    static public void show(String message, boolean isLongDuration) {
        new UNToast().showInternal(message, isLongDuration);
    }

}
