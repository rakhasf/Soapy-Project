using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private Button targetButton;
    public static ButtonManager Instance;
    public static bool isPaused = false;
    void Awake()
    { 
        if (Instance == null) Instance = this;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerFirstActiveButton("Esc");
        }


        if (Input.GetKey(KeyCode.LeftAlt) || isPaused)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        if (!isPaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }
    
    void TriggerFirstActiveButton(string prefix)
    {
        Button[] allButtons = GameObject.FindObjectsOfType<Button>(true); 
        foreach (Button btn in allButtons)
        {
            GameObject go = btn.gameObject;
            if (go.name.StartsWith(prefix) && go.activeInHierarchy && btn.interactable)
            {
                Debug.Log("Menekan tombol: " + go.name);
                btn.onClick.Invoke();
                break; 
            }
        }
    }
   
    
    public void LoadSceneByName(string sceneName)
    {
        Time.timeScale = 1f;   

        StartCoroutine(ByNameSequence(sceneName));
    }      

     private IEnumerator ByNameSequence(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }


    public void pause()
    {

    }


    public void Resume()
    {

    }


    public void Restart()
    {
        Time.timeScale = 1f;
        StartCoroutine(RestartSequence());
    }

    private IEnumerator RestartSequence()
    {
        yield return new WaitForSeconds(0.2f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Debug.unityLogger.Log("Scene Restard");
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameSequence());
    }

    private IEnumerator QuitGameSequence()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
    
    
}
