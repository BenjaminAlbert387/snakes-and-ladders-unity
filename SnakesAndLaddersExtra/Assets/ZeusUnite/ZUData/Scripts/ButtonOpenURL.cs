using UnityEngine;

namespace ZeusUnite
{
    /// <summary>
    /// Attached on a Unity UI Button the Click on it with Call the URL to Open
    /// </summary>
    public class ButtonOpenURL : MonoBehaviour
    {
        [SerializeField] string urlToOpen = "https://www.stussegames.com";

        void OnEnable() =>
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OpenURL);

        void OpenURL() =>
            Application.OpenURL(urlToOpen);

        void OnDisable() =>
            GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(OpenURL);
    }
}
