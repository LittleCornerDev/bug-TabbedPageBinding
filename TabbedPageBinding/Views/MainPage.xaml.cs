using System.Collections.Generic;
using TabbedPageBinding.ViewModels;
using Xamarin.Forms;

namespace TabbedPageBinding.Views {
	public partial class MainPage : TabbedPage {
		MainPageViewModel _ViewModel;
		List<Page> _TabItems = new List<Page> {
			new MyPage(),
			new MyPage()
		};

		public MainPage() {
			InitializeComponent();
			BindingContext = _ViewModel = new MainPageViewModel();
			CreateTabs();
		}

		/*protected override void OnAppearing() {
			base.OnAppearing();
			_ViewModel.OnPropertyChanged(nameof(_ViewModel.Count));
		}*/

		public void IncrementCount() {
			// directly set `CountWithSetter`
			_ViewModel.CountWithSetter++;

			// notify `Count` of update, so getter could reload
			OnPropertyChanged(nameof(_ViewModel.Count));

			DisplayAlert("Count With Setter", _ViewModel.CountWithSetter.ToString(), "ok");
			DisplayAlert("Count With PropertyChanged", _ViewModel.Count.ToString(), "ok");
		}

		private void CreateTabs() {
			for (var i = 0; i < _TabItems.Count; i++) {
				var item = new NavigationPage(_TabItems[i]);

				if (i == 0) {
					item.SetBinding(TitleProperty, new Binding("CountWithSetter", mode: BindingMode.OneWay, stringFormat: "With Setter: {0:d}"));
				} else {
					item.SetBinding(TitleProperty, new Binding("Count", mode: BindingMode.OneWay, stringFormat: "With PropertyChanged: {0:d}"));
				}

				Children.Add(item);
			}
		}
	}
}
