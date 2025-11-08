using UnityEngine;

namespace Game.UI
{
    public class OptionsBackHotkey : MonoBehaviour
    {
        [SerializeField] private MenuController menu;

        void Update()
        {
            if (menu && menu.State == MenuState.Options && Input.GetKeyDown(KeyCode.Escape))
                menu.ShowMain();
        }
    }
}
