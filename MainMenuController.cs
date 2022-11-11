using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Allow the user to transfer from different window
public class MainMenuController : MonoBehaviour
{
    public void PlayGame() 
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("GamePlay");
    }
}
