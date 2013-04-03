using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Entities;

namespace LogicBusiness
{
    public class TaskLogic
    {
        TaskAccess oTaskAccess = new TaskAccess();

        public  int insertTask(String pName, DateTime pStartDate, DateTime pDueDate, string pTaskComments)
        {
            return oTaskAccess.insertTask( pName,  pStartDate,  pDueDate,  pTaskComments);
        }

        public  int updateTask(int pTaskId,String pName, DateTime pStartDate, DateTime pDueDate, DateTime pCompletionDate, string pTaskComments)
        {
            return oTaskAccess.updateTask( pTaskId, pName,  pStartDate,  pDueDate,   pCompletionDate,  pTaskComments);
        }

        public  List<Task> consultDueTask(DateTime pDueDate)
        {
            return oTaskAccess.consultDueTasks(pDueDate );
        }

        public List<Task> consultUnfinishedTasks(DateTime pDueDate)
        {
            return oTaskAccess.consultUnfinishedTasks(pDueDate );
        }
    }
}
