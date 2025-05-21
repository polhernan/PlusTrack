using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusTrackForms.Controler
{
    public class CrearEmpleatController
    {
        FormCrearEmpleat fCrearEmpleat = new FormCrearEmpleat();
        FormsRepository fRepository = new FormsRepository();

        public CrearEmpleatController()
        {
            SetListeners();
            LoadData();
            fCrearEmpleat.ShowDialog();
        }
        private void SetListeners()
        {
            fCrearEmpleat.bCrear.Click += BCrear_Click;
            fCrearEmpleat.bTancar.Click += BTancar_Click;
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            fCrearEmpleat.Close();
            new EmpleatsController();
        }

        private async void BCrear_Click(object sender, EventArgs e)
        {
            if (fCrearEmpleat.tbNom.Text != null && fCrearEmpleat.tbNom.Text != "" && fCrearEmpleat.tbCognoms.Text != null && fCrearEmpleat.tbCognoms.Text != "" &&
                fCrearEmpleat.tbDNI.Text != null && fCrearEmpleat.tbDNI.Text != "" &&  fCrearEmpleat.dtpDataNaixement.Checked == true && 
                fCrearEmpleat.tbEmail.Text != null && fCrearEmpleat.tbEmail.Text != "" && fCrearEmpleat.tbContrasenya.Text != null && fCrearEmpleat.tbContrasenya.Text != "")
            {
                Employee newEmployee = new Employee
                {
                    Name = fCrearEmpleat.tbNom.Text,
                    Surnames = fCrearEmpleat.tbCognoms.Text,
                    Dni = fCrearEmpleat.tbDNI.Text,
                    BirthDate = fCrearEmpleat.dtpDataNaixement.Value,
                    Email = fCrearEmpleat.tbEmail.Text,
                    Password = fCrearEmpleat.tbContrasenya.Text,
                    companyId = LoginController.companyId
                };
                await fRepository.PostEmployee(newEmployee);
                fCrearEmpleat.Close();
                new EmpleatsController();
            }
            else
            {
                MessageBox.Show("Falten dades per omplir.");
            }
        }

        private void LoadData()
        {
            fCrearEmpleat.dtpDataNaixement.Checked = false;
        }
    }
}
