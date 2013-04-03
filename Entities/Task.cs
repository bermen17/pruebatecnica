using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Task
    {
        private int taskId;
        private string taskName;
        private DateTime startDate;
        private DateTime dueDate;
        private DateTime completionDate;
        private string taskComments;

        public Task() { }

        public Task(int pTaskId, String pName, DateTime pStartDate, DateTime pDueDate, DateTime pCompletionDate, string pTaskComments)
        {
            TaskId = pTaskId;
            TaskName = pName;
            StartDate = pStartDate;
            DueDate = dueDate;
            CompletionDate = pCompletionDate;
            TaskComments = pTaskComments;
        }

        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }


        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }



        public DateTime CompletionDate
        {
            get { return completionDate; }
            set { completionDate = value; }
        }


        public string TaskComments
        {
            get { return taskComments; }
            set { taskComments = value; }
        }

    }
}
