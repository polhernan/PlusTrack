using PlusTrackForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Controler
{
    public class FormsController
    {
        FormEnviaments fenviaments = new FormEnviaments();
        FormsRepository formsRepository = new FormsRepository();

        public FormsController()
        {
            SetListeners();
            LoadData();
            fenviaments.Show();
        }

        private void SetListeners()
        {
            //fenviaments.bUbicacions.Click += 
        }

        private void LoadData()
        {
            
        }
    }
}
