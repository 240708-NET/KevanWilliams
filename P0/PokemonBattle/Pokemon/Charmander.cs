
public class Charmander: Pokemon {



    public override string name { get; } = "Charmander";
    public override string type { get; } = "Fire";

    public override string weakness { get; } = "Water";
    public override string resistance {get; } = "Grass";



    public override double Attack(){
        Console.WriteLine("Charmander used Flamethrower!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Charmander ate a berry!");
        return 3 * lvl;
    }


} 