public class Pikachu : Pokemon
{
    public override string name { get; } = "Pikachu";
    public override string type { get; } = "Electric";

    public override string weakness { get; } = "Ground";
    public override string resistance {get; } = "Electric";


     public override double Attack(){
        Console.WriteLine("Pikachu used Thundershock!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Pikachu ate a berry!");
        return 3 * lvl;
    }

}