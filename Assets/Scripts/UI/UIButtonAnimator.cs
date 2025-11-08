using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using Game.Utils;

namespace Game.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIButtonAnimator : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Scales")]
        public Vector3 normalScale = Vector3.one;
        public Vector3 hoverScale = Vector3.one * 1.05f;
        public Vector3 pressedScale = Vector3.one * 0.95f;
        public float animTime = 0.12f;

        [Header("Optional")]
        public CanvasGroup canvasGroup;
        public AudioSource sfxSource;
        public AudioClip hoverClip;
        public AudioClip clickClip;

        RectTransform _rt;
        Coroutine _routine;

        void Awake()
        {
            _rt = GetComponent<RectTransform>();
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
            _rt.localScale = normalScale;
        }

        public void OnSelect(BaseEventData eventData) => Hover();
        public void OnDeselect(BaseEventData eventData) => Normal();
        public void OnPointerEnter(PointerEventData e) => Hover();
        public void OnPointerExit(PointerEventData e) => Normal();
        public void OnPointerDown(PointerEventData e) => Pressed();
        public void OnPointerUp(PointerEventData e) => Hover();

        void Play(AudioClip c)
        {
            if (sfxSource && c) sfxSource.PlayOneShot(c);
        }

        void Hover()
        {
            Play(hoverClip);
            StartScale(hoverScale);
        }

        void Normal()
        {
            StartScale(normalScale);
        }

        void Pressed()
        {
            Play(clickClip);
            StartScale(pressedScale);
        }

        void StartScale(Vector3 target)
        {
            if (_routine != null) StopCoroutine(_routine);
            _routine = StartCoroutine(UITween.Scale(_rt, _rt.localScale, target, animTime));
        }
    }
}
