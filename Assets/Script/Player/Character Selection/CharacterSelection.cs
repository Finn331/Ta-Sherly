using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    //public Button character1Button;
    //public Button character2Button;
    public GameObject character1Prefabs;
    public GameObject character2Prefabs;
    public string nextSceneName;

    private int currentCharacter;

    private void Start()
    {
        //character1Button.onClick.AddListener(() => SelectCharacter(0));
        //character2Button.onClick.AddListener(() => SelectCharacter(1));

        //currentCharacter = SaveManager.instance.currentCharacter;
        //SelectCharacter(currentCharacter);
    }

    public void SelectCharacter(/*int _index*/)
    {
        //Debug.Log("SelectCharacter called with index: " + _index);
        //currentCharacter = _index;

        //for (int i = 0; i < characterPrefabs.Length; i++)
        //{
        //    characterPrefabs[i].SetActive(i == _index);
        //}

        //SaveManager.instance.currentCharacter = currentCharacter;
        //SaveManager.instance.Save();
        character1Prefabs.SetActive(true);
        LoadNextScene();
    }

    public void SelectCharacter2()
    {
        character2Prefabs.SetActive(true);
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
