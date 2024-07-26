using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pokedex.Models;
namespace Pokedex.Repo;

public interface IPlayerPokemonRepository
{
    IEnumerable<PlayerPokemon> GetAll();
    PlayerPokemon GetById(int id);
   
    void Add(PlayerPokemon pokemon);
    void Update(PlayerPokemon pokemon);
    void Delete(int id);
}

public class PlayerPokemonRepository : IPlayerPokemonRepository
{
    private readonly PokemonContext _context;

    public PlayerPokemonRepository(PokemonContext context)
    {
        _context = context;
    }

    public IEnumerable<PlayerPokemon> GetAll()
    {
        return _context.PlayerPokemons.ToList();
    }

    public PlayerPokemon GetById(int id)
    {
        return _context.PlayerPokemons.Find(id);
    }
   

     public void Add(PlayerPokemon pokemon)
        {
           
            _context.PlayerPokemons.Add(pokemon);
            _context.SaveChanges();
            
        }


    public void Update(PlayerPokemon pokemon)
    {
        _context.PlayerPokemons.Update(pokemon);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var pokemon = _context.PlayerPokemons.Find(id);
        if (pokemon != null)
        {
            _context.PlayerPokemons.Remove(pokemon);
            _context.SaveChanges();
        }
    }
}