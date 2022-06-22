using System;
using System.ComponentModel;
using Xamarin.Forms;
using FigurasGeometricas.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;

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
                        Circulo tmp = new Circulo()
                        {

                            radio = C1.radio
                        };

                        tmp.calcularArea();
                        tmp.calcularPerimetro();

                        if (lista.Count == 0)
                        {
                            lista.Add(tmp);
                        }else
                        {
                            bool existia = false;
                            for (int i = 0; i < lista.Count; i++)
                            {

                                if (C1.radio == lista[i].radio)
                                {
                                    C1.radio = lista[i].radio;
                                    C1.area = lista[i].area;
                                    C1.perimetro  = lista[i].perimetro;
                                    C1 = C1;
                                    existia = true;                                     
                                }
                            }

                            if (existia == false)
                            {
                                lista.Add(tmp);
                            }

                        }

                        

                        

                        BinaryFormatter formatter = new BinaryFormatter();
                        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Circulo.aut");
                        Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(archivo, lista);
                        archivo.Close();


                        CantidadRegistros = lista.Count;
                    }
                );

            Abrir = new Command(()=> {


                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Circulo.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                lista = (ObservableCollection<Circulo>)formatter.Deserialize(archivo);
                archivo.Close();

                CantidadRegistros = lista.Count;

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

        ObservableCollection<Circulo> lista = new ObservableCollection<Circulo>();


        int cantidadRegistros;

        public int CantidadRegistros { get => cantidadRegistros;

            set {

                cantidadRegistros = value;
                var args = new PropertyChangedEventArgs(nameof(CantidadRegistros));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command CrearCirculo { get; }
        public Command Abrir { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
