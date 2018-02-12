package com.android.unitynative;

import android.app.AlertDialog;
import android.content.DialogInterface;

import com.android.unitynative.Util.StringUtil;

/**
 * Class to be used for showing an Android alert dialog
 */
public class UNAlertDialog extends UnityNativeBase {

    private AlertDialog dialog = null;
    private boolean isClosed = false;

    private UNAlertDialog() {
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
     * Show an Android alert dialog
     *
     * @param title      displayed title of the dialog
     * @param message    displayed message of the dialog
     * @param button     button text of the dialog
     * @param gameObject name of unity game object receiving the callback
     * @param callback   method name of unity component of callback from the dialog
     */
    private void showInternal(final String title, final String message, final String button, final String gameObject, final String callback) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // 1. Instantiate an AlertDialog.Builder with its constructor
                AlertDialog.Builder builder = new AlertDialog.Builder(getCurrentActivity());

                // 2. Chain together various setter methods to set the dialog characteristics
                builder.setMessage(StringUtil.returnEmptyIfNull(message));

                if (!StringUtil.isNullOrEmpty(title)) {
                    builder.setTitle(title);
                }

                boolean hasGameObject = !StringUtil.isNullOrEmpty(gameObject);
                boolean hasCallback = !StringUtil.isNullOrEmpty(callback);

                if (button != null || (hasGameObject && hasCallback)) {
                    builder.setPositiveButton(StringUtil.isNullOrEmpty(button) ? "OK" : button, (hasGameObject && hasCallback) ? new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            if (StringUtil.isNullOrEmpty(gameObject) || StringUtil.isNullOrEmpty(callback)) {
                                return;
                            }
                            sendMessage(gameObject, callback, String.valueOf(which));
                        }
                    } : null);
                }

                // Prevent from showing the dialog again when it is already closed
                if (isClosed) return;

                // 3. Get the AlertDialog from create()
                dialog = builder.create();

                dialog.show();
            }
        });

    }

    private void showInternal(final String title, final String message, final String button, final DialogInterface.OnClickListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // 1. Instantiate an AlertDialog.Builder with its constructor
                AlertDialog.Builder builder = new AlertDialog.Builder(getCurrentActivity());

                // 2. Chain together various setter methods to set the dialog characteristics
                builder.setMessage(StringUtil.returnEmptyIfNull(message));

                if (!StringUtil.isNullOrEmpty(title)) {
                    builder.setTitle(title);
                }

                builder.setPositiveButton(StringUtil.isNullOrEmpty(button) ? "OK" : button, listener);

                // Prevent from showing the dialog again when it is already closed
                if (isClosed) return;

                // 3. Get the AlertDialog from create()
                dialog = builder.create();

                dialog.show();
            }
        });

    }

    /**
     * Show an Android alert dialog
     *
     * @param title      displayed title of the dialog
     * @param message    displayed message of the dialog
     * @param button     button text of the dialog
     * @param gameObject name of unity game object receiving the callback
     * @param callback   method name of unity component of callback from the dialog
     * @return instance of this alert dialog
     */
    static public UNAlertDialog show(String title, String message, String button, String gameObject, String callback) {

        UNAlertDialog dialog = new UNAlertDialog();

        dialog.showInternal(title, message, button, gameObject, callback);

        return dialog;

    }

    /**
     * Show an Android alert dialog
     *
     * @param title    displayed title of the dialog
     * @param message  displayed message of the dialog
     * @param button   button text of the dialog
     * @param listener listener to receive callback
     * @return instance of this alert dialog
     */
    static public UNAlertDialog show(String title, String message, String button, DialogInterface.OnClickListener listener) {

        UNAlertDialog dialog = new UNAlertDialog();

        dialog.showInternal(title, message, button, listener);

        return dialog;

    }
}
