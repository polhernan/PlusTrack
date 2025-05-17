using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusTrackForms.Controler
{
    public class PaquetsController
    {
        FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutas = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();

        FormsRepository formsRepository = new FormsRepository();

        List<Package> packages = null;
        public PaquetsController()
        {
            SetListeners();
            LoadData();
            fPaquets.Show();
        }

        private void SetListeners()
        {
            fPaquets.bEnviaments.Click += BEnviaments_Click;
            fPaquets.bEmpleats.Click += BEmpleats_Click;
            fPaquets.bCamions.Click += BCamions_Click;
            fPaquets.bRutes.Click += BRutes_Click;
            //fPaquets.bPaquets.Click += BPaquets_Click;
            fPaquets.bUbicacions.Click += BUbicacions_Click;
        }

        private void BEnviaments_Click(object sender, EventArgs e)
        {
            fPaquets.Close();
            EnviamentsController.fEnviaments.Show();
        }

        private void BEmpleats_Click(object sender, EventArgs e)
        {
            fPaquets.Close();
            new EmpleatsController();
        }

        private void BCamions_Click(object sender, EventArgs e)
        {
            fPaquets.Close();
            new CamionsController();
        }

        private void BRutes_Click(object sender, EventArgs e)
        {
            fPaquets.Close();
            new RutesController();
        }

        //private void BPaquets_Click(object sender, EventArgs e)
        //{
        //    fPaquets.Close();
        //    new PaquetsController();
        //}

        private void BUbicacions_Click(object sender, EventArgs e)
        {
            fPaquets.Close();
            new UbicacionsController();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string filter = fPaquets.tbFiltre.Text;
            if (filter != null && filter != "")
            {
                SearchByFilter(filter);
            }
        }

        private void SearchByFilter(string filter)
        {
            switch (fPaquets.cbFiltre.Text)
            {
                case "Id":
                    fPaquets.dgvUbicacions.DataSource = packages.Where(x => x.Id.ToString().Contains(filter)).ToList();
                    break;

                case "Estat":
                    fPaquets.dgvUbicacions.DataSource = packages.Where(x => x.Status.Equals(filter)).ToList();
                    break;

                case "Email":
                    fPaquets.dgvUbicacions.DataSource = packages.Where(x => x.User.Email.Contains(filter));
                    break;
            }
        }

        private async void LoadData()
        {
            List<string> opcions = new List<string> { "ID Paquet", "Estat", "Email"};
            fPaquets.cbFiltre.DataSource = opcions;
            packages = await formsRepository.GetPackages(LoginController.companyId);
            fPaquets.dgvUbicacions.DataSource = packages;
        }
    }
}
