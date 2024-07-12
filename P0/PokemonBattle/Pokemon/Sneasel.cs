public class Sneasel : Pokemon
{
    public override string name { get; } = "Sneasel";
    public override string type { get; } = "Dark";

    public override string weakness { get; } = "Fighting";
    public override string resistance {get; } = "Psychic";


     public override double Attack(){
        Console.WriteLine("Sneasel used Crunch!");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Sneasel ate a berry!");
        return 3 * lvl;
    }

}