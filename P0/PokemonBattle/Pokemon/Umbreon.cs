public class Umbreon : Pokemon
{
    public override string name { get; } = "Umbreon";
    public override string type { get; } = "Dark";

    public override string weakness { get; } = "Fighting";
    public override string resistance {get; } = "Psychic";


     public override double Attack(){
        Console.WriteLine("Umbreon used Curse!");
        Console.WriteLine("😈😈😈😈😈😈😈😈😈😈😈😈😈");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Umbreon ate a berry!");
        return 3 * lvl;
    }

}