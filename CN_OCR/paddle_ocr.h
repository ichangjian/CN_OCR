#include "opencv2/core.hpp"
#define API_EXPORT_C extern "C" __declspec(dllexport)
#define API_EXPORT  __declspec(dllexport)

API_EXPORT std::vector<std::string> paddle_ocr(const cv::Mat &_image, 
	const std::string &_config);