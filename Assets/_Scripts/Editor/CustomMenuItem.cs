using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomMenuItem : MonoBehaviour {
    [MenuItem("Custom/Character Builder")]
    public static void InstantiateCharacterBuilder () {
        GameObject characterBuilder = new GameObject("Character Builder");
        characterBuilder.transform.position = Vector3.zero;
        characterBuilder.AddComponent(typeof(CharacterBuilder));
    }

    [MenuItem("Custom/Create Recipe")]
    public static void NewRecipe () {
        GameObject NewRecipe = new GameObject("Recipe");
        NewRecipe.transform.position = Vector3.zero;
        NewRecipe.AddComponent(typeof(Recipe));
    }
}
