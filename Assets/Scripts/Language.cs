using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Language : MonoBehaviour
{
    public static Language Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }




    public bool languageIsEnglish = true;

    public void EnglishButton()
    {
        languageIsEnglish = true;
        Debug.Log("Idioma selecionado: Inglês");
    }
    public void BrasilianButton()
    {
        languageIsEnglish = false;
        Debug.Log("Idioma selecionado: Português");
    }
}
