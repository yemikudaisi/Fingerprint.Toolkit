using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprint.Toolkit
{
    public class FingerprintTemplateCollection : Collection<FingerprintTemplate>
    {
        public new void Add(FingerprintTemplate f)
        {
            for (var i = 0; i<this.Count-1; i++)
            {
                if ( this[i].Finger == f.Finger && this[i].Hand == f.Hand)
                {
                    base.RemoveAt(i);
                }
            }
            base.Add(f);
        }

        public new void Remove(FingerprintTemplate f)
        {
            for (var i = 0; i < this.Count - 1; i++)
            {
                if (this[i].Finger == f.Finger && this[i].Hand == f.Hand)
                {
                    base.RemoveAt(i);
                }
            }
        }

        public void RemoveFinger(int f)
        {
            for (var i = 0; i < this.Count - 1; i++)
            {
                if (this[i].Finger == DigitalPersonaHelper.FingerToFingers(f) && this[i].Hand == DigitalPersonaHelper.FingerToHands(f))
                {
                    base.RemoveAt(i);
                }
            }
        }
    }
}
