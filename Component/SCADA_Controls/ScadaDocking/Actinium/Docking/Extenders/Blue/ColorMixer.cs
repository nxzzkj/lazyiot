using System;
using System.Windows.Forms;
using System.Drawing;
namespace GraphicsUI.DockControl.Docking.Extenders.Blue
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
		public static Color DarkColor = Color.FromArgb(0,51,102);
		/// <summary>
		/// The complementary color of the design.
		/// If there is a gradient this is the lighter color.
		/// </summary>
		public static Color LightColor = Color.WhiteSmoke;

		public static Color AutoHideTabColor = DarkColor;

		public static Color AutoHideTabTextColor = LightColor;

		public static Color TabSelectedTextColor = LightColor;

		public static Color DockPaneStripBackDarkColor = Color.FromArgb(226,230,243);


		public static Color DockPaneStripBackLightColor = LightColor;
	}
}
