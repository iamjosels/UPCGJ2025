using UnityEngine;
using System.Collections;
using Game.Utils;

namespace Game.UI
{
    public class MenuIntroAnimator : MonoBehaviour
    {
        [SerializeField] CanvasGroup rootGroup;
        [Header("Refs")]
        [SerializeField] RectTransform title;
        [SerializeField] RectTransform menuGroup;

        [Header("Timings")]
        [SerializeField] float fadeTime = 0.35f;
        [SerializeField] float moveTime = 0.28f;

        [Header("Offsets (desde su posición actual)")]
        [SerializeField] Vector2 titleOffsetFrom = new Vector2(0, 140);
        [SerializeField] Vector2 menuOffsetFrom = new Vector2(0, -80);

        Vector2 _titleBasePos;
        Vector2 _menuBasePos;

        void Awake()
        {
            if (title) _titleBasePos = title.anchoredPosition;
            if (menuGroup) _menuBasePos = menuGroup.anchoredPosition;
        }

        void OnEnable()
        {
            StartCoroutine(Play());
        }

        IEnumerator Play()
        {
            if (!rootGroup) yield break;

            // Estado inicial
            rootGroup.alpha = 0f;
            if (title) title.anchoredPosition = _titleBasePos + titleOffsetFrom;
            if (menuGroup) menuGroup.anchoredPosition = _menuBasePos + menuOffsetFrom;

            // Fade + slides hacia su POSICIÓN BASE (no 0,0)
            yield return UITween.Fade(rootGroup, 0, 1, fadeTime);
            if (title) yield return UITween.MoveAnchored(title, title.anchoredPosition, _titleBasePos, moveTime);
            if (menuGroup) yield return UITween.MoveAnchored(menuGroup, menuGroup.anchoredPosition, _menuBasePos, moveTime);
        }
    }
}
