using System;
using DevelopmentChallenge.Data.Implementaciones;

namespace DevelopmentChallenge.Data.Formas
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal radio;

        public Circulo(decimal radio)
        {
            this.radio = radio;
        }

        public decimal CalcularArea() => (decimal)Math.PI * radio * radio;

        public decimal CalcularPerimetro() => 2 * (decimal)Math.PI * radio;

        public string Nombre => "Círculo";
    }
}
