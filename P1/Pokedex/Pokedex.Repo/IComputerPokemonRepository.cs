using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


using Pokedex.Models;
namespace Pokedex.Repo;

public interface IComputerPokemonRepository
{
    IEnumerable<ComputerPokemon> GetAll();
    ComputerPokemon GetById(int id);
    
    void Add(ComputerPokemon pokemon);
    void Update(ComputerPokemon pokemon);
    void Delete(int id);
}

public class ComputerPokemonRepository : IComputerPokemonRepository
{
    private readonly PokemonContext _context;

    public ComputerPokemonRepository(PokemonContext context)
    {
        _context = context;
    }

    public IEnumerable<ComputerPokemon> GetAll()
    {
        return _context.ComputerPokemons.ToList();
    }

    public ComputerPokemon GetById(int id)
    {
        return _context.ComputerPokemons.Find(id);
    }
   

   public void Add(ComputerPokemon pokemon)
        {
            
            _context.ComputerPokemons.Add(pokemon);
            _context.SaveChanges();
            
        }


    public void Update(ComputerPokemon pokemon)
    {
        _context.ComputerPokemons.Update(pokemon);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var pokemon = _context.ComputerPokemons.Find(id);
        if (pokemon != null)
        {
            _context.ComputerPokemons.Remove(pokemon);
            _context.SaveChanges();
        }
    }
}