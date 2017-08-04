#pragma once

#include "FileCache.h" 

using namespace System;

namespace MyInteropLib      //��[1] 
{
	ref class ManagedData;  //��[2] 

	public ref class FileCacheWrapper  //��[3] 
	{
	private:
		CFileCache* m_pCache;   //��[4] 
		ManagedData^ m_MData;   //��[5] 
	public:
		FileCacheWrapper();     //��[6] 
		~FileCacheWrapper();    //��[7] 
		!FileCacheWrapper();    //��[8] 
	public:
		bool Load(String ^filePath);            //��[9] 
		property unsigned char default[int]     //��[10] 
		{
			unsigned char get(int ndx)  //��[11] 
			{
			if (ndx < 0 || ndx >= m_pCache->GetLength())  //��[12] 
				throw gcnew IndexOutOfRangeException();  //��[13] 
			return (*m_pCache)[ndx];                     //��[14] 
			}
		}
			property int Length  //��[15] 
		{
			int get() { return m_pCache->GetLength(); }
		}
	};

	ref class ManagedData  //��[16] 
	{
	public:
		ManagedData() {}
	public:
		~ManagedData()
		{
			this->!ManagedData();
		}
		!ManagedData()
		{
		}
	};
}