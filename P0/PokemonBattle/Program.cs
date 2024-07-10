
class Program
{


    static void Main(string[] args)
    {


        Console.WriteLine("Starting battle!");

         Dictionary<int, Func<Pokemon>> pokemonOptions = new Dictionary<int, Func<Pokemon>>()
        {
            { 1, () => new Cyndaquil() },
            { 2, () => new Pikachu() },
            // Add more options here
        };

        Console.WriteLine("Choose your Pokémon:");
        foreach (var option in pokemonOptions)
        {
            Console.WriteLine($"{option.Key}. {option.Value().name}");
        }

        int choice = 0;
        Pokemon selectedPokemon = null;

        while (selectedPokemon == null)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && pokemonOptions.ContainsKey(choice))
            {
                selectedPokemon = pokemonOptions[choice]();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        Console.WriteLine($"{selectedPokemon.name}, I choose you!");
        

       

       int damage = selectedPokemon.Attack();
       Console.WriteLine($"It did {damage} damage!");
        selectedPokemon.Heal();
        selectedPokemon.Defend();

    }

}
