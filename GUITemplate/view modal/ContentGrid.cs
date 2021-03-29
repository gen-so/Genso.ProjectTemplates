using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace GUITemplate
{
    public class ContentGrid : INotifyPropertyChanged
    {
        /** BACKING FIELDS **/
        private Visibility _visibility;
        private string _option1Text;
        private Brush _option1BorderColor = DefaultBorderColor; //set defaults
        private Thickness _option1BorderThickness = DefaultTextInputThickness; //set defaults


        /** PRESET STYLING **/
        private static readonly Brush DefaultBorderColor = new SolidColorBrush(Color.FromRgb(170, 170, 170));
        private static readonly Thickness DefaultTextInputThickness = new Thickness(1);

        private static readonly Brush ErrorBorderColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        private static readonly Thickness ErrorBorderThickness = new Thickness(2);




        /** EVENTS **/
        public event EventHandler ExecuteButtonClicked;
        public event PropertyChangedEventHandler PropertyChanged;



        /** PROPERTIES **/
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Visibility"));
            }
        }
        public string Option1Text
        {
            get => _option1Text;
            set
            {
                _option1Text = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Option1Text"));
            }
        }
        public Brush Option1BorderColor
        {
            get => _option1BorderColor;
            set
            {
                _option1BorderColor = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Option1BorderColor"));
            }
        }
        public Thickness Option1BorderThickness
        {
            get => _option1BorderThickness;
            set
            {
                _option1BorderThickness = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Option1BorderThickness"));
            }
        }



        /** PUBLIC METHODS **/
        public void setDefaultStyling()
        {
            //name shortning
            var color = DefaultBorderColor;
            var thick = DefaultTextInputThickness;


            //set default value only if not default (stops unnecessary style updates)
            if (Option1BorderColor != color) { Option1BorderColor = color; }
            if (Option1BorderThickness != thick) { Option1BorderThickness = thick; }
        }

        /// <summary>
        /// Shows domain not available error
        /// </summary>
        public void DomainNotAvailableError()
        {
            Option1BorderColor = ErrorBorderColor;
            Option1BorderThickness = ErrorBorderThickness;
        }



        /** EVENT ROUTING **/
        public void CalculateEventsButton_Click(object sender, RoutedEventArgs routedEventArgs) => ExecuteButtonClicked?.Invoke(sender, routedEventArgs);

    }

}
