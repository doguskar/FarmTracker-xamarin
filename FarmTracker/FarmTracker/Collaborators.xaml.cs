﻿using FarmTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Collaborators : ContentPage
    {
        public Collaborators()
        {
            InitializeComponent();
            //lvCollaborators.ItemsSource = Repository.Collaborators;
        }
    }
}