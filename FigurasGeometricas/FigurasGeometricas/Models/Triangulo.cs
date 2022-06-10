using System;
namespace FigurasGeometricas.Models
{

    [Serializable]
    public class Triangulo : FiguraGeometrica
    {
        public double ladoa { get; set; }
        private double altura { get; set; }

        private void calcularAltura()
        {

            altura = ladoa * (Math.Sqrt(3.00) / 2.00);

        }

        public double GetAltura()
        {
            return altura;
        }

        public override void calcularPerimetro()
        {
            perimetro = 3 * ladoa;
        }

        public override void calcularArea()
        {
            area = Math.Pow(ladoa, 2) * (Math.Sqrt(3.00) / 4.00);
        }

        public void calcularAreaAltura()
        {
            calcularAltura();

            area = Math.Pow(altura, 2) * (Math.Sqrt(3.00) / 3.00);
        }
    }
}
