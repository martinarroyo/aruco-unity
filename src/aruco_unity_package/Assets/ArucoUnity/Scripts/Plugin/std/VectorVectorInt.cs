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
      public class VectorVectorInt : HandleCppPtr
      {
        // Constructor & Destructor
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorVectorInt_new();

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorVectorInt_delete(System.IntPtr vector);

        // Functions
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_std_vectorVectorInt_at(System.IntPtr vector, uint pos, System.IntPtr exception);

        [DllImport("ArucoUnity")]
        static extern unsafe System.IntPtr* au_std_vectorVectorInt_data(System.IntPtr vector);

        [DllImport("ArucoUnity")]
        static extern void au_std_vectorVectorInt_push_back(System.IntPtr vector, System.IntPtr value);

        [DllImport("ArucoUnity")]
        static extern uint au_std_vectorVectorInt_size(System.IntPtr vector);

        public VectorVectorInt() : base(au_std_vectorVectorInt_new())
        {
        }

        public VectorVectorInt(System.IntPtr vectorVectorIntPtr, DeleteResponsibility deleteResponsibility = DeleteResponsibility.True)
          : base(vectorVectorIntPtr, deleteResponsibility)
        {
        }

        protected override void DeleteCvPtr()
        {
          au_std_vectorVectorInt_delete(cvPtr);
        }

        public VectorInt At(uint pos)
        {
          Exception exception = new Exception();
          VectorInt element = new VectorInt(au_std_vectorVectorInt_at(cvPtr, pos, exception.cvPtr), DeleteResponsibility.False);
          exception.Check();
          return element;
        }

        public unsafe VectorInt[] Data()
        {
          System.IntPtr* dataPtr = au_std_vectorVectorInt_data(cvPtr);
          uint size = Size();

          VectorInt[] data = new VectorInt[size];
          for (int i = 0; i < size; i++)
          {
            data[i] = new VectorInt(dataPtr[i], DeleteResponsibility.False);
          }

          return data;
        }

        public void PushBack(VectorInt value)
        {
          au_std_vectorVectorInt_push_back(cvPtr, value.cvPtr);
        }

        public uint Size()
        {
          return au_std_vectorVectorInt_size(cvPtr);
        }
      }
    }
  }

  /// \} aruco_unity_package
}