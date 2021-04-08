#include "stdafx.h"
#include <opencv2/opencv.hpp>
#include "CN_OCR.h"
#include "paddle_ocr.h"

using namespace CNOCR;
int RECG::setImage(IntPtr image, int imageWidth, int imageHeight, int pixelFormat, Collections::Generic::List<String^>^ cnt)
{
	cv::Mat img=cv::Mat(imageHeight, imageWidth, CV_8UC3, (char*)image.ToPointer(), 0).clone();
	std::vector<std::string> cnts = paddle_ocr(img, "./config.txt");
	cv::waitKey(2000);
	for (size_t i = 0; i < cnts.size(); i++)
	{
		array<uchar>^ c_array = gcnew array<uchar>(cnts[i].length());
		for (size_t j = 0; j < cnts[i].length(); j++)
		{
			c_array[j] = cnts[i][j];
		}
		Text::Encoding^ u8enc = Text::Encoding::UTF8;
				cnt->Add(u8enc->GetString(c_array));
	}
	return 0;
}