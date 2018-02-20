package com.android.unitynative;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;

import java.util.Calendar;

public class UNDatePickerDialog extends UnityNativeBase {

    /**
     * Date picker dialog fragment
     */
    public static class DatePickerDialogFragment extends DialogFragment {

        private DatePickerDialog.OnDateSetListener listener = null;

        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            Bundle bundle = getArguments();
            int year = 0;
            int month = 0;
            int day = 0;

            if (bundle == null) {
                Calendar calendar = Calendar.getInstance();
                year = calendar.get(Calendar.YEAR);
                month = calendar.get(Calendar.MONTH);
                day = calendar.get(Calendar.DAY_OF_MONTH);
            } else {
                year = bundle.getInt("y");
                month = bundle.getInt("m");
                day = bundle.getInt("d");
            }

            DatePickerDialog datePickerDialog = new DatePickerDialog(getActivity(), listener, year, month, day);
            return datePickerDialog;
        }

        public void setDateSetListener(DatePickerDialog.OnDateSetListener listener) {
            this.listener = listener;
        }
    }

    private DatePickerDialogFragment dialogFragment = null;

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

    private void showInternal(final DatePickerDialog.OnDateSetListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                dialogFragment = new DatePickerDialogFragment();
                dialogFragment.setDateSetListener(listener);
                dialogFragment.show(getCurrentActivity().getFragmentManager(), "date-picker");

            }
        });

    }

    private void showInternal(final int year, final int month, final int day, final DatePickerDialog.OnDateSetListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                dialogFragment = new DatePickerDialogFragment();
                Bundle bundle = new Bundle();
                bundle.putInt("y", year);
                bundle.putInt("m", month);
                bundle.putInt("d", day);
                dialogFragment.setArguments(bundle);
                dialogFragment.setDateSetListener(listener);
                dialogFragment.show(getCurrentActivity().getFragmentManager(), "date-picker");

            }
        });

    }

    static public UNDatePickerDialog show(int year, int month, int day, DatePickerDialog.OnDateSetListener listener) {

        UNDatePickerDialog datePickerDialog = new UNDatePickerDialog();
        datePickerDialog.showInternal(year, month, day, listener);
        return  datePickerDialog;

    }

    static public UNDatePickerDialog show(DatePickerDialog.OnDateSetListener listener) {

        UNDatePickerDialog datePickerDialog = new UNDatePickerDialog();
        datePickerDialog.showInternal(listener);
        return  datePickerDialog;

    }

}
