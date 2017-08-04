#include "stdafx.h"
#include "FileCacheWrapper.h"

using namespace System;
using namespace System::Runtime::InteropServices;

using namespace MyInteropLib;

FileCacheWrapper::FileCacheWrapper()  //��[17] 
{
	m_pCache = new CFileCache();      //��[18] 
	m_MData = gcnew ManagedData();   //��[19] 
}

bool FileCacheWrapper::Load(String^ filePath)  //��[20] 
{
	IntPtr p1;
	p1 = Marshal::StringToHGlobalUni(filePath);
	BOOL b = m_pCache->Load((LPCWSTR)p1.ToPointer());  //��[21] 
	Marshal::FreeHGlobal(p1);
	return (b) ? true : false;
}

FileCacheWrapper::~FileCacheWrapper()  //��[21] 
{
	delete m_MData;                    //��[22] 
	this->!FileCacheWrapper();         //��[23] 
}

FileCacheWrapper::!FileCacheWrapper()  //��[24] 
{
	delete m_pCache;                   //��[25] 
}