using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Pokemon {

    public int lvl {get; set;} = 3;
    public int hp {get; set;} = 100;

    public abstract string name { get; }
    public abstract string type { get; }

    public abstract string weakness {get;}

    public abstract string resistance {get;}





    

    public abstract double Attack();

    public abstract double Heal();

    public void Defend(){
        Console.WriteLine("Pokemon defended!");
    }
    
}