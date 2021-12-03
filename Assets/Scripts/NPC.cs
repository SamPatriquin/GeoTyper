using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] int gameSceneIndex;

    public void startGame() {
        SceneManager.LoadScene(gameSceneIndex);
    }
    
}
