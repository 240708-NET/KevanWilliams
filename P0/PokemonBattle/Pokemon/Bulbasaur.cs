
public class Bulbasaur: Pokemon {



    public override string name { get; } = "Bulbasaur";
    public override string type { get; } = "Grass";

    public override string weakness { get; } = "Fire";
    public override string resistance {get; } = "Water";



    public override double Attack(){
        Console.WriteLine("Bulbasaur used Razor Leaf!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Bulbasaur ate a berry!");
        return 3 * lvl;
    }


} 