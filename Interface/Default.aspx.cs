using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicBusiness;
using Entities;

namespace Interface
{
    public partial class Default : System.Web.UI.Page
    {
        TaskLogic oTaskLogic = new TaskLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<Task> lDueTasks = oTaskLogic.consultDueTask(System.DateTime.Now );
            List<Task> lUnfinishedTasks = oTaskLogic.consultUnfinishedTasks (System.DateTime.Now);

            if (lDueTasks.Count != 0)
            {
                gvDueTasks.DataSource = lDueTasks;
                gvDueTasks.DataBind();
            }

            if (lUnfinishedTasks.Count != 0)
            {
                gvUnfinishedTasks .DataSource = lUnfinishedTasks;
                gvUnfinishedTasks.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {            
            int result = oTaskLogic.insertTask(txtName.Text, Convert.ToDateTime (txtStartDate.Text), Convert.ToDateTime (txtFinishDate.Text), txtComments.Text);
            if (result != -1)
            {
                
            }
        }
    }
}