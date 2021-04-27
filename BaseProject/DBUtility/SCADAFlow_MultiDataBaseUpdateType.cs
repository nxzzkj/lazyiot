namespace Scada.DBUtility
{
    using System;

    [Serializable]
    public enum SCADAFlow_MultiDataBaseUpdateType
    {
        不刷新 = 0,
        频率1分钟 = 0x1770,
        频率2分钟 = 0x2ee0,
        频率5分钟 = 0x7530,
        频率10分钟 = 0xea60,
        频率20分钟 = 0x1d4c0,
        频率30分钟 = 0x2bf20
    }
}

