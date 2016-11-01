using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public Sprite NPCImage;

    public Color playerColor;

    //Player Prefabs
    public GameObject[] playerClass;

    // Colors of classes
    public Color[] colorList;

    int currentLevel = 0;

    public static GameManager instance;

    public virtual void Awake(){
        // Checks if GameManager Exist & Creates new instance
        playerColor = colorList[0];
        if (instance == null){
            instance = this;
        }
        else{
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(this);
    }


    //Load Level
    public void LoadNextLevelOne() {
        ++currentLevel;
        SceneManager.LoadScene(1);
    }
}
