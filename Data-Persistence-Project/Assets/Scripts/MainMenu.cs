using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public string valueText;
    public string endText;

    private void Start()
    {
        if (MenuManager.Instance != null)
        {
            GameObject.Find("NameField").GetComponent<InputField>().SetTextWithoutNotify(MenuManager.Instance.Name);
        }
    }

    private void Update()
    {
        if (MenuManager.Instance != null && MenuManager.Instance.Name != null)
        {
            GameObject.Find("NameField").GetComponent<InputField>().SetTextWithoutNotify(MenuManager.Instance.Name);
            if (MenuManager.Instance.Champion != null && MenuManager.Instance.Champion != "")
            {
                GameObject.Find("Score").GetComponent<Text>().text = $"Score: {MenuManager.Instance.Champion} : {MenuManager.Instance.score}";
            }
        }


        GameObject.Find("NameField").GetComponent<InputField>().onValueChanged.AddListener(ChangedValue);
        GameObject.Find("NameField").GetComponent<InputField>().onEndEdit.AddListener(EndValue);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    public void NewNameEntered(string name)
    {
        MenuManager.Instance.Name = name;
    }

    private void ChangedValue(string value)
    {
        valueText = value;
        Debug.Log("¬ведено " + value);
        NewNameEntered(value);
    }

    private void EndValue(string value)
    {
        valueText = value;
        Debug.Log("¬ведено " + value);
    }
}
