class Program {

static void Main(string[] args){
Console.WriteLine("Hello, World!");

int count = 0;
Random rand = new Random();
int target = rand.Next(1001);
int guess;
do{
count++;
guess = rand.Next(1001);

if(guess == target)
{
Console.WriteLine($"The secret number was {target}. It took {count} tries to guess.");
}
} while (guess != target);

Console.WriteLine("Exiting program!");
}
}
