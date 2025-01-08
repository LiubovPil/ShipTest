using UnityEngine;
using UnityEngine.UI;

namespace ShipTest
{
    public class DifficultButton : MonoBehaviour
    {
        [SerializeField] private int difficulty;

        private GameManagerPrototype5 gameManager;
        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficulty);

            gameManager = GameObject.Find("GameManager").GetComponent<GameManagerPrototype5>();
        }
        public void SetDifficulty()
        {
            gameManager.StartGame(difficulty);
        }
    }
}
