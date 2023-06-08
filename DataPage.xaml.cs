using Microsoft.EntityFrameworkCore;
using Pritt.Entities;
using Pritt.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Pritt
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public Animal SelectedAnimal { get; set; }

        public DataPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void ShowGrid(DataGrid grid)
        {
            grid.Visibility = Visibility.Visible;
        }

        private void HideGridsExcept(DataGrid gridToShow)
        {
            List<DataGrid> allGrids = new List<DataGrid> { animalsGrid, municipalGrid, organizationsGrid, vaccinationGrid };

            foreach (DataGrid grid in allGrids)
            {
                if (grid != gridToShow)
                {
                    grid.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                var animals = context.Animals
                    .Include(a => a.Category)
                    .Include(a => a.Sex)
                    .Include(a => a.Locality)
                    .ToList();

                animalsGrid.ItemsSource = animals;

                var municipalContracts = context.MunicipalContracts
                    .Include(a => a.Customer)
                    .Include(a => a.Contractor)
                    .Include(a => a.Localities)
                    .ToList();

                municipalGrid.ItemsSource = municipalContracts;

                var organizations = context.Organizations
                    .Include(a => a.OrganizationType)
                    .Include(a => a.Locality)
                    .Include(a => a.Users)
                    .ToList();

                organizationsGrid.ItemsSource = organizations;

                var vaccinations = context.Vaccinations
                    .Include(a => a.Animal)
                    .Include(a => a.Vet)
                    .Include(a => a.MunicipalContract)
                    .Include(a => a.Type)
                    .ToList();

                vaccinationGrid.ItemsSource = vaccinations;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (animalsGrid.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new AddPage());
            }
            else if (organizationsGrid.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new AddPageOrganization());
            }
            else if (municipalGrid.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new AddPageMunicipal());
            }
            else if (vaccinationGrid.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new AddVaccinationPage());
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (animalsGrid.Visibility == Visibility.Visible)
                {
                    var currentAnimal = animalsGrid.SelectedItem as Animal;
                    if (currentAnimal != null)
                    {
                        using (Context context = new Context())
                        {
                            context.Animals.Remove(currentAnimal);
                            context.SaveChanges();

                            animalsGrid.ItemsSource = context.Animals
                                .Include(a => a.Category)
                                .Include(a => a.Sex)
                                .Include(a => a.Locality)
                                .ToList();
                        }
                    }
                }
                else if (municipalGrid.Visibility == Visibility.Visible)
                {
                    var currentMunicipalContract = municipalGrid.SelectedItem as MunicipalContract;
                    if (currentMunicipalContract != null)
                    {
                        using (Context context = new Context())
                        {
                            context.MunicipalContracts.Remove(currentMunicipalContract);
                            context.SaveChanges();

                            municipalGrid.ItemsSource = context.MunicipalContracts
                                .Include(a => a.Customer)
                                .Include(a => a.Contractor)
                                .Include(a => a.Localities)
                                .ToList();
                        }
                    }
                }
                else if (organizationsGrid.Visibility == Visibility.Visible)
                {
                    var currentOrganization = organizationsGrid.SelectedItem as Organization;
                    if (currentOrganization != null)
                    {
                        using (Context context = new Context())
                        {
                            context.Organizations.Remove(currentOrganization);
                            context.SaveChanges();

                            organizationsGrid.ItemsSource = context.Organizations
                                .Include(a => a.OrganizationType)
                                .Include(a => a.Locality)
                                .Include(a => a.Users)
                                .ToList();
                        }
                    }
                }
                else if (vaccinationGrid.Visibility == Visibility.Visible)
                {
                    var currentVaccination = vaccinationGrid.SelectedItem as Vaccination;
                    if (currentVaccination != null)
                    {
                        using (Context context = new Context())
                        {
                            context.Vaccinations.Remove(currentVaccination);
                            context.SaveChanges();

                            vaccinationGrid.ItemsSource = context.Vaccinations
                                .Include(a => a.Animal)
                                .Include(a => a.Vet)
                                .Include(a => a.MunicipalContract)
                                .Include(a => a.Type)
                                .ToList();
                        }
                    }
                }
            }
        }


        private void BtnAnimalChange_Click(object sender, RoutedEventArgs e)
        {
            ShowGrid(animalsGrid);
            HideGridsExcept(animalsGrid);
        }

        private void BtnMunicipalChange_Click(object sender, RoutedEventArgs e)
        {
            ShowGrid(municipalGrid);
            HideGridsExcept(municipalGrid);
        }

        private void BtnVaccinationChange_Click(object sender, RoutedEventArgs e)
        {
            ShowGrid(vaccinationGrid);
            HideGridsExcept(vaccinationGrid);
        }

        private void BtnOrganizationsChange_Click(object sender, RoutedEventArgs e)
        {
            ShowGrid(organizationsGrid);
            HideGridsExcept(organizationsGrid);
        }
    }
}
