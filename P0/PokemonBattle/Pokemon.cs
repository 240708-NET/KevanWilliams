
public abstract class Pokemon {

    public int lvl {get; set;} = 3;
    public int hp {get; set;} = 100;

    public abstract string name { get; }
    public abstract string type { get; }



    

    public abstract int Attack();

    public virtual void Heal(){
        Console.WriteLine("Pokemon healed!");
    }

    public virtual void Defend(){
        Console.WriteLine("Pokemon defended!");
    }
    
}