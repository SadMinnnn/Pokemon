namespace Actividad.Class;

using System;
using System.Linq;
public class Pokemon : IPokemones
{
    private List<PokemonDTO> BD;

    public Pokemon()
    {
        this.BD = new List<PokemonDTO>();
    }

    public void Add(PokemonDTO Pokemon)
    {
        this.BD.Add(Pokemon);
    }

    public void Delete(string nombre)
    {
        this.BD.RemoveAll(pokemon => pokemon.Nombre == nombre);
    }

    public void Update(string nombre, PokemonDTO Pokemon)
    {
        PokemonDTO pokeUpdate = this.BD.Single(pokemon => pokemon.Nombre == nombre);
        pokeUpdate = Pokemon;
    }

    public List<PokemonDTO> GetByType(string tipo)
    {
        return this.BD.Where(pokemon => pokemon.Tipo == tipo).ToList();
    }

    public List<PokemonDTO> GetByName(string nombre)
    {
        return this.BD.Where(pokemon => pokemon.Nombre == nombre).ToList();
    }

    public List<PokemonDTO> All()
    {
        return this.BD;
    }

}