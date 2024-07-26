using System;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Repo{

public class PokemonContext : DbContext
{
   public DbSet<PlayerPokemon> PlayerPokemons { get; set; }
        public DbSet<ComputerPokemon> ComputerPokemons { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = File.ReadAllText("./connectionstring");
            optionsBuilder.UseSqlServer(ConnectionString);
        }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
            modelBuilder.Entity<PlayerPokemon>().ToTable("PlayerPokemons");
            modelBuilder.Entity<ComputerPokemon>().ToTable("ComputerPokemons");
        }
}

 public class PlayerPokemon : Pokemon { }
    public class ComputerPokemon : Pokemon { }
}
