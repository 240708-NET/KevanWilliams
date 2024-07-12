
public class Cyndaquil: Pokemon {



    public override string name { get; } = "Cyndaquil";
    public override string type { get; } = "Fire";

    public override string weakness { get; } = "Water";
    public override string resistance {get; } = "Grass";



    public override double Attack(){
        Console.WriteLine("Cyndaquil used Ember!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Cyndaquil ate a berry!");
        return 3 * lvl;
    }


} 