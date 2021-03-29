using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GUITemplate
{
    /// <summary>
    /// The view modal of the Main Window that contains all the rest of view modals
    /// All manipulation to underlying XML is done through this modal
    /// </summary>
    public class MainGrid : INotifyPropertyChanged
    {
        /** BACKING FIELDS **/
        private ContentGrid _contentGrid;
        private OptionsGrid _optionsGrid;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler WindowInitialized;
        public event EventHandler MainWindow_Closed;


        /// <summary>
        /// Create the modal to store UI data
        /// </summary>
        public MainGrid()
        {
            _contentGrid = new();
            _optionsGrid = new();
        }



        /** PROPERTIES **/

        public ContentGrid ContentGrid => _contentGrid;
        public OptionsGrid OptionsGrid => _optionsGrid;



        /** EVENT ROUTING **/
        public void Window_Initialized(object sender, EventArgs eventArgs) => WindowInitialized?.Invoke(sender, eventArgs);
        public void mainWindow_Closed(object sender, EventArgs eventArgs) => MainWindow_Closed?.Invoke(sender, eventArgs);



        /** INotifyPropertyChanged **/
        protected virtual void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
