using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CDeviceLightControllerVirtual : CDeviceLightControllerAbstract
    {
        AlignVision.CDeviceLightControllerAbstract.CLightControllerError m_objError = new AlignVision.CDeviceLightControllerAbstract.CLightControllerError();
        private CallBackFuntionReceiveData m_objCallback = null;

        public CDeviceLightControllerVirtual()
        {
        }

        public override string GetVersion()
        {
            return "1.0.0.1";
        }

        public override bool Initialize( AlignVision.CDeviceLightControllerAbstract.CInitializeParameter objInitializeParameter )
        {
            bool bReturn = false;

            do
            {
                bReturn = true;
            } while( false );

            return bReturn;
        }

        public override void DeInitialize()
        {
        }

        public override bool IsConnected()
        {
            return true;
        }

        public override void SetCallbackFunction( AlignVision.CDeviceLightControllerAbstract.CallBackFuntionReceiveData objReceiveData )
        {
            m_objCallback = objReceiveData;
        }

        public override bool SetLightIntensity( int iChannel, int iIntensity )
        {
            bool bReturn = false;

            do {

                bReturn = true;
            } while( false );

            return bReturn;
        }

        public override bool SetLightIntensity( int[] iIntensity )
        {
            bool bReturn = false;

            do {

                bReturn = true;
            } while( false );

            return bReturn;
        }

        public override bool SetLightOff( int iChannel )
        {
            bool bReturn = false;

            do {

                bReturn = true;
            } while( false );

            return bReturn;
        }

        public override bool SetLightOff()
        {
            bool bReturn = false;

            do {


                bReturn = true;
            } while( false );

            return bReturn;
        }


        private void MakeError()
        {

        }

        public override AlignVision.CDeviceLightControllerAbstract.CLightControllerError HLGetErrorCode()
        {
            return ( AlignVision.CDeviceLightControllerAbstract.CLightControllerError )m_objError.Clone();
        }

    }
}
