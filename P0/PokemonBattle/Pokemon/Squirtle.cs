public class Squirtle : Pokemon
{
    public override string name { get; } = "Squirtle";
    public override string type { get; } = "Water";

    public override string weakness { get; } = "Electric";
    public override string resistance {get; } = "Fire";



     public override double Attack(){
        Console.WriteLine("Squirtle used Water Gun!");
        Console.WriteLine("💧💧💧💧💧💧💧💧💧💧💧💧💧💧💧");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Squirtle ate a berry!");
        return 3 * lvl;
    }

}