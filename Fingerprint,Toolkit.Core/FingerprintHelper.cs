
using System;
using DPFP;
using DPFP.Verification;

namespace Fingerprint.Toolkit
{
    public class FingerprintHelper
    {
        public static DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        
        public static bool Verify(DPFP.Template template, DPFP.Sample sample)
        {
            var verificator = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
            // Process the sample and create a feature set for verification.
            DPFP.FeatureSet features = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
            if (features != null)
            {
                // Compare the feature set with our template
                verificator.Verify(features, template, ref result);
            }
            return result.Verified;
        }
    }
}
