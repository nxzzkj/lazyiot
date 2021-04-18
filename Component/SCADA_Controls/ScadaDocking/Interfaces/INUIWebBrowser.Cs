using System;
using System.Collections;

namespace Netron.Neon
{
	/// <summary>
	/// Describes the base methods of a web browser
	/// </summary>
	public interface INUIWebBrowser : INUITabElement
	{

		int HistoryCapacity {get; set;}

		NAFHistoryCollection History {get;}

		/// <summary>
		/// Navigate to an address
		/// </summary>
		/// <param name="address"></param>
		void Navigate(string address);
		/// <summary>
		/// Go back in the histroy
		/// </summary>
		void GoBack();
		/// <summary>
		/// Go forward in the history
		/// </summary>
		void GoForward();
		/// <summary>
		/// Go to the home page
		/// </summary>
		void GoHome();

		/// <summary>
		/// Reloads the current page
		/// </summary>
		void RefreshPage();

		/// <summary>
		/// Gets the current URL of the browser
		/// </summary>
		string CurrentURL {get;}

	}
}
