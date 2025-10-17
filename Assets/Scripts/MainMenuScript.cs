using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private AudioClip selectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        // Code to start the game
        Debug.Log("Play Game button clicked");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        // Code to quit the game
        Debug.Log("Quit Game button clicked");
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position);
        Application.Quit();
    }
}
