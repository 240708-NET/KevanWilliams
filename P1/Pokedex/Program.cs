using System;
using System.Collections.Generic;
using System.Linq;
using Pokedex.Repo; // Ensure this is the correct namespace for PokemonContext and Repositories
using Pokedex.Models; // Ensure this is the correct namespace for the Pokemon model

/* class Program
{
    static void Main(string[] args)
    {
        using (var context = new PokemonContext())
        {
            var playerRepository = new PlayerPokemonRepository(context);
            var computerRepository = new ComputerPokemonRepository(context);

            bool battleAgain = true;

            while (battleAgain)
            {
                Console.WriteLine("Starting battle!");

                 // Restore HP to max HP at the start of each battle
                var allPlayerPokemons = playerRepository.GetAll().ToList();
                var allComputerPokemons = computerRepository.GetAll().ToList();

                int playerLvlTotal = 0;

                foreach (var pokemon in allPlayerPokemons)
                {
                    playerLvlTotal += pokemon.lvl;
                    pokemon.hp = pokemon.maxHp;
                    playerRepository.Update(pokemon);
                }

                foreach (var pokemon in allComputerPokemons)
                {
                    pokemon.hp = pokemon.maxHp;
                    pokemon.lvl = (int) (playerLvlTotal/6);
                    computerRepository.Update(pokemon);
                }

                var playerPokemons = playerRepository.GetAll().Cast<Pokemon>().ToList();
                var computerPokemons = computerRepository.GetAll().Cast<Pokemon>().OrderBy(x => Guid.NewGuid()).Take(6).ToList();

                Pokemon selectedPokemon = null;
                Pokemon compPokemon = null;

                int userDefense = 0;
                int compDefense = 0;

                int userWins = 0;
                int compWins = 0;

                while (userWins < 6 && compWins < 6)
                {
                    if (userWins == 6)
                    {
                        Console.WriteLine("You won!");
                        break;
                    }

                    if (compWins == 6 || !computerPokemons.Any(p => p.hp > 0))
                    {
                        Console.WriteLine("Rival Trainer won!");
                        break;
                    }

                    while (selectedPokemon == null || selectedPokemon.hp <= 0)
                    {
                        Console.WriteLine("Choose your Pokémon:");
                        for (int i = 0; i < playerPokemons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {playerPokemons[i].name} (HP: {playerPokemons[i].hp})");
                        }

                        Console.Write("Enter the number of your choice: ");
                        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= playerPokemons.Count)
                        {
                            selectedPokemon = playerPokemons[choice - 1];
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
                    var remaining = Enumerable.Range(0, computerPokemons.Count).ToList();
                    int compChoice = 0;

                    while ((compPokemon == null || compPokemon.hp <= 0) && remaining.Count > 0)
                    {
                        compChoice = rand.Next(remaining.Count);
                        compPokemon = computerPokemons[remaining[compChoice]];
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

                    if (compPokemon == null)
                    {
                        Console.WriteLine("Rival Trainer has no Pokémon left!");
                        compWins = 6; // End the game
                        break;
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
                            ExecuteMove(moveChoice, selectedPokemon, compPokemon, ref userDefense, ref compDefense, ref userWins, ref compWins, playerPokemons, remaining, compChoice, playerRepository, computerRepository);
                            if (compPokemon.hp > 0)
                            {
                                int compMove = rand.Next(1, 4);
                                ExecuteMove(compMove, compPokemon, selectedPokemon, ref compDefense, ref userDefense, ref compWins, ref userWins, computerPokemons, remaining, compChoice, playerRepository, computerRepository);
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            int compMove = rand.Next(1, 4);
                            ExecuteMove(compMove, compPokemon, selectedPokemon, ref compDefense, ref userDefense, ref compWins, ref userWins, computerPokemons, remaining, compChoice, playerRepository, computerRepository);
                            if (selectedPokemon.hp > 0)
                            {
                                ExecuteMove(moveChoice, selectedPokemon, compPokemon, ref userDefense, ref compDefense, ref userWins, ref compWins, playerPokemons, remaining, compChoice, playerRepository, computerRepository);
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                            }
                        }
                    }

                    if (selectedPokemon.hp <= 0)
                    {
                        Console.WriteLine($"{selectedPokemon.name} has fainted!");
                        selectedPokemon = null;
                    }

                    if (compPokemon.hp <= 0)
                    {
                        Console.WriteLine($"{compPokemon.name} has fainted!");
                        compPokemon = null;
                    }
                }

                // Restore HP to max HP after the battle
                foreach (var pokemon in playerPokemons)
                {
                    pokemon.hp = pokemon.maxHp;
                    playerRepository.Update((PlayerPokemon)pokemon);
                }

                foreach (var pokemon in computerPokemons)
                {
                    pokemon.hp = pokemon.maxHp;
                    computerRepository.Update((ComputerPokemon)pokemon);
                }

                Console.Write("Do you want to battle again? (yes/no): ");
                var response = Console.ReadLine().Trim().ToLower();
                if (response != "yes")
                {
                    battleAgain = false;
                }
            }
        }
    }

    static void ExecuteMove(int moveChoice, Pokemon attacker, Pokemon defender, ref int attackerDefense, ref int defenderDefense, ref int attackerWins, ref int defenderWins, List<Pokemon> attackerOptions, List<int> defenderRemaining, int defenderChoice, PlayerPokemonRepository playerRepository, ComputerPokemonRepository computerRepository)
    {
        if (moveChoice == 1)
        {
            double damage = attacker.Attack();
            Console.WriteLine($"{attacker.name} used {attacker.special}!");
            Console.WriteLine($"{GetEmoji(attacker.type)}");
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
                Console.WriteLine($"{attacker.name} earned XP...");
                Console.WriteLine($"{attacker.name} grew to lvl {attacker.lvl}");
                attacker.maxHp += 5;
                attackerWins++;
                defenderRemaining.Remove(defenderChoice);

                // Update level and max HP in the database
                if (attacker is PlayerPokemon playerPokemon)
                {
                    playerRepository.Update(playerPokemon);
                }
                else if (attacker is ComputerPokemon computerPokemon)
                {
                    computerRepository.Update(computerPokemon);
                }
            }
            else
            {
                Console.WriteLine($"{defender.name} has {defender.hp} left!");
            }
            defenderDefense = 0;
        }
        else if (moveChoice == 2)
        {
            double healed = attacker.Heal();
            attacker.hp += (int) healed; // Example heal value, replace with actual logic
            if (attacker.hp > attacker.maxHp)
            {
                attacker.hp = attacker.maxHp;
            }
            Console.WriteLine($"{attacker.name} healed {healed} hp!");
            Console.WriteLine($"{attacker.name} has {attacker.hp} left!");

            // Update HP in the database
            if (attacker is PlayerPokemon playerPokemon)
            {
                playerRepository.Update(playerPokemon);
            }
            else if (attacker is ComputerPokemon computerPokemon)
            {
                computerRepository.Update(computerPokemon);
            }
        }
        else if (moveChoice == 3)
        {
            Console.WriteLine($"{attacker.name} is defending!");
            attackerDefense = 3 * attacker.lvl;
        }
    }

  
    static string GetEmoji(string atype)
{
    switch (atype)
    {
        case "Grass":
            return "🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿";
        case "Fire":
            return "🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥";
        case "Water":
            return "💧💧💧💧💧💧💧💧💧💧💧💧💧";
        case "Normal":
            return "🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾";
        case "Flying":
            return "🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️🕊️";
        case "Bug":
            return "🐛🐛🐛🐛🐛🐛🐛🐛🐛🐛🐛🐛🐛";
        case "Poison":
            return "☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️";
        case "Electric":
            return "⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡";
        case "Fairy":
            return "✨✨✨✨✨✨✨✨✨✨✨✨✨";
        case "Psychic":
            return "🔮🔮🔮🔮🔮🔮🔮🔮🔮🔮🔮🔮🔮";
        case "Rock":
            return "🪨🪨🪨🪨🪨🪨🪨🪨🪨🪨🪨🪨🪨";
        case "Ground":
            return "🌍🌍🌍🌍🌍🌍🌍🌍🌍🌍🌍🌍🌍";
        case "Steel":
            return "🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️🛡️";
        case "Dark":
            return "🌑🌑🌑🌑🌑🌑🌑🌑🌑🌑🌑🌑🌑";
        case "Ghost":
            return "👻👻👻👻👻👻👻👻👻👻👻👻👻";
        case "Ice":
            return "❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️❄️";
        case "Fighting":
            return "🥊🥊🥊🥊🥊🥊🥊🥊🥊🥊🥊🥊🥊";
        default:
            return "❓❓❓❓❓❓❓❓❓❓❓❓❓"; // Default case for unknown types
    }
}
}
    */


    class Program
{
    static void Main(string[] args)
    {
        using (var context = new PokemonContext())
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            var playerRepository = new PlayerPokemonRepository(context);
            var computerRepository = new ComputerPokemonRepository(context);

            // Read and add Computer Pokémon from the text file
            string filePath = "computer_pokemons.txt"; // Make sure this path is correct

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 8)
                    {
                        var pokemon = new ComputerPokemon
                        {
                            name = parts[0],
                            type = parts[1],
                            lvl = int.Parse(parts[2]),
                            maxHp = int.Parse(parts[3]),
                            hp = int.Parse(parts[4]),
                            weakness = parts[5],
                            resistance = parts[6],
                            special = parts[7]
                        };
                        computerRepository.Add(pokemon);
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }

            // List all Computer Pokémon
            var computerPokemons = computerRepository.GetAll();
            Console.WriteLine("Computer Pokémon:");
            foreach (var pokemon in computerPokemons)
            {
                Console.WriteLine($"{pokemon.name} ({pokemon.type}) - Level: {pokemon.lvl}, HP: {pokemon.hp}, Special: {pokemon.special}");
            }

            // Other operations (e.g., playerRepository)...
        }
    }
}