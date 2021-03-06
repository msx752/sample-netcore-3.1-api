﻿using netCoreAPI.Core.ApplicationService;
using netCoreAPI.Model.Tables;
using System;

namespace netCoreAPI.Static.DbSeed
{
    public static class MyContextSeed
    {
        private static bool initiated = false;

        public static void SeedData(IUnitOfWork unitOfWork)
        {
            if (initiated)
                return;
            initiated = true;
            /*
                we have in-memory database so we have to call always
             */
            var p1 = new Personal()
            {
                Id = 1,
                Name = "Mustafa Salih",
                Surname = "ASLIM",
                Age = 29,
                NationalId = "11111111111"
            };
            if (unitOfWork.Db<Personal>().GetById(p1.Id) == null)
                unitOfWork.Db<Personal>().Add(p1);

            var p2 = new Personal()
            {
                Id = 2,
                Name = "Üsame Fetullah",
                Surname = "AVCI",
                Age = 25,
                NationalId = "2222222222"
            };
            if (unitOfWork.Db<Personal>().GetById(p2.Id) == null)
                unitOfWork.Db<Personal>().Add(p2);

            //triggers saveChanges for the updating Database
            unitOfWork.Commit();

            //database has been updated
            if (unitOfWork.Db<Personal>().GetById(p2.Id) != null)
                Console.WriteLine("this user is already in Database");
        }
    }
}