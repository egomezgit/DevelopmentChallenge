
namespace DevelopmentChallenge.Data.Implementaciones
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string Nombre { get; }
    }

}
