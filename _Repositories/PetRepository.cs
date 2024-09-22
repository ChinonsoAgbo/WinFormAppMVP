﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CrudWinFormMVP.Model;

namespace CrudWinFormMVP._Repositories
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        //Constructor 
        public PetRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Pet order by Pet_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        // use the ExecutionReader obj to the read the database table colum
                        petModel.Id = (int)reader[0];
                        petModel.Name = reader[1].ToString();
                        petModel.Type = reader[2].ToString();
                        petModel.Colour = reader[3].ToString();
                        // add to the pet list 
                        petList.Add(petModel);

                    }

                }

            }


            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();
            // TryParse to check if the value can be converted otherwise we set the value to 0 
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from Pet 
                                           where Pet_Id = @id or Pet_Name like @name+'%'
                                            order by Pet_Id desc";
                // some kinda preparedstatement in java 
                command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        // use the ExecutionReader obj to the read the database table colum
                        petModel.Id = (int)reader[0];
                        petModel.Name = reader[1].ToString();
                        petModel.Type = reader[2].ToString();
                        petModel.Colour = reader[3].ToString();
                        // add to the pet list 
                        petList.Add(petModel);

                    }

                }

            }


            return petList;
        }
    }
}
