using UnityEngine;
using Game.Core;

public class MenuMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField, Range(0f, 1f)] private float volume = 0.6f;
    [SerializeField] private bool playOnStart = true;

    void Start()
    {
        if (playOnStart && AudioBus.I && music)
            AudioBus.I.PlayMusic(music, volume, true);
    }
}
