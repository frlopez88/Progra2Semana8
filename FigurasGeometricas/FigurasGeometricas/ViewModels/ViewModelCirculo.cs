using System;
using System.ComponentModel;
using Xamarin.Forms;
using FigurasGeometricas.Models;

namespace FigurasGeometricas.ViewModels
{
    public class ViewModelCirculo : INotifyPropertyChanged
    {
        private Circulo c = new Circulo();

        public ViewModelCirculo()
        {
            CrearCirculo = new Command(
                    ()=>{

                        c = new Circulo() {
                            radio = Radio
                        };
                        c.calcularArea();
                        c.calcularPerimetro();

                        Area = c.area;
                        Perimetro = c.perimetro;

                    }
                );


        }

        double radio;
        public double Radio {
            get => radio;
            set {

                radio = value;
                var args = new PropertyChangedEventArgs(nameof(Radio));
                PropertyChanged?.Invoke(this, args);

            }
        }

        double area;
        public double Area
        {
            get => area;
            set
            {

                area = value;
                var args = new PropertyChangedEventArgs(nameof(Area));
                PropertyChanged?.Invoke(this, args);

            }
        }

        double perimetro;
        public double Perimetro
        {
            get => perimetro;
            set
            {

                perimetro = value;
                var args = new PropertyChangedEventArgs(nameof(Perimetro));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command CrearCirculo { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
