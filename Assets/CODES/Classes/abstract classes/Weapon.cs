public abstract class Weapon {

    private string name;
    private float meleePower, rangedPower, criticalPercentage;
    private int criticalPower;

    public Weapon(string name, float meleePower, float rangedPower, float criticalPercentage, int criticalPower){
        this.name = name;
        this.meleePower = meleePower;
        this.rangedPower = rangedPower;
        this.criticalPercentage = criticalPercentage;
        this.criticalPower = criticalPower;
    }

    public abstract void attack();

}
