using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMaster : MonoBehaviour
{
    public GameObject BatlleCanvas;
    public static SceneMaster Instance;
    public void ChangeScene(int scenenumber)
    {
        //BatlleCanvas.SetActive(scenenumber == 1);
        SceneManager.LoadScene(scenenumber);
    }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
