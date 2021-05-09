﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace GUITemplate
{
    public class ViewEventOptions : ViewModal
    {
        /** BACKING FIELDS **/
        private string _startTimeText;
        private string _endTimeText;
        private object _selectedPerson;
        private object _selectedTag;
        private object _selectedLocation;
        private List<object> _personList;
        private List<object> _tagList;
        private List<object> _locationList;
        private int _selectedPersonIndex;
        private int _selectedLocationIndex;
        private int _selectedTagIndex;




        /** EVENTS **/
        public event EventHandler CalculateEventsButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event EventHandler SendToCalendarButtonClicked;



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
        public List<object> TagList
        {
            get => _tagList;
            set
            {
                _tagList = value;
                OnPropertyChanged(nameof(TagList));
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



        /** PUBLIC METHODS **/



        /** EVENT ROUTING **/
        public void CalculateEventsButton_Click(object sender, RoutedEventArgs routedEventArgs) => CalculateEventsButtonClicked?.Invoke(sender, routedEventArgs);
        public void CancelButton_OnClick(object sender, RoutedEventArgs routedEventArgs) => CancelButtonClicked?.Invoke(sender, routedEventArgs);
        public void SendToCalendarButton_Click(object sender, RoutedEventArgs routedEventArgs) => SendToCalendarButtonClicked?.Invoke(sender, routedEventArgs);
    }
}
