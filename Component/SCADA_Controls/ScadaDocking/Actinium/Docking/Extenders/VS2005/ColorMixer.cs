using System;
using System.Windows.Forms;
using System.Drawing;
namespace GraphicsUI.DockControl.Docking.Extenders.VS2005
{
	/// <summary>
	/// Holds the colors of the UI
	/// </summary>
	public class ColorMixer
	{
		/// <summary>
		/// The main color on which the overall design is based.
		/// If there is a gradient this is the darker color.
		/// </summary>
		public static Color DarkColor = Color.DimGray;// Color.FromArgb(0,51,102);

		public static Color DarkDarkColor = Color.Black;
		/// <summary>
		/// The complementary color of the design.
		/// If there is a gradient this is the lighter color.
		/// </summary>
		public static Color LightColor = Color.WhiteSmoke;

		public static Color AutoHideTabColor = DarkColor;

		public static Color AutoHideTabTextColor = Color.Black;

		public static Color TabSelectedTextColor = Color.Black;

		public static Color DockPaneStripBackDarkColor = Color.FromArgb(226,230,243);


		public static Color DockPaneStripBackLightColor = Color.WhiteSmoke;
	}
}
