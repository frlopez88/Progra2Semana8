using System;
using System.ComponentModel;
using Xamarin.Forms;
using FigurasGeometricas.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FigurasGeometricas.ViewModels
{
    public class ViewModelCirculo : INotifyPropertyChanged
    {
        

        public ViewModelCirculo()
        {
            CrearCirculo = new Command(
                    ()=>{

                        C1.calcularArea();
                        C1.calcularPerimetro();
                        C1 = C1;

                        BinaryFormatter formatter = new BinaryFormatter();
                        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Circulo.aut");
                        Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(archivo, C1);
                        archivo.Close();

                    }
                );

            Abrir = new Command(()=> {


                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Circulo.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                C1 = (Circulo)formatter.Deserialize(archivo);
                archivo.Close();


            });


        }



        Circulo c1 = new Circulo();
        public Circulo C1
        {
            get => c1;
            set
            {

                c1 = value;
                var args = new PropertyChangedEventArgs(nameof(C1));
                PropertyChanged?.Invoke(this, args);

            }
        }

       

        public Command CrearCirculo { get; }
        public Command Abrir { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
