﻿namespace WindowsInterop.CoreAudio
{
    using System;
    using System.Runtime.InteropServices;
    using WindowsInterop.Win32;

    public class AudioPolicyConfig2 : IAudioPolicyConfig, IDisposable
    {
        private readonly IAudioPolicyConfig2 audioPolicyConfigInterface;

        public AudioPolicyConfig2()
        {
            IntPtr hString;
            string classId = "Windows.Media.Internal.AudioPolicyConfig";
            Guid iid = typeof(IAudioPolicyConfig2).GUID;

            // Create the HSTRING using the existing WindowsCreateString function.
            if (Combase.WindowsCreateString(classId, classId.Length, out hString) == HRESULT.S_OK)
            {
                try
                {
                    // Use the HSTRING (IntPtr) in the RoGetActivationFactory call.
                    if (Combase.RoGetActivationFactory(hString, ref iid, out IntPtr factoryPtr) == HRESULT.S_OK)
                    {
                        try
                        {
                            // Use Marshal.QueryInterface to explicitly get the IAudioPolicyConfig2 interface
                            Guid audioPolicyConfigIID = typeof(IAudioPolicyConfig2).GUID;
                            IntPtr audioPolicyConfigPtr;

                            // QueryInterface using Marshal.QueryInterface
                            int result = Marshal.QueryInterface(factoryPtr, ref audioPolicyConfigIID, out audioPolicyConfigPtr);

                            if (result == 0) // S_OK == 0
                            {
                                this.audioPolicyConfigInterface = Marshal.GetObjectForIUnknown(audioPolicyConfigPtr) as IAudioPolicyConfig2;

                                // Release the queried interface after use
                                Marshal.Release(audioPolicyConfigPtr);
                            }
                            else
                            {
                                // Handle case where QueryInterface fails
                                throw new InvalidOperationException("Failed to query IAudioPolicyConfig2 interface.");
                            }
                        }
                        finally
                        {
                            // Release the COM object
                            Marshal.Release(factoryPtr);
                        }
                    }
                }
                finally
                {
                    // Clean up the HSTRING using WindowsDeleteString.
                    Combase.WindowsDeleteString(hString);
                }
            }
        }

        public bool SetPersistedDefaultAudioEndpoint(int processId, DataFlow flow, Role role, IntPtr deviceId)
        {
            return this.audioPolicyConfigInterface.SetPersistedDefaultAudioEndpoint(processId, flow, role, deviceId) == HRESULT.S_OK;
        }

        public bool GetPersistedDefaultAudioEndpoint(int processId, DataFlow flow, Role role, out string deviceId)
        {
            return this.audioPolicyConfigInterface.GetPersistedDefaultAudioEndpoint(processId, flow, role, out deviceId) == HRESULT.S_OK;
        }

        public bool ClearAllPersistedApplicationDefaultEndpoints()
        {
            return this.audioPolicyConfigInterface.ClearAllPersistedApplicationDefaultEndpoints() == HRESULT.S_OK;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (this.audioPolicyConfigInterface != null)
            {
                Marshal.ReleaseComObject(this.audioPolicyConfigInterface);
            }
        }

        ~AudioPolicyConfig2()
        {
            this.Dispose();
        }
    }
}
