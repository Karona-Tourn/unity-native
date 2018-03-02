package com.android.unitynative;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.text.TextUtils;

/**
 * Class for showing confirm dialog
 */
public class UNConfirmDialog extends UnityNativeBase {

    private AlertDialog dialog = null;
    private boolean isClosed = false;

    private UNConfirmDialog() {
    }

    /**
     * Used to close this dialog
     */
    public void close() {

        if (isClosed) return;

        if (dialog != null) dialog.dismiss();

        isClosed = true;
    }

    /**
     * Show a confirm dialog
     *
     * @param title          displayed title of the dialog
     * @param message        displayed message of the dialog
     * @param positiveButton positive button text of the dialog
     * @param negativeButton negative button text of the dialog
     * @param neutralButton  neutral button text of the dialog
     * @param listener       listener to receive callback
     */
    private void showInternal(final String title, final String message, final String positiveButton, final String negativeButton, final String neutralButton, final DialogInterface.OnClickListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // 1. Instantiate an AlertDialog.Builder with its constructor
                AlertDialog.Builder builder = new AlertDialog.Builder(getCurrentActivity());

                // 2. Chain together various setter methods to set the dialog characteristics
                builder.setMessage(message);

                if (!TextUtils.isEmpty(title)) {
                    builder.setTitle(title);
                }

                builder.setPositiveButton(TextUtils.isEmpty(positiveButton) ? "YES" : positiveButton, listener);
                builder.setNegativeButton(TextUtils.isEmpty(negativeButton) ? "NO" : negativeButton, listener);

                if (!TextUtils.isEmpty(neutralButton)) {
                    builder.setNeutralButton(neutralButton, listener);
                }

                // Prevent from showing the dialog again when it is already closed
                if (isClosed) return;

                // 3. Get the AlertDialog from create()
                dialog = builder.create();

                dialog.show();
            }
        });

    }

    /**
     * Show a confirm dialog
     *
     * @param title          displayed title of the dialog
     * @param message        displayed message of the dialog
     * @param positiveButton positive button text of the dialog
     * @param negativeButton negative button text of the dialog
     * @param listener       listener to receive callback
     * @return instance of this confirm dialog
     */
    static public UNConfirmDialog show(String title, String message, String positiveButton, String negativeButton, DialogInterface.OnClickListener listener) {

        return show(title, message, positiveButton, negativeButton, null, listener);

    }

    /**
     * Show a confirm dialog
     *
     * @param title          displayed title of the dialog
     * @param message        displayed message of the dialog
     * @param positiveButton positive button text of the dialog
     * @param negativeButton negative button text of the dialog
     * @param neutralButton  neutral button text of the dialog
     * @param listener       listener to receive callback
     * @return instance of this confirm dialog
     */
    static public UNConfirmDialog show(String title, String message, String positiveButton, String negativeButton, String neutralButton, DialogInterface.OnClickListener listener) {

        UNConfirmDialog dialog = new UNConfirmDialog();

        dialog.showInternal(title, message, positiveButton, negativeButton, neutralButton, listener);

        return dialog;

    }

}
