
public class Lucario: Pokemon {



    public override string name { get; } = "Lucario";
    public override string type { get; } = "Fighting";

    public override string weakness { get; } = "Psychic";
    public override string resistance {get; } = "Normal";



    public override double Attack(){
        Console.WriteLine("Lucario used Double Kick!");
        Console.WriteLine("👊👊👊👊👊👊👊👊👊👊👊👊👊👊👊");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Lucario ate a berry!");
        return 3 * lvl;
    }


} 