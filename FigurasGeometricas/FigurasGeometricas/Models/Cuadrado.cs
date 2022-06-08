using System;
namespace FigurasGeometricas.Models
{
    public class Cuadrado : FiguraGeometrica
    {
        public double ladoa { get; set; }
        public double ladob { get; set; }

        public override void calcularArea()
        {
            // La formula matematica de calcular el area de un cuadrado
            // lado a x lado b
            area = ladoa * ladob;

        }

        public override void calcularPerimetro()
        {
            // La formula matematica de calcular el area de un cuadrado
            // lado a(2) + ladob(2)
            perimetro = (ladoa * 2) + (ladob * 2);
        }
    }
}
