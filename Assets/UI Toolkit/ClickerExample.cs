using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickerExample : MonoBehaviour
{


    public int ClickCount = 0;
    public List<BaseCharater> characters;
    VisualElement root;




    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        characters = Resources.LoadAll<BaseCharater>("characters").ToList();
        DrawCharacters();

        // var b1 = root.Q<Button>("b1");
        // var b2 = root.Q<Button>("b2");
        // var b3 = root.Q<Button>("b3");

        // b1.text = "+1";
        // b2.text = "-1";
        // b3.text = "Reset";

        // b1.clicked += () => Increment(1);
        // b2.clicked += () => Increment(-1);
        // b3.clicked += Reset;
    }

    void DrawCharacters()
    {
        var sidebar = root.Q<VisualElement>("Sidebar");
        sidebar.Clear();

        foreach (var character in characters)
        {
            var characterButton = new Button();
            var characterName = new Label(character.Name);
            var icon = new Image();
            characterButton.text = "";
            icon.style.backgroundImage = new StyleBackground(character.Sprite.texture);
            icon.AddToClassList("character-icon");
            characterButton.Add(icon);
            characterButton.Add(characterName);
            characterButton.AddToClassList("menu-button");
            characterButton.clicked += () => SetActiveCharacter(character);
            sidebar.Add(characterButton);
        }

    }

    void SetActiveCharacter(BaseCharater character)
    {
        if (character != null)
        {
            Debug.Log("Selected character: " + character.name);
        }

        root.Q<Label>("clicker").text = character.Name;

    }


    // void Increment(int amount)
    // {
    //     ClickCount += amount;
    //     UpdateScreen();
    // }


    // void Reset()
    // {
    //     ClickCount = 0;
    //     UpdateScreen();
    // }


    void UpdateScreen()
    {
        var label = root.Q<Label>("clicker");
        label.text = "Click Count: " + ClickCount;
    }



}
