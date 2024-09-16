using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWinFormMVP.Model;
using CrudWinFormMVP.Views;


namespace CrudWinFormMVP.Presenters
{
    public class PetPresenter
    {
        // Fields 
        // Note that the Interface for Model is ignored in this tutorial 
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource; // stores the list of pets 
        private IEnumerable<PetModel> petList;

        // constructor 
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource = new BindingSource();   
            this.view = view;
            this.repository = repository;

            // Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSeletedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;

            // set pets binding source 
            this.view.SetPetListBindingSource(petsBindingSource);

            // load pet list view 
            LoadAllPetList(); 

            // Show view 
            this.view.Show();
        }

        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList; // Set data source -> updates the data anytime the data Grid changes 
        }

        private void SearchPet(object sender, EventArgs e)
        {

            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petsBindingSource.DataSource = petList; // load the list 
        }

        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSeletedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SavePet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
