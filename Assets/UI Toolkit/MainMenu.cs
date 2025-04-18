using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    VisualElement root;
    List<BaseCharacter> characters;

    public Player SelectedCharacter;


    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        characters = Resources.LoadAll<BaseCharacter>("characters").ToList();


        Button startButton = root.Q<Button>("start-button");

        DrawCharacterButtons();

        startButton.clicked += StartGame;
    }


    void DrawCharacterButtons()
    {
        var list = root.Q<VisualElement>("character-list");
        list.Clear();


        foreach (var character in characters)
        {
            var button = new Button();
            button.AddToClassList("menu-button");
            button.AddToClassList("character-button");

            var icon = new Image();
            icon.AddToClassList("character-icon");
            icon.style.backgroundImage = new StyleBackground(character.Icon);

            var label = new Label(character.CharacterName);

            button.Add(icon);
            button.Add(label);

            button.clicked += () => SetActiveCharacter(character);

            list.Add(button);
        }

    }

    void SetActiveCharacter(BaseCharacter character)
    {
        PlayerPrefs.SetString("SelectedCharacter", character.name);

        SelectedCharacter.Start();

        // StartCoroutine(CycleAnimations());

    }

    // IEnumerator CycleAnimations()
    // {

    //     string state = "idle";

    //     while (state != "hello")
    //     {
    //         if (state == "idle")
    //         {
    //             state = "running";
    //             SelectedCharacter.SetBool("isRunning", true);
    //         }
    //         else
    //         {
    //             SelectedCharacter.SetBool("isRunning", false);
    //         }

    //         yield return new WaitForSeconds(Random.Range(3, 5));
    //     }

    //     yield return null;

    // }



    void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }



}
