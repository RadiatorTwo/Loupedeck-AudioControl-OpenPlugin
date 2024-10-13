﻿namespace WindowsInterop
{
    public enum HRESULT : uint
    {
        S_OK = 0x00000000,
        S_FALSE = 0x00000001,
        AUDCLNT_E_DEVICE_INVALIDATED = 0x88890004,
        AUDCLNT_S_NO_SINGLE_PROCESS = 0x889000d,
        ERROR_NOT_FOUND = 0x80070490,
        ERROR_INSUFFICIENT_BUFFER = 0x0000007a,
        PROCESS_NO_AUDIO = 0x80070057
    }
}
