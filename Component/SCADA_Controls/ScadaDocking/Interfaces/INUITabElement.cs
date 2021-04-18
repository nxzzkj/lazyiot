using System;
using System.Windows.Forms;
namespace Scada.Controls
{
	public interface INUITabElement : INElement
	{
		event EventHandler OnShow;
		TabPage Tab {get; set;}

		void RaiseShow();
	}
}
