using DevelopmentChallenge.Data.Implementaciones;

namespace DevelopmentChallenge.Data.Formas
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal lado;

        public Cuadrado(decimal lado)
        {
            this.lado = lado;
        }

        public decimal CalcularArea() => lado * lado;

        public decimal CalcularPerimetro() => lado * 4;

        public string Nombre => "Cuadrado";
    }
}
