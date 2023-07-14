using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WPF_music_player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //TODO criar o movimento da bola que representa a duração
            // StartMovingAnimation(); 
        }

        private void Play_Click(object sender, RoutedEventArgs e) { // Evento que lida com click para play, stop, next e previous. Falta ajustar para cada botão, mas está funcionando o clique
            
            Button button = (Button)sender;
            button.Background = button.Background is SolidColorBrush solidColorBrush && solidColorBrush.Color == Colors.Black? Brushes.Transparent : Brushes.Black;
            Console.WriteLine("I'm playing!");
            Console.WriteLine(e);
        }
    
        private void StartMovingAnimation() {

            DoubleAnimation animationX = new DoubleAnimation
            {
                From = 0,
                To = 200, // Punto final X
                Duration = TimeSpan.FromSeconds(5), // Duración de la animación en segundos
                FillBehavior = FillBehavior.Stop // Detiene la animación en su posición final
            };

            Storyboard.SetTarget(animationX, timeLapse);
            Storyboard.SetTargetProperty(animationX, new PropertyPath("(Grid.Margin).(Thickness.Left)"));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animationX);

            storyboard.Begin();

        }

    }
}
