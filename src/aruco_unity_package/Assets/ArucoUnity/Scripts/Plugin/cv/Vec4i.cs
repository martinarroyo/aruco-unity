using System.Runtime.InteropServices;

namespace ArucoUnity
{
  /// \addtogroup aruco_unity_package
  /// \{

  namespace Plugin
  {
    namespace cv
    {
      public class Vec4i : HandleCppPtr
      {
        // Constructor & Destructor
        [DllImport("ArucoUnity")]
        static extern System.IntPtr au_cv_Vec4i_new();

        [DllImport("ArucoUnity")]
        static extern void au_cv_Vec4i_delete(System.IntPtr vec4i);

        // Variables
        [DllImport("ArucoUnity")]
        static extern int au_cv_Vec4i_get(System.IntPtr vec4i, int i, System.IntPtr exception);

        [DllImport("ArucoUnity")]
        static extern void au_cv_Vec4i_set(System.IntPtr vec4i, int i, int value, System.IntPtr exception);

        public Vec4i() : base(au_cv_Vec4i_new())
        {
        }

        public Vec4i(System.IntPtr vec4iPtr, DeleteResponsibility deleteResponsibility = DeleteResponsibility.True)
          : base(vec4iPtr, deleteResponsibility)
        {
        }

        protected override void DeleteCvPtr()
        {
          au_cv_Vec4i_delete(cvPtr);
        }

        public int Get(int i)
        {
          Exception exception = new Exception();
          int value = au_cv_Vec4i_get(cvPtr, i, exception.cvPtr);
          exception.Check();
          return value;
        }

        public void Set(int i, int value)
        {
          Exception exception = new Exception();
          au_cv_Vec4i_set(cvPtr, i, value, exception.cvPtr);
          exception.Check();
        }
      }
    }
  }

  /// \} aruco_unity_package
}