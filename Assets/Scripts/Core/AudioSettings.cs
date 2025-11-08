using UnityEngine;
using Game.Core;

public static class AudioSettings
{
    const string MUSIC_KEY = "audio_music";
    const string SFX_KEY = "audio_sfx";

    public static float Music
    {
        get => PlayerPrefs.GetFloat(MUSIC_KEY, 0.6f);
        set { PlayerPrefs.SetFloat(MUSIC_KEY, Mathf.Clamp01(value)); Apply(); }
    }
    public static float Sfx
    {
        get => PlayerPrefs.GetFloat(SFX_KEY, 1f);
        set { PlayerPrefs.SetFloat(SFX_KEY, Mathf.Clamp01(value)); Apply(); }
    }

    public static void Apply()
    {
        if (AudioBus.I)
        {
            if (AudioBus.I.music) AudioBus.I.music.volume = Music;
            if (AudioBus.I.sfx) AudioBus.I.sfx.volume = Sfx;
        }
    }
}
