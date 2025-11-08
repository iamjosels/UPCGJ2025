using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class OptionsPanel : MonoBehaviour
    {
        [SerializeField] Slider music;
        [SerializeField] Slider sfx;
        [SerializeField] Toggle fullscreen;

        void OnEnable()
        {
            // Cargar estados
            if (music) music.value = AudioSettings.Music;
            if (sfx) sfx.value = AudioSettings.Sfx;
            if (fullscreen) fullscreen.isOn = Screen.fullScreen;
            AudioSettings.Apply();
        }

        public void OnMusicChanged(float v) { AudioSettings.Music = v; }
        public void OnSfxChanged(float v) { AudioSettings.Sfx = v; }
        public void OnFullscreen(bool f) { Screen.fullScreen = f; }
    }
}
