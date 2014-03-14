using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAudioApi;

namespace XETA
{
    public class audioInterface
    {
        public MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
        public MMDevice device;

        public audioInterface()
        {
             device = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        }
        
        public int getMasterVolume()
        {
            return (int)device.AudioEndpointVolume.MasterVolumeLevelScalar * 100;
        }

        public int getMasterPeak()
        {
            return (int)(device.AudioMeterInformation.MasterPeakValue * 100);
        }

        public int getLeftPeak()
        {
            return (int)(device.AudioMeterInformation.PeakValues[0] * 100);
        }

        public int getRightPeak()
        {
            return (int)(device.AudioMeterInformation.PeakValues[1] * 100);
        }
    }
}
