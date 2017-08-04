#include "stdafx.h"
#include "FileCacheWrapper.h"

using namespace System;
using namespace System::Runtime::InteropServices;

using namespace MyInteropLib;

FileCacheWrapper::FileCacheWrapper()  //Å©[17] 
{
	m_pCache = new CFileCache();      //Å©[18] 
	m_MData = gcnew ManagedData();   //Å©[19] 
}

bool FileCacheWrapper::Load(String^ filePath)  //Å©[20] 
{
	IntPtr p1;
	p1 = Marshal::StringToHGlobalUni(filePath);
	BOOL b = m_pCache->Load((LPCWSTR)p1.ToPointer());  //Å©[21] 
	Marshal::FreeHGlobal(p1);
	return (b) ? true : false;
}

FileCacheWrapper::~FileCacheWrapper()  //Å©[21] 
{
	delete m_MData;                    //Å©[22] 
	this->!FileCacheWrapper();         //Å©[23] 
}

FileCacheWrapper::!FileCacheWrapper()  //Å©[24] 
{
	delete m_pCache;                   //Å©[25] 
}