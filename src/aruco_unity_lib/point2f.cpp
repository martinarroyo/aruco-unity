#include "aruco_unity/utility/point2f.hpp"

extern "C" {
  // Constructors & Destructors
  cv::Point2f* au_Point2f_new() {
    return new cv::Point2f();
  }
  
  void au_Point2f_delete(cv::Point2f* point2f) {
    delete point2f;
  }

  // Variables
  float au_Point2f_getX(cv::Point2f* point2f) {
    return point2f->x;
  }

  void au_Point2f_setX(cv::Point2f* point2f, float x) {
    point2f->x = x;
  }

  float au_Point2f_getY(cv::Point2f* point2f) {
    return point2f->y;
  }

  void au_Point2f_setY(cv::Point2f* point2f, float y) {
    point2f->y = y;
  }
}