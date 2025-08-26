using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;

    private GameObject currentCharacter;

    void Start()
    {
        currentCharacter = character1;
        character1.SetActive(true);
        character2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        if (currentCharacter == character1)
        {
            character1.SetActive(false);
            character2.SetActive(true);
            currentCharacter = character2;
        }
        else
        {
            character2.SetActive(false);
            character1.SetActive(true);
            currentCharacter = character1;
        }
    }
}