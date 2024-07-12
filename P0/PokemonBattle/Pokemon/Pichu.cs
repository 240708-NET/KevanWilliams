public class Pichu : Pokemon
{
    public override string name { get; } = "Pichu";
    public override string type { get; } = "Electric";

    public override string weakness { get; } = "Ground";
    public override string resistance {get; } = "Electric";


     public override double Attack(){
        Console.WriteLine("Pichu used Thunderbolt!");
        Console.WriteLine("⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Pichu ate a berry!");
        return 3 * lvl;
    }

}