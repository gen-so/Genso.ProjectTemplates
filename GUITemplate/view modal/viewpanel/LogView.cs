using System;
using System.Windows;

namespace GUITemplate
{
    /// <summary>
    /// The place used to show internal logs from log manager
    /// </summary>
    public class LogView : ViewModal
    {
        /** BACKING FIELDS **/
        private string _log;


        /** CTOR **/
        public LogView()
        {
            //when log becomes visible need to do stuff
            IsVisible_Changed += LogView_IsVisible_Changed;
        }



        /** PROPERTIES **/
        public string Log
        {
            get => _log;
            set
            {
                _log = value;
                OnPropertyChanged(nameof(Log));
            }
        }



        /** EVENT HADLERS **/


        /// <summary>
        /// only update/listen for logs from log manager when the log panel is visible
        /// based on visibility start or stop listening to updates from log manager
        /// </summary>
        private void LogView_IsVisible_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }


        /** PUBLIC METHODS **/

        /// <summary>
        /// Gets latest logs from log manager, and load them into "Log" property which is watched by WPF binding
        /// </summary>
        private void ReloadLogText() => throw new NotImplementedException();
        

    }
}