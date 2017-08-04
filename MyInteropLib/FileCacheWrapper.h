#pragma once

#include "FileCache.h" 

using namespace System;

namespace MyInteropLib      //Å©[1] 
{
	ref class ManagedData;  //Å©[2] 

	public ref class FileCacheWrapper  //Å©[3] 
	{
	private:
		CFileCache* m_pCache;   //Å©[4] 
		ManagedData^ m_MData;   //Å©[5] 
	public:
		FileCacheWrapper();     //Å©[6] 
		~FileCacheWrapper();    //Å©[7] 
		!FileCacheWrapper();    //Å©[8] 
	public:
		bool Load(String ^filePath);            //Å©[9] 
		property unsigned char default[int]     //Å©[10] 
		{
			unsigned char get(int ndx)  //Å©[11] 
			{
			if (ndx < 0 || ndx >= m_pCache->GetLength())  //Å©[12] 
				throw gcnew IndexOutOfRangeException();  //Å©[13] 
			return (*m_pCache)[ndx];                     //Å©[14] 
			}
		}
			property int Length  //Å©[15] 
		{
			int get() { return m_pCache->GetLength(); }
		}
	};

	ref class ManagedData  //Å©[16] 
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