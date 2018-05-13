using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public string myName;
    public int life;
    public int power;

    //Classes
    public enum CharacterClasses { Mage, Warrior, Cleric, Thief };
    public CharacterClasses characterClass;

    //Races
    public enum CharacterRaces { Human, Dwarf, Elf, Halfling };
    public CharacterRaces characterRace;

    public enum CharacterGenders { Female, Male }
    public CharacterGenders characterGender;
}
