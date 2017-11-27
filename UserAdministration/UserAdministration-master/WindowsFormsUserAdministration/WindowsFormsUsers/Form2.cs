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
    public partial class FormEditUser : Form
    {
        private readonly Form1 FormUserList;//objekt prve forme kao podatkovni član
        public FormEditUser(Form1 FormUser)//konstruktor klase FEU, prilikom inicijalizacije prima objekt prve 
         //forme i podatkovni član klase postaje onak koji smo pozvali (this) u prvoj formi 
        {
            FormUserList = FormUser ;
            InitializeComponent();
        }

        public Form1 WindowsFormUser { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            User oUser = new User();
            oUser.nUserID = Int32.Parse(lblEditID.Text);//DOHVAĆANJE PODATAKA IZ INPUTA
            oUser.sUserFirstName = inptEditName.Text;
            oUser.sUserLastName = inptEditSurname.Text;
            oUser.sUserPassword = inptEditPassword.Text;
            oUser.sUserName = lblEditUsername.Text;
            Crud Crud = new Crud();
            Crud.UpdateUsers(oUser);
            this.FormUserList.dataGridViewUsers.DataSource = Crud.GetUsers();//dohvaća grid iz prve forme
            this.Hide();

        }
    }
}
