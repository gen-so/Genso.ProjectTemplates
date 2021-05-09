using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GUITemplate
{
    public class FindEventOptions : ViewModal
    {
        /** BACKING FIELDS **/
        private string _startTimeText;
        private string _endTimeText;
        private object _selectedPerson;
        private object _selectedTag;
        private object _selectedLocation;
        private List<object> _personList;
        private List<object> _locationList;
        private int _selectedPersonIndex;
        private int _selectedLocationIndex;
        private int _selectedTagIndex;
        private List<object> _eventsToFindList;
        private List<object> _selectedEventsToFind = new List<object>();//initialize by itself because the list is created by the panel
        private string _eventListFilterText = "";
        private List<object> _eventsToFindListFiltered;
        private IList _selectedItems;
        private string _selectedEventsCount = ""; //default empty string, so nothing appears

        /** EVENTS **/
        public event EventHandler SendToCalendarButtonClicked;
        public event EventHandler FindEventsButtonClicked;



        /** PROPERTIES **/
        public string StartTimeText
        {
            get => _startTimeText;
            set
            {
                _startTimeText = value;
                OnPropertyChanged(nameof(StartTimeText));
            }
        }
        public string EndTimeText
        {
            get => _endTimeText;
            set
            {
                _endTimeText = value;
                OnPropertyChanged(nameof(EndTimeText));
            }
        }
        /// <summary>
        /// The text that is used to filter
        /// </summary>
        public string EventListFilterText
        {
            get => _eventListFilterText;
            set
            {
                _eventListFilterText = value;
                OnPropertyChanged(nameof(EventListFilterText));
            }
        }
        public object SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }
        public object SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }
        public object SelectedTag
        {
            get => _selectedTag;
            set
            {
                _selectedTag = value;
                OnPropertyChanged(nameof(SelectedTag));
            }
        }
        public List<object> PersonList
        {
            get => _personList;
            set
            {
                _personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }
        public List<object> LocationList
        {
            get => _locationList;
            set
            {
                _locationList = value;
                OnPropertyChanged(nameof(LocationList));
            }
        }
        /// <summary>
        /// The full event list that is not modified
        /// Used as reference when filtering
        /// </summary>
        public List<object> EventsToFindList
        {
            get => _eventsToFindList;
            set
            {
                //when the full list is set, set filtered list also
                //use property to trigger WPF update
                EventsToFindListFiltered = value;
                _eventsToFindList = value;
                OnPropertyChanged(nameof(EventsToFindList));
            }
        }
        /// <summary>
        /// This is the visible filterable list,
        /// it changes according to filter text
        /// </summary>
        public List<object> EventsToFindListFiltered
        {
            get => _eventsToFindListFiltered;
            set
            {
                _eventsToFindListFiltered = value;
                OnPropertyChanged(nameof(EventsToFindListFiltered));
                ReselectEventsToFind();
            }
        }
        /// <summary>
        /// This is a seperate internal list to keep track of events that are selected by the user
        /// since during filtering the selected events might not be visible
        /// </summary>
        public List<object> SelectedEventsToFind
        {
            get => _selectedEventsToFind;
            set
            {
                _selectedEventsToFind = value;
                OnPropertyChanged(nameof(SelectedEventsToFind));
            }
        }
        public int SelectedPersonIndex
        {
            get => _selectedPersonIndex;
            set
            {
                _selectedPersonIndex = value;
                OnPropertyChanged(nameof(SelectedPersonIndex));
            }
        }
        public int SelectedLocationIndex
        {
            get => _selectedLocationIndex;
            set
            {
                _selectedLocationIndex = value;
                OnPropertyChanged(nameof(SelectedLocationIndex));
            }
        }
        public int SelectedTagIndex
        {
            get => _selectedTagIndex;
            set
            {
                _selectedTagIndex = value;
                OnPropertyChanged(nameof(SelectedTagIndex));
            }
        }
        /// <summary>
        /// The raw list selected items from the listview,
        /// it is used to programmatically select the events in the list
        /// </summary>
        public IList SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
            }

        }
        /// <summary>
        /// This is the number of selected events,
        /// useful to show user the events selected when filtering,
        /// since the previously selected event can be hidden
        /// Note: stored as string so that easy to hide when it is 0 ("")
        /// </summary>
        public string SelectedEventsCount
        {
            get => _selectedEventsCount;
            set
            {
                //if count is 0, then don't show anything
                if (value == "0")
                {
                    value = "";
                }
                _selectedEventsCount = value;
                OnPropertyChanged(nameof(SelectedEventsCount));
            }
        }


        /** PUBLIC METHODS **/



        /** EVENT HANDLERS **/
        /// <summary>
        /// is called when user selects/clicks an event to find
        /// keeps track of selected events
        /// </summary>
        public void EventsToFind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = ((ListView)sender);

            //make a copy of the Selected Items for use later
            SelectedItems ??= listView.SelectedItems;


            //if user did not click the event checkbox then,
            //the event is being triggered by the filterng machanism or autoselect
            //so ignore
            if (!listView.IsMouseOver || !listView.IsKeyboardFocusWithin) { return; }


            //add & remove events from the internal list which
            //is used to keep track of selected events
            foreach (object eventToRemove in e.RemovedItems)
            {
                //remove all, becasue duplicate events are possible
                SelectedEventsToFind.RemoveAll(selectedEvent => selectedEvent == eventToRemove);
            }

            foreach (object eventToAdd in e.AddedItems)
            {
                SelectedEventsToFind.Add(eventToAdd);
            }

            //if control reaches here, than user has changed selectec events
            //so need to update selected event count
            SelectedEventsCount = SelectedEventsToFind.Count.ToString();

        }

        /// <summary>
        /// Filters the events list box as filter text changes
        /// The function that does the filtering
        /// </summary>
        public void EventListFilterText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //get the latest filtered text
            var filterText = ((TextBox)sender).Text;

            //if no text, include all
            if (filterText.Length == 0)
            {
                EventsToFindListFiltered = EventsToFindList;
                return;
            }

            //set the found list into view
            EventsToFindListFiltered = GetEventsThatMatchAllKeywords(filterText);



            //------------------FUNCTIONS---------------------------

            //splits the filter text into keywords, and finds events that match all
            //if 2 keyswords are inputed, an event has to match both keywords to be included
            List<object> GetEventsThatMatchAllKeywords(string filterText)
            {
                throw new NotImplementedException();
            }

        }



        /** EVENT ROUTING **/
        public void SendToCalendarButton_Click(object sender, RoutedEventArgs routedEventArgs) => SendToCalendarButtonClicked?.Invoke(sender, routedEventArgs);
        public void FindEventsButton_Click(object sender, RoutedEventArgs routedEventArgs) => FindEventsButtonClicked?.Invoke(sender, routedEventArgs);



        /** PRIVATE METHODS **/

        /// <summary>
        /// This method is for compensating the first item auto selecting feature of listview,
        /// it removes the auto selection and selects only items found in the selected list
        /// it is called everytime hte event list is updated
        /// </summary>
        private void ReselectEventsToFind()
        {
            //remove auto selected events
            SelectedItems.Clear();

            //reselect the correct events
            foreach (var item in SelectedEventsToFind) { SelectedItems.Add(item); }

        }
    }
}
