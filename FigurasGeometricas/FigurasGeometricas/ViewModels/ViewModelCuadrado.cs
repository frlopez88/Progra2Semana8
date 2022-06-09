using System;
using System.ComponentModel;
using FigurasGeometricas.Models;
using Xamarin.Forms;

namespace FigurasGeometricas.ViewModels
{
    public class ViewModelCuadrado : INotifyPropertyChanged
    {





        public ViewModelCuadrado()
        {

            Crear = new Command( ()=> {

                C1.calcularArea();
                C1.calcularPerimetro();
                C1 = C1;
                    
            } );

        }


        Cuadrado c1 = new Cuadrado();
        public Cuadrado C1
        {
            get => c1;
            set
            {

                c1 = value;
                var args = new PropertyChangedEventArgs(nameof(C1));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Crear { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
