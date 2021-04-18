using System;

namespace Scada.Controls
{
	/// <summary>
	/// Interface a NAF outputter
	/// </summary>
	public interface INUITextEditor : INUITabElement
	{

		
		/// <summary>
		/// Write a line to the end of the editor
		/// </summary>
		/// <param name="message"></param>
		void WriteLine(string message);
	}
}
