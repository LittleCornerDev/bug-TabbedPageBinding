using System;
using TabbedPageBinding.ViewModels;
using Xamarin.Forms;

namespace TabbedPageBinding.Views {
	public partial class MyPage : ContentPage {
		MyPageViewModel _ViewModel;

		public MyPage() {
			InitializeComponent();
			BindingContext = _ViewModel = new MyPageViewModel();
		}

		public void IncrementCount(object sender, EventArgs args) {
			// Simplified mock for a db update and data reload
			_ViewModel.MyApp.UserCredits++;  
			_ViewModel.MyMainPage.IncrementCount();
		}
	}
}
