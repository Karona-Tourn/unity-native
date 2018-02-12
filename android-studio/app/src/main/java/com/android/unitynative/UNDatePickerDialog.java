package com.android.unitynative;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;

import java.util.Calendar;

public class UNDatePickerDialog extends UnityNativeBase {

    private DatePickerFragment datePickerFragment = null;

    public static class DatePickerFragment extends DialogFragment {

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

    public void close() {

        if (datePickerFragment == null) return;

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                datePickerFragment.dismiss();
                datePickerFragment = null;

            }
        });
    }

    private void showInternal(final DatePickerDialog.OnDateSetListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                datePickerFragment = new DatePickerFragment();
                datePickerFragment.setDateSetListener(listener);
                datePickerFragment.show(getCurrentActivity().getFragmentManager(), "date-picker");

            }
        });

    }

    private void showInternal(final int year, final int month, final int day, final DatePickerDialog.OnDateSetListener listener) {

        getCurrentActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {

                datePickerFragment = new DatePickerFragment();
                Bundle bundle = new Bundle();
                bundle.putInt("y", year);
                bundle.putInt("m", month);
                bundle.putInt("d", day);
                datePickerFragment.setArguments(bundle);
                datePickerFragment.setDateSetListener(listener);
                datePickerFragment.show(getCurrentActivity().getFragmentManager(), "date-picker");

            }
        });

    }

    static public void show(int year, int month, int day, DatePickerDialog.OnDateSetListener listener) {

        UNDatePickerDialog datePickerDialog = new UNDatePickerDialog();
        datePickerDialog.showInternal(year, month, day, listener);

    }

    static public void show(DatePickerDialog.OnDateSetListener listener) {

        UNDatePickerDialog datePickerDialog = new UNDatePickerDialog();
        datePickerDialog.showInternal(listener);

    }

}
