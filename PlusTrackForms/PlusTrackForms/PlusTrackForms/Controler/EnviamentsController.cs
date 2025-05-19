using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlusTrackForms.Controler
{
    public class EnviamentsController
    {
        public static FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutas = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();
        FormLogin fLogin = new FormLogin();

        FormsRepository formsRepository = new FormsRepository();

        List<Route> rutes = null;

        public EnviamentsController()
        {
            SetListeners();
            LoadData();
            fEnviaments.Show();
        }

        private void SetListeners()
        {
            //fEnviaments.bEnviaments.Click += BEnviaments_Click;
            fEnviaments.bEmpleats.Click += BEmpleats_Click;
            fEnviaments.bCamions.Click += BCamions_Click;
            fEnviaments.bRutes.Click += BRutes_Click;
            fEnviaments.bPaquets.Click += BPaquets_Click;
            fEnviaments.bUbicacions.Click += BUbicacions_Click;
            fEnviaments.bBuscar.Click += BBuscar_Click;

        }

        //private void BEnviaments_Click(object sender, EventArgs e)
        //{

        //}

        private void BEmpleats_Click(object sender, EventArgs e)
        {
            fEnviaments.Hide();
            new EmpleatsController();
        }

        private void BCamions_Click(object sender, EventArgs e)
        {
            fEnviaments.Hide();
            new CamionsController();
        }

        private void BRutes_Click(object sender, EventArgs e)
        {
            fEnviaments.Hide();
            new RutesController();
        }

        private void BPaquets_Click(object sender, EventArgs e)
        {
            fEnviaments.Hide();
            new PaquetsController();
        }

        private void BUbicacions_Click(object sender, EventArgs e)
        {
            fEnviaments.Hide();
            new UbicacionsController();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string filter = fEnviaments.tbFiltre.Text;
            if (filter != null && filter != "")
            {
                SearchByFilter(filter);
            }
        }

        private void SearchByFilter(string filter)
        {
            switch (fEnviaments.cbFiltre.Text)
            {
                case "ID Ruta":
                    fEnviaments.dgvPackages.DataSource = rutes.Where(x => x.Id.Equals(filter)).ToList();                    
                    break;

                case "Repartidor":
                    fEnviaments.dgvPackages.DataSource = rutes.Where(x => x.Employee.Email.Contains(filter)).ToList();                    
                    break;

                case "Camio":
                    fEnviaments.dgvPackages.DataSource = rutes.Where(x => x.Truck.Plate.Contains(filter)).ToList();
                    break;
            }
        }

        public async void CreateRoutesCards(List<Route> rutes)
        {
            foreach (Route ruta in rutes)
            {
                var card = new CardviewEnviaments();
                card.lId.Text = ruta.Id.ToString();
                card.lRepartidor.Text = (ruta.Employee.Name + " " + ruta.Employee.Surnames);
                card.lCamio.Text = ruta.Truck.Plate;
                card.bBuscar.Click += async (sender, e) =>
                {
                    List<Package> packagesFromRoute = await formsRepository.getPackagesFromRoute(ruta.Id.ToString());
                    fEnviaments.dgvPackages.DataSource = packagesFromRoute;
                };
                fEnviaments.flpComandes.Controls.Add(card);
            }
        }

        private async void LoadData()
        {
            List<string> opcions = new List<string> { "ID Ruta", "Repartidor", "Camio" };
            fEnviaments.cbFiltre.DataSource = opcions;
            rutes = await formsRepository.GetRoutes(LoginController.companyId);
            //fEnviaments.dgvPackages.DataSource = rutes.ToList();
            fEnviaments.flpComandes.Controls.Clear();
            CreateRoutesCards(rutes);
        }
    }
}
