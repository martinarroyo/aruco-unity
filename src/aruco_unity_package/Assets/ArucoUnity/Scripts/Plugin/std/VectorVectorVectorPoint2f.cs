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
      public class VectorVectorVectorPoint2f : HandleCppPtr
      {
        // Constructor & Destructor
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorVectorVectorPoint2f_new();

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorVectorVectorPoint2f_delete(System.IntPtr vector);

        // Functions
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorVectorVectorPoint2f_at(System.IntPtr vector, uint pos, System.IntPtr exception);

        [DllImport("ArucoUnity")]
        static extern unsafe System.IntPtr* au_std_vectorVectorVectorPoint2f_data(System.IntPtr vector);

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorVectorVectorPoint2f_push_back(System.IntPtr vector, System.IntPtr value);

        [DllImport("ArucoUnity")]
        static extern uint au_std_vectorVectorVectorPoint2f_size(System.IntPtr vector);

        public VectorVectorVectorPoint2f() : base(au_std_vectorVectorVectorPoint2f_new())
        {
        }

        public VectorVectorVectorPoint2f(System.IntPtr vectorVectorVectorPoint2fPtr, DeleteResponsibility deleteResponsibility = DeleteResponsibility.True)
          : base(vectorVectorVectorPoint2fPtr, deleteResponsibility)
        {
        }

        protected override void DeleteCvPtr()
        {
          au_std_vectorVectorVectorPoint2f_delete(cvPtr);
        }

        public VectorVectorPoint2f At(uint pos)
        {
          Exception exception = new Exception();
          VectorVectorPoint2f element = new VectorVectorPoint2f(au_std_vectorVectorVectorPoint2f_at(cvPtr, pos, exception.cvPtr), DeleteResponsibility.False);
          exception.Check();
          return element;
        }

        public unsafe VectorVectorPoint2f[] Data()
        {
          System.IntPtr* dataPtr = au_std_vectorVectorVectorPoint2f_data(cvPtr);
          uint size = Size();

          VectorVectorPoint2f[] data = new VectorVectorPoint2f[size];
          for (int i = 0; i < size; i++)
          {
            data[i] = new VectorVectorPoint2f(dataPtr[i], DeleteResponsibility.False);
          }

          return data;
        }

        public void PushBack(VectorVectorPoint2f value)
        {
          au_std_vectorVectorVectorPoint2f_push_back(cvPtr, value.cvPtr);
        }

        public uint Size()
        {
          return au_std_vectorVectorVectorPoint2f_size(cvPtr);
        }
      }
    }
  }

  /// \} aruco_unity_package
}