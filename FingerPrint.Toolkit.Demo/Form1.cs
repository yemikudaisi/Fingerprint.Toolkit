using Fingerprint.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerPrint.Toolkit.Demo
{
    public partial class Form1 : Form
    {
        const string FILE_NAME= "fingerprints-collection.tarc";
        FingerprintTemplateCollection templatesCollection;

        public Form1()
        {
            templatesCollection = new FingerprintTemplateCollection();
            InitializeComponent();

            // Read ab archive file is it exists
            if (File.Exists(FILE_NAME))
                templatesCollection =  TemplateArchiveHelper.GetTemplates(FILE_NAME);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnrollmentView view = new EnrollmentView();
            view.MaxEnrollFingerCount = 2;
            view.EnrollmentCompleteEvent += View_EnrollmentCompleteEvent;
            view.ShowDialog();
        }


        private void View_EnrollmentCompleteEvent(EnrollmentEventArgs e)
        {
            templatesCollection = e.Templates;
            // Save templates collection as a archive
            TemplateArchiveHelper.SaveTemplateArchive(templatesCollection, FILE_NAME);
        }
    }
}
