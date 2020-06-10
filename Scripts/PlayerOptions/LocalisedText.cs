using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalisedText : MonoBehaviour
{
    public string Text_ID;

    void UpdateText()
    {
        gameObject.GetComponent<Text>().text = Options.current.ReturnWord(Text_ID);
    }

    private void Update()
    {
        UpdateText();
    }
}
