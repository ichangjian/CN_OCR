#pragma once

using namespace System;


namespace CNOCR {
	public ref class RECG
	{
	public:
		int setImage(IntPtr image, int imageWidth, int imageHeight, int pixelFormat,  Collections::Generic::List<String^>^ cnt);
	};
}
