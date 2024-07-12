
public class Pidgey: Pokemon {



    public override string name { get; } = "Pidgey";
    public override string type { get; } = "Flying";

    public override string weakness { get; } = "Electric";
    public override string resistance {get; } = "Ground";



    public override double Attack(){
        Console.WriteLine("Pidgey used Gust!");
        Console.WriteLine("🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️🌪️");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Pidgey ate a berry!");
        return 3 * lvl;
    }


} 