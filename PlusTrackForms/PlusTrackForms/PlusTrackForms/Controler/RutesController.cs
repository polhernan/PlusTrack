using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Models.RequestModels;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusTrackForms.Controler
{
    public class RutesController
    {
        FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutes = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();

        FormsRepository formsRepository = new FormsRepository();
        
        List<Route> rutes = null;
        List<Route> rutesFiltrades = null;
        CardviewRuta newCard = null;
        public RutesController()
        {
            SetListeners();
            LoadData();
            fRutes.Show();
        }

        private void SetListeners()
        {
            fRutes.bEnviaments.Click += BEnviaments_Click;
            fRutes.bEmpleats.Click += BEmpleats_Click;
            fRutes.bCamions.Click += BCamions_Click;
            //fRutes.bRutes.Click += BRutes_Click;
            fRutes.bPaquets.Click += BPaquets_Click;
            fRutes.bUbicacions.Click += BUbicacions_Click;
            fRutes.bCrearRutes.Click += BCrearRutes_Click;
        }

        private void BCrearRutes_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private async Task SendRequest()
        {
            if (fRutes.dgvConductors.Rows.Count > 0 && fRutes.dgvConductors.SelectedRows.Count > 0 && fRutes.dgvCamions.Rows.Count > 0 && fRutes.dgvCamions.SelectedRows.Count > 0)
            {
                Employee selectedEmployee = fRutes.dgvConductors.SelectedRows[0].DataBoundItem as Employee;
                Truck selectedTruck = fRutes.dgvCamions.SelectedRows[0].DataBoundItem as Truck;
                String totalRutesAux = fRutes.tbQtyRutes.Text;
                if (int.TryParse(totalRutesAux, out int totalRutes))
                {
                    CreateRouteRequest newRequest = new CreateRouteRequest
                    {
                        employeeId = selectedEmployee.Id,
                        truckId = selectedTruck.Id,
                        amountStops = totalRutes
                    };
                    bool aux = await formsRepository.CreateRoute(newRequest);
                    LoadData();
                }
                else
                {
                    Console.WriteLine("Nomes s'accepten numeros sencers");
                }
            }
        }

        private void BEnviaments_Click(object sender, EventArgs e)
        {
            fRutes.Close();
            EnviamentsController.fEnviaments.Show();
        }

        private void BEmpleats_Click(object sender, EventArgs e)
        {
            fRutes.Close();
            new EmpleatsController();
        }

        private void BCamions_Click(object sender, EventArgs e)
        {
            fRutes.Close();
            new CamionsController();
        }

        //private void BRutes_Click(object sender, EventArgs e)
        //{
        //    fRutes.Close();
        //    new RutesController();
        //}

        private void BPaquets_Click(object sender, EventArgs e)
        {
            fRutes.Close();
            new PaquetsController();
        }

        private void BUbicacions_Click(object sender, EventArgs e)
        {
            fRutes.Close();
            new UbicacionsController();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string filter = fRutes.tbFiltre.Text;
            if (filter != null && filter != "")
            {
                SearchByFilter(filter);
            }
        }

        private void SearchByFilter(string filter)
        {
            switch (fRutes.cbFiltre.Text)
            {
                case "Email":
                    rutesFiltrades = rutes.Where(x => x.Employee.Email.Contains(filter)).ToList();
                    break;

                case "Matricula":
                    rutesFiltrades = rutes.Where(x => x.Truck.Plate.Contains(filter)).ToList();
                    break;
            }
        }

        public void CreateRoutesCards(List<Route> rutes)
        {
            foreach (Route ruta in rutes)
            {
                var card = new CardviewRuta();
                card.lConductor.Text = ruta.Employee.Email;
                card.lCamio.Text = ruta.Truck.Plate;
                fRutes.flpConductor.Controls.Add(card);
            }
        }

        private async void LoadData()
        {
            List<string> opcions = new List<string> { "Email", "Matricula" };
            fRutes.cbFiltre.DataSource = opcions;
            fRutes.dgvConductors.DataSource = await formsRepository.GetEmployeesWithoutRoute(LoginController.companyId);
            fRutes.dgvConductors.Columns["Id"].Visible = false;
            fRutes.dgvCamions.DataSource = await formsRepository.GetTrucksAvailable(LoginController.companyId);
            fRutes.dgvCamions.Columns["Id"].Visible = false;
            rutes = await formsRepository.GetRoutes(LoginController.companyId);
            fRutes.flpConductor.Controls.Clear();
            CreateRoutesCards(rutes);
        }
    }
}
