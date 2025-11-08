using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Game.Utils;

namespace Game.UI
{
    public class FadeTransition : MonoBehaviour
    {
        [SerializeField] CanvasGroup overlay;
        [SerializeField] float fadeTime = 0.8f;
        [SerializeField] string sceneToLoad = "Game";

        public void StartFade() => StartCoroutine(FadeAndLoad());

        IEnumerator FadeAndLoad()
        {
            if (!overlay) yield break;
            yield return UITween.Fade(overlay, 0, 1, fadeTime);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
