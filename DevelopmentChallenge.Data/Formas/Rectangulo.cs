using DevelopmentChallenge.Data.Implementaciones;

namespace DevelopmentChallenge.Data.Formas
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal largo;
        private readonly decimal ancho;

        public Rectangulo(decimal largo, decimal ancho)
        {
            this.largo = largo;
            this.ancho = ancho;
        }

        public decimal CalcularArea() => largo * ancho;

        public decimal CalcularPerimetro() => 2 * (largo + ancho);

        public string Nombre => "Rectángulo";
    }

}
