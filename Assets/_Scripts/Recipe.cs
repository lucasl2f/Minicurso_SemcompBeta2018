using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Recipe : MonoBehaviour {
    [Header("RECIPE")]
    public string recipeName;
    public Sprite recipePhoto;
    public float quantity;
    public Unit unit;

    public enum Unit { Quantity, Cup, Spoon, Glass, Liter, Kg };

    [Space(20)]
    [Header("INGREDIENTS")]
    public List<Ingredient> ingredients = new List<Ingredient>();
}

[System.Serializable]
public class Ingredient {
    [Tooltip("Name of ingredient")]
    public string name;
    public Sprite photo;
    public float quantity;
    public Recipe.Unit unit;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Recipe))]
public class RecipeCustom : Editor {
    Recipe myScript;
    bool foldout;

    void OnEnable () {
        myScript = (Recipe)target;
        foldout = true;
    }

    public override void OnInspectorGUI () {
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            GUILayout.Label("RECIPE", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        {
            GUILayout.BeginVertical();
            {
                myScript.recipeName = EditorGUILayout.TextField(myScript.recipeName);
                GUILayout.BeginHorizontal();
                {
                    myScript.quantity = EditorGUILayout.FloatField(myScript.quantity);
                    myScript.unit = (Recipe.Unit)EditorGUILayout.EnumPopup(myScript.unit);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            myScript.recipePhoto = (Sprite)EditorGUILayout.ObjectField(myScript.recipePhoto, typeof(Sprite), false, GUILayout.Width(80), GUILayout.Height(80));
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.BeginVertical("box");
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label("INGREDIENTS", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                foldout = EditorGUILayout.Toggle(foldout, EditorStyles.foldout, GUILayout.Width(20));
            }
            GUILayout.EndHorizontal();

            if (foldout) {
                GUILayout.Space(20);

                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("ADD", GUILayout.Width(60), GUILayout.Height(40))) {
                        myScript.ingredients.Add(new Ingredient());
                        return;
                    }
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();

                GUILayout.Space(20);

                for (int i = 0; i < myScript.ingredients.Count; i++) {
                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.BeginVertical();
                        {
                            myScript.ingredients[i].name = EditorGUILayout.TextField(myScript.ingredients[i].name);
                            GUILayout.BeginHorizontal();
                            {
                                myScript.ingredients[i].quantity = EditorGUILayout.FloatField(myScript.ingredients[i].quantity);
                                myScript.ingredients[i].unit = (Recipe.Unit)EditorGUILayout.EnumPopup(myScript.ingredients[i].unit);
                            }
                            GUILayout.EndHorizontal();

                            GUILayout.Space(10);

                            if (GUILayout.Button("Remove", GUILayout.Width(60))) {
                                myScript.ingredients.RemoveAt(i);
                                return;
                            }
                        }
                        GUILayout.EndVertical();
                        myScript.ingredients[i].photo = (Sprite)EditorGUILayout.ObjectField(myScript.ingredients[i].photo, typeof(Sprite), false, GUILayout.Width(80), GUILayout.Height(80));
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(10);
                }
            } else {
                GUILayout.Label("All contents are hidden");
            }
        }
        GUILayout.EndVertical();

        DrawDefaultInspector();
    }
}
#endif
