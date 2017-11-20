using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dialogueTest : MonoBehaviour {

    public LevelDialogues dialoguesTest;

    // Use this for initialization
    void Start () {
        dialoguesTest = new LevelDialogues();
        dialoguesTest = dialoguesTest.newSceneDialogue(1);
        DialogueCharacter fraDialogsIT = dialoguesTest.characterDialogues("Fra", dialoguesTest.dialogues, "it");
        DialogueCharacter gabDialogsIT = dialoguesTest.characterDialogues("Gabri", dialoguesTest.dialogues, "it");

        for(int i=0; i<2; i++)
        {
            Debug.Log(fraDialogsIT.name + ": " + fraDialogsIT.dialogueTexts[i].text);
            Debug.Log(gabDialogsIT.name + ": " + gabDialogsIT.dialogueTexts[i].text);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
