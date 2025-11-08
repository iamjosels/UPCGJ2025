using UnityEngine;

namespace Game.UI
{
    public class Breathing : MonoBehaviour
    {
        [SerializeField] Vector3 baseScale = Vector3.one;
        [SerializeField] float amplitude = 0.02f;
        [SerializeField] float speed = 1.2f;
        Transform _t;

        void Awake() => _t = transform;

        void Update()
        {
            float k = (Mathf.Sin(Time.unscaledTime * speed) + 1f) * 0.5f;
            _t.localScale = baseScale * (1f + amplitude * (k - 0.5f) * 2f);
        }
    }
}
