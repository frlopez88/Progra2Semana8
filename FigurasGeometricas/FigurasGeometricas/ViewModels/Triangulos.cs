using System;
using System.ComponentModel;
using FigurasGeometricas.Models;
using Xamarin.Forms;

namespace FigurasGeometricas.ViewModels
{
    public class Triangulos : INotifyPropertyChanged
    {
        public Triangulos()
        {

            Crear = new Command( ()=> {

                T.calcularArea();
                T.calcularPerimetro();
                T = T;
            } );

        }

        Triangulo t = new Triangulo();
        public Triangulo T {
            get => t;
            set {

                t = value;
                var args = new PropertyChangedEventArgs(nameof(T));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Crear { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
