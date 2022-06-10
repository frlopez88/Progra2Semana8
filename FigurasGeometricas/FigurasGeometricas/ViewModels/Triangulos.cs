using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Triangulo.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, T);
                archivo.Close();

            } );

            Abrir = new Command( ()=> {


                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Triangulo.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                T  = (Triangulo)formatter.Deserialize(archivo);

                archivo.Close();

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

        public Command Crear { get;  }

        public Command Abrir { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
