using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FigurasGeometricas.ViewModels
{
    public class ViewModelVideos : INotifyPropertyChanged
    {
        public ViewModelVideos()
        {

            CambiarVideoTriangulo = new Command( ()=> {

                VideoActual = videoTriangulos;

            } );

            CambiarVideoCirculos = new Command(() => {

                VideoActual = videoCirculos;

            });


            CambiarVideoCuadros = new Command(() => {

                VideoActual = videoCuadrado;

            });

        }

        private string videoTriangulos = "https://www.youtube.com/embed/I9S1kBXLkBo";
        private string videoCuadrado = "https://www.youtube.com/embed/SMyYhwo9MWs";
        private string videoCirculos = "https://www.youtube.com/embed/eQXMPh87F4M";


        string videoActual = "https://www.youtube.com/embed/IHHQm4MeoV0";

        public event PropertyChangedEventHandler PropertyChanged;

        public String VideoActual {
            get => videoActual;
            set {
                videoActual = value;
                var args = new PropertyChangedEventArgs(nameof(VideoActual));
                PropertyChanged?.Invoke(this, args);
            }
        }


        public Command CambiarVideoTriangulo { get; }
        public Command CambiarVideoCirculos { get; }
        public Command CambiarVideoCuadros { get; }

    }
}
