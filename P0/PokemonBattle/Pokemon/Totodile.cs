public class Totodile : Pokemon
{
    public override string name { get; } = "Totodile";
    public override string type { get; } = "Water";

    public override string weakness { get; } = "Electric";
    public override string resistance {get; } = "Fire";



     public override double Attack(){
        Console.WriteLine("Totodile used Bubble!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Totodile ate a berry!");
        return 3 * lvl;
    }

}