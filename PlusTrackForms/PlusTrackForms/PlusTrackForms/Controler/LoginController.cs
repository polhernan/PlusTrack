using PlusTrackForms.Model;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusTrackForms.Controler
{
    public class LoginController
    {
        public static FormLogin fLogin = new FormLogin();
        public static FormEnviaments fEnviaments = new FormEnviaments();
        public static String companyId = null;
        FormsRepository fRepository = new FormsRepository();

        public LoginController()
        {
            SetListeners();
            LoadData();
            Application.Run(fLogin);
        }

        private void SetListeners()
        {
            fLogin.bEntrar.Click += BEntrar_Click;
        }

        private async void BEntrar_Click(object sender, EventArgs e)
        {
            string email = fLogin.tbEmail.Text;
            companyId = await fRepository.GetBuisnessId(email);
            if (companyId != null && companyId != "")
            {
                fLogin.Hide();
                new EnviamentsController();
            } else
            {
                //Empresa no existe
            }
        }

        private void LoadData()
        {
            
        }
    }
}
