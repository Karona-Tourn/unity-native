package com.android.unitynative.Util;

public class StringUtil {

    static public boolean isNullOrEmpty(String value){
        return value == null || value.isEmpty();
    }

    static public String returnEmptyIfNull(String value) { return value == null ? "" : value; }

}
