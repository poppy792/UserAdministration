﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseService;

namespace WindowsFormsUsers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Crud Crud = new Crud();
            List<User> lUsers = Crud.GetUsers();
            dataGridViewUsers.DataSource = lUsers;


            //programsko dodavanje kolona u data grid 
            DataGridViewImageColumn oEditButton = new DataGridViewImageColumn();//nova kolona koja je tipa "image"
            oEditButton.Image = Image.FromFile("D:/Barbara Strapac/pencil.png");
            oEditButton.Width = 20;
            oEditButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewUsers.Columns.Add(oEditButton);

            DataGridViewImageColumn oDeleteButton = new DataGridViewImageColumn();//nova kolona koja je tipa "image"
            oDeleteButton.Image = Image.FromFile("D:/Barbara Strapac/trash.png");
            oDeleteButton.Width = 20;
            oDeleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewUsers.Columns.Add(oDeleteButton);            dataGridViewUsers.AutoGenerateColumns = false; //program nam neće sam posložiti kolone
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor=Color.Lavender;            dataGridViewUsers.EnableHeadersVisualStyles = false;            //ako je true, kolone nam se mogu pobrkati
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Yello!"); //pop-up box-ić
            dataGridViewUsers.Rows[e.RowIndex].Selected = true;  //broj retka u kojem se nalazimo, redak u kojem smo pritisnuli gumb postaje onaj označeni redak (selektiran)
            if (dataGridViewUsers.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                /*ako mi redak nije -1 neka radnja se izvršava, čelija, wtf*/
                FormEditUser FormEditUser = new FormEditUser(this); //stvara se forma FormEditUser (objekt klase feu) za kreiranje korisnika           
                FormEditUser.lblEditID.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();//postavljanje teksta u labeli forme 2 
                FormEditUser.lblEditUsername.Text =dataGridViewUsers.Rows[e.RowIndex].Cells[1].Value.ToString();//korisničko ime čelija 2
                FormEditUser.inptEditPassword.Text =dataGridViewUsers.Rows[e.RowIndex].Cells[2].Value.ToString();//lozinka čelija 3
                FormEditUser.inptEditName.Text =dataGridViewUsers.Rows[e.RowIndex].Cells[3].Value.ToString();//ime čelija 4
                FormEditUser.inptEditSurname.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[4].Value.ToString();//prezime čelija 5
                //kupimo vrijednosti iz tablice u prvoj formi i stavljamo ih uz pripadajuće čelije u drugoj formi
                FormEditUser.Show();
            }
            if (dataGridViewUsers.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
            {
                DeleteUser FormDeleteUser = new DeleteUser(this);
                FormDeleteUser.ID = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                FormDeleteUser.Username = dataGridViewUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                FormDeleteUser.Password = dataGridViewUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                FormDeleteUser.Name = dataGridViewUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                FormDeleteUser.Surname = dataGridViewUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
                FormDeleteUser.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser AddNewUser = new AddUser(this);
            AddNewUser.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Crud Crud = new Crud();
            List<User> lUser = Crud.SearchUsers(inptSearchUsers.Text);
            /* string sSearch = inptSearchUsers.Text;
             var ContainsQuery = from c in lUser where c.sUserName.Contains(inptSearchUsers.Text) select c;
             List<User> lContainFilteredUsers = ContainsQuery.ToList();
             for (int i = 0; i < lContainFilteredUsers.Count; i++)
             {
                 dataGridViewUsers.DataSource = lContainFilteredUsers;
             }*/
            dataGridViewUsers.DataSource = lUser;

        }

        private void izlazToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             Application.Exit();
        }

        private void oProgramuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Created by Majstorica Barbara \n Version 1.2.1 \n Author Barbarica d.o.o \n Year 2017.");
        }

        private void izlazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser AddNewUser = new AddUser(this);
            AddNewUser.Show();
        }
    }
}



//https://www.iconfinder.com/iconsets/nasty ikonice mice 
//kako bi prva forma znala za objekt druge forme prvoj formi se daje neki inicijalni objekt koji šaljemo drugoj formi -> (this)
