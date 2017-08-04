#include "StdAfx.h" 
#include "FileCache.h" 

CFileCache::CFileCache(void)
	: m_pData(NULL), m_nLength(0)
{
}

CFileCache::~CFileCache(void)
{
	ClearData();
}

BOOL CFileCache::AllocData(int size)
{
	m_pData = (char*) ::HeapAlloc(
		::GetProcessHeap(), HEAP_ZERO_MEMORY, (SIZE_T)size);
	if (m_pData == NULL)
	{
		m_nLength = 0;
		return FALSE;
	}
	m_nLength = size;
	return TRUE;
}

void CFileCache::ClearData()
{
	if (m_pData != NULL)
	{
		::HeapFree(::GetProcessHeap(), 0, m_pData);
		m_pData = NULL;
	}
	m_nLength = 0;
}

// ファイルの読み込み 
BOOL CFileCache::Load(LPCWSTR filePath)
{
	// 既存のメモリクリア 
	ClearData();
	// ファイルのオープン 
	HANDLE handle = ::CreateFileW(
		filePath,      //ファイル名  
		GENERIC_READ,  //読み込み 
		0,             //排他的アクセス(共有無し) 
		NULL,          //セキュリティ情報 
		OPEN_EXISTING, //既存ファイルを開く 
		FILE_ATTRIBUTE_NORMAL,  //ファイル属性  
		NULL                    //読み込み時のテンプレートファイル 
	);
	if (handle == INVALID_HANDLE_VALUE)
		return FALSE;
	//ファイルサイズの範囲確認(int型の範囲か) 
	LARGE_INTEGER size;
	BOOL result = ::GetFileSizeEx(handle, &size);
	if (!result || size.HighPart != 0 ||
		size.LowPart > (DWORD)0x7fffffff)
	{
		::CloseHandle(handle);
		return FALSE;
	}
	//メモリ確保 
	if (!AllocData((int)size.LowPart))
	{
		::CloseHandle(handle);
		return FALSE;
	}
	//読み込み 
	DWORD resultLength;
	result = ::ReadFile(
		handle, (LPVOID)m_pData, (DWORD)m_nLength, &resultLength, NULL);
	::CloseHandle(handle);
	if (!result)
	{
		ClearData();
		return FALSE;
	}
	//読み込みサイズに修正 
	m_nLength = (int)resultLength;
	//読み込み成功 
	return TRUE;
}

// インデックスを用いたアクセス 
char CFileCache::operator[](int ndx)
{
	if (ndx <= 0 || ndx >= m_nLength)
		throw (int)FILECACHE_OUTOF_RANGE;
	return m_pData[ndx];
}