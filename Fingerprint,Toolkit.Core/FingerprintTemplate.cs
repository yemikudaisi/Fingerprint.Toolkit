using DPFP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprint.Toolkit
{
    public class FingerprintTemplate
    {
        public virtual Hands Hand { get; set; }
        public virtual Fingers Finger { get; set; }
        public virtual Template Template { get; set; }

        public FingerprintTemplate(){
            // Added to allow the use of object initializer    
        }

        public FingerprintTemplate(string identifier, Template template)
        {
            if (identifier.Length > 2)
            {
                throw new ArgumentOutOfRangeException("The template identifier cannot be more that 2 characters");
            }

            if (template == null)
            {
                throw new ArgumentException("Template cannot be empty");
            }

            try
            {
                Hand = (Hands)Int32.Parse(identifier.Substring(0, 1));
                Finger = (Fingers)Int32.Parse(identifier.Substring(1, 1));
                Template = template;
            }
            catch
            {
                throw new ArgumentException("Illegal hand or finger identifier for fingerprint");
            }

        }

        public FingerprintTemplate(int finger, Template template)
        {
            Hand = DigitalPersonaHelper.FingerToHands(finger);
            Finger = DigitalPersonaHelper.FingerToFingers(finger);
            Template = template;
        }

        public string Identifier
        {
            get {
                var h = (int)Hand;
                var f = (int)Finger;
                return h.ToString() + f.ToString();
            }
        }

        public KeyValuePair<string, Template> ToKeyValuePair()
        {
            if (Template == null)
            {
                throw new NullReferenceException("Template has not been initialized.");
            }
            return new KeyValuePair<string, Template>(Identifier, Template);
        }
    }
}
