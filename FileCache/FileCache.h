#pragma once
#include "windows.h"
 
#define FILECACHE_OUTOF_RANGE (-1)  //�C���f�b�N�X�͈͊O�̃G���[�R�[�h 
 
// �t�@�C�����������ɃL���b�V�� 
class CFileCache 
{ 
private: 
    char* m_pData;  //��������̃o�b�t�@�|�C���^�[ 
    int m_nLength;  //��������̃f�[�^�T�C�Y(�o�C�g��) 
public: 
    CFileCache(void);  //�R���X�g���N�^�[ 
    ~CFileCache(void); //�f�X�g���N�^�[ 
private: 
    BOOL AllocData(int size); //�������m�ہA�����o�[�ϐ��ݒ� 
    void ClearData();         //����������A�����o�[�ϐ������� 
public: 
    BOOL Load(LPCWSTR filePath);  //�t�@�C���ǂݍ��� 
    char operator[](int ndx);     //�C���f�b�N�X�ł̃A�N�Z�X 
    int GetLength() { return m_nLength; } //�f�[�^�T�C�Y�̎擾(�o�C�g��) 
};