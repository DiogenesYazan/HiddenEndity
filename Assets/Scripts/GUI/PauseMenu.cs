using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject Camera;
    public StarterAssetsInputs Inputs;
    private bool isPaused = false;
    public GameObject PnlSure;
    public GameObject InventaryMenu;
    public GameObject Config;
    public GameObject Btn;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Camera.SetActive(true);
        Inputs.SetCursorState(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Camera.SetActive(false);
        Inputs.SetCursorState(false);
        Time.timeScale = 0f;
        isPaused = true;
        Btn.SetActive(true);
    }

    public void inventoryButton() {
        Btn.SetActive(false);
        InventaryMenu.SetActive(!InventaryMenu.activeSelf);
    }

    public void configButton() {
        Config.SetActive(!Config.activeSelf);
    }

    public void exitButton() {
        PnlSure.SetActive(!PnlSure.activeSelf);
    }

    public void backButton() {
        PnlSure.SetActive(false);
        InventaryMenu.SetActive(false);
        Config.SetActive(false);
    }
    

    public void sureButton() {
        PnlSure.SetActive(false);
        Btn.SetActive(true);
    }

    public void noButton() {
        PnlSure.SetActive(false);
        Btn.SetActive(true);
    }

    public void yesButton() {
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
