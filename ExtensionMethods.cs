using System.Windows.Forms;

namespace PoeTradeMonitorClient
{
    public static class ExtensionMethods
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            while (!control.Visible)
            {
                System.Threading.Thread.Sleep(50);
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
