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
    public class CrearCamioController
    {
        FormCrearCamio fCrearCamio = new FormCrearCamio();
        FormsRepository fRepository = new FormsRepository();

        public CrearCamioController()
        {
            SetListeners();
            LoadData();
            fCrearCamio.ShowDialog();
        }
        private void SetListeners()
        {
            fCrearCamio.bCrear.Click += BCrear_Click;
            fCrearCamio.bTancar.Click += BTancar_Click;
        }

        private void BTancar_Click(object sender, EventArgs e)
        {
            fCrearCamio.Close();
            new CamionsController();
        }

        private async void BCrear_Click(object sender, EventArgs e)
        {
            if (fCrearCamio.tbMatricula.Text != null && fCrearCamio.tbMatricula.Text != "" && fCrearCamio.dtpUltimaITV.Checked == true &&
                fCrearCamio.dtpSeguentITV.Checked == true && fCrearCamio.tbCapacitat.Text != null && fCrearCamio.tbCapacitat.Text != "")
            {
                Truck newTruck = new Truck
                {
                    Plate = fCrearCamio.tbMatricula.Text,
                    LastItv = fCrearCamio.dtpUltimaITV.Value,
                    NextItv = fCrearCamio.dtpSeguentITV.Value,
                    Capacity = int.Parse(fCrearCamio.tbCapacitat.Text),
                    companyId = LoginController.companyId
                };
                await fRepository.PostTruck(newTruck);
                fCrearCamio.Close();
                new CamionsController();
            }
            else
            {
                MessageBox.Show("Falten dades per omplir.");
            }
        }

        private void LoadData()
        {
            fCrearCamio.dtpUltimaITV.Checked = false;
            fCrearCamio.dtpSeguentITV.Checked = false;
        }
    }
}
