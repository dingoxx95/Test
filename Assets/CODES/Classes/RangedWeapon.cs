public class RangedWeapon : Weapon {

    private float fireRate;
    private int totalAmmo;
    private int currentAmmo;

    public int CurrentAmmo{
        get { return currentAmmo; }
        set { currentAmmo = CurrentAmmo; }
    }

    RangedWeapon(string name, float meleePower, float rangedPower, float criticalPercentage, int criticalPower, float fireRate, int totalAmmo, int currentAmmo) : base(name, meleePower, rangedPower, criticalPercentage, criticalPower){
        this.fireRate = fireRate;
        this.totalAmmo = totalAmmo;
        this.currentAmmo = currentAmmo;
    }

    public override void attack(){

    }

}