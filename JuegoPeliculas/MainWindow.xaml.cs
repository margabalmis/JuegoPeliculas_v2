using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void CargarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CargarJson();
        }

        private void GuardarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            vm.GuardarJson();
        }

        private void AñadirPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirPelicula();
        }

        private void EditarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EditarPelicula();
        }

        private void EliminarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarPelicula();
        }

        private void SelectImagenButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SeleccionarImagen();
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.NuevaPartida();
        }

        private void FinPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.FinPartida();
        }


    }
}
