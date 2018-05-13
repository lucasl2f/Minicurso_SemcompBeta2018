using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterBuilder : MonoBehaviour {
    public string _name = "Juca";
    public int _life, _power;
    public Sprite _charImage;

    public CharacterStats.CharacterClasses _characterClass;
    public CharacterStats.CharacterRaces _characterRace;
    public CharacterStats.CharacterGenders _characterGender;

    public void CreateCharacter () {
        GameObject character = new GameObject();
        character.name = _name;
        character.transform.position = Vector3.zero;

        CharacterStats stats = character.AddComponent(typeof(CharacterStats)) as CharacterStats;
        stats.myName = _name;
        stats.life = _life;
        stats.power = _power;
        stats.characterClass = _characterClass;
        stats.characterRace = _characterRace;
        stats.characterGender = _characterGender;

        SpriteRenderer spriteRenderer = character.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRenderer.sprite = _charImage;
    }
}

[CustomEditor(typeof(CharacterBuilder))]
public class CharacterBuilderCustom : Editor {
    CharacterBuilder characterBuilder;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable () {
        characterBuilder = (CharacterBuilder)target;
    }

    public override void OnInspectorGUI () {
        if (GUILayout.Button("Generate")) {
            characterBuilder.CreateCharacter();
        }

        characterBuilder._name = GUILayout.TextField(characterBuilder._name);
        characterBuilder._charImage = (Sprite)EditorGUILayout.ObjectField("Image", characterBuilder._charImage, typeof(Sprite), false);
        characterBuilder._life = EditorGUILayout.IntField("Life", characterBuilder._life);
        characterBuilder._power = EditorGUILayout.IntField("Power", characterBuilder._power);
        characterBuilder._characterClass = (CharacterStats.CharacterClasses)EditorGUILayout.EnumPopup("Class", characterBuilder._characterClass);
        characterBuilder._characterRace = (CharacterStats.CharacterRaces)EditorGUILayout.EnumPopup("Race", characterBuilder._characterRace);
        characterBuilder._characterGender = (CharacterStats.CharacterGenders)EditorGUILayout.EnumPopup("Gender", characterBuilder._characterGender);

        if (GUI.changed) {
            //EditorUtility.SetDirty(target);
        }
    }
}
