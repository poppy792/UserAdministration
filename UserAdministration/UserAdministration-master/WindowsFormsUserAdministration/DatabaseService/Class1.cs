﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace DatabaseService
{
    public class Crud
    {
        

        public List<User> GetUsers()
        {
            List<User> lUsers = new List<User>();
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "SELECT * FROM users";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lUsers.Add(new User()
                        {
                            nUserID = (int)oReader["USER_ID"],
                            sUserName = (string)oReader["USERNAME"],
                            sUserPassword = (string)oReader["PASSWORD"],
                            sUserFirstName = (string)oReader["NAME"],
                            sUserLastName = (string)oReader["SURNAME"]
                        });
                    }
                }
            }
            return lUsers;
        }
        public void UpdateUsers(User oUser)
        {
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];//System.Configuration se dodaje u DatabaseService
            String sSqlConnectionString =  ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;//System.Configuration se dodaje u DatabaseService
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
                //using- pozivanjem ove naredbe iskorištena memorija nakon korištenja se oslobađa
            {
                oCommand.CommandText = "UPDATE USERS SET NAME = '" + oUser.sUserFirstName + "', SURNAME = '" + oUser.sUserLastName + "', PASSWORD = '" + oUser.sUserPassword + "' WHERE USER_ID = " + oUser.nUserID;
                //kombinacija stringa sa varijablama kako bi smo popunili sql naredbe za promjene u bazi podataka (za string '' u sql)
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
            }
        }
        public void DeleteUsers(User oUser)
        {
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "DELETE FROM users WHERE USER_ID = '" + oUser.nUserID +"'";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
            }
        }
        public void AddUsers(User oUser)
        {
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "INSERT INTO users (USERNAME, PASSWORD, NAME, SURNAME) VALUES ('" + oUser.sUserName + "', '"+ oUser.sUserPassword + "', '"+ oUser.sUserFirstName + "', '"+ oUser.sUserLastName + "');";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
            }

        }
        public List<User> SearchUsers(string inptSearch)
        {
            List<User> lFilteredUsers = new List<User>();
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "SELECT * FROM users WHERE USERNAME LIKE '%"+ inptSearch+"%'";// % ako želimo pretražiti nešto što postoji u tekstu
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lFilteredUsers.Add(new User()
                        {
                            nUserID = (int)oReader["USER_ID"],
                            sUserName = (string)oReader["USERNAME"],
                            sUserPassword = (string)oReader["PASSWORD"],
                            sUserFirstName = (string)oReader["NAME"],
                            sUserLastName = (string)oReader["SURNAME"]
                        });
                    }
                }
            }
            return lFilteredUsers;
        }
    }
       
 }

//trace.writeline (ispiše dolje negdje 'output')







    

