using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject panel_play;
    public GameObject panel_config;
    public GameObject panel_about;
    


    void Start()
    {

    }
    public void play(){
        panel_play.SetActive(true);
    }
    public void config(){
        panel_config.SetActive(true);
    }
    public void about(){
        panel_about.SetActive(true);
    }
    public void back(){
        panel_play.SetActive(false);
        panel_config.SetActive(false);
        panel_about.SetActive(false);
    }
    public void exit(){
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
    #endif
    #if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
    #elif (UNITY_STANDALONE) 
    A   pplication.Quit();
    #elif (UNITY_WEBGL)
        Application.OpenURL("https://diogenesyazan.itch.io");
    #endif
    }
}
