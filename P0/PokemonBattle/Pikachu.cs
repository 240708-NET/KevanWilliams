public class Pikachu : Pokemon
{
    public override string name { get; } = "Pikachu";
    public override string type { get; } = "Electric";


     public override int Attack(){
        Console.WriteLine("Pikachu used Thundershock!");
        return 5 * lvl;
    }

}