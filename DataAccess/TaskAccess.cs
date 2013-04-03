using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace DataAccess
{
    public class TaskAccess
    {
        public string connString
        {
            get { return "Data Source=BERNAL;Initial Catalog=TechnicalTest;Integrated Security=True"; }
        }

        public int executeNonQuery(String pProcedureName, List<SqlParameter> pLParameters)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {

                    conn.ConnectionString = connString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = pProcedureName;

                        foreach (var item in pLParameters)
                        {
                            command.Parameters.Add(item);
                        }

                        conn.Open();

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public int insertTask(String pName, DateTime pStartDate, DateTime pDueDate, string pTaskComments)
        {
            List<SqlParameter> lParameters = new List<SqlParameter>();

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "pTASKNAME";
            paramName.Value = pName;

            lParameters.Add(paramName);

            SqlParameter paramStartDate = new SqlParameter();
            paramStartDate.Value = pStartDate;
            paramStartDate.ParameterName = "pSTARTDATE";

            lParameters.Add(paramStartDate);

            SqlParameter paramDueDate = new SqlParameter();
            paramDueDate.Value = pDueDate;
            paramDueDate.ParameterName = "pDUEDATE";

            lParameters.Add(paramDueDate);

            SqlParameter paramTaskComments = new SqlParameter();
            paramTaskComments.Value = pTaskComments;
            paramTaskComments.ParameterName = "pCOMMENTS";

            lParameters.Add(paramTaskComments);

            SqlParameter paramTaskStatus = new SqlParameter();
            paramTaskStatus.Value = 0;
            paramTaskStatus.ParameterName = "pSTATUS";

            lParameters.Add(paramTaskStatus);

            SqlParameter paramCompletionDate = new SqlParameter();
            paramCompletionDate.Value = "";
            paramCompletionDate.ParameterName = "@pCOMPLETIONDATE";

            lParameters.Add(paramCompletionDate);

            return executeNonQuery("insertTasks", lParameters);
        }


        public int updateTask(int pTaskId, String pName, DateTime pStartDate, DateTime pDueDate, DateTime pCompletionDate, string pTaskComments)
        {
            List<SqlParameter> lParameters = new List<SqlParameter>();

            SqlParameter paramTaskId = new SqlParameter();
            paramTaskId.ParameterName = "pTASKID";
            paramTaskId.Value = pTaskId;

            lParameters.Add(paramTaskId);

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "pTASKNAME";
            paramName.Value = pName;

            lParameters.Add(paramName);

            SqlParameter paramStartDate = new SqlParameter();
            paramStartDate.Value = pStartDate;
            paramStartDate.ParameterName = "pSTARTDATE";

            lParameters.Add(paramStartDate);

            SqlParameter paramDueDate = new SqlParameter();
            paramDueDate.Value = pDueDate;
            paramDueDate.ParameterName = "pDUEDATE";

            lParameters.Add(paramDueDate);


            SqlParameter paramCompletionDate = new SqlParameter();
            paramCompletionDate.Value = pCompletionDate;
            paramCompletionDate.ParameterName = "pCOMPLETIONDATE";

            lParameters.Add(paramCompletionDate);

            SqlParameter paramTaskComments = new SqlParameter();
            paramTaskComments.Value = pTaskComments;
            paramTaskComments.ParameterName = "pCOMMENTS";

            lParameters.Add(paramTaskComments);

            SqlParameter paramTaskStatus = new SqlParameter();
            paramTaskStatus.Value = 0;
            paramTaskStatus.ParameterName = "pSTATUS";

            lParameters.Add(paramTaskStatus);

            return executeNonQuery("updateTasks", lParameters);
        }

        public List<Task> consultDueTasks(DateTime pDueDate)
        {
            List<Task> lTasks = new List<Task>();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dueTasks";

                        SqlParameter paramDueDate = new SqlParameter();
                        paramDueDate.Value = pDueDate;
                        paramDueDate.ParameterName = "pDUEDATE";

                        command.Parameters.Add(paramDueDate);

                        conn.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Task newTask = new Task();
                                newTask.TaskId = (int)dr[0];
                                newTask.TaskName = (string)dr[1];
                                newTask.StartDate = (DateTime)dr[2];
                                newTask.TaskComments = (string)dr[3];

                                lTasks.Add(newTask);
                            }
                        }
                    }
                }
                return lTasks;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Task> consultUnfinishedTasks(DateTime pDueDate)
        {
            List<Task> lTasks = new List<Task>();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "unfinishedTasks";

                        SqlParameter paramDueDate = new SqlParameter();
                        paramDueDate.Value = pDueDate;
                        paramDueDate.ParameterName = "pDUEDATE";

                        command.Parameters.Add(paramDueDate);

                        conn.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Task newTask = new Task();
                                newTask.TaskName = (string)dr[0];
                                newTask.StartDate = (DateTime)dr[1];
                                newTask.TaskComments = (string)dr[2];
                                newTask.DueDate = (DateTime)dr[4];

                                lTasks.Add(newTask);
                            }
                        }
                    }
                }
                return lTasks;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
