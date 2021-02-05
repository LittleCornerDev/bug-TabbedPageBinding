using System;
using TabbedPageBinding.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageBinding {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart() {
		}

		protected override void OnSleep() {
		}

		protected override void OnResume() {
		}

		// mock global property usually read from db
		public int UserCredits {
			get; set;
		} = 0;
	}
}
