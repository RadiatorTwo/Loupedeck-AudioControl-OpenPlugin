﻿namespace Loupedeck.AudioControlPlugin
{
    using System;

    using WindowsInterop.CoreAudio;

    public class AudioImageData : IActionImageData, IEquatable<AudioImageData>
    {
        public string Id { get; set; } = null;
        public DataFlow DataFlow { get; set; } = DataFlow.All;

        public bool NotFound { get; set; } = false;
        public string DisplayName { get; set; } = null;
        public string UnmutedIconPath { get; set; } = null;
        public string MutedIconPath { get; set; } = null;
        public bool Highlighted { get; set; } = false;
        public bool IsActive { get; set; } = false;

        public bool Muted { get; set; } = false;
        public float Volume { get; set; } = 0.0f;
        public float VolumeScalar { get; set; } = 0.0f;
        public float PeakL { get; set; } = 0.0f;
        public float PeakR { get; set; } = 0.0f;

        public bool IsCommunicationsDefault { get; set; } = false;
        public bool IsMultimediaDefault { get; set; } = false;

        public bool Equals(AudioImageData other)
        {
            bool equals = true;
            equals &= this.NotFound == other.NotFound;
            equals &= this.DisplayName == other.DisplayName;
            equals &= this.UnmutedIconPath == other.UnmutedIconPath;
            equals &= this.MutedIconPath == other.MutedIconPath;
            equals &= this.Highlighted == other.Highlighted;
            equals &= this.IsActive == other.IsActive;
            equals &= this.Muted == other.Muted;
            equals &= this.Volume == other.Volume;
            equals &= this.VolumeScalar == other.VolumeScalar;
            equals &= this.PeakL == other.PeakL;
            equals &= this.PeakR == other.PeakR;
            equals &= this.IsCommunicationsDefault == other.IsCommunicationsDefault;
            equals &= this.IsMultimediaDefault == other.IsMultimediaDefault;
            return equals;
        }

        public override int GetHashCode() => (this.NotFound, this.DisplayName, this.UnmutedIconPath, this.MutedIconPath, this.Highlighted, this.IsActive, this.Muted, this.Volume, this.VolumeScalar, this.PeakL, this.PeakR, this.IsCommunicationsDefault, this.IsMultimediaDefault).GetHashCode();

        public override bool Equals(object obj) => obj is AudioImageData other && this.Equals(other);

        bool IEquatable<IActionImageData>.Equals(IActionImageData other) => this.Equals(other);

        public static bool operator ==(AudioImageData left, AudioImageData right) => left.Equals(right);

        public static bool operator !=(AudioImageData left, AudioImageData right) => !left.Equals(right);
    }
}
