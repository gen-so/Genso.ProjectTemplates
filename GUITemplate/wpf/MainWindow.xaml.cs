using System.Windows;

namespace GUITemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the grid that holds all stuff
        //frist element inside Window
        public MainGrid MainGrid;


        public MainWindow()
        {
            InitializeComponent();

            //get the view modal of the main grid, which holds all other viewmodals
            //get it here to pass events to it 
            MainGrid = TryFindResource("MainGrid") as MainGrid;

        }



        /** EVENT ROUTING **/

        private void ExecuteButton_Click(object sender, RoutedEventArgs e) => MainGrid.OptionsGrid.CalculateEventsButton_Click(sender, e);

    }
}
