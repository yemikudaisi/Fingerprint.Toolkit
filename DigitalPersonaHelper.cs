using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CND.Biometric.Fingerprint
{
    public class DigitalPersonaHelper
    {
        public static Hands FingerToHands(int finger)
        {
            if (finger > 5)
            {
                return Hands.LEFT;
            }
            return Hands.RIGHT;
        }

        public static Fingers FingerToFingers(int finger)
        {
            switch (finger)
            {
                case 1:
                case 6:
                    return Fingers.THUMB;
                case 2:
                case 7:
                    return Fingers.INDEX;
                case 3:
                case 8:
                    return Fingers.MIDDLE;
                case 4:
                case 9:
                    return Fingers.RING;
                case 5:
                case 10:
                    return Fingers.PINKY;
                default:
                    throw new ArgumentException("finger cannot be less than 1 or greater than 10");
            }
        }
    }
}
