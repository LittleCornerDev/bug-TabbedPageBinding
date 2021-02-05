
using System;
using System.Diagnostics;

namespace TabbedPageBinding.ViewModels {
	public class MainPageViewModel: BaseViewModel {
		public MainPageViewModel() {
		}

		private int _CountWithSetter = 0;
		public int CountWithSetter {
			get {
				return _CountWithSetter;
			}
			set {
				SetProperty(ref _CountWithSetter, value);
			}
		}

		public int Count {
			get {
				return MyApp.UserCredits;
			}
		}

	}
}
