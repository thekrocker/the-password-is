using System;
using Sirenix.OdinInspector;
using SO;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {

        public int CurrentPhaseIndex;

        public void IncreasePhase() => CurrentPhaseIndex++;



        public void GameOver()
        {
            Debug.Log("Game is over..");
        }
    }
}