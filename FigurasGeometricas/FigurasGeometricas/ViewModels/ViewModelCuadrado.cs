using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Cuadros.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None  );
                formatter.Serialize(archivo, C1);
                archivo.Close();

            } );


            Abrir = new Command( ()=> {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Cuadros.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                Cuadrado C1 = (Cuadrado)formatter.Deserialize(archivo);

                archivo.Close();

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

        public Command Abrir { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
