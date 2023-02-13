using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameBasic() {
        SceneManager.LoadScene("Basic", LoadSceneMode.Single);
    }

    public void GamePrincipal() {
        SceneManager.LoadScene("Principal", LoadSceneMode.Single);
    }


    public void GameMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void ExistGame() {
        Application.Quit();
    }

    
}
