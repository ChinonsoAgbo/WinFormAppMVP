using CrudWinFormMVP.Views;
using CrudWinFormMVP.Model;
using CrudWinFormMVP.Presenters;
using CrudWinFormMVP._Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CrudWinFormMVP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // connect the view and Repository to PetPresenter 

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IPetView petView = new PetView();
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(petView,repository);   

            Application.Run((Form)petView); // cast the form to view 
        }
    }
}
