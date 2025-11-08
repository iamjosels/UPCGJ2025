using UnityEngine;

namespace Game.Core
{
    public class AudioBus : MonoBehaviour
    {
        public static AudioBus I { get; private set; }

        [Header("Mixers")]
        public AudioSource music;
        public AudioSource sfx;

        private void Awake()
        {
            if (I != null) { Destroy(gameObject); return; }
            I = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlayMusic(AudioClip clip, float volume = 0.6f, bool loop = true)
        {
            if (!music || !clip) return;
            music.loop = loop;
            music.volume = volume;
            music.clip = clip;
            music.Play();
        }

        public void PlaySfx(AudioClip clip, float volume = 1f)
        {
            if (!sfx || !clip) return;
            sfx.PlayOneShot(clip, volume);
        }
    }
}
