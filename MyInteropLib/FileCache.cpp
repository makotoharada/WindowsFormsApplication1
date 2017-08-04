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

// �t�@�C���̓ǂݍ��� 
BOOL CFileCache::Load(LPCWSTR filePath)
{
	// �����̃������N���A 
	ClearData();
	// �t�@�C���̃I�[�v�� 
	HANDLE handle = ::CreateFileW(
		filePath,      //�t�@�C����  
		GENERIC_READ,  //�ǂݍ��� 
		0,             //�r���I�A�N�Z�X(���L����) 
		NULL,          //�Z�L�����e�B��� 
		OPEN_EXISTING, //�����t�@�C�����J�� 
		FILE_ATTRIBUTE_NORMAL,  //�t�@�C������  
		NULL                    //�ǂݍ��ݎ��̃e���v���[�g�t�@�C�� 
	);
	if (handle == INVALID_HANDLE_VALUE)
		return FALSE;
	//�t�@�C���T�C�Y�͈̔͊m�F(int�^�͈̔͂�) 
	LARGE_INTEGER size;
	BOOL result = ::GetFileSizeEx(handle, &size);
	if (!result || size.HighPart != 0 ||
		size.LowPart > (DWORD)0x7fffffff)
	{
		::CloseHandle(handle);
		return FALSE;
	}
	//�������m�� 
	if (!AllocData((int)size.LowPart))
	{
		::CloseHandle(handle);
		return FALSE;
	}
	//�ǂݍ��� 
	DWORD resultLength;
	result = ::ReadFile(
		handle, (LPVOID)m_pData, (DWORD)m_nLength, &resultLength, NULL);
	::CloseHandle(handle);
	if (!result)
	{
		ClearData();
		return FALSE;
	}
	//�ǂݍ��݃T�C�Y�ɏC�� 
	m_nLength = (int)resultLength;
	//�ǂݍ��ݐ��� 
	return TRUE;
}

// �C���f�b�N�X��p�����A�N�Z�X 
char CFileCache::operator[](int ndx)
{
	if (ndx <= 0 || ndx >= m_nLength)
		throw (int)FILECACHE_OUTOF_RANGE;
	return m_pData[ndx];
}