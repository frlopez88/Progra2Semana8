using System;
namespace FigurasGeometricas.Models
{
    public class FiguraGeometrica
    {
        public double perimetro { get; set; }
        public double area { get; set; }


        public virtual void calcularPerimetro()
        {
            perimetro = 0;
        }

        public virtual void calcularArea()
        {
            area = 0;
        }
    }
}
