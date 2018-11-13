using Fingerprint.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprint.Toolkit
{
    public class EnrollmentEventArgs
    {
        FingerprintTemplateCollection _templates;

        public EnrollmentEventArgs(FingerprintTemplateCollection templates)
        {
            _templates = templates;
        }

        public FingerprintTemplateCollection Templates
        {
            get
            {
                return _templates;
            }
        }
}
}
