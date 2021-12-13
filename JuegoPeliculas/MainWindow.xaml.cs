using System.Windows;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void cargarJsonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void guardarJsonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void añadirPeliculaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void selectImagenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finPartidaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
