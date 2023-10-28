using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectToggle : MonoBehaviour
{
    public int CharacterIndex;
    public AudioSource slectSFX;

    public void ToggleSelected()
    {
        
            UserData.charIndex = CharacterIndex;
            slectSFX.Play();


    }

}
