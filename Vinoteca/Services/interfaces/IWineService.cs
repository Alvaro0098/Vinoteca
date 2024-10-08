﻿using System.Security.Cryptography.X509Certificates;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;

namespace Vinoteca.Services.interfaces
{
    public interface IWineService
    {

        void addWine(CreateAndUpdateWineDto wine);

        public List<Wine> GetAllWines();
        //Wine? getOneWine(int id);

        //public bool RemoveOneWine(int id);

    }
}
