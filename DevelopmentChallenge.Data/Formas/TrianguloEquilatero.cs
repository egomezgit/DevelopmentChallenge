using System;
using DevelopmentChallenge.Data.Implementaciones;

namespace DevelopmentChallenge.Data.Formas
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal lado;

        public TrianguloEquilatero(decimal lado)
        {
            this.lado = lado;
        }

        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * lado * lado;

        public decimal CalcularPerimetro() => lado * 3;

        public string Nombre => "Triángulo Equilátero";
    }

}
