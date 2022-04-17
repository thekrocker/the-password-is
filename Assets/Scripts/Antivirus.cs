using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Antivirus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private GameObject fixButton;

    private string antivirusText =
        "Tarama başlatılı......Gerçekten bunun işe yarayacağını düşünmedin değil mi? Kırıldım ama.";

    public void StartScan()
    {
        StartCoroutine(CO_StartScan());

        IEnumerator CO_StartScan()
        {
            yield return new WaitForSeconds(1f);
            text.text = " ";
            foreach (var letter in antivirusText)
            {
                text.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}