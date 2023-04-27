namespace Actividad.Class;
using System.Linq;
interface IPokemones
{
    void Add(PokemonDTO Pokemon);
    void Delete(string nombre);
    void Update(string nombre, PokemonDTO Pokemon);
    List<PokemonDTO> GetByType(string tipo);
    List<PokemonDTO> GetByName(string nombre);
    List<PokemonDTO> All();


}