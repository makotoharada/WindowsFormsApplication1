#include "stdafx.h" 
#include "FileCache.h" 
#include "windows.h" 

int _tmain(int argc, _TCHAR* argv[])
{
	CFileCache* pFileCache = new CFileCache();  //��[1] 
	BOOL b = pFileCache->Load(L"Test.txt");     //��[2] 

	try
	{
		::printf("Length=%d\n", pFileCache->GetLength());  //��[3] 
		::printf("%c\n", (*pFileCache)[2]);                //��[4] 
		::printf("%c\n", (*pFileCache)[5]);
	}
	catch (int code)  //��[5] 
	{
		::printf("error=%d\n", code);
	}

	delete pFileCache;  //��[6] 

	return 0;
}