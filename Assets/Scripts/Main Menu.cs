using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene", LoadSceneMode.Single);
    }

    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.UnloadSceneAsync("Main Menu");
    }
}
