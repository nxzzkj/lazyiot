using System;
using System.Collections.Generic;
using System.Text;

namespace Scada.Controls
{
    public interface ICobaltTab
    {
        /// <summary>
        /// Tab页面的类型定义
        /// </summary>
        TabTypes TabType { get; }
        /// <summary>
        /// The unique identifier of the tab, useful if a certain tab can have multiple instances
        /// like the scripting tab to edit multiple files
        /// </summary>
        string TabIdentifier { get; set; }
    }
}
