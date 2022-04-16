using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        
        [SerializeField] private GameObject gameWinPanel;
        [SerializeField] private GameObject gameLosePanel;
        
        [SerializeField] private WinText winText;

        [field: SerializeField] public PhaseData[] PhaseDatas { get; set; }

        public bool PasswordFailed { get; set; }
        public bool IsGameOver { get; set; }


        public int currentPhaseIndex;

        public void IncreasePhase() => currentPhaseIndex++;

        public void GameOver()
        {
            Debug.Log("Game is over.. You lost..");
            gameLosePanel.SetActive(true);
        }

        public void Restart()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }

        [Button("Win Game")]
        public void HandleGameWin()
        {
            gameWinPanel.SetActive(true);
            var img = gameWinPanel.GetComponent<Image>();
            img.DOColor(new Color(img.color.r, img.color.g, img.color.b, 1f), 5f)
                .OnComplete(
                    () =>
                    {
                        //Set cyberpunk music here...
                        winText.gameObject.SetActive(true);
                    });
        }

        public PhaseData GetCurrentPhase() => PhaseDatas[currentPhaseIndex];
    }
}