namespace Actividad.Class;
using System.Linq;

public class PokemonDTO
{

    public string Nombre { set; get; }
    public string Tipo { set; get; }
    public string[] Habilidades { set; get; }
    public int[] PoderHabilidad { set; get; }
    public double Defensa { set; get; }

}