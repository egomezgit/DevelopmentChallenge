using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Implementaciones;
using DevelopmentChallenge.Data.Resource;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;


namespace DevelopmentChallenge.Data.Reporte
{
    public class ReporteFormas
    {
        private readonly IEnumerable<IFormaGeometrica> formas;
        private readonly IdiomaReporte idioma;
        public ReporteFormas(IEnumerable<IFormaGeometrica> formas, IdiomaReporte idioma)
        {
            this.formas = formas;
            this.idioma = idioma;
        }

        public static string GenerarReporte(IEnumerable<IFormaGeometrica> formas, IdiomaReporte idioma)
        {
            // Implementación del reporte utilizando StringBuilder y el idioma seleccionado

            CultureInfo ci = new CultureInfo(idioma.ToString());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            // Ahora, cuando accedas a los recursos, se utilizará el idioma seleccionado


            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{FormasGeometricas.ListaVacia}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{FormasGeometricas.ReporteDeFormas}</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;


                foreach (var forma in formas)
                {
                    if (forma.Nombre == "Cuadrado")
                    {
                        numeroCuadrados++;
                        areaCuadrados += forma.CalcularArea();
                        perimetroCuadrados += forma.CalcularPerimetro();

                    }
                    if (forma.Nombre == "Círculo")
                    {
                        numeroCirculos++;
                        areaCirculos += forma.CalcularArea();
                        perimetroCirculos += forma.CalcularPerimetro();
                    }
                    if (forma.Nombre == "Triángulo Equilátero")
                    {
                        numeroTriangulos++;
                        areaTriangulos += forma.CalcularArea();
                        perimetroTriangulos += forma.CalcularPerimetro();
                    }

                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, typeof(Cuadrado).Name));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, typeof(Circulo).Name));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, typeof(TrianguloEquilatero).Name));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + $"{FormasGeometricas.Formas}" + " ");
                sb.Append($"{FormasGeometricas.Perimetro} " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();

        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | {FormasGeometricas.Area} {area:#.##} | {FormasGeometricas.Perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(string tipo, int cantidad)
        {
            switch (tipo)
            {
                case "Cuadrado":
                    return cantidad == 1 ? FormasGeometricas.Cuadrado : FormasGeometricas.Cuadrados;
                case "Circulo":
                    return cantidad == 1 ? FormasGeometricas.Circulo : FormasGeometricas.Circulos;
                case "TrianguloEquilatero":
                    return cantidad == 1 ? FormasGeometricas.Triangulo : FormasGeometricas.Triangulos;
            }

            return string.Empty;
        }
    }
}
