using MyClientApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClientApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployee : ContentPage
    {
        private EmployeeServices empServices;
        public ShowEmployee()
        {
            InitializeComponent();
            empServices = new EmployeeServices();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvEmployee.ItemsSource = await empServices.GetData();
        }

        private async void btnAddEmployee_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeePage());
        }
    }
}