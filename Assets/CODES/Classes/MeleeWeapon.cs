public class MeleeWeapon : Weapon {

    public int attackRange;

    MeleeWeapon(string name, float meleePower, float rangedPower, float criticalPercentage, int criticalPower, int attackRange) : base(name, meleePower, rangedPower, criticalPercentage, criticalPower){
        this.attackRange = attackRange;
    }

    public override void attack(){

    }

}