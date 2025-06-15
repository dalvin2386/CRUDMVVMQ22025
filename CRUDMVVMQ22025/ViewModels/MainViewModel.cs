

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMVVMQ22025.Models;
using CRUDMVVMQ22025.Services;
using CRUDMVVMQ22025.Views;
using System.Collections.ObjectModel;

namespace CRUDMVVMQ22025.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection= new ObservableCollection<Empleado>();

        private EmpleadoService _service;

        public MainViewModel()
        {
            _service = new EmpleadoService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll= _service.GetAll();

            if (getAll.Count>0)
            {
                EmpleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    EmpleadoCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }
    }
}
