using UnityEngine;
using System.Collections;

namespace Game.UI
{
    public class PlayTransition : MonoBehaviour
    {
        [SerializeField] Camera cam;
        [SerializeField] Vector3 targetOffset = new Vector3(0, -5f, 0);
        [SerializeField] float panTime = 0.8f;
        [SerializeField] AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField] string sceneToLoad = "Game";

        Vector3 _startPos;

        void Awake()
        {
            if (!cam) cam = Camera.main;
        }

        public void OnPlayPressed()
        {
            if (gameObject.activeInHierarchy)
                StartCoroutine(PanThenLoad());
        }

        IEnumerator PanThenLoad()
        {
            _startPos = cam.transform.position;
            Vector3 end = _startPos + targetOffset;

            float e = 0f;
            while (e < panTime)
            {
                e += Time.unscaledDeltaTime;
                float k = Mathf.Clamp01(e / panTime);
                float t = curve.Evaluate(k);
                cam.transform.position = Vector3.LerpUnclamped(_startPos, end, t);
                yield return null;
            }
            cam.transform.position = end;

            // Aquí puedes mostrar un fade negro rápido si quieres
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}
