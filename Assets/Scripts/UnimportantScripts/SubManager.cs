using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubManager : MonoBehaviour
{
    [SerializeField] private List<string> phrases;
    [SerializeField] private List<float> secondsForphrase;
    [SerializeField] private TextMeshProUGUI subText;
    [SerializeField] private Image BGimage;
    private int subNum = 0;
    private Coroutine coroutine;
    private void Start()
    {
       coroutine = StartCoroutine(PhrasesTimer());
    }

    private IEnumerator PhrasesTimer()
    {
        bool TempValue = true;
        while (TempValue)
        {
            subText.text = phrases[subNum];
            yield return new WaitForSeconds(secondsForphrase[subNum]);
            subNum++;
            if (subNum == phrases.Count)
            {
                TempValue = false;
                subText.gameObject.SetActive(false);
                BGimage.gameObject.SetActive(false);    
            }
        }
    }
}
