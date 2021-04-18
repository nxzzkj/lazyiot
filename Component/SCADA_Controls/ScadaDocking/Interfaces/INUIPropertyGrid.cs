using System;

namespace Scada.Controls
{
	/// <summary>
	/// The specs of a property grid plugin
	/// </summary>
	public interface INUIPropertyGrid :  INUITabElement
	{
		/// <summary>
		/// Gets or sets the object whose properties will be displayed
		/// </summary>
		object SelectedObject {get; set;}
	}
}
