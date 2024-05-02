using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Text2 : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public String textEN;
    public String textBR;

    void FixedUpdate()
    {
        if (Language.Instance.languageIsEnglish == true){
            textMeshPro.text = textEN;
        }
        else if (Language.Instance.languageIsEnglish == false){
            textMeshPro.text = textBR;
        }
    }

}
