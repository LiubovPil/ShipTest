using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ShipTest
{
    public class GameManagerPrototype5 : MonoBehaviour
    {
        [SerializeField] private List<Target> targets = new List<Target>();

        [SerializeField] private Button restartButton;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gameoverText;

        [SerializeField] private GameObject titleScreen;

        private float spawnRate = 1.0f;
        private int score;
        private bool isGameOver;

        void Start()
        {

        }

        IEnumerator SpawnTarget()
        {
            while (!isGameOver)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

        public void StartGame(int difficulty)
        {
            isGameOver = false;
            score = 0;

            spawnRate /= difficulty;

            StartCoroutine(SpawnTarget());
            UpdateScore(0);

            titleScreen.SetActive(false);
        }

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.SetText("Score: " + score);
        }

        public void GameOver()
        {
            gameoverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameOver = true;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
