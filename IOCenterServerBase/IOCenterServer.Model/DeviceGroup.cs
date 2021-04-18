using System;
namespace Scada.Model
{
	/// <summary>
	/// DeviceGroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeviceGroup
	{
		public DeviceGroup()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private int? _io_server_id;
		private int? _io_comm_id;
		private int? _io_device_id;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_SERVER_ID
		{
			set{ _io_server_id=value;}
			get{return _io_server_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_COMM_ID
		{
			set{ _io_comm_id=value;}
			get{return _io_comm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IO_DEVICE_ID
		{
			set{ _io_device_id=value;}
			get{return _io_device_id;}
		}
		#endregion Model

	}
}

