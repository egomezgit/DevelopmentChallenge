using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.enums;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Implementaciones;

using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            //Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
            //    FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<Cuadrado>(), Idioma.es));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
           
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
               FormaGeometrica.Imprimir(new List<Cuadrado>(), Idioma.en));
        }

        
        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<Cuadrado>(), Idioma.it));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            

            var cuadrados = new List<Cuadrado> { new Cuadrado(5) };

            
            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.es);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<Cuadrado>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.en);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.en);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52.03 |" +
                " Perimeter 36.13 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 115.73 Area 130.67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.es);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 52,03 " +
                "| Perímetro 36,13 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 115,73 Area 130,67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
   
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.it);

            Assert.AreEqual(
                "<h1>Rapporto di Forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 52,03 " +
                "| Perimetro 36,13 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 115,73 Area 130,67",
                resumen);

        }

        [TestCase]
        public void TestResumenListaConMasTrapecios()
        {
            var trapecios = new List<Trapecio>
            {
                new Trapecio(5, 3, 4),
                new Trapecio(1, 2, 3),
                new Trapecio(3, 4, 5)
            };

            var resumen = FormaGeometrica.Imprimir(trapecios, Idioma.en);

            Assert.AreEqual("<h1>Shapes report</h1>3 Trapezoids | Area 38 | Perimeter 42.38 <br/>TOTAL:<br/>3 shapes Perimeter 42.38 Area 38", resumen);
        }

        //generame un test que valide que si le paso una lista con 3 rectangulos, me devuelva el resumen correcto

        [TestCase]
        public void TestResumenListaConMasRectangulos()
        {
            var rectangulos = new List<Rectangulo>
            {
                new Rectangulo(5, 3),
                new Rectangulo(1, 2),
                new Rectangulo(3, 4)
            };

            var resumen = FormaGeometrica.Imprimir(rectangulos, Idioma.en);

            Assert.AreEqual("<h1>Shapes report</h1>3 Rectangles | Area 29 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 29", resumen);
        }

     


    }
}
