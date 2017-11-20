public abstract class Character {

    protected string name;
    protected string nickname;
    protected Gender gender;
    protected Race race;
    protected string origin;
    protected string habits;
    protected string nature;
    protected string food;

    public string Name { get { return name; } }
    public string Nickname { get { return nickname; } }
    public Gender Gender { get { return gender; } }
    public Race Race { get { return race; } }
    public string Origin { get { return origin; } }
    public string Habits { get { return habits; } }
    public string Nature { get { return nature; } }
    public string Food { get { return food; } }

    protected Character(string name, string nickname){
        this.name = name;
        this.nickname = nickname;
        gender = Gender.NotSpecified;
        race = Race.NotSpecified;
        origin = "Uknown";
        habits = "Uknown";
        nature = "Uknown";
        food = "Uknown";
    }

    protected Character(string name, string nickname, Gender gender, Race race, string origin, string habits, string nature, string food){
        this.name = name;
        this.nickname = nickname;
        this.gender = gender;
        this.race = race;
        this.origin = origin;
        this.habits = habits;
        this.nature = nature;
        this.food = food;
    }

    public void presentation() { }

    public void talk(string text){ }

}
