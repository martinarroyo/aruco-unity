using System.Runtime.InteropServices;
using ArucoUnity.Plugin.cv;

namespace ArucoUnity
{
  /// \addtogroup aruco_unity_package
  /// \{

  namespace Plugin
  {
    namespace std
    {
      public class VectorMat : HandleCppPtr
      {
        // Constructor & Destructor
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorMat_new();

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorMat_delete(System.IntPtr vector);

        // Functions
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorMat_at(System.IntPtr vector, uint pos, System.IntPtr exception);

        [DllImport("ArucoUnity")]
        static extern unsafe System.IntPtr* au_std_vectorMat_data(System.IntPtr vector);

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorMat_push_back(System.IntPtr vector, System.IntPtr value);

        [DllImport("ArucoUnity")]
        static extern uint au_std_vectorMat_size(System.IntPtr vector);

        public VectorMat() : base(au_std_vectorMat_new())
        {
        }

        public VectorMat(System.IntPtr vectorMatPtr, DeleteResponsibility deleteResponsibility = DeleteResponsibility.True)
          : base(vectorMatPtr, deleteResponsibility)
        {
        }

        protected override void DeleteCvPtr()
        {
          au_std_vectorMat_delete(cvPtr);
        }

        public Mat At(uint pos)
        {
          Exception exception = new Exception();
          Mat element = new Mat(au_std_vectorMat_at(cvPtr, pos, exception.cvPtr), DeleteResponsibility.False);
          exception.Check();
          return element;
        }

        public unsafe Mat[] Data()
        {
          System.IntPtr* dataPtr = au_std_vectorMat_data(cvPtr);
          uint size = Size();

          Mat[] data = new Mat[size];
          for (int i = 0; i < size; i++)
          {
            data[i] = new Mat(dataPtr[i], DeleteResponsibility.False);
          }

          return data;
        }

        public void PushBack(Mat value)
        {
          au_std_vectorMat_push_back(cvPtr, value.cvPtr);
        }

        public uint Size()
        {
          return au_std_vectorMat_size(cvPtr);
        }
      }
    }
  }

  /// \} aruco_unity_package
}