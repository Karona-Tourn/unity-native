package com.android.unitynative;

import android.app.Dialog;
import android.app.DialogFragment;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.text.format.DateFormat;

import java.util.Calendar;

/**
 * Class used for display a time picker dialog
 */
public class UNTimePickerDialog extends UnityNativeBase {

    /**
     * Time picker dialog fragment
     */
    public static class TimePickerDialogFragment extends DialogFragment {

        private TimePickerDialog.OnTimeSetListener listener = null;

        public void setTimeSetListener(TimePickerDialog.OnTimeSetListener listener) {
            this.listener = listener;
        }

        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {

            Bundle bundle = getArguments();

            int hour = 0;
            int minute = 0;

            if (bundle == null) {
                // Use the current time as the default values for the picker
                final Calendar c = Calendar.getInstance();
                hour = c.get(Calendar.HOUR_OF_DAY);
                minute = c.get(Calendar.MINUTE);
            } else {
                hour = bundle.getInt("h");
                minute = bundle.getInt("m");
            }

            // Create a new instance of TimePickerDialog and return it
            return new TimePickerDialog(getActivity(), listener, hour, minute,
                    DateFormat.is24HourFormat(getActivity()));

        }
    }

    private TimePickerDialogFragment dialogFragment = null;

    /**
     * Close time picker dialog
     */
    public void close() {

        if (dialogFragment == null) return;

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                dialogFragment.dismiss();
                dialogFragment = null;
            }
        });

    }

    /**
     * Show time picker dialog
     *
     * @param hour     predefined hour
     * @param minute   predefined minute
     * @param listener listener as callback when date is set
     */
    private void showInternal(final int hour, final int minute, final TimePickerDialog.OnTimeSetListener listener) {
        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                dialogFragment = new TimePickerDialogFragment();
                Bundle bundle = new Bundle();
                bundle.putInt("h", hour);
                bundle.putInt("m", minute);
                dialogFragment.setArguments(bundle);
                dialogFragment.setTimeSetListener(listener);
                dialogFragment.show(getCurrentActivity().getFragmentManager(), "time-picker");
            }
        });
    }

    /**
     * Show time picker dialog
     *
     * @param listener listener as callback when date is set
     */
    private void showInternal(final TimePickerDialog.OnTimeSetListener listener) {
        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                dialogFragment = new TimePickerDialogFragment();
                dialogFragment.setTimeSetListener(listener);
                dialogFragment.show(getCurrentActivity().getFragmentManager(), "time-picker");
            }
        });
    }

    /**
     * Show time picker dialog
     *
     * @param hour     predefined hour
     * @param minute   predefined minute
     * @param listener listener as callback when date is set
     * @return The instance object of this class
     */
    static public UNTimePickerDialog show(int hour, int minute, TimePickerDialog.OnTimeSetListener listener) {
        UNTimePickerDialog dialog = new UNTimePickerDialog();
        dialog.showInternal(hour, minute, listener);
        return dialog;
    }

    /**
     * Show time picker dialog
     *
     * @param listener listener as callback when date is set
     * @return The instance object of this class
     */
    static public UNTimePickerDialog show(TimePickerDialog.OnTimeSetListener listener) {
        UNTimePickerDialog dialog = new UNTimePickerDialog();
        dialog.showInternal(listener);
        return dialog;
    }

}
