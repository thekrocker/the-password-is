using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WinText : MonoBehaviour
{
    private TextMeshProUGUI winText;

    void Start()
    {
        winText = GetComponent<TextMeshProUGUI>();
        
        SetWinText();
    }
    
    private string _complexName = "'/()&AP/'^+!..";
    public void SetWinText()
    {

        StartCoroutine(CO_SetText());

        IEnumerator CO_SetText()
        {
            foreach (var letter in _complexName)
            {
                winText.text += letter;
                yield return new WaitForSeconds(0.06f);
            }
            
            yield return new WaitForSeconds(1.5f);
            
            for (var i = 0; i < _complexName.Length; i++)
            {
                winText.text = winText.text.Remove(winText.text.Length - 1);
                yield return new WaitForSeconds(0.05f);
            }

            _complexName = "Safa Dedeakay"; 

            foreach (char letter in _complexName)
            {
                winText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(1f);

            winText.DOFade(0, 3f).OnComplete(() =>
            {
                Application.Quit();
            });
        }
    }
    
}