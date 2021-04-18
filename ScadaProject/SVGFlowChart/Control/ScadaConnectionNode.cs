namespace ScadaFlowDesign.Control
{
    using Scada.DBUtility;
    using System;
    using System.Windows.Forms;

    public class ScadaConnectionNode : TreeNode
    {
        public ScadaConnectionBase ScadaConnection;

        public ScadaConnectionNode(ScadaConnectionBase connection)
        {
            base.ImageKey = connection.DataBaseType.ToString().ToLower();
            base.SelectedImageKey = connection.DataBaseType.ToString().ToLower();
            this.ScadaConnection = connection;
            base.Text = connection.ToString();
        }
    }
}

