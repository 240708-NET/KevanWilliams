
public class Cyndaquil: Pokemon {



    public override string name { get; } = "Cyndaquil";
    public override string type { get; } = "Fire";


    public override int Attack(){
        Console.WriteLine("Cyndaquil used Ember!");
        return 5 * lvl;
    }


} 