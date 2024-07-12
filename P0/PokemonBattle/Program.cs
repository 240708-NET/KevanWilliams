
class Program
{


    static void Main(string[] args)
    {


        Console.WriteLine("Starting battle!");

        List<Func<Pokemon>> userOptions = new List<Func<Pokemon>>()
        {
           () => new Charmander() ,
           () => new Pikachu(),
           () => new Squirtle(),
           () => new Pidgey(),
           () => new Bulbasaur(),
           () => new Mewtwo(),


        };

        List<Func<Pokemon>> compOptions = new List<Func<Pokemon>>()
        {
            () => new Cyndaquil() ,
            () => new Pichu() ,
            () => new Totodile() ,
            () => new Chikorita() ,
            () => new Umbreon() ,
            () => new Lucario() ,

        };




        /*  Console.WriteLine("Choose your Pokémon:");
         foreach (var option in userOptions)
         {
             if(option.Value().hp > 0){
             Console.WriteLine($"{option.Key}. {option.Value().name}");
             }
         } */


        Pokemon selectedPokemon = null;
        Pokemon compPokemon = null;

        int userDefense = 0;
        int compDefense = 0;

        int userWins = 0;
        int compWins = 0;



        while (userWins <= 6 || compWins <= 6)
        {

            if (userWins == 6)
            {
                Console.WriteLine("You won!");
                return;
            }

            if (compWins == 6)
            {
                Console.WriteLine("Rival Trainer won!");
                return;
            }



            while (selectedPokemon == null || selectedPokemon.hp <= 0)
            {
                Console.WriteLine("Choose your Pokémon:");
                for (int i = 0; i < userOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userOptions[i]().name}");
                }

                Console.Write("Enter the number of your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= userOptions.Count)
                {
                    selectedPokemon = userOptions[choice - 1]();
                    if (selectedPokemon.hp <= 0)
                    {
                        Console.WriteLine($"{selectedPokemon.name} has already fainted!");
                        selectedPokemon = null;
                    }
                    else
                    {
                        Console.WriteLine($"{selectedPokemon.name}, I choose you!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }


            Random rand = new Random();
            List<int> remaining = Enumerable.Range(1, compOptions.Count).ToList();
            int compChoice = 0;

            while (compPokemon == null || compPokemon.hp <= 0)
            {
                compChoice = rand.Next(remaining.Count);
                compPokemon = compOptions[remaining[compChoice] - 1]();
                if (compPokemon.hp > 0)
                {
                    Console.WriteLine($"Rival Trainer chooses {compPokemon.name}!");
                }
                else
                {
                    remaining.RemoveAt(compChoice);
                    compPokemon = null;
                }
            }







            while (selectedPokemon.hp > 0 && compPokemon.hp > 0)
            {
                Console.WriteLine("Select a move:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Defend");

                int moveChoice = 0;
                while (moveChoice == 0)
                {
                    Console.Write("Enter the number of your choice: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedChoice) && selectedChoice > 0 && selectedChoice <= 3)
                    {
                        moveChoice = selectedChoice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }

                if (selectedPokemon.lvl >= compPokemon.lvl)
                {
                    ExecuteMove(moveChoice, selectedPokemon, compPokemon, ref userDefense, ref compDefense, ref userWins, ref compWins, userOptions, remaining, compChoice);
                    if (compPokemon.hp > 0)
                    {
                        int compMove = rand.Next(1, 4);
                        ExecuteMove(compMove, compPokemon, selectedPokemon, ref compDefense, ref userDefense, ref compWins, ref userWins, compOptions, remaining, compChoice);
                    }
                }
                else
                {
                    int compMove = rand.Next(1, 4);
                    ExecuteMove(compMove, compPokemon, selectedPokemon, ref compDefense, ref userDefense, ref compWins, ref userWins, compOptions, remaining, compChoice);
                    if (selectedPokemon.hp > 0)
                    {
                        ExecuteMove(moveChoice, selectedPokemon, compPokemon, ref userDefense, ref compDefense, ref userWins, ref compWins, userOptions, remaining, compChoice);
                    }
                }
            }

            if (selectedPokemon.hp <= 0)
            {
                Console.WriteLine($"{selectedPokemon.name} has fainted!");
                Console.WriteLine($"{compPokemon.name} gained XP...");
                Console.WriteLine($"{compPokemon.name} grew to lvl {compPokemon.lvl}!");
                userOptions.RemoveAll(p => p().name == selectedPokemon.name);
                selectedPokemon = null;
            }

            if (compPokemon.hp <= 0)
            {
                Console.WriteLine($"{compPokemon.name} has fainted!");
                Console.WriteLine($"{selectedPokemon.name} gained XP...");
                Console.WriteLine($"{selectedPokemon.name} grew to lvl {selectedPokemon.lvl}!");
                compOptions.RemoveAll(p => p().name == compPokemon.name);
                compPokemon = null;
            }
        }
    }

    static void ExecuteMove(int moveChoice, Pokemon attacker, Pokemon defender, ref int attackerDefense, ref int defenderDefense, ref int attackerWins, ref int defenderWins, List<Func<Pokemon>> attackerOptions, List<int> defenderRemaining, int defenderChoice)
    {
        if (moveChoice == 1)
        {

            double damage = attacker.Attack();
            if (defender.weakness == attacker.type)
            {
                Console.WriteLine("It's super effective!");
                damage = (damage * 2) - defenderDefense;
            }
            else if (defender.resistance == attacker.type)
            {
                Console.WriteLine("It's not very effective...");
                damage = Math.Floor(damage / 2) - defenderDefense;
            }
            Console.WriteLine($"It did {damage} damage!");
            defender.hp -= (int)damage;
            if (defender.hp <= 0)
            {

                attacker.lvl++;
                attacker.hp += 5;
                attackerWins++;
                defenderRemaining.Remove(defenderChoice);
            }
            else
            {
                Console.WriteLine($"{defender.name} has {defender.hp} left!");
            }
            defenderDefense = 0;
        }
        else if (moveChoice == 2)
        {
            attacker.Heal();
            attacker.hp += 20; // Example heal value, replace with actual logic
            Console.WriteLine($"{attacker.name} healed 20 hp!");
            Console.WriteLine($"{attacker.name} has {attacker.hp} left!");
        }
        else if (moveChoice == 3)
        {
            Console.WriteLine($"{attacker.name} is defending!");
            attackerDefense = 3 * attacker.lvl;
        }
    }
}


