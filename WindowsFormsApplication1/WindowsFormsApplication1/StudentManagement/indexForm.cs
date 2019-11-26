using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.StudentManagement
{

    public partial class indexForm : Form
    {
        private LogicLayer Business;
        public indexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += indexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStundents.DoubleClick += grdStundent_DoubleClick;

        }

        void grdStundent_DoubleClick(object sender, EventArgs e)
        {
            if ( this.grdStundents.SelectedRows.Count==1)
            {
                var row = this.grdStundents.SelectedRows[0];
                var studentView = (StudentView)row.DataBoundItem;

                new UpdateStudent(studentView.id).ShowDialog();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
           
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudents();
        }
        private void ShowAllStudents()
        {
            //this.grdStundent.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentViews = new StudentView[students.Length];
            for (int i =0;i<students.Length;i++)
                studentViews[i] = new StudentView(students[i]);
            this.grdStundents.DataSource = studentViews;
        }
        void indexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudents();
           
        }
    }
}
