using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Pritt.Entities;

namespace PRITT;

public static class MunicipalContractController
{
    public static MunicipalContract CurrentMunicipalContract { get; }
    public static List<MunicipalContract> MunicipalContractList { get; }
    
    public static void CreateMunicipalContract(string contractNumber, DateTime agreementDate, DateTime validityDate,
        Organization customer, Organization contractor, List<Locality> localities, Image photo)
    {
        // TODO: Создание контракта в бд
    }

    public static void UpdateCurrentMunicipalContract(List<Locality> localities, Image photo)
    {
        // TODO: Обновление контракта в бд
    }

    public static void DeleteCurrentMunicipalContract()
    {
        // TODO: Удаление контратка в бд
    }

    public static void OpenMunicipalContractCard()
    {
        //TODO: maaaaaaaaaaaaaaaaaaaaan
    }

    public static void OpenMunicipalContractRegister()
    {
        //TODO: ok
    }

}