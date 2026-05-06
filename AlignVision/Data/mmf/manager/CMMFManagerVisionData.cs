using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    internal sealed class CMMFManagerVisionData
    {
        public enum enumPage
        {
            //VISION_MAIN_ALIGN_1,
            //VISION_MAIN_ALIGN_2,
            //VISION_PRE_ALIGN,
            PAGE_FINAL = 1
        };

        private MemoryMappedFile _memMap;

        private MMVisionData_PageBase[] _VisionDataPages;

        private static CMMFManagerVisionData _instance = null;

        private static object _instanceCreateLock = new object();

        public static CMMFManagerVisionData Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_instanceCreateLock)
                    {
                        if (null == _instance)
                        {
                            _instance = new CMMFManagerVisionData();
                        }
                    }
                }
                return _instance;
            }
        }

        public CMMFPagesVisionData this[int iIndex] => _VisionDataPages[iIndex] as CMMFPagesVisionData;

        public CMMFPagesVisionData this[enumPage ePage] => _VisionDataPages[(int)ePage] as CMMFPagesVisionData;

        /// <summary>
        /// Initializes a new instance of the CMMFManagerVisionData class and sets up memory-mapped vision data storage.
        /// </summary>
        /// <remarks>This constructor creates or opens the underlying memory-mapped file used for vision
        /// data. If the file does not exist, it is initialized with default values. The vision data pages are allocated
        /// and associated with the memory map. This constructor is private and intended for internal use within the
        /// class.</remarks>
        private CMMFManagerVisionData()
        {
            string memMapFileName = "MEMData/MemoryMappedFileVisionData.bin";
            string memMapName = "MemoryMappedFileVisionData_" + Program.ID;
            bool flag = false;
            if (!File.Exists(memMapFileName))
            {
                flag = true;
            }
            _memMap = MMVisionData_PageBase.CreateMemMap(fileName: memMapFileName, mapName:memMapName, pageCount: (uint)enumPage.PAGE_FINAL);

            _VisionDataPages = new CMMFPagesVisionData[(int)enumPage.PAGE_FINAL];
            for (int i = 0; i < (int)enumPage.PAGE_FINAL; i++)
            {
                _VisionDataPages[i] = new CMMFPagesVisionData(_memMap, (uint)i, pageCount: (uint)enumPage.PAGE_FINAL);
            }
            if (flag)
            {
                DefaultValue();
            }
        }

        private void DefaultValue()
        {
            for (int i = 0; i < (int)enumPage.PAGE_FINAL; i++)
            {
                ((CMMFPagesVisionData)_VisionDataPages[i]).DefaultValue();
            }
        }
    }

}


