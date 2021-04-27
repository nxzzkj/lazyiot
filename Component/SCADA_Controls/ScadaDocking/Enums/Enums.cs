using System;

namespace Scada.Controls
{
	/// <summary>
	/// Enumerates the base services
	/// </summary>
	public enum BaseServices : int
	{
		/// <summary>
		/// the browser service
		/// </summary>
		BrowserService = 0,
		/// <summary>
		/// the output service
		/// </summary>
		OutputService = 1,
		/// <summary>
		/// the help service
		/// </summary>
		HelpService = 2,
		/// <summary>
		/// the exception handler service
		/// </summary>
		ExceptionHandlerService = 3,
		/// <summary>
		/// the property grid
		/// </summary>
		PropertyGridService = 4,
		/// <summary>
		/// The graph service
		/// </summary>
		GraphService = 5,
		/// <summary>
		/// The HTML service
		/// </summary>
		HTMLService = 6,
		/// <summary>
		/// The favorites service
		/// </summary>
		FavoritesService = 7,
		/// <summary>
		/// The NAF sripting service
		/// </summary>
		NAFScriptService = 8,
		/// <summary>
		/// The tasks service
		/// </summary>
		TasksService =9,


	}

	/// <summary>
	/// List of plugin types used throughout the framework
	/// </summary>
	public enum NAFPluginTypes
	{
		/// <summary>
		/// the base plugin
		/// </summary>
		Base,
		/// <summary>
		/// an application plugin
		/// </summary>
		Application,
		/// <summary>
		/// a hostservice plugin
		/// </summary>
		HostService,
		/// <summary>
		/// an unknown plugin type
		/// </summary>
		Unknown
	}

	/// <summary>
	/// The different docking states of a NAFPanel
	/// </summary>
	public enum NAFDockState
	{
		/// <summary>
		/// Dock at the bottom of the screen
		/// </summary>
		Bottom,
		/// <summary>
		/// Fill the screen as much as possible
		/// </summary>
		Fill,
		/// <summary>
		/// Dock at the left of the screen
		/// </summary>
		Left,
		/// <summary>
		/// Dock at the right of the screen
		/// </summary>
		Right,
		/// <summary>
		/// Dock at the bottom of the screen
		/// </summary>
		Top,
		/// <summary>
		/// Don't dock (floating window)
		/// </summary>
		None
	
	}

	/// <summary>
	/// Where the help resides
	/// </summary>
	public enum HelpLocations
	{
		/// <summary>
		/// Help accessed over http://
		/// </summary>
		Remote,
		/// <summary>
		/// Help accessed over file
		/// </summary>
		Local
	}

	/// <summary>
	/// The forms in which help resources can be stored
	/// </summary>
	public enum HelpTypes
	{
		/// <summary>
		/// flat file resource
		/// </summary>
		Flat,
		/// <summary>
		/// compiled assembly type resource
		/// </summary>
		Assembly
	}

	public enum UIStyle
	{
		Neon,
		Flat,
		WinXP
	}
	public enum UIColorScheme
	{
		SkyBlue,
		Dark,
		Grey,
		Colorful
	}
	public enum OutputPicture
	{
		Question,
		Info,
		Exclamation,
		None
	}

	public enum HighliteStyles
	{
		Flat,
		Shadow,
		Box
	}

	
}
