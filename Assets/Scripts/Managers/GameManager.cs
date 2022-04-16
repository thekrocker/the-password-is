using System;
using Sirenix.OdinInspector;
using SO;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {

        [SerializeField] private GameObject dialoguePanel;


        public int CurrentPhaseIndex;

        public void IncreasePhase() => CurrentPhaseIndex++;

        public void OpenDialoguePanel()
        {
            dialoguePanel.SetActive(true);
        }
        
    }
}