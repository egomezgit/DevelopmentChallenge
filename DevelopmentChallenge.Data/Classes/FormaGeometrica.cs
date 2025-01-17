﻿/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.enums;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Implementaciones;
using DevelopmentChallenge.Data.Resource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        private readonly IEnumerable<IFormaGeometrica> formas;
        private readonly Idioma idioma;
        public FormaGeometrica(IEnumerable<IFormaGeometrica> formas, Idioma idioma)
        {
            this.formas = formas;
            this.idioma = idioma;
        }

        public static string Imprimir(IEnumerable<IFormaGeometrica> formas, Idioma idioma)
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
                var numeroTrapecios = 0;
                var numeroRectangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecios = 0m;
                var areaRectangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecios = 0m;
                var perimetroRectangulos = 0m;

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

                    if (forma.Nombre == "Trapecio")
                    {
                        numeroTrapecios++;
                        areaTrapecios += forma.CalcularArea();
                        perimetroTrapecios += forma.CalcularPerimetro();
                    }

                    if (forma.Nombre == "Rectángulo")
                    {
                        numeroRectangulos++;
                        areaRectangulos += forma.CalcularArea();
                        perimetroRectangulos += forma.CalcularPerimetro();
                    }

                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, typeof(Cuadrado).Name));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, typeof(Circulo).Name));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, typeof(TrianguloEquilatero).Name));
                sb.Append(ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, typeof(Trapecio).Name));
                sb.Append(ObtenerLinea(numeroRectangulos, areaRectangulos, perimetroRectangulos, typeof(Rectangulo).Name));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + numeroRectangulos + " " + $"{FormasGeometricas.Formas}" + " ");
                sb.Append($"{FormasGeometricas.Perimetro} " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecios + perimetroRectangulos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTrapecios + areaRectangulos).ToString("#.##"));
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
                case "Trapecio":
                    return cantidad == 1 ? FormasGeometricas.Trapecio : FormasGeometricas.Trapecios;
                case "Rectangulo":
                    return cantidad == 1 ? FormasGeometricas.Rectangulo : FormasGeometricas.Rectangulos;
            }

            return string.Empty;
        }
    }
}
