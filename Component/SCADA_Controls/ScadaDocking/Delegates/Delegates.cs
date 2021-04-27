using System;

namespace Scada.Controls
{
	
	public delegate void ChannelNotification(string channelName, string msg);
	/// <summary>
	/// General purpose string delegate
	/// </summary>
	public delegate void StringNotification(string msg);
	/// <summary>
	/// Passes the object to be shown in the propsgrid
	/// </summary>
	public delegate void PropsInfo(object obj);



}
