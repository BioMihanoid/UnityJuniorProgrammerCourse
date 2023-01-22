using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gameManger;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficuly);
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    void SetDifficuly()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManger.StartGame(difficulty);
    }
}
