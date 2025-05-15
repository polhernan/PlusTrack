using PlusTrackForms.Model;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTrackForms.Controler
{
    public class UbicacionsController
    {
        FormEnviaments fEnviaments = new FormEnviaments();
        FormEmpleats fEmpleats = new FormEmpleats();
        FormCamions fCamions = new FormCamions();
        FormRutes fRutas = new FormRutes();
        FormPaquets fPaquets = new FormPaquets();
        FormUbicacions fUbicacions = new FormUbicacions();

        FormsRepository formsRepository = new FormsRepository();

        List<Locator> locator = null;
        public UbicacionsController()
        {
            SetListeners();
            LoadData();
            fUbicacions.Show();
        }

        private void SetListeners()
        {
            fUbicacions.bEnviaments.Click += BEnviaments_Click;
            fUbicacions.bEmpleats.Click += BEmpleats_Click;
            fUbicacions.bCamions.Click += BCamions_Click;
            fUbicacions.bRutes.Click += BRutes_Click;
            fUbicacions.bPaquets.Click += BPaquets_Click;
            //fUbicacions.bUbicacions.Click += BUbicacions_Click;
            fUbicacions.bActualitzar.Click += BActualitzar_Click;
        }

        private void BActualitzar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BEnviaments_Click(object sender, EventArgs e)
        {
            fUbicacions.Close();
            EnviamentsController.fEnviaments.Show();
        }

        private void BEmpleats_Click(object sender, EventArgs e)
        {
            fUbicacions.Close();
            new EmpleatsController();
        }

        private void BCamions_Click(object sender, EventArgs e)
        {
            fUbicacions.Close();
            new CamionsController();
        }

        private void BRutes_Click(object sender, EventArgs e)
        {
            fUbicacions.Close();
            new RutesController();
        }

        private void BPaquets_Click(object sender, EventArgs e)
        {
            fUbicacions.Close();
            new PaquetsController();
        }

        //private void BUbicacions_Click(object sender, EventArgs e)
        //{
        //    fUbicacions.Close();
        //    new UbicacionsController();
        //}

        private async void LoadData()
        {
            locator = await formsRepository.getLocations(LoginController.companyId);

            await fUbicacions.wvMap.EnsureCoreWebView2Async();

            string html = File.ReadAllText(@"C:\Users\cv\Desktop\PlusTrack\PlusTrackForms\PlusTrackForms\PlusTrackForms\Models\Entities\map.html");
            fUbicacions.wvMap.NavigateToString(html);

            // Suscribirse al mensaje desde el WebView
            fUbicacions.wvMap.CoreWebView2.WebMessageReceived += async (sender, args) =>
            {
                if (args.TryGetWebMessageAsString() == "Mapa listo")
                {
                    foreach (var location in locator)
                    {
                        string script = $"putMarker({location.Location.Latitude}, {location.Location.Longitude}, \"{location.Plate}\");";
                        await fUbicacions.wvMap.ExecuteScriptAsync(script);
                    }
                }
            };
        }
    }
}
