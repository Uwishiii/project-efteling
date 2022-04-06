using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//This is important
using TMPro;

public sealed class Dialogue : MonoBehaviour
{
    #region Variables

    //To be able to access the text
    public TextMeshProUGUI textComponent;
    
    //New Array to keep track of lines
    public string[] lines;
    
    //Text Speed
    public float textSpeed;

    //Just an index variable for use with the array
    private int index;

    #endregion

    #region Functions

    private void Start()
    {
        //Empty the text field
        textComponent.text = String.Empty;
        StartDialogue();
    }

    private void Update()
    {
        //Check for Mouse1 for skipping text / going to the next line
        //This is where you would add detection for a "Talk-able" NPC to enable the text box
        if (Input.GetMouseButtonDown(0))
        {
            //Checking if line is fully written or not, if not writes it instantly, if yes skips to next line
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                //Stopping the letter-by-letter coroutine and instantly writing text
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        //Just init stuff
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Fancy one-by-one letters
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //Skips to next line, if there is no line then disables text box
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            
        }
    }
    
    #endregion
}
