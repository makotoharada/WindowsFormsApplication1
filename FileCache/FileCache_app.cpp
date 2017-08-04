#include "stdafx.h" 
#include "FileCache.h" 
#include "windows.h" 

int _tmain(int argc, _TCHAR* argv[])
{
	CFileCache* pFileCache = new CFileCache();  //Å©[1] 
	BOOL b = pFileCache->Load(L"Test.txt");     //Å©[2] 

	try
	{
		::printf("Length=%d\n", pFileCache->GetLength());  //Å©[3] 
		::printf("%c\n", (*pFileCache)[2]);                //Å©[4] 
		::printf("%c\n", (*pFileCache)[5]);
	}
	catch (int code)  //Å©[5] 
	{
		::printf("error=%d\n", code);
	}

	delete pFileCache;  //Å©[6] 

	return 0;
}