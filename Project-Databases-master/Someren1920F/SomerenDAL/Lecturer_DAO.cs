﻿using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
   public class Lecturer_DAO : Base
    {
        public List<Lecturer> Db_Get_All_Lecturers()
        {
            string query = "SELECT docentnummer, voornaam, achternaam FROM [Docent]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Lecturer> ReadTables(DataTable dataTable)
        {
            List<Lecturer> teachers = new List<Lecturer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecturer teacher = new Lecturer()
                {
                    Number = (int)dr["docentnummer"],
                    Name = (String)dr["voornaam"].ToString() + " " +
                    (String)dr["achternaam"].ToString()
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

    }
}
