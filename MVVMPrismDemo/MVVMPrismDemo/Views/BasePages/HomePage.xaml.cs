﻿using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMPrismDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage, IMasterDetailPageOptions
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}