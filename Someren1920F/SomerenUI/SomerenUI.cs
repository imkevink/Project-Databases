﻿using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_CashRegister.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_CashRegister.Hide();


                // show students
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Items.Clear();

                // TODO: Listview Aanpassen

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);

                }
            }
            else if (panelName == "Cash Register")
            {

                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                //pnl_Students.Hide();

                // show Cash Register
                pnl_Students.Show();
                pnl_CashRegister.Show();
                //pnl_Students.Show();

                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();


                lv_RegisterStudent.Clear();
                lv_RegisterStock.Clear();

                foreach (SomerenModel.Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.Name);

                    lv_RegisterStudent.Items.Add(li);
                }

                SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                List<Stock> stockList = stockService.GetStock();

                foreach (SomerenModel.Stock v in stockList)
                {
                    ListViewItem li = new ListViewItem(v.Name);
                    lv_RegisterStock.Items.Add(li);
                }


            }

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
            lbl_Students.Text = "Students";
        }


       // Show the teachers
        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
            lbl_Students.Text = ("Lecturers");
            listViewStudents.Items.Clear();
            pnl_CashRegister.Hide();


            SomerenLogic.Lecturer_Service lecturerService = new SomerenLogic.Lecturer_Service();
            List<Teacher> lecturerList = lecturerService.GetTeachers();


            foreach (SomerenModel.Teacher t in lecturerList)
            {

                ListViewItem li = new ListViewItem(t.Name);
                listViewStudents.Items.Add(li);
            }


        }

        // Show the rooms
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
            lbl_Students.Text = ("Rooms");
            listViewStudents.Items.Clear();

            SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
            List<Room> roomList = roomService.GetRooms();

            foreach (SomerenModel.Room r in roomList)
            {
                ListViewItem li = new ListViewItem(r.Number.ToString());
                listViewStudents.Items.Add(li);
            }

        }

        //Show the cashregister
        private void cashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Cash Register");
            lbl_Students.Text = "Cash Register";
        }

        private void stockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Students");
            lbl_Students.Text = ("Stock");
            listViewStudents.Items.Clear();

            SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
            List<Stock> stockList = stockService.GetStock();

            foreach (SomerenModel.Stock s in stockList)
            {
                ListViewItem li = new ListViewItem(s.Name.ToString());
                listViewStudents.Items.Add(li);
            }
        }
    }
}
