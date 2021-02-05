using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TabbedPageBinding.Views;
using Xamarin.Forms;

namespace TabbedPageBinding.ViewModels {
	public class BaseViewModel:INotifyPropertyChanged {
		public BaseViewModel() {
		}

		/// <summary>
		/// 	The <see cref="Application.Current"/> instance.
		/// </summary>
		public App MyApp = ((App)Application.Current);

		/// <summary>
		/// 	The current <see cref="ghost.Views.MainPage"/> instance.
		/// </summary>
		public MainPage MyMainPage { get => MyApp.MainPage as MainPage; }


		/// <summary>
		/// 	Sets given <paramref name="propertyName"/> to given <paramref name="value"/>,
		/// 	while also raising <see cref="System.ComponentModel.INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// 
		/// <typeparam name="T">Generic type.</typeparam>
		/// <param name="backingStore"> Reference to the variable of type <typeparamref name="T"/> whose property is to be set.</param>
		/// <param name="value"> Value to set for <paramref name="backingStore"/> </param>
		/// <param name="propertyName">Name of the property. Optional. Defaults to <c>""</c></param>
		/// <param name="onChanged">Action to take on property being changed. Optional. Defaults to <see langword="null"/></param>
		/// <param name="forceUpdate">Optional flag to ignore equality with old value before triggering <see cref="System.ComponentModel.INotifyPropertyChanged.PropertyChanged"/>.</param>
		/// 
		/// <remarks>
		/// 	Reference: https://www.wpf-tutorial.com/data-binding/responding-to-changes/
		/// </remarks>
		///	
		/// <returns>
		/// 	<see langword="false"/> when <paramref name="value"/> is the same as what's already stored at <paramref name="backingStore"/>,
		/// 	meaning that the <paramref name="propertyName"/> is not set.
		/// 	<see langword="true"/> otherwise.
		/// </returns>
		protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null, bool forceUpdate = false) {
			if (!forceUpdate && EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}


		#region INotifyPropertyChanged
		/// <summary>
		///		Event that is raised by <see cref="OnPropertyChanged"/>.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// 	Represents the method that will handle the <see cref="System.ComponentModel.INotifyPropertyChanged.PropertyChanged"/>
		/// 	event raised when a property is changed on a component.
		/// </summary>
		public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
			var changed = PropertyChanged;
			if (changed == null)
				return;

			//LoggerUtil.Log(LogEventLevel.Debug, "BaseViewModel Property {0} changed", propertyName);

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanged

	}
}
