
public class Chikorita: Pokemon {



    public override string name { get; } = "Chikorita";
    public override string type { get; } = "Grass";

    public override string weakness { get; } = "Fire";
    public override string resistance {get; } = "Water";



    public override double Attack(){
        Console.WriteLine("Chikorita used Vine Whip!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Chikorita ate a berry!");
        return 3 * lvl;
    }


} 