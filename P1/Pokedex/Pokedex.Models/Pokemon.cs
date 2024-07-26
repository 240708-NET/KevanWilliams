namespace Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;


public class Pokemon
{


  
    public int Id {get; set;}
    
    public int lvl {get; set;}

    public int hp {get; set;}
    public int maxHp {get; set;}
    
    public string name { get; set;}
    public string type { get; set;}

    public string weakness {get; set;}

    public string resistance {get; set;}

    public string special {get; set;}

    


    public Pokemon(string name, int lvl, int hp, int maxHp, string type, string weakness, string resistance, string special ){
        this.name = name;
        this.lvl = lvl;
        this.hp = hp;
        this.maxHp = maxHp;
        this.type = type;
        this.weakness = weakness;
        this.resistance = resistance;
        this.special = special;
           

    }
    /* public Pokemon(string name, string type, string weakness, string resistance, string special ){
        this. no = no;
        this.name = name;
        this.lvl = 3;
        this.maxHp = 40;
        this.hp = 40;
        this.type = type;
        this.weakness = weakness;
        this.resistance = resistance;
           

    } */

    public Pokemon(){}


    

    public double Attack(){
        return this.lvl * 3;
    }

    public double Heal(){
        return this.lvl * 3;

    }

    public void Defend(){
        Console.WriteLine("Pokemon defended!");
    }

    public string ToString(){
        string result = "";
        result = "#" + this.Id + " "+ this.name;
        return result;
    }
    
}

