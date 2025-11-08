using UnityEngine;

namespace Game.UI
{
    public class ParallaxUI : MonoBehaviour
    {
        [SerializeField] RectTransform[] layers;
        [SerializeField] Vector2[] speeds = { new Vector2(2f, 0f), new Vector2(4f, 0f), new Vector2(8f, 0f) };

        void Update()
        {
            for (int i = 0; i < layers.Length; i++)
            {
                if (!layers[i]) continue;
                var s = (i < speeds.Length) ? speeds[i] : Vector2.right * 2f;
                layers[i].anchoredPosition += s * Time.unscaledDeltaTime;
            }
        }
    }
}
