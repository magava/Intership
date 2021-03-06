﻿using Internship.PeopleDbBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.Workspaces
{
    public class MainWorkspace:ViewModelBase
    {
        public bool IsSettingsCommandChecked { get; set; }
        public bool IsImportCommandChecked { get; set; }
        public bool IsSearchCommandChecked { get; set; }
        public RelayCommand SettingsCommand { get; set; }
        public RelayCommand ImportCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        ViewModelBase CurrentView { get; set; }

        public MainWorkspace()
        {
            SettingsCommand = new RelayCommand(() => CurrentView = new SearchViewModel());
            //SettingsCommand = new RelayCommand(() => CurrentView = new importViewModel());
            SettingsCommand = new RelayCommand(() => CurrentView = new SearchViewModel());
        }




    }
}
