
class Program
{


    static void Main(string[] args)
    {


        Console.WriteLine("Starting battle!");

         Dictionary<int, Func<Pokemon>> userOptions = new Dictionary<int, Func<Pokemon>>()
        {
            { 1, () => new Charmander() },
            { 2, () => new Pikachu() },
            { 3, () => new Squirtle() },
            { 4, () => new Pidgey() },
            { 5, () => new Bulbasaur() },
            { 6, () => new Mewtwo() },
           
           
        };

         Dictionary<int, Func<Pokemon>> compOptions = new Dictionary<int, Func<Pokemon>>()
        {
            { 1, () => new Cyndaquil() },
            { 2, () => new Pichu() },
            { 3, () => new Totodile() },
            { 4, () => new Chikorita() },
            { 5, () => new Sneasel() },
            { 6, () => new Lucario() },
           
        };

      
     

        Console.WriteLine("Choose your Pokémon:");
        foreach (var option in userOptions)
        {
            if(option.Value().hp > 0){
            Console.WriteLine($"{option.Key}. {option.Value().name}");
            }
        }

        int choice = 0;
        Pokemon selectedPokemon = null;
       Pokemon compPokemon = null;

       int userDefense = 0;
       int compDefense = 0;

       int userWins = 0;
       int compWins = 0;


      
       while(userWins <= 6 || compWins <= 6){

         if(userWins == 6){
        Console.WriteLine("You won!");
        return;
       }

       if(compWins == 6){
        Console.WriteLine("Rival Trainer won!");
        return;
       }

       

        while (selectedPokemon == null || selectedPokemon.hp <= 0)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && userOptions.ContainsKey(choice))
            {
                if(userOptions[choice]().hp <= 0)
                {
                     Console.WriteLine($"{userOptions[choice]().name} has already fainted!");
                } 
                else 
                {
                     selectedPokemon = userOptions[choice]();
                      Console.WriteLine($"{selectedPokemon.name}, I choose you!");
                }
               
               
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        
        }

       
        
        Random rand = new Random();
        int compChoice = rand.Next(1, 7);

        while(compPokemon == null || compPokemon.hp <= 0){
            if (compOptions[compChoice]().hp <= 0)
            {
                continue;
            } 
            
            else 
            {
                 compPokemon = compOptions[compChoice]();
                  Console.WriteLine($"Rival Trainer chooses {compPokemon.name}!");
            }
             
        }


        


        

      
       while(selectedPokemon.hp > 0 && compPokemon.hp > 0){


          Console.WriteLine("Select a move:");
       
           
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Defend");
          
       

        int moveChoice = 0;
        int compMove;
        int selectedChoice;

         while (moveChoice == 0)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out selectedChoice) && selectedChoice > 0 && selectedChoice <=3)
            {
                
                moveChoice = selectedChoice;
                
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

      if(selectedPokemon.lvl >= compPokemon.lvl)
      {

        if(moveChoice == 1){
              double damage = selectedPokemon.Attack();
       if(compPokemon.weakness == selectedPokemon.type){
        Console.WriteLine("It's super effective!");
        damage = (damage * 2) - compDefense;
       } else if (compPokemon.resistance == selectedPokemon.type){
        Console.WriteLine("It's not very effective...");
        damage = Math.Floor(damage/2) - compDefense;
       }
       Console.WriteLine($"It did {damage} damage!");
       compPokemon.hp -= (int) damage ;
       if(compPokemon.hp <= 0){
        Console.WriteLine($"{compPokemon} has fainted!");
        selectedPokemon.lvl++;
        selectedPokemon.hp += 5;
        userWins++;
        
        
       } else {
         Console.WriteLine($"{compPokemon} has {compPokemon.hp} left!");
       }

       compDefense = 0;
      

        } else if(moveChoice == 2){
             double health = selectedPokemon.Heal();
        selectedPokemon.hp += (int) health;
         Console.WriteLine($"{selectedPokemon} healed {health} hp!");
         Console.WriteLine($"{selectedPokemon} has {selectedPokemon.hp} left!");

        } else if(moveChoice == 3){
            Console.WriteLine($"{selectedPokemon} is defending!");
            userDefense = 3 * selectedPokemon.lvl;

        }
      

      compMove = rand.Next(1, 3);

       if(compMove == 1){
        double cdamage = compPokemon.Attack();
        if(selectedPokemon.weakness == compPokemon.type){
        Console.WriteLine("It's super effective!");
        cdamage = (cdamage * 2) - userDefense;
       } else if (selectedPokemon.resistance == compPokemon.type){
        Console.WriteLine("It's not very effective...");
        cdamage = Math.Floor(cdamage/2) - userDefense;
       }
       Console.WriteLine($"It did {cdamage} damage!");
       selectedPokemon.hp -= (int) cdamage ;
       if(selectedPokemon.hp <= 0){
        Console.WriteLine($"{selectedPokemon} has fainted!");
        compPokemon.lvl++;
        compPokemon.hp += 5;
        compWins++;
        
       } else {
         Console.WriteLine($"{selectedPokemon} has {selectedPokemon.hp} left!");
       }

       userDefense = 0;

       } else if (compMove == 2){
        double health = compPokemon.Heal();
        compPokemon.hp += (int) health;
         Console.WriteLine($"{compPokemon} healed {health} hp!");
         Console.WriteLine($"{compPokemon} has {compPokemon.hp} left!");


       
       } else if (compMove == 3){
        
         Console.WriteLine($"{compPokemon} is defending!");
          compDefense = 3 * compPokemon.lvl;
        

       }


      } else {

        

        compMove = rand.Next(1, 3);

       if(compMove == 1){
        double cdamage = compPokemon.Attack();
        if(selectedPokemon.weakness == compPokemon.type){
        Console.WriteLine("It's super effective!");
        cdamage = cdamage - userDefense;
       } else if (selectedPokemon.resistance == compPokemon.type){
        Console.WriteLine("It's not very effective...");
        cdamage = Math.Floor(cdamage/2) - userDefense;
       }
       Console.WriteLine($"It did {cdamage} damage!");
       selectedPokemon.hp -= (int) cdamage ;
       if(selectedPokemon.hp <= 0){
        Console.WriteLine($"{selectedPokemon} has fainted!");
        compPokemon.lvl++;
        compPokemon.hp += 5;
        compWins++;
        
       } else {
         Console.WriteLine($"{selectedPokemon} has {selectedPokemon.hp} left!");
       }

       userDefense = 0;

       } else if (compMove == 2){
        double health = compPokemon.Heal();
        compPokemon.hp += (int) health;
         Console.WriteLine($"{compPokemon} healed {health} hp!");
         Console.WriteLine($"{compPokemon} has {compPokemon.hp} left!");


       
       } else if (compMove == 3){
        
         Console.WriteLine($"{compPokemon} is defending!");
          compDefense = 3 * compPokemon.lvl;
        

       }

        if(moveChoice == 1){
              double damage = selectedPokemon.Attack();
       if(compPokemon.weakness == selectedPokemon.type){
        Console.WriteLine("It's super effective!");
        damage = (damage * 2) - compDefense;
       } else if (compPokemon.resistance == selectedPokemon.type){
        Console.WriteLine("It's not very effective...");
        damage = Math.Floor(damage/2) - compDefense;
       }
       Console.WriteLine($"It did {damage} damage!");
       compPokemon.hp -= (int) damage ;
       if(compPokemon.hp <= 0){
        Console.WriteLine($"{compPokemon} has fainted!");
        selectedPokemon.lvl++;
        selectedPokemon.hp += 5;
        userWins++;
        

        
       } else {
         Console.WriteLine($"{compPokemon} has {compPokemon.hp} left!");
       }

       compDefense = 0;
      

        } else if(moveChoice == 2){
             double health = selectedPokemon.Heal();
        selectedPokemon.hp += (int) health;
         Console.WriteLine($"{selectedPokemon} healed {health} hp!");
         Console.WriteLine($"{selectedPokemon} has {selectedPokemon.hp} left!");

        } else if(moveChoice == 3){
            Console.WriteLine($"{selectedPokemon} is defending!");
            userDefense = 3 * selectedPokemon.lvl;

        }
      



      
      }
      moveChoice = 0;
      

      

       

       }

       }
       
       


    }

}
