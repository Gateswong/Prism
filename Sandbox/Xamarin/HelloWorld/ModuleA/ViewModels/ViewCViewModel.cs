﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewCViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        string _title = "View C";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public ViewCViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            //NavigateCommand = new DelegateCommand(Navigate);
            NavigateCommand = new DelegateCommand(async () => await Navigate());

            //NavigateCommand = DelegateCommand.FromAsyncHandler(Navigate);
        }

        async Task Navigate()
        {
            await _navigationService.Navigate("ViewB");

            Debug.WriteLine("After _navigationService.Navigate(ViewB) ...");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatedFrom ViewC ...");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
