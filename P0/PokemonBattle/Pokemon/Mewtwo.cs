
public class Mewtwo: Pokemon {



    public override string name { get; } = "Mewtwo";
    public override string type { get; } = "Psychic";

    public override string weakness { get; } = "Dark";
    public override string resistance {get; } = "Psychic";



    public override double Attack(){
        Console.WriteLine("Mewtwo used Psychic!");
        Console.WriteLine("🧿🧿🧿🧿🧿🧿🧿🧿🧿🧿🧿🧿🧿🧿");
        return 5 * lvl;
    }

     public override double Heal(){
        Console.WriteLine("Mewtwo ate a berry!");
        return 3 * lvl;
    }


} 