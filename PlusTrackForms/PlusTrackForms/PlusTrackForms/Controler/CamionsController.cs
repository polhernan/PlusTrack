using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusTrackForms.Controler
{
    public class CamionsController
    {
        FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutas = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();

        List<Truck> trucks = null;

        FormsRepository formsRepository = new FormsRepository();
        public CamionsController()
        {
            SetListeners();
            LoadData();
            fCamions.Show();
        }

        private void SetListeners()
        {
            fCamions.bEnviaments.Click += BEnviaments_Click;
            fCamions.bEmpleats.Click += BEmpleats_Click;
            //fCamions.bCamions.Click += BCamions_Click;
            fCamions.bRutes.Click += BRutes_Click;
            fCamions.bPaquets.Click += BPaquets_Click;
            fCamions.bUbicacions.Click += BUbicacions_Click;
            fCamions.bBuscar.Click += BBuscar_Click;
            fCamions.bCrear.Click += BCrear_Click;
        }

        private void BEnviaments_Click(object sender, EventArgs e)
        {
            fCamions.Close();
            EnviamentsController.fEnviaments.Show();
        }

        private void BEmpleats_Click(object sender, EventArgs e)
        {
            fCamions.Close();
            new EmpleatsController();
        }

        //private void BCamions_Click(object sender, EventArgs e)
        //{
        //    fCamions.Close();
        //    new CamionsController();
        //}

        private void BRutes_Click(object sender, EventArgs e)
        {
            fCamions.Close();
            new RutesController();
        }

        private void BPaquets_Click(object sender, EventArgs e)
        {
            fCamions.Close();
            new PaquetsController();
        }

        private void BUbicacions_Click(object sender, EventArgs e)
        {
            fCamions.Close();
            new UbicacionsController();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string filter = fCamions.tbFiltre.Text;
            if (filter != null && filter != "")
            {
                SearchByFilter(filter);
            }
        }

        private void SearchByFilter(string filter)
        {
            switch (fCamions.cbFiltre.Text)
            {
                case "ID Enviament":
                    fCamions.dgvCamions.DataSource = trucks.Where(x => x.Id.ToString().Contains(filter)).ToList();
                    break;

                case "Matricula":
                    fCamions.dgvCamions.DataSource = trucks.Where(x => x.Plate.Contains(filter)).ToList();
                    break;
            }
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            new CrearCamioController();
            fCamions.Close();
        }

        private async void LoadData()
        {
            List<string> opcions = new List<string> { "ID Camió", "Matricula", "Ultima ITV", "Seguent ITV", "Capacitat" };
            fCamions.cbFiltre.DataSource = opcions;
            trucks = await formsRepository.GetTrucks(LoginController.companyId);
            fCamions.dgvCamions.DataSource = trucks;
            fCamions.dgvCamions.Columns["Id"].Visible = false;
        }
    }
}
