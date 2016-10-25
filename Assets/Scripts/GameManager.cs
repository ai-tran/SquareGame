using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    private Color playerColor;
    public Color pColor {
        get { return playerColor; }
        set { playerColor = value; }
    }

    //Player Prefabs
    public GameObject[] playerClass;

    // List of Classes
    public Color[] colList = {Color.red, Color.blue, Color.green };

    public int classIndex;

    int currentLevel = 0;

    public static GameManager instance;

    public virtual void Awake()
    {
        // Checks if GameManager Exist & Creates new instance
        if (instance == null){
            instance = this;
        }
        else{
            DestroyObject(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Select class from playerClass array
    public void selectClass(int select){
        classIndex = select;
        playerColor = colList[classIndex];
    }

    //Load Level
    public void LoadNextLevelOne() {
        ++currentLevel;
        SceneManager.LoadScene(1);
    }

    void Update() {
    }

}
