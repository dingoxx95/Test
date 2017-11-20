using UnityEngine;

public class PlayableCharacter : Character, IKillable{

    private float totalHealt, currentHealt, meleePower, rangedPower, meleeDefence, rangedDefence, agility;
    private Alignment alignment;

    public float Health{
        get { return currentHealt; }
    }

    PlayableCharacter(string name, string nickname, Gender gender, Race race, string origin, string habits, string nature, string food,
                      float totalHealt, 
                      float currentHealt, 
                      float meleePower, 
                      float rangedPower, 
                      float meleeDefence, 
                      float rangedDefence, 
                      float agility,
                      Alignment alignment) : base (name, nickname, gender, race, origin, habits, nature, food) {
        this.totalHealt = totalHealt;
        this.currentHealt = currentHealt;
        this.meleePower = meleePower;
        this.rangedPower = rangedPower;
        this.meleeDefence = meleeDefence;
        this.rangedDefence = rangedDefence;
        this.agility = agility;
        this.alignment = alignment;
    }

    public void attack(){
        MonoBehaviour.print("Attack from a playable character");
    }

    public void die(){
        MonoBehaviour.print("Death for a playable character");
    }

}
