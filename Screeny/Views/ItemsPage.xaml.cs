using System;
using System.ComponentModel;
using System.Diagnostics;
using Screeny.Models;
using Screeny.ViewModels;
using Xamarin.Forms;

namespace Screeny.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            var screenShotter = DependencyService.Get<IScreenShotter>();
            Debug.WriteLine("platform dependency: " + screenShotter);

            BindingContext = viewModel = new ItemsViewModel(screenShotter);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        
        async void SnapItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ViewScreenshot(viewModel.takeScreenShotOfView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}