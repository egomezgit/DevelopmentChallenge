using DevelopmentChallenge.Data.Implementaciones;
using System;

namespace DevelopmentChallenge.Data.Formas
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly decimal baseMenor;
        private readonly decimal baseMayor;
        private readonly decimal altura;

        public Trapecio(decimal baseMenor, decimal baseMayor, decimal altura)
        {
            this.baseMenor = baseMenor;
            this.baseMayor = baseMayor;
            this.altura = altura;
        }

        public decimal CalcularArea() => ((baseMenor + baseMayor) / 2) * altura;

        public decimal CalcularPerimetro()
        {
            // Necesitaríamos los lados no paralelos para un cálculo exacto, asumiendo lados iguales por simplicidad
            var lado = (decimal)Math.Sqrt(Math.Pow((double)(baseMayor - baseMenor) / 2, 2) + Math.Pow((double)altura, 2));
            return baseMenor + baseMayor + 2 * lado;
        }

        public string Nombre => "Trapecio";
    }

}
