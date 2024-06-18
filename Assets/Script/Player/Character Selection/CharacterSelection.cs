using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentCharacter;

    private void Start()
    {
        currentCharacter = SaveManager.instance.currentCharacter;
        SelectCharacter(currentCharacter);
    }

    private void SelectCharacter(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
    }

    public void ChangeCharacter(int _change)
    {
        currentCharacter += _change;

        if (currentCharacter > transform.childCount - 1)
            currentCharacter = 0;
        else if (currentCharacter < 0)
            currentCharacter = transform.childCount - 1;

        SaveManager.instance.currentCharacter = currentCharacter;
        SaveManager.instance.Save();
        SelectCharacter(currentCharacter);
    }
}
