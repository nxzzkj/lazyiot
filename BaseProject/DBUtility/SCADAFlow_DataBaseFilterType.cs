namespace Scada.DBUtility
{
    using System;

    [Serializable]
    public enum SCADAFlow_DataBaseFilterType
    {
        StaticDropList,
        DynamicDropList,
        Key,
        DateRange
    }
}

