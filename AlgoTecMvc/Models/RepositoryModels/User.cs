﻿using System;

namespace AlgoTecMvc.Models.RepositoryModels
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}