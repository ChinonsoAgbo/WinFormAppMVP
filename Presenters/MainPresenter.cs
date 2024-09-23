using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using CrudWinFormMVP.Views;
using CrudWinFormMVP.Model;
using CrudWinFormMVP._Repositories;

namespace CrudWinFormMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowPetView += ShowPetsView;
        }

        private void ShowPetsView(object sender, EventArgs e)
        {
            IPetView petView = PetView.GetInstance((Form)mainView);
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(petView, repository);


        }
    }
}
