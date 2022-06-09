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

        private string videoTriangulos = "https://www.youtube.com/watch?v=I9S1kBXLkBo";
        private string videoCuadrado = "https://www.youtube.com/watch?v=SMyYhwo9MWs";
        private string videoCirculos = "https://www.youtube.com/watch?v=eQXMPh87F4M";


        string videoActual = "https://www.youtube.com/watch?v=1Jj7H6DAuMA";

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
