using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Utils
{
    public static class UITween
    {
        public static IEnumerator Scale(RectTransform rt, Vector3 from, Vector3 to, float t)
        {
            float e = 0f;
            rt.localScale = from;
            while (e < t)
            {
                e += Time.unscaledDeltaTime;
                float k = Mathf.SmoothStep(0, 1, Mathf.Clamp01(e / t));
                rt.localScale = Vector3.LerpUnclamped(from, to, k);
                yield return null;
            }
            rt.localScale = to;
        }

        public static IEnumerator Fade(CanvasGroup cg, float from, float to, float t)
        {
            float e = 0f;
            cg.alpha = from;
            while (e < t)
            {
                e += Time.unscaledDeltaTime;
                float k = Mathf.SmoothStep(0, 1, Mathf.Clamp01(e / t));
                cg.alpha = Mathf.LerpUnclamped(from, to, k);
                yield return null;
            }
            cg.alpha = to;
        }

        public static IEnumerator MoveAnchored(RectTransform rt, Vector2 from, Vector2 to, float t)
        {
            float e = 0f;
            rt.anchoredPosition = from;
            while (e < t)
            {
                e += Time.unscaledDeltaTime;
                float k = Mathf.SmoothStep(0, 1, Mathf.Clamp01(e / t));
                rt.anchoredPosition = Vector2.LerpUnclamped(from, to, k);
                yield return null;
            }
            rt.anchoredPosition = to;
        }
    }
}
