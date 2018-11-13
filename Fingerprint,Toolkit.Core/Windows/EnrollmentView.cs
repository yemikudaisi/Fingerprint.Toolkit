using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint.Toolkit
{
    public partial class EnrollmentView : Form
    {
        public delegate void EnrollmentEventHandler(EnrollmentEventArgs e);
        public event EnrollmentEventHandler EnrollmentCompleteEvent;
        private bool isEventHandlerSucceeds = true;
        FingerprintTemplateCollection enrolledTemplates;
        private int enrolledFingerMask;

        // This determines the amout of finger prints that will be scanned during enrollment
        private int maxEnrollFingerCount;

        public int EnrolledFingerMask { get => enrolledFingerMask; set => enrolledFingerMask = value; }
        public int MaxEnrollFingerCount { get => maxEnrollFingerCount; set => maxEnrollFingerCount = value; }

        public EnrollmentView()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            btnComplete.Enabled = false;
            EnrollmentControl.EnrolledFingerMask = EnrolledFingerMask;
            EnrollmentControl.MaxEnrollFingerCount = MaxEnrollFingerCount;
            enrolledTemplates = new FingerprintTemplateCollection();
        }

        protected virtual void OnEnrollmentComplete()
        {
            EnrollmentCompleteEvent?.Invoke(new EnrollmentEventArgs(enrolledTemplates));
        }


        public void EnrollmentControl_OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (isEventHandlerSucceeds)
            {
                enrolledTemplates.Add(new FingerprintTemplate(Finger, Template));						// update other data
                ListEvents.Items.Insert(0, String.Format("OnEnroll: finger {0}", Finger));
                if (enrolledTemplates.Count == MaxEnrollFingerCount)
                {
                    btnComplete.Enabled = true;
                }
            }
            else
                Status = DPFP.Gui.EventHandlerStatus.Failure;   // force a "failure" status
        }

        private void EnrollmentControl_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        public void EnrollmentControl_OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (isEventHandlerSucceeds)
            {
                enrolledTemplates.RemoveFinger(Finger);
                ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger));
            }
            else
                Status = DPFP.Gui.EventHandlerStatus.Failure;   // force a "failure" status
        }

        private void EnrollmentControl_OnCancelEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerRemove(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback));
        }

        private void EnrollmentControl_OnComplete(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            ListEvents.Items.Clear();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            OnEnrollmentComplete();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (enrolledTemplates.Count > 0)
            {
                DialogResult myResult;
                StringBuilder message = new StringBuilder();
                message.AppendLine("Are you sure you want to cancel fingerprint enrollment ?");
                message.AppendFormat("Your have {0} enrolled fingerprints", enrolledTemplates.Count);
                myResult = MessageBox.Show(message.ToString(), "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (myResult != DialogResult.Yes)
                {
                    return;
                }
            }
            Close();
        }
    }
}
