using UnityEngine;
using System.Collections;
using TrueGames.Bullshit.DataModels;
using UnityEngine.UI;
using TMPro;

namespace TrueGames.Bullshit
{
    [RequireComponent(typeof(Button))]
    public class TrueGamesButton : MonoBehaviour
    {
        private Button button;
        [SerializeField] private TextMeshProUGUI _text;

        public TextMeshProUGUI Text { get => _text; set => _text = value; }

        void Awake()
        {
            button = GetComponent<Button>();
        }

        public void SetClickAction(System.Action<string> action)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => action(_text.text));
        }
    }
}

