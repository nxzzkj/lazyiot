using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.DBUtility
{
  public abstract  class ScadaTask:IDisposable
    {
        public static List<Task> TaskManager = new List<Task>();
        private System.Threading.Timer taskTimer = null;
        public ScadaTask()
        {
            taskTimer = new System.Threading.Timer(delegate {

                for(int i= TaskManager.Count-1; i>=0;i--)
                {
                    Task task = TaskManager[i];
                    if(task!=null)
                    {
                        if (task.IsCanceled || task.IsCompleted || task.IsFaulted)
                        {
                            task.Dispose();
                            TaskManager.RemoveAt(i);
                            task = null;
                        }
                    }
                
                }


            },null,1000,1000);
        }

        public  virtual void Dispose()
        {
            if(taskTimer!=null)
            taskTimer.Dispose();
            taskTimer = null;
            GC.Collect();
        }
     
    }
}
