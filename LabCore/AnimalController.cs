using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Pritt.Entities;

namespace PRITT
{
    public static class AnimalController
    {
        private static List<Animal> AnimalList;

        public static Animal CurrentAnimal { get; }

        public static void CreateVaccination(Vaccination vaccination)
        {
            /*Добавление в бд*/
        }

        public static void CreateAnimal(Animal animal)
        {
            /*Добавление в бд*/
        }

        public static void UpdateAnimal(Animal animal)
        {
            /*Запрос в бд для обновления записи животного*/
        }

        public static void DeleteAnimal(Animal animal)
        {
            /*Удаление записи животного в бд*/
        }

        public static void GetAnimalList()
        {
            /*Fetch all animals*/
        }

        public static void OpenAnimalCard(Animal animal)
        {
            //TODO: Открытие карты животного
        }

        public static void OpenAnimalRegister(Animal animal)
        {
            //TODO: Отерытие чего-то
        }
    }
}