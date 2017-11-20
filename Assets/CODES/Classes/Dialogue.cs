using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDialogues {
    public int level;
    public string levelName;
    public List<Dialogues> dialogues;

    public LevelDialogues newSceneDialogue(int sceneNumber){
        string levelDialoguesJson = System.IO.File.ReadAllText("Assets/TEXTS/Dialogues/dialogues"+sceneNumber+".json");
        LevelDialogues dialogues = new LevelDialogues();
        dialogues = JsonUtility.FromJson<LevelDialogues>(levelDialoguesJson);
        return dialogues;
    }

    public DialogueCharacter characterDialogues(string characterName, List<Dialogues> dialogues, string language){
        Dialogues currentDialogue = new Dialogues();
        DialogueCharacter currentCharacter = new DialogueCharacter();
        for (int i=0; i<dialogues.Count; i++){
            if(dialogues[i].language == language){
                currentDialogue = dialogues[i];
            }
        }
        for (int i = 0; i < currentDialogue.characters.Count; i++){
            if (currentDialogue.characters[i].name == characterName){
                currentCharacter = currentDialogue.characters[i];
            }
        }
        return currentCharacter;
    }

}

[Serializable]
public class Dialogues {
    public string language;
    public List<DialogueCharacter> characters;
}

[Serializable]
public class DialogueCharacter {
    public string name;
    public List<DialogueText> dialogueTexts;
}

[Serializable]
public class DialogueText {
    public DialogueTextType type;
    public string text;
}

