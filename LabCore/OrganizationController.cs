using Org.BouncyCastle.Bcpg.OpenPgp;
using Pritt.Entities;
using System.Collections.Generic;

namespace PRITT;

public static class OrganizationController
{
    public static Organization CurrentOrganization { get; }
    public static List<Organization> OrganizationList { get; }

    public static void CreateOrganization(Organization organization)
    {
        // TODO: Создание организации в бд
    }

    public static void UpdateCurrentOrganization(Organization organization)
    {
        // TODO: Обновление организации в бд
    }

    public static void DeleteCurrentOrganization(Organization organization)
    {
        // TODO: Удаление организации в бд
    }

    public static void OpenOrganizationCard()
    {
        //TODO: Открытие карты организации
    }

    public static void OpenOrganizationRegister()
    {
        //TODO: Че-то открыть
    }

}