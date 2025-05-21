using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusTrackForms.Controler
{
    public class EmpleatsController
    {
        FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutas = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();

        FormsRepository formsRepository = new FormsRepository();

        List<Employee> employees = null;
        public EmpleatsController()
        {
            SetListeners();
            LoadData();
            fEmpleats.Show();
        }

        private void SetListeners()
        {
            fEmpleats.bEnviaments.Click += BEnviaments_Click;
            //fEmpleats.bEmpleats.Click += BEmpleats_Click;
            fEmpleats.bCamions.Click += BCamions_Click;
            fEmpleats.bRutes.Click += BRutes_Click;
            fEmpleats.bPaquets.Click += BPaquets_Click;
            fEmpleats.bUbicacions.Click += BUbicacions_Click;
            fEmpleats.bBuscar.Click += BBuscar_Click;
            fEmpleats.bCrear.Click += BCrear_Click;
        }

        private void BEnviaments_Click(object sender, EventArgs e)
        {
            fEmpleats.Close();
            EnviamentsController.fEnviaments.Show();
        }

        //private void BEmpleats_Click(object sender, EventArgs e)
        //{
        //    fEmpleats.Hide();
        //    new EmpleatsController();
        //}

        private void BCamions_Click(object sender, EventArgs e)
        {
            fEmpleats.Close();
            new CamionsController();
        }

        private void BRutes_Click(object sender, EventArgs e)
        {
            fEmpleats.Close();
            new RutesController();
        }

        private void BPaquets_Click(object sender, EventArgs e)
        {
            fEmpleats.Close();
            new PaquetsController();
        }

        private void BUbicacions_Click(object sender, EventArgs e)
        {
            fEmpleats.Close();
            new UbicacionsController();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string filter = fEmpleats.tbFiltre.Text;
            if (filter != null && filter != "")
            {
                SearchByFilter(filter);
            }
        }

        private void SearchByFilter(string filter)
        {
            switch (fEmpleats.cbFiltre.Text)
            {
                case "ID empleat":
                    fEmpleats.dgvEmpleats.DataSource = employees.Where(x => x.Id.ToString().Contains(filter)).ToList();
                    break;

                case "Nom":
                    fEmpleats.dgvEmpleats.DataSource = employees.Where(x => x.Name.Contains(filter)).ToList();
                    break;

                case "Cognom":
                    fEmpleats.dgvEmpleats.DataSource = employees.Where(x => x.Surnames.Contains(filter)).ToList();
                    break;

                case "DNI":
                    fEmpleats.dgvEmpleats.DataSource = employees.Where(x => x.Dni.Contains(filter)).ToList();
                    break;
                case "Email":
                    fEmpleats.dgvEmpleats.DataSource = employees.Where(x => x.Email.Contains(filter)).ToList();
                    break;
            }
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            new CrearEmpleatController();
            fEmpleats.Close();
        }
        private async void LoadData()
        {
            List<string> opcions = new List<string> { "ID empleat", "Nom", "Cognom", "DNI", "Email" };
            fEmpleats.cbFiltre.DataSource = opcions;
            employees = await formsRepository.GetEmployees(LoginController.companyId);
            fEmpleats.dgvEmpleats.DataSource = employees;
            fEmpleats.dgvEmpleats.Columns["Id"].Visible = false;
        }
    }
}
