using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Passwords/PasswordData")]
    public class PhaseData : ScriptableObject
    {
        [TextArea(10,20)] public string[] dialogues;
        public string currentPassword;
        
        public float phaseTimer;
    }
}
