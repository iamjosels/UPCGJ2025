using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public enum MenuState { Main, Options, Credits, Transitioning }

    public class MenuController : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject panelMain;
        [SerializeField] private GameObject panelOptions;
        [SerializeField] private GameObject panelCredits;

        [Header("First Selectables")]
        [SerializeField] private Selectable firstMain;
        [SerializeField] private Selectable firstOptions;
        [SerializeField] private Selectable firstCredits;

        public MenuState State { get; private set; } = MenuState.Main;

        private void Awake()
        {
            ShowMain();
        }

        private void SetSelected(Selectable s)
        {
            if (!s) return;
            EventSystem.current?.SetSelectedGameObject(s.gameObject);
        }

        public void ShowMain()
        {
            State = MenuState.Main;
            panelMain.SetActive(true);
            panelOptions.SetActive(false);
            panelCredits.SetActive(false);
            SetSelected(firstMain);
        }

        public void ShowOptions()
        {
            State = MenuState.Options;
            panelMain.SetActive(false);
            panelOptions.SetActive(true);
            panelCredits.SetActive(false);
            SetSelected(firstOptions);
        }

        public void ShowCredits()
        {
            State = MenuState.Credits;
            panelMain.SetActive(false);
            panelOptions.SetActive(false);
            panelCredits.SetActive(true);
            SetSelected(firstCredits);
        }

        public void QuitApp()
        {
            Application.Quit();
        }
    }
}
