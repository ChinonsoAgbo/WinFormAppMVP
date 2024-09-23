using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWinFormMVP.Views
{
    public partial class PetView : Form, IPetView
    {
        private bool isSuccessful;
        private bool isEdit;
        private string message;

        // constructor 
        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
          tabControl1.TabPages.Remove(tabPageDetail);
            btnPetClose.Click += delegate { this.Close(); };

        }

        private void AssociateAndRaiseViewEvents()
        {
            searchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            searchPetValue.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);

            };
            // Others
         }

        public string PetId
        {
            get { return petIDValue.Text; }
            set { petIDValue.Text = value; }
        }
        public string PetName
        {
            get { return petNameValue.Text; }
            set { petNameValue.Text = value; }
        }
        public string PetType
        {
            get { return petTypeValue.Text; }
            set { petTypeValue.Text = value; }
        }
        public string PetColour
        {
            get { return petColourValue.Text; }
            set { petColourValue.Text = value; }
        }
        public string SearchValue
        {
            get { return searchPetValue.Text; }
            set { searchPetValue.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        // Eventz 
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        // Methods
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }


        // Singleton pattern open a single form instance 
        private static PetView instance;
        public static PetView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;

            }

            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }


    }
}
