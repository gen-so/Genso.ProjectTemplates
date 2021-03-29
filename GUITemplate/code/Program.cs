using System;
using System.Windows;

namespace GUITemplate
{
    public class Program
    {


        //managers to handle data & encapsulated logic
        private GuiManager _guiManager;



        /** CTOR **/

        /// <summary>
        /// Prepare data for the program to run
        /// </summary>
        public Program()
        {
            //create managers
            _guiManager = new GuiManager();

        }






        /** EVENT HANDLERS **/

        //EVENT OPTIONS
        private void ExecuteButtonClicked(object sender, EventArgs e)
        {
            //set text to content grid
            _guiManager.MainGrid.ContentGrid.Option1Text = "Hello World!";

            MessageBox.Show("Execute Button Clicked!");

        }

        //MAIN WINDOW
        private void WindowInitialized(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Closes the program once the main window is closed
        /// </summary>
        private void MainGrid_MainWindow_Closed(object sender, EventArgs e) => System.Environment.Exit(1);






        /** PUBLIC METHODS **/
        //runs the program
        public void Run()
        {
            //attach handlers to the GUI events
            attachEventHandlers();

            //run the gui
            _guiManager.Run();

        }




        /** PRIVATE METHODS **/

        //attaches all event handlers to the from the gui
        private void attachEventHandlers()
        {
            //MAIN GRID
            _guiManager.MainGrid.WindowInitialized += WindowInitialized;
            _guiManager.MainGrid.MainWindow_Closed += MainGrid_MainWindow_Closed;

            //LOGIN PANEL
            _guiManager.MainGrid.OptionsGrid.ExecuteButtonClicked += ExecuteButtonClicked;

        }



    }
}
